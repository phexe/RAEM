using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace RAPlayer
{
    public partial class frmConfig : Form
    {
        string strCoreExtension;
        SortedList slCores;
        ListViewItem lviEditing;
        bool bEditing;

        public frmConfig()
        {
            InitializeComponent();
            slCores = new SortedList();
            lviEditing = new ListViewItem();
            bEditing = false;
        }

        private void frmConfig_Load(object sender, EventArgs e)
        {
            fnGetOSExtension();
            gbCores.Text = "Libretro Cores Directory :: Must contain libretro cores (File extension: " + strCoreExtension + ")";
            if (File.Exists(Application.StartupPath + Path.DirectorySeparatorChar + "RA-Player.ini"))
            {
                fnReadINI();
            }
            else
            {
                fnScanAndLoadLibretroCores();
            }
        }

        private void fnReadINI()
        {
            StreamReader srIn = new StreamReader(Application.StartupPath + Path.DirectorySeparatorChar + "RA-Player.ini");
            string strTemp = srIn.ReadToEnd();
            srIn.Close();

            string[] strLines = strTemp.Split(Environment.NewLine.ToCharArray());

            foreach (string strLine in strLines)
            {
                if (strLine.ToLower().StartsWith("raplayer_retroarch_exe="))
                {
                    string strEXEC = strLine.ToLower().Replace("raplayer_retroarch_exe=", string.Empty);
                    if (File.Exists(strEXEC))
                    {
                        txtRetroArchExecutable.Text = strEXEC;
                    }
                }

                if (strLine.ToLower().StartsWith("raplayer_retroarch_cores="))
                {
                    string strCores = strLine.ToLower().Replace("raplayer_retroarch_cores=", string.Empty);

                    if (Directory.Exists(strCores))
                    {
                        if (Directory.GetFiles(strCores, "*." + strCoreExtension).Length > 0)
                        {
                            txtRetroArchCoresDir.Text = strCores;
                            fnScanAndLoadLibretroCores();
                        }
                    }
                }

                if (strLine.ToLower().StartsWith("raplayer_system="))
                {
                    string strSystem = strLine.Replace("raplayer_system=", string.Empty);
                    string[] arraySystem = strSystem.Split('¬');

                    ListViewItem lviNew = new ListViewItem();
                    lviNew.Text = arraySystem[0];
                    lviNew.SubItems.Add(arraySystem[1]);
                    lviNew.SubItems.Add(arraySystem[2]);
                    lviNew.SubItems.Add(arraySystem[3]);
                    lvCurrentSystems.Items.Add(lviNew);
                }
            }
        }

        private void fnGetOSExtension()
        {
            OperatingSystem os = Environment.OSVersion;
            PlatformID pid = os.Platform;
            switch (pid)
            {
                case PlatformID.Win32NT:
                case PlatformID.Win32S:
                case PlatformID.Win32Windows:
                case PlatformID.WinCE:
                    strCoreExtension = "dll";
                    break;
                case PlatformID.Unix:
                    strCoreExtension = "so";
                    break;
                case PlatformID.MacOSX:
                    strCoreExtension = "dylib";
                    break;
            }
        }

        private void btnRetroArchExecBrowser_Click(object sender, EventArgs e)
        {

            ofdRetroArchExec.InitialDirectory = Application.StartupPath;
            if (txtRetroArchExecutable.Text.Length > 0)
            {
                if (Directory.Exists(Path.GetFullPath(txtRetroArchExecutable.Text)))
                {
                    ofdRetroArchExec.InitialDirectory = txtRetroArchExecutable.Text;
                }
            }

            ofdRetroArchExec.Title = "Locate RetroArch Executable";
            ofdRetroArchExec.ShowDialog();
            txtRetroArchExecutable.Text = ofdRetroArchExec.FileName;
        }

        private void btnRetroArchCoreBrowser_Click(object sender, EventArgs e)
        {
            fbdRetroArchCores.SelectedPath = Application.StartupPath;
            if (Directory.Exists(txtRetroArchCoresDir.Text))
            {
                fbdRetroArchCores.SelectedPath = txtRetroArchCoresDir.Text;
            }
            
            fbdRetroArchCores.Description = "Locate the directory containing the Libretro cores,\n(File extension: " + strCoreExtension + ")";  
            fbdRetroArchCores.ShowDialog();

            if (Directory.GetFiles(fbdRetroArchCores.SelectedPath, "*." + strCoreExtension).Length > 0)
            {
                txtRetroArchCoresDir.Text = fbdRetroArchCores.SelectedPath;
                fnScanAndLoadLibretroCores();
            }
            else
            {
                MessageBox.Show(null, "Selected Libretro Core Directory does not contain any libretro Cores!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
        }

        private void btnRomDirBrowser_Click(object sender, EventArgs e)
        {
            fbdRomDirectory.SelectedPath = Application.StartupPath;
            fbdRomDirectory.Description = "Locate the directory containing your Roms for this emulator";
            fbdRomDirectory.ShowDialog();
            txtRomDirectory.Text = fbdRomDirectory.SelectedPath;
            
        }

        private void fnScanAndLoadLibretroCores()
        {
            slCores.Clear();

            if (Directory.Exists(txtRetroArchCoresDir.Text))
            {
                foreach (string strCore in Directory.GetFiles(txtRetroArchCoresDir.Text, "*." + strCoreExtension))
                {
                    string strCoreName = Path.GetFileName(strCore);
                    string strFileExt = string.Empty;
                    string strInfoDir = string.Empty;

                    foreach (string strDirs in Directory.GetDirectories(Path.GetDirectoryName(txtRetroArchExecutable.Text)))
                    {
                        if(Directory.GetFiles(strDirs,"*.info").Length > 0)
                        {
                            strInfoDir = strDirs;
                        }
                    }

                    if (strInfoDir != string.Empty)
                    {
                        strCoreName = fnGetCoreName(strInfoDir + Path.DirectorySeparatorChar + Path.GetFileNameWithoutExtension(strCore) + ".info").Split('¬')[0];
                        strFileExt = fnGetCoreName(strInfoDir + Path.DirectorySeparatorChar + Path.GetFileNameWithoutExtension(strCore) + ".info").Split('¬')[1];
                    }

                    ComboboxItem cbiItem = new ComboboxItem();
                    cbiItem.Text = strCoreName;
                    cbiItem.Value = strCore + "¬" + strFileExt;

                    cbCoreList.Items.Add(cbiItem);

                }

                gbCurrentSystems.Enabled = true;
            }
        }

        public class ComboboxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }

        private string fnGetCoreName(string strINFOFile)
        {
            StreamReader srIn = new StreamReader(strINFOFile);
            string strTemp = srIn.ReadToEnd();
            srIn.Close();
            string strOut = string.Empty;
            string strExt = string.Empty;
            
            string[] arrayTemp = strTemp.Split(Environment.NewLine.ToCharArray());

            foreach (string strLine in arrayTemp)
            {
                if (strLine.ToLower().StartsWith("display_name"))
                {
                    strOut = strLine.Split('"')[1];
                }

                if (strLine.ToLower().StartsWith("supported_extensions"))
                {
                    strExt = strLine.Split('"')[1];
                }
            }

            return strOut + "¬" + strExt;
        }

        private void btnAddSystem_Click(object sender, EventArgs e)
        {
            gbAddSystem.Enabled = true;
        }

        private void btnCancelAdd_Click(object sender, EventArgs e)
        {
            lviEditing = new ListViewItem();
            bEditing = false;
            fnClearNewSystem();            
        }

        private void fnClearNewSystem()
        {
            txtRomDirectory.Text = string.Empty;
            txtSystemName.Text = string.Empty;
            cbCoreList.Text = string.Empty;
            cbCoreList.SelectedText = string.Empty;
            cbCoreList.Items.Clear();
            fnScanAndLoadLibretroCores();
            gbAddSystem.Enabled = false;
            chkAutoAddArchiveExt.CheckState = CheckState.Checked;
        }

        private void btnSaveSystem_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(txtRomDirectory.Text))
            {
                if (bEditing == false)
                {
                    ListViewItem lviNew = new ListViewItem();
                    lviNew.Text = txtSystemName.Text.Replace("\\", string.Empty).Replace("/", string.Empty).Replace("$", string.Empty).Replace("#", string.Empty);
                    lviNew.SubItems.Add((cbCoreList.SelectedItem as ComboboxItem).Value.ToString().Split('¬')[0]);
                    lviNew.SubItems.Add(txtRomDirectory.Text);
                    lviNew.SubItems.Add(txtRomExt.Text);
                    lvCurrentSystems.Items.Add(lviNew);
                    fnClearNewSystem();
                }
                else
                {
                    DialogResult drResult = MessageBox.Show(null, "Do you wish to overwrite this System?", "Confirm Save Edits?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (drResult == System.Windows.Forms.DialogResult.Yes)
                    {
                        lvCurrentSystems.Items.Remove(lviEditing);
                        ListViewItem lviNew = new ListViewItem();
                        lviNew.Text = txtSystemName.Text.Replace("\\", string.Empty).Replace("/", string.Empty).Replace("$", string.Empty).Replace("#", string.Empty);
                        lviNew.SubItems.Add((cbCoreList.SelectedItem as ComboboxItem).Value.ToString().Split('¬')[0]);
                        lviNew.SubItems.Add(txtRomDirectory.Text);
                        lviNew.SubItems.Add(txtRomExt.Text);
                        lvCurrentSystems.Items.Add(lviNew);                                                
                        lviEditing = new ListViewItem();
                        bEditing = false;
                        fnClearNewSystem();
                    }
                }
            }
            else
            {
                MessageBox.Show(null, "Selected Rom Directory does not Exist!", "Error!",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btnDeleteSystem_Click(object sender, EventArgs e)
        {
            if (lvCurrentSystems.SelectedItems.Count > 0)
            {
                ListViewItem lviCurrent = lvCurrentSystems.SelectedItems[0];
                DialogResult drResult = MessageBox.Show(null,"Do you wish to remove \"" + lviCurrent.Text + "\" ?", "Confirm Deletion?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (drResult == System.Windows.Forms.DialogResult.Yes)
                {   
                    lvCurrentSystems.Items.Remove(lviCurrent);
                }
            }
        }

        private void btnSaveExit_Click(object sender, EventArgs e)
        {
            if (File.Exists(txtRetroArchExecutable.Text))
            {
                if (Directory.GetFiles(txtRetroArchCoresDir.Text, "*." + strCoreExtension).Length > 0)
                {
                    fnSaveINI();
                }
            }            
        }

        private void fnSaveINI()
        {
            StreamWriter srOut = new StreamWriter(Application.StartupPath + Path.DirectorySeparatorChar + "RA-Player.ini",false);
            srOut.AutoFlush = true;

            srOut.WriteLine("raplayer_retroarch_exe=" + txtRetroArchExecutable.Text);
            srOut.WriteLine("raplayer_retroarch_cores=" + txtRetroArchCoresDir.Text.ToLower());

            foreach (ListViewItem lviRecord in lvCurrentSystems.Items)
            {
                string strOut = "raplayer_system=" + lviRecord.Text + "¬" + lviRecord.SubItems[1].Text + "¬" + lviRecord.SubItems[2].Text + "¬" + lviRecord.SubItems[3].Text;
                srOut.WriteLine(strOut);
                fnWriteSystemCFG(lviRecord.Text, lviRecord.SubItems[1].Text, lviRecord.SubItems[2].Text);
            }

            srOut.Flush();
            srOut.Flush();

            srOut.Close();

            if (Directory.Exists(Application.StartupPath + Path.DirectorySeparatorChar + "savefile") == false)
            {
                Directory.CreateDirectory(Application.StartupPath + Path.DirectorySeparatorChar + "savefile");
            }

            if (Directory.Exists(Application.StartupPath + Path.DirectorySeparatorChar + "savestate") == false)
            {
                Directory.CreateDirectory(Application.StartupPath + Path.DirectorySeparatorChar + "savestate");
            }

            if (Directory.Exists(Application.StartupPath + Path.DirectorySeparatorChar + "system") == false)
            {
                Directory.CreateDirectory(Application.StartupPath + Path.DirectorySeparatorChar + "system");
            }

            if (Directory.Exists(Application.StartupPath + Path.DirectorySeparatorChar + "shaders") == false)
            {
                Directory.CreateDirectory(Application.StartupPath + Path.DirectorySeparatorChar + "shaders");
            }

            if (Directory.Exists(Application.StartupPath + Path.DirectorySeparatorChar + "joyautoconfig") == false)
            {
                Directory.CreateDirectory(Application.StartupPath + Path.DirectorySeparatorChar + "joyautoconfig");
            }

            if (Directory.Exists(Application.StartupPath + Path.DirectorySeparatorChar + "screenshots") == false)
            {
                Directory.CreateDirectory(Application.StartupPath + Path.DirectorySeparatorChar + "screenshots");
            }

            if (Directory.Exists(Application.StartupPath + Path.DirectorySeparatorChar + "cheat_database") == false)
            {
                Directory.CreateDirectory(Application.StartupPath + Path.DirectorySeparatorChar + "cheat_database");
            }

            if (Directory.Exists(Application.StartupPath + Path.DirectorySeparatorChar + "rgui_config") == false)
            {
                Directory.CreateDirectory(Application.StartupPath + Path.DirectorySeparatorChar + "rgui_config");
            }

            if (Directory.Exists(Application.StartupPath + Path.DirectorySeparatorChar + "game_history") == false)
            {
                Directory.CreateDirectory(Application.StartupPath + Path.DirectorySeparatorChar + "game_history");
            }

            if (Directory.Exists(Application.StartupPath + Path.DirectorySeparatorChar + "overlay") == false)
            {
                Directory.CreateDirectory(Application.StartupPath + Path.DirectorySeparatorChar + "overlay");
            }

            if (Directory.Exists(Application.StartupPath + Path.DirectorySeparatorChar + "core_options") == false)
            {
                Directory.CreateDirectory(Application.StartupPath + Path.DirectorySeparatorChar + "core_options");
            }            
        }

        private void btnEditSystem_Click(object sender, EventArgs e)
        {
            if (lvCurrentSystems.SelectedItems.Count > 0)
            {
                bEditing = true;
                lviEditing = lvCurrentSystems.SelectedItems[0];
                gbAddSystem.Enabled = true;

                txtSystemName.Text = lviEditing.Text;
                txtRomDirectory.Text = lviEditing.SubItems[2].Text;
                txtRomExt.Text = lviEditing.SubItems[3].Text;

                foreach (ComboboxItem cbiItem in cbCoreList.Items)
                {
                    if (lviEditing.SubItems[1].Text.ToLower() == cbiItem.Value.ToString().Split('¬')[0].ToLower())
                    {
                        cbCoreList.Text = cbiItem.Text;
                    }
                }                
            }
        }

        private void cbCoreList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(chkAutoAddArchiveExt.CheckState == CheckState.Checked)
            {
                string strTmpExt = (cbCoreList.SelectedItem as ComboboxItem).Value.ToString().Split('¬')[1].Replace("|zip", "").Replace("|7z", "").Replace("zip", "").Replace("7z", "") + "|zip|7z";
                txtRomExt.Text = strTmpExt.TrimStart('|').TrimEnd('|');
            }
            else
            {
                txtRomExt.Text = (cbCoreList.SelectedItem as ComboboxItem).Value.ToString().Split('¬')[1].Replace("|zip", "").Replace("|7z", "").Replace("zip", "").Replace("7z", "").TrimStart('|').TrimEnd('|');
            }
            
            txtSystemName.Text = (cbCoreList.SelectedItem as ComboboxItem).ToString().Replace("\\", string.Empty).Replace("/", string.Empty).Replace("$", string.Empty).Replace("#", string.Empty);
        }

        private void fnWriteSystemCFG(string strSystemName, string strLibretro_path, string strRgui_browser_directory)
        {
            StreamWriter srOut = new StreamWriter(Application.StartupPath + Path.DirectorySeparatorChar + strSystemName + ".cfg");
            srOut.WriteLine("savefile_directory = \"" + Application.StartupPath + Path.DirectorySeparatorChar + "savefile\"");
            srOut.WriteLine("savestate_directory = \"" + Application.StartupPath + Path.DirectorySeparatorChar + "savestate\"");
            srOut.WriteLine("core_options_path = \"" + Application.StartupPath + Path.DirectorySeparatorChar + "core_options\"");
            srOut.WriteLine("game_history_path = \"" + Application.StartupPath + Path.DirectorySeparatorChar + "game_history\"");
            srOut.WriteLine("system_directory = \"" + Application.StartupPath + Path.DirectorySeparatorChar + "system\"");
            srOut.WriteLine("rgui_config_directory = \"" + Application.StartupPath + Path.DirectorySeparatorChar + "rgui_config\"");
            srOut.WriteLine("joypad_autoconfig_dir = \"" + Application.StartupPath + Path.DirectorySeparatorChar + "joyautoconfig\"");
            srOut.WriteLine("video_shader_dir = \"" + Application.StartupPath + Path.DirectorySeparatorChar + "shaders\"");
            srOut.WriteLine("screenshot_directory = \"" + Application.StartupPath + Path.DirectorySeparatorChar + "screenshots\"");
            srOut.WriteLine("cheat_database_path = \"" + Application.StartupPath + Path.DirectorySeparatorChar + "cheat_database\"");
            srOut.WriteLine("overlay_directory = \"" + Application.StartupPath + Path.DirectorySeparatorChar + "overlay\"");
            srOut.WriteLine("libretro_info_path = \"" + Path.GetDirectoryName(strLibretro_path) + "\"");
            srOut.WriteLine("libretro_path = \"" + strLibretro_path + "\"");
            srOut.WriteLine("rgui_browser_directory = \"" + strRgui_browser_directory + "\""); // Rom Directory
            srOut.WriteLine("config_save_on_exit = \"true\"");
            srOut.WriteLine("video_vsync = \"false\"");
            srOut.Flush(); srOut.Flush();
            srOut.Close();
        }

    }
}
