using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace RAPlayer
{
    public partial class frmControlSelector : Form
    {
        string strRetroarchPath;
        string strCoreConfig;

        public frmControlSelector(string strInRetroarchDIR, string strInCoreCFG)
        {
            InitializeComponent();            
            strRetroarchPath = strInRetroarchDIR;
            strCoreConfig = strInCoreCFG;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            string strPlayerID = cbPlayer.Text;
            string strJoystickID = (Convert.ToInt32(cbJoystick.Text) - 1).ToString();            

            Process pJoyConfig = new Process();
            pJoyConfig.StartInfo.FileName = strRetroarchPath + Path.DirectorySeparatorChar + "retroarch-joyconfig.exe";
            pJoyConfig.StartInfo.CreateNoWindow = false;
            pJoyConfig.StartInfo.UseShellExecute = false;
            pJoyConfig.StartInfo.WindowStyle = ProcessWindowStyle.Maximized;
            if (chkExtra.CheckState == CheckState.Checked)
            {
                pJoyConfig.StartInfo.Arguments = "-i \"" + strCoreConfig + "\" -o \"" + strCoreConfig + "\" -p " + strPlayerID + " -j " + strJoystickID + " -t 5 -m";
            }
            else
            {
                pJoyConfig.StartInfo.Arguments = "-i \"" + strCoreConfig + "\" -o \"" + strCoreConfig + "\" -p " + strPlayerID + " -j " + strJoystickID + " -t 5";
            }

            pJoyConfig.Start();
            pJoyConfig.WaitForExit();

        }

        private void frmControlSelector_Load(object sender, EventArgs e)
        {
            cbPlayer.SelectedIndex = cbPlayer.FindStringExact("1");
            cbJoystick.SelectedIndex = cbJoystick.FindStringExact("1");
        }
    }
}
