using RAEM;
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
        string strNetPlayInfo;

        const string strNoNetInfo = "0.0.0.0|55435|HOST|0|PLAYER";

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
            strNetPlayInfo = strNoNetInfo;
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

                    if (strLine.ToLower().StartsWith("raem_netplay_config="))
                    {
                        string strTempNetPlaySettings = strLine.ToLower().Replace("raem_netplay_config=", string.Empty);
                        string[] arrayNetPlaySettings = strTempNetPlaySettings.Split('|');

                        bool bPassedChecks = true;

                        // Check Valid IP
                        System.Net.IPAddress ipAddress = null;
                        bPassedChecks = System.Net.IPAddress.TryParse(arrayNetPlaySettings[0], out ipAddress);

                        // Check Valid Port
                        try{
                        
                            if( (Convert.ToInt32(arrayNetPlaySettings[1]) > 0)
                              &&(Convert.ToInt32(arrayNetPlaySettings[1]) < 65534))
                            {
                                bPassedChecks = true;
                            }
                        
                        }catch{
                            bPassedChecks = false;
                        }


                        // Check Valid Participant Type
                        switch (arrayNetPlaySettings[2].ToLower().Trim())
                        {
                            case "host":
                                bPassedChecks = true;
                                break;
                            case "client":
                                bPassedChecks = true;
                                break;
                            case "spectator":
                                bPassedChecks = true;
                                break;
                            default:
                                bPassedChecks = false;
                                break;
                        }

                        // Check if Valid Frame delay
                        try
                        {

                            if (Convert.ToInt32(arrayNetPlaySettings[3]) >= 0)
                            {
                                bPassedChecks = true;
                            }

                        }
                        catch
                        {
                            bPassedChecks = false;
                        }

                        // Does not matter about Nickname, can be anything

                        if(bPassedChecks == true)
                        {
                            strNetPlayInfo = strTempNetPlaySettings;
                        }
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
                    try
                    {
                        foreach (string strFile in Directory.GetFiles(strRomPath, "*." + strExt))
                        {
                            slCurrentGameList.Add(Path.GetFileNameWithoutExtension(strFile), strFile);
                        }
                    }
                    catch { }
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
            try
            {
                StringBuilder sbLog = new StringBuilder();               

                Process pGame = new Process();
                pGame.StartInfo.FileName = strRetroArchExec;
                
                StringBuilder sbArgs = new StringBuilder();
                sbArgs.Append("-v -c \"" + Application.StartupPath + Path.DirectorySeparatorChar + lvSystems.SelectedItems[0].Text + ".cfg\" \"" + lvGameList.SelectedItems[0].Tag.ToString() + "\"");

                string strNetStatus = string.Empty;

                if(chkEnableNetplay.CheckState == CheckState.Checked)
                {
                    // Add Netplay Parameters
                    string[] arrayNetPlayInfo = strNetPlayInfo.Split('|');

                    switch (arrayNetPlayInfo[2].ToLower())
                    {
                        case "host":
                            sbArgs.Append(" -H --port " + arrayNetPlayInfo[1] + " -F " + arrayNetPlayInfo[3] + " --nick " + arrayNetPlayInfo[4]);
                            strNetStatus = "\nWaiting for Client to Connect on Port " + arrayNetPlayInfo[1] + "";
                            break;
                        case "client":
                            sbArgs.Append(" -C " + arrayNetPlayInfo[0] + " --port " + arrayNetPlayInfo[1] + " -F " + arrayNetPlayInfo[3] + " --nick " + arrayNetPlayInfo[4]);
                            strNetStatus = "\nConnecting to Host on Port " + arrayNetPlayInfo[1] + "";
                            break;
                        case "spectator":
                            sbArgs.Append(" -C " + arrayNetPlayInfo[0] + " --spectate --port " + arrayNetPlayInfo[1] + " -F " + arrayNetPlayInfo[3] + " --nick " + arrayNetPlayInfo[4]);
                            strNetStatus = "\nConnecting to Spectate on Port " + arrayNetPlayInfo[1] + "";
                            break;
                    }
                }

                pGame.StartInfo.Arguments = sbArgs.ToString();
                pGame.StartInfo.CreateNoWindow = true;
                pGame.StartInfo.UseShellExecute = false;
                pGame.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                pGame.StartInfo.RedirectStandardOutput = true;
                pGame.StartInfo.RedirectStandardError = true;
                pGame.OutputDataReceived += (sender, args) => sbLog.AppendLine("LOG: " + args.Data);
                pGame.ErrorDataReceived += (sender, args) => sbLog.AppendLine("ERR: " + args.Data);
                fnShowStatus("Playing: " + lvGameList.SelectedItems[0].Text.ToString() + strNetStatus, true);
                pGame.Start();
                pGame.BeginOutputReadLine();
                pGame.BeginErrorReadLine();
                pGame.WaitForExit();
                if (pGame.ExitCode != 0)
                {
                    frmError newError = new frmError(sbLog.ToString());
                    newError.ShowDialog();
                }

                StreamWriter srOut = new StreamWriter(Application.StartupPath + Path.DirectorySeparatorChar + ("RAEM.log"));
                srOut.Write(sbLog.ToString());
                srOut.Flush(); srOut.Flush();
                srOut.Close();

            }
            catch(Exception erError) { 
                    frmError newError2 = new frmError(erError.Message.ToString());
                    newError2.ShowDialog();
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
        
        private void mainmenuConfigureControls_Click(object sender, EventArgs e)
        {
            if ((File.Exists(Path.GetDirectoryName(strRetroArchExec) + Path.DirectorySeparatorChar + "retroarch-joyconfig.exe"))
               && (lvSystems.SelectedItems.Count > 0))
            {
                frmControlSelector newControlSelector = new frmControlSelector(Path.GetDirectoryName(strRetroArchExec), Application.StartupPath + Path.DirectorySeparatorChar + lvSystems.SelectedItems[0].Text.ToString() + ".cfg");
                newControlSelector.ShowDialog();
            }
            else
            {
                MessageBox.Show(null, "Please make sure \"retroarch-joyconfig.exe\" resides in the same directory as \"retroarch.exe\", and that you have selected a system to configure controls for.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mainmenuConfigureCores_Click(object sender, EventArgs e)
        {
            fnRunConfig();
        }

        private void chkEnableNetplay_Click(object sender, EventArgs e)
        {
            if(strNetPlayInfo == strNoNetInfo)
            {
                fnEnableNetPlay(false);
                MessageBox.Show(null, "Please configure Netplay first!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                chkEnableNetplay.CheckState = CheckState.Unchecked;
            }
            else
            {
                if(chkEnableNetplay.CheckState == CheckState.Checked)
                {
                    fnEnableNetPlay(true);
                }
                else
                {
                    fnEnableNetPlay(false);
                }
            }

        }

        private void fnEnableNetPlay(bool bEnable)
        {
            if(bEnable == true)
            {
                // Enable NetPlay
                
                string[] arrayNetPlayInfo = strNetPlayInfo.Split('|');
                toolstripNetPlay.Text = "NetPlay: Enabled" +
                                        " - IP: " + arrayNetPlayInfo[0] +
                                        " - Port: " + arrayNetPlayInfo[1] +
                                        " - Mode: " + arrayNetPlayInfo[2] +
                                        " - Frame Delay: " + arrayNetPlayInfo[3] +
                                        " - Nickname: " + arrayNetPlayInfo[4];
            }
            else
            {
                // Disable NetPlay
                
                toolstripNetPlay.Text = "NetPlay: Disabled";
            }
        }

        

        private void mainmenuConfigureNetplay_Click(object sender, EventArgs e)
        {
            string[] arrayNetPlayInfo = strNetPlayInfo.Split('|');
            frmNetPlayConfig newNetPlayConfig = new frmNetPlayConfig(arrayNetPlayInfo[0],
                                                                     arrayNetPlayInfo[1],
                                                                     arrayNetPlayInfo[2],
                                                                     arrayNetPlayInfo[3],
                                                                     arrayNetPlayInfo[4]);

            DialogResult srNetPlayConfig = newNetPlayConfig.ShowDialog();

            if(srNetPlayConfig == System.Windows.Forms.DialogResult.OK)
            {
                strNetPlayInfo = newNetPlayConfig.fnGetNewDetails();
                if (chkEnableNetplay.CheckState == CheckState.Checked)
                {
                    fnEnableNetPlay(true);
                }
            }
        }
                
    }
}
