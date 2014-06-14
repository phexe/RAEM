using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace RAEM
{
    public partial class frmNetPlayConfig : Form
    {
        string strIP;
        string strPORT;
        string strMODE;
        string strFRAME;
        string strNICK;

        public frmNetPlayConfig(string strNewIP, string strNewPORT, string strNewMODE, string strNewFRAME, string strNewNICK)
        {
            InitializeComponent();
            strIP = strNewIP;
            strPORT = strNewPORT;
            strMODE = strNewMODE;
            strFRAME = strNewFRAME;
            strNICK = strNewNICK;
        }

        private void frmNetPlayConfig_Load(object sender, EventArgs e)
        {
            fnLoadCFG();   
        }

        private void fnLoadCFG()
        {
            txtIP.Text = strIP;
            txtPort.Text = strPORT;
            txtFrame.Text = strFRAME;
            txtNick.Text = strNICK;
            try
            {
                cbMode.SelectedIndex = cbMode.FindStringExact(strMODE);
            }
            catch { }
        }

        public static string GetPublicIP()
        {
            string a4 = "0.0.0.0";
            try
            {
                string url = "http://checkip.dyndns.org";
                System.Net.WebRequest req = System.Net.WebRequest.Create(url);
                System.Net.WebResponse resp = req.GetResponse();
                System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
                string response = sr.ReadToEnd().Trim();
                string[] a = response.Split(':');
                string a2 = a[1].Substring(1);
                string[] a3 = a2.Split('<');
                a4 = a3[0];

            }
            catch { }
            return a4;
        }

        private void btnGetIP_Click(object sender, EventArgs e)
        {
            pnlMain.Visible = false;
            this.Refresh(); this.Refresh(); this.Refresh();
            txtIP.Text = GetPublicIP().ToString();
            pnlMain.Visible = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Check All values

            bool bPassedChecks = true;

            // Check Valid IP
            System.Net.IPAddress ipAddress = null;
            bPassedChecks = System.Net.IPAddress.TryParse(txtIP.Text, out ipAddress);

            // Check Valid Port
            try
            {

                if ((Convert.ToInt32(txtPort.Text) > 0)
                  && (Convert.ToInt32(txtPort.Text) < 65534))
                {
                    bPassedChecks = true;
                }

            }
            catch
            {
                bPassedChecks = false;
            }


            // Check Valid Participant Type
            switch (cbMode.Text.ToLower())
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

                if (Convert.ToInt32(txtFrame.Text) >= 0)
                {
                    bPassedChecks = true;
                }

            }
            catch
            {
                bPassedChecks = false;
            }

            // Does not matter about Nickname, can be anything

            if (bPassedChecks == true)
            {
                fnSaveNetPlay();
            }
            else
            {
                MessageBox.Show(null, "Not all details are filled out.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public string fnGetNewDetails()
        {
            return txtIP.Text + "|" +
                   txtPort.Text + "|" +
                   cbMode.Text + "|" +
                   txtFrame.Text + "|" +
                   txtNick.Text;
        }

        private void fnSaveNetPlay()
        {
            // Read in Original INI

            if (File.Exists(Application.StartupPath + Path.DirectorySeparatorChar + ("RAEM.ini")))
            {
                StreamReader srIn = new StreamReader(Application.StartupPath + Path.DirectorySeparatorChar + "RAEM.ini");
                String strTemp = srIn.ReadToEnd();
                string[] strLines = strTemp.Split(Environment.NewLine.ToCharArray());
                srIn.Close();

                StringBuilder sbOut = new StringBuilder();
                bool bAddedNetPlay = false;

                foreach (string strLine in strLines)
                {
                    if (strLine.ToLower().StartsWith("raem_netplay_config="))
                    {
                        sbOut.AppendLine("raem_netplay_config=" + txtIP.Text + "|" + 
                                                                  txtPort.Text + "|" + 
                                                                  cbMode.Text + "|" +
                                                                  txtFrame.Text + "|" +
                                                                  txtNick.Text);
                        bAddedNetPlay = true;
                    }
                    else
                    {
                        if(strLine.Trim().Length > 0)
                        {
                            sbOut.AppendLine(strLine);
                        }
                        
                    }
                }

                if(bAddedNetPlay == false)
                {
                    sbOut.AppendLine("raem_netplay_config=" + txtIP.Text + "|" +
                                                                  txtPort.Text + "|" +
                                                                  cbMode.Text + "|" +
                                                                  txtFrame.Text + "|" +
                                                                  txtNick.Text);
                }

                StreamWriter srOut = new StreamWriter(Application.StartupPath + Path.DirectorySeparatorChar + "RAEM.ini");
                srOut.Write(sbOut.ToString());
                srOut.Flush(); srOut.Flush();
                srOut.Close();

            }
        }
        
    }
}
