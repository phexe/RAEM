using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace raem
{
    public partial class frmError : Form
    {
        string strErrorText;

        public frmError(string newErrorText)
        {
            InitializeComponent();          
            strErrorText = newErrorText;
        }

        private void frmError_Load(object sender, EventArgs e)
        {
            txtErrorText.Text = strErrorText;
        }
    }
}
