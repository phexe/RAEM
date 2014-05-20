using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RAPlayer
{
    public partial class frmChangeValue : Form
    {
        public string strOption;
        public string strValue;
        

        public frmChangeValue(string strInOption, string strInValue)
        {
            InitializeComponent();
            strOption = strInOption;
            strValue = strInValue;
        }

        private void frmChangeValue_Load(object sender, EventArgs e)
        {
            txtOptionName.Text = strOption;
            txtOptionValue.Text = strValue;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            strValue = txtOptionValue.Text;
        }
    }
}
