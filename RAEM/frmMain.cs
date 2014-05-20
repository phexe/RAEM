using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace raem
{
    public partial class frmMain : Form
    {
        SortedList<string, string> slSystems;
        SortedList<string, string> slCurrentGameList;

        string strCoreExtension;

        string strRetroArchExec;

        public frmMain()
        {
            InitializeComponent();
            fnGetOSExtension();
        }

        private void fnStartRAEM()
        {
            fnLoadVersion();
            slSystems = new SortedList<string, string>();
            slCurrentGameList = new SortedList<string, string>();
            strCoreExtension = string.Empty;
            slSystems.Clear();
            slCurrentGameList.Clear();
            lvGameList.Items.Clear();
            lvSystems.Items.Clear();
            fnLoadSystems();
        }

        private void fnLoadSystems()
        {
            fnReadINI();

            lvSystems.Items.Clear();

            foreach (KeyValuePair<string, string> Item in slSystems)
            {
                string strSystemName = Item.Key;
                ListViewItem lviSystemItem = new ListViewItem();
                lviSystemItem.Text = strSystemName;
                lviSystemItem.Tag = Item.Value;
                lvSystems.Items.Add(lviSystemItem);
            }
        }

        private void fnReadINI()
        {
            if (File.Exists(Application.StartupPath + Path.DirectorySeparatorChar + ("RAEM.ini")))
            {
                StreamReader srIn = new StreamReader(Application.StartupPath + Path.DirectorySeparatorChar + "RAEM.ini");
                String strTemp = srIn.ReadToEnd();
                string[] strLines = strTemp.Split(Environment.NewLine.ToCharArray());
                srIn.Close();

                foreach (string strLine in strLines)
                {
                    if (strLine.ToLower().StartsWith("raem_retroarch_exe="))
                    {
                        string strEXEC = strLine.ToLower().Replace("raem_retroarch_exe=", string.Empty);
                        if (File.Exists(strEXEC))
                        {
                            strRetroArchExec = strEXEC;
                        }
                    }

                    if (strLine.ToLower().StartsWith("raem_system="))
                    {
                        string strSystem = strLine.Replace("raem_system=", string.Empty);

                        string[] arraySystem = strSystem.Split('¬');

                        slSystems.Add(arraySystem[0], arraySystem[1]+"¬"+arraySystem[2]+"¬"+arraySystem[3]);
                    }
                }

            }
            else
            {
                MessageBox.Show(null, "No Configuration file found!\nPlease Configure RAEM.", "RAEM :: First Run", MessageBoxButtons.OK, MessageBoxIcon.Information);
                fnRunConfig();
            }          
        }

        private void fnLoadGamesListIntoUI()
        {
            lvGameList.Items.Clear();            

            lvGameList.BeginUpdate();

            foreach (KeyValuePair<string, string> strItem in slCurrentGameList)
            {
                ListViewItem lviNew = new ListViewItem();
                lviNew.Text = strItem.Key;
                lviNew.Tag = strItem.Value;
                lvGameList.Items.Add(lviNew);
            }
            lvGameList.Columns[0].Width = -1;
            lvGameList.EndUpdate();
        }

        private void fnLoadGamesList()
        {
            slCurrentGameList.Clear();

            string strRomPath = slSystems[lvSystems.SelectedItems[0].Text.ToString()].Split('¬')[1];
            string[] strExtensions = slSystems[lvSystems.SelectedItems[0].Text.ToString()].Split('¬')[2].Split('|');

            foreach (string strExt in strExtensions)
            {
                if (strExt == string.Empty)
                {
                    foreach (string strFile in Directory.GetFiles(strRomPath, "*.*"))
                    {
                        try
                        {
                            slCurrentGameList.Add(Path.GetFileNameWithoutExtension(strFile), strFile);
                        }
                        catch { }
                    }
                }
                else
                {
                    foreach (string strFile in Directory.GetFiles(strRomPath, "*." + strExt))
                    {
                        try
                        {
                            slCurrentGameList.Add(Path.GetFileNameWithoutExtension(strFile), strFile);
                        }
                        catch { }

                    }
                }
            }
        }

        private void lvSystems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvSystems.SelectedItems.Count > 0)
            {
                fnLoadGamesList();
                fnLoadGamesListIntoUI();
            }
        }

        private void raemUI_Load(object sender, EventArgs e)
        {
            fnStartRAEM();
        }

        private void fnLoadVersion()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fvi.FileVersion;
            this.Text = "RAEM v" + version;
        }


        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void configureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fnRunConfig();
        }

        private void fnRunConfig()
        {
            frmConfig newConfig = new frmConfig();

            if (newConfig.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                fnStartRAEM();
            } 
        }

        private void aboutraemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout newAbout = new frmAbout();
            newAbout.ShowDialog();
        }

        private void fnShowStatus(string strText, bool bEnable)
        {
            lblStatusMessage.Text = strText;

            if (bEnable == true)
            {
                pnlStatusMessage.BringToFront();
            }
            else
            {
                pnlStatusMessage.SendToBack();
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

        private void lvGameList_DoubleClick(object sender, EventArgs e)
        {
            if (lvGameList.SelectedItems.Count > 0)
            {
                fnLoadGame();
            }
        }

        private void fnLoadGame()
        {
            StringBuilder sbLog = new StringBuilder();
            
            Process pGame = new Process();
            pGame.StartInfo.FileName = strRetroArchExec;
            pGame.StartInfo.Arguments = "-c \"" + Application.StartupPath + Path.DirectorySeparatorChar + lvSystems.SelectedItems[0].Text + ".cfg\" \"" + lvGameList.SelectedItems[0].Tag.ToString() + "\"";
            pGame.StartInfo.CreateNoWindow = true;
            pGame.StartInfo.UseShellExecute = false;
            pGame.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            pGame.StartInfo.RedirectStandardOutput = true;
            pGame.StartInfo.RedirectStandardError = true;
            pGame.OutputDataReceived += (sender, args) => sbLog.AppendLine("LOG: " + args.Data);
            pGame.ErrorDataReceived += (sender, args) => sbLog.AppendLine("ERR: " + args.Data);
            fnShowStatus("Playing: " + lvGameList.SelectedItems[0].Text.ToString(), true);
            pGame.Start();
            pGame.BeginOutputReadLine();
            pGame.BeginErrorReadLine();
            pGame.WaitForExit();
            if (pGame.ExitCode != 0)
            {                
                frmError newError = new frmError(sbLog.ToString());
                newError.ShowDialog();
            }
            fnShowStatus("", false);
        }
        
        private void lvSystems_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if(lvSystems.SelectedItems.Count > 0)
            {
                lvSystems.ContextMenuStrip = mnuCoreConfig;
            }

            if (lvSystems.SelectedItems.Count == 0)
            {
                lvSystems.ContextMenuStrip = null;
            }
        }

        private void mnuiCoreConfig_Click(object sender, EventArgs e)
        {
            frmCoreConfig newCoreConfig = new frmCoreConfig(Application.StartupPath + Path.DirectorySeparatorChar + lvSystems.SelectedItems[0].Text.ToString() + ".cfg");
            newCoreConfig.ShowDialog();
        }

        private void configureSystemControlsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(File.Exists(Path.GetDirectoryName(strRetroArchExec) + Path.DirectorySeparatorChar + "retroarch-joyconfig.exe"))
            {
                frmControlSelector newControlSelector = new frmControlSelector(Path.GetDirectoryName(strRetroArchExec), Application.StartupPath + Path.DirectorySeparatorChar + lvSystems.SelectedItems[0].Text.ToString() + ".cfg");
                newControlSelector.ShowDialog();
            }
            else
            {
                MessageBox.Show(null, "Please make sure \"retroarch-joyconfig.exe\" resides in the same directory as \"retroarch.exe\".", "Error!",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

        }
        
    }
}
