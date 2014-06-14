namespace raem
{
    partial class frmConfig
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfig));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRetroArchExecBrowser = new System.Windows.Forms.Button();
            this.txtRetroArchExecutable = new System.Windows.Forms.TextBox();
            this.gbAddSystem = new System.Windows.Forms.GroupBox();
            this.chkAutoAddArchiveExt = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRomExt = new System.Windows.Forms.TextBox();
            this.btnRomDirBrowser = new System.Windows.Forms.Button();
            this.btnSaveSystem = new System.Windows.Forms.Button();
            this.btnCancelAdd = new System.Windows.Forms.Button();
            this.cbCoreList = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRomDirectory = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSystemName = new System.Windows.Forms.TextBox();
            this.gbCurrentSystems = new System.Windows.Forms.GroupBox();
            this.btnEditSystem = new System.Windows.Forms.Button();
            this.lvCurrentSystems = new System.Windows.Forms.ListView();
            this.chSystemName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chCore = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chRomDirectory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chExtensions = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnAddSystem = new System.Windows.Forms.Button();
            this.btnDeleteSystem = new System.Windows.Forms.Button();
            this.btnSaveExit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.gbCores = new System.Windows.Forms.GroupBox();
            this.btnRetroArchCoreBrowser = new System.Windows.Forms.Button();
            this.txtRetroArchCoresDir = new System.Windows.Forms.TextBox();
            this.fbdRetroArchCores = new System.Windows.Forms.FolderBrowserDialog();
            this.ofdRetroArchExec = new System.Windows.Forms.OpenFileDialog();
            this.fbdRomDirectory = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox1.SuspendLayout();
            this.gbAddSystem.SuspendLayout();
            this.gbCurrentSystems.SuspendLayout();
            this.gbCores.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRetroArchExecBrowser);
            this.groupBox1.Controls.Add(this.txtRetroArchExecutable);
            this.groupBox1.Location = new System.Drawing.Point(5, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(585, 60);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "RetroArch Directory :: (Must contain Retroarch executable)";
            // 
            // btnRetroArchExecBrowser
            // 
            this.btnRetroArchExecBrowser.Location = new System.Drawing.Point(532, 31);
            this.btnRetroArchExecBrowser.Name = "btnRetroArchExecBrowser";
            this.btnRetroArchExecBrowser.Size = new System.Drawing.Size(42, 20);
            this.btnRetroArchExecBrowser.TabIndex = 1;
            this.btnRetroArchExecBrowser.Text = "...";
            this.btnRetroArchExecBrowser.UseVisualStyleBackColor = true;
            this.btnRetroArchExecBrowser.Click += new System.EventHandler(this.btnRetroArchExecBrowser_Click);
            // 
            // txtRetroArchExecutable
            // 
            this.txtRetroArchExecutable.Location = new System.Drawing.Point(11, 31);
            this.txtRetroArchExecutable.Name = "txtRetroArchExecutable";
            this.txtRetroArchExecutable.Size = new System.Drawing.Size(515, 20);
            this.txtRetroArchExecutable.TabIndex = 0;
            // 
            // gbAddSystem
            // 
            this.gbAddSystem.Controls.Add(this.chkAutoAddArchiveExt);
            this.gbAddSystem.Controls.Add(this.label4);
            this.gbAddSystem.Controls.Add(this.txtRomExt);
            this.gbAddSystem.Controls.Add(this.btnRomDirBrowser);
            this.gbAddSystem.Controls.Add(this.btnSaveSystem);
            this.gbAddSystem.Controls.Add(this.btnCancelAdd);
            this.gbAddSystem.Controls.Add(this.cbCoreList);
            this.gbAddSystem.Controls.Add(this.label3);
            this.gbAddSystem.Controls.Add(this.txtRomDirectory);
            this.gbAddSystem.Controls.Add(this.label2);
            this.gbAddSystem.Controls.Add(this.label1);
            this.gbAddSystem.Controls.Add(this.txtSystemName);
            this.gbAddSystem.Enabled = false;
            this.gbAddSystem.Location = new System.Drawing.Point(5, 138);
            this.gbAddSystem.Name = "gbAddSystem";
            this.gbAddSystem.Size = new System.Drawing.Size(585, 168);
            this.gbAddSystem.TabIndex = 1;
            this.gbAddSystem.TabStop = false;
            this.gbAddSystem.Text = "Add System";
            // 
            // chkAutoAddArchiveExt
            // 
            this.chkAutoAddArchiveExt.AutoSize = true;
            this.chkAutoAddArchiveExt.Checked = true;
            this.chkAutoAddArchiveExt.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAutoAddArchiveExt.Location = new System.Drawing.Point(377, 109);
            this.chkAutoAddArchiveExt.Name = "chkAutoAddArchiveExt";
            this.chkAutoAddArchiveExt.Size = new System.Drawing.Size(180, 17);
            this.chkAutoAddArchiveExt.TabIndex = 11;
            this.chkAutoAddArchiveExt.Text = "Automatically Add ZIP/7Z as Ext";
            this.chkAutoAddArchiveExt.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(166, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Rom Extensions (seperate with | ):";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtRomExt
            // 
            this.txtRomExt.Location = new System.Drawing.Point(180, 107);
            this.txtRomExt.Name = "txtRomExt";
            this.txtRomExt.Size = new System.Drawing.Size(178, 20);
            this.txtRomExt.TabIndex = 9;
            // 
            // btnRomDirBrowser
            // 
            this.btnRomDirBrowser.Location = new System.Drawing.Point(532, 82);
            this.btnRomDirBrowser.Name = "btnRomDirBrowser";
            this.btnRomDirBrowser.Size = new System.Drawing.Size(42, 20);
            this.btnRomDirBrowser.TabIndex = 2;
            this.btnRomDirBrowser.Text = "...";
            this.btnRomDirBrowser.UseVisualStyleBackColor = true;
            this.btnRomDirBrowser.Click += new System.EventHandler(this.btnRomDirBrowser_Click);
            // 
            // btnSaveSystem
            // 
            this.btnSaveSystem.Location = new System.Drawing.Point(478, 139);
            this.btnSaveSystem.Name = "btnSaveSystem";
            this.btnSaveSystem.Size = new System.Drawing.Size(96, 23);
            this.btnSaveSystem.TabIndex = 8;
            this.btnSaveSystem.Text = "Save System";
            this.btnSaveSystem.UseVisualStyleBackColor = true;
            this.btnSaveSystem.Click += new System.EventHandler(this.btnSaveSystem_Click);
            // 
            // btnCancelAdd
            // 
            this.btnCancelAdd.Location = new System.Drawing.Point(11, 139);
            this.btnCancelAdd.Name = "btnCancelAdd";
            this.btnCancelAdd.Size = new System.Drawing.Size(96, 23);
            this.btnCancelAdd.TabIndex = 7;
            this.btnCancelAdd.Text = "Cancel Adding";
            this.btnCancelAdd.UseVisualStyleBackColor = true;
            this.btnCancelAdd.Click += new System.EventHandler(this.btnCancelAdd_Click);
            // 
            // cbCoreList
            // 
            this.cbCoreList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCoreList.FormattingEnabled = true;
            this.cbCoreList.Location = new System.Drawing.Point(87, 56);
            this.cbCoreList.Name = "cbCoreList";
            this.cbCoreList.Size = new System.Drawing.Size(485, 21);
            this.cbCoreList.Sorted = true;
            this.cbCoreList.TabIndex = 6;
            this.cbCoreList.SelectedIndexChanged += new System.EventHandler(this.cbCoreList_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Rom Directory:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtRomDirectory
            // 
            this.txtRomDirectory.Location = new System.Drawing.Point(87, 82);
            this.txtRomDirectory.Name = "txtRomDirectory";
            this.txtRomDirectory.Size = new System.Drawing.Size(439, 20);
            this.txtRomDirectory.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Core:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "System Name:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSystemName
            // 
            this.txtSystemName.Location = new System.Drawing.Point(87, 30);
            this.txtSystemName.Name = "txtSystemName";
            this.txtSystemName.Size = new System.Drawing.Size(485, 20);
            this.txtSystemName.TabIndex = 0;
            // 
            // gbCurrentSystems
            // 
            this.gbCurrentSystems.Controls.Add(this.btnEditSystem);
            this.gbCurrentSystems.Controls.Add(this.lvCurrentSystems);
            this.gbCurrentSystems.Controls.Add(this.btnAddSystem);
            this.gbCurrentSystems.Controls.Add(this.btnDeleteSystem);
            this.gbCurrentSystems.Enabled = false;
            this.gbCurrentSystems.Location = new System.Drawing.Point(5, 312);
            this.gbCurrentSystems.Name = "gbCurrentSystems";
            this.gbCurrentSystems.Size = new System.Drawing.Size(585, 235);
            this.gbCurrentSystems.TabIndex = 2;
            this.gbCurrentSystems.TabStop = false;
            this.gbCurrentSystems.Text = "Current Systems";
            // 
            // btnEditSystem
            // 
            this.btnEditSystem.Location = new System.Drawing.Point(242, 203);
            this.btnEditSystem.Name = "btnEditSystem";
            this.btnEditSystem.Size = new System.Drawing.Size(84, 23);
            this.btnEditSystem.TabIndex = 4;
            this.btnEditSystem.Text = "Edit System";
            this.btnEditSystem.UseVisualStyleBackColor = true;
            this.btnEditSystem.Click += new System.EventHandler(this.btnEditSystem_Click);
            // 
            // lvCurrentSystems
            // 
            this.lvCurrentSystems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chSystemName,
            this.chCore,
            this.chRomDirectory,
            this.chExtensions});
            this.lvCurrentSystems.FullRowSelect = true;
            this.lvCurrentSystems.Location = new System.Drawing.Point(11, 19);
            this.lvCurrentSystems.MultiSelect = false;
            this.lvCurrentSystems.Name = "lvCurrentSystems";
            this.lvCurrentSystems.Size = new System.Drawing.Size(563, 179);
            this.lvCurrentSystems.TabIndex = 3;
            this.lvCurrentSystems.UseCompatibleStateImageBehavior = false;
            this.lvCurrentSystems.View = System.Windows.Forms.View.Details;
            // 
            // chSystemName
            // 
            this.chSystemName.Text = "System Name";
            this.chSystemName.Width = 148;
            // 
            // chCore
            // 
            this.chCore.Text = "Core";
            this.chCore.Width = 122;
            // 
            // chRomDirectory
            // 
            this.chRomDirectory.Text = "Rom Directory";
            this.chRomDirectory.Width = 201;
            // 
            // chExtensions
            // 
            this.chExtensions.Text = "Extensions";
            this.chExtensions.Width = 80;
            // 
            // btnAddSystem
            // 
            this.btnAddSystem.Location = new System.Drawing.Point(332, 203);
            this.btnAddSystem.Name = "btnAddSystem";
            this.btnAddSystem.Size = new System.Drawing.Size(86, 23);
            this.btnAddSystem.TabIndex = 2;
            this.btnAddSystem.Text = "Add New";
            this.btnAddSystem.UseVisualStyleBackColor = true;
            this.btnAddSystem.Click += new System.EventHandler(this.btnAddSystem_Click);
            // 
            // btnDeleteSystem
            // 
            this.btnDeleteSystem.Location = new System.Drawing.Point(152, 203);
            this.btnDeleteSystem.Name = "btnDeleteSystem";
            this.btnDeleteSystem.Size = new System.Drawing.Size(84, 23);
            this.btnDeleteSystem.TabIndex = 1;
            this.btnDeleteSystem.Text = "Delete System";
            this.btnDeleteSystem.UseVisualStyleBackColor = true;
            this.btnDeleteSystem.Click += new System.EventHandler(this.btnDeleteSystem_Click);
            // 
            // btnSaveExit
            // 
            this.btnSaveExit.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSaveExit.Location = new System.Drawing.Point(515, 552);
            this.btnSaveExit.Name = "btnSaveExit";
            this.btnSaveExit.Size = new System.Drawing.Size(75, 24);
            this.btnSaveExit.TabIndex = 3;
            this.btnSaveExit.Text = "Save && Exit";
            this.btnSaveExit.UseVisualStyleBackColor = true;
            this.btnSaveExit.Click += new System.EventHandler(this.btnSaveExit_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(5, 552);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 24);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // gbCores
            // 
            this.gbCores.Controls.Add(this.btnRetroArchCoreBrowser);
            this.gbCores.Controls.Add(this.txtRetroArchCoresDir);
            this.gbCores.Location = new System.Drawing.Point(5, 71);
            this.gbCores.Name = "gbCores";
            this.gbCores.Size = new System.Drawing.Size(585, 61);
            this.gbCores.TabIndex = 5;
            this.gbCores.TabStop = false;
            this.gbCores.Text = "Libretro Cores Directory :: ";
            // 
            // btnRetroArchCoreBrowser
            // 
            this.btnRetroArchCoreBrowser.Location = new System.Drawing.Point(532, 31);
            this.btnRetroArchCoreBrowser.Name = "btnRetroArchCoreBrowser";
            this.btnRetroArchCoreBrowser.Size = new System.Drawing.Size(42, 20);
            this.btnRetroArchCoreBrowser.TabIndex = 1;
            this.btnRetroArchCoreBrowser.Text = "...";
            this.btnRetroArchCoreBrowser.UseVisualStyleBackColor = true;
            this.btnRetroArchCoreBrowser.Click += new System.EventHandler(this.btnRetroArchCoreBrowser_Click);
            // 
            // txtRetroArchCoresDir
            // 
            this.txtRetroArchCoresDir.Location = new System.Drawing.Point(11, 31);
            this.txtRetroArchCoresDir.Name = "txtRetroArchCoresDir";
            this.txtRetroArchCoresDir.Size = new System.Drawing.Size(515, 20);
            this.txtRetroArchCoresDir.TabIndex = 0;
            // 
            // fbdRetroArchCores
            // 
            this.fbdRetroArchCores.Description = "Locate the directory containing the Libretro cores";
            // 
            // frmConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 580);
            this.Controls.Add(this.gbCores);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSaveExit);
            this.Controls.Add(this.gbCurrentSystems);
            this.Controls.Add(this.gbAddSystem);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConfig";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RAEM :: Config";
            this.Load += new System.EventHandler(this.frmConfig_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbAddSystem.ResumeLayout(false);
            this.gbAddSystem.PerformLayout();
            this.gbCurrentSystems.ResumeLayout(false);
            this.gbCores.ResumeLayout(false);
            this.gbCores.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnRetroArchExecBrowser;
        private System.Windows.Forms.TextBox txtRetroArchExecutable;
        private System.Windows.Forms.GroupBox gbAddSystem;
        private System.Windows.Forms.GroupBox gbCurrentSystems;
        private System.Windows.Forms.Button btnSaveExit;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSaveSystem;
        private System.Windows.Forms.Button btnCancelAdd;
        private System.Windows.Forms.ComboBox cbCoreList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRomDirectory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSystemName;
        private System.Windows.Forms.Button btnAddSystem;
        private System.Windows.Forms.Button btnDeleteSystem;
        private System.Windows.Forms.ListView lvCurrentSystems;
        private System.Windows.Forms.ColumnHeader chSystemName;
        private System.Windows.Forms.ColumnHeader chCore;
        private System.Windows.Forms.ColumnHeader chRomDirectory;
        private System.Windows.Forms.Button btnEditSystem;
        private System.Windows.Forms.GroupBox gbCores;
        private System.Windows.Forms.Button btnRetroArchCoreBrowser;
        private System.Windows.Forms.TextBox txtRetroArchCoresDir;
        private System.Windows.Forms.Button btnRomDirBrowser;
        private System.Windows.Forms.FolderBrowserDialog fbdRetroArchCores;
        private System.Windows.Forms.OpenFileDialog ofdRetroArchExec;
        private System.Windows.Forms.FolderBrowserDialog fbdRomDirectory;
        private System.Windows.Forms.ColumnHeader chExtensions;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRomExt;
        private System.Windows.Forms.CheckBox chkAutoAddArchiveExt;
    }
}