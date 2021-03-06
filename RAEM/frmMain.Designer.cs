﻿namespace raem
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.mnusMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.emulatorOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainmenuConfigureCores = new System.Windows.Forms.ToolStripMenuItem();
            this.mainmenuConfigureControls = new System.Windows.Forms.ToolStripMenuItem();
            this.netPlayOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainmenuConfigureNetplay = new System.Windows.Forms.ToolStripMenuItem();
            this.chkEnableNetplay = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutraemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlStatusMessage = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolstripNetPlay = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblStatusMessage = new System.Windows.Forms.Label();
            this.mnuCoreConfig = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuiCoreConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.configureSystemControlsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lvSystems = new System.Windows.Forms.ListView();
            this.chSystem = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvGameList = new System.Windows.Forms.ListView();
            this.chTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mnusMain.SuspendLayout();
            this.pnlStatusMessage.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.mnuCoreConfig.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnusMain
            // 
            this.mnusMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.mnusMain.Location = new System.Drawing.Point(0, 0);
            this.mnusMain.Name = "mnusMain";
            this.mnusMain.Size = new System.Drawing.Size(636, 24);
            this.mnusMain.TabIndex = 3;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.emulatorOptionsToolStripMenuItem,
            this.netPlayOptionsToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "&Options";
            // 
            // emulatorOptionsToolStripMenuItem
            // 
            this.emulatorOptionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainmenuConfigureCores,
            this.mainmenuConfigureControls});
            this.emulatorOptionsToolStripMenuItem.Name = "emulatorOptionsToolStripMenuItem";
            this.emulatorOptionsToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.emulatorOptionsToolStripMenuItem.Text = "Emulator Options";
            // 
            // mainmenuConfigureCores
            // 
            this.mainmenuConfigureCores.Name = "mainmenuConfigureCores";
            this.mainmenuConfigureCores.Size = new System.Drawing.Size(175, 22);
            this.mainmenuConfigureCores.Text = "Configure Cores";
            this.mainmenuConfigureCores.Click += new System.EventHandler(this.mainmenuConfigureCores_Click);
            // 
            // mainmenuConfigureControls
            // 
            this.mainmenuConfigureControls.Name = "mainmenuConfigureControls";
            this.mainmenuConfigureControls.Size = new System.Drawing.Size(175, 22);
            this.mainmenuConfigureControls.Text = "Configure Controls";
            this.mainmenuConfigureControls.Click += new System.EventHandler(this.mainmenuConfigureControls_Click);
            // 
            // netPlayOptionsToolStripMenuItem
            // 
            this.netPlayOptionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainmenuConfigureNetplay,
            this.chkEnableNetplay});
            this.netPlayOptionsToolStripMenuItem.Name = "netPlayOptionsToolStripMenuItem";
            this.netPlayOptionsToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.netPlayOptionsToolStripMenuItem.Text = "NetPlay Options";
            // 
            // mainmenuConfigureNetplay
            // 
            this.mainmenuConfigureNetplay.Name = "mainmenuConfigureNetplay";
            this.mainmenuConfigureNetplay.Size = new System.Drawing.Size(171, 22);
            this.mainmenuConfigureNetplay.Text = "Configure NetPlay";
            this.mainmenuConfigureNetplay.Click += new System.EventHandler(this.mainmenuConfigureNetplay_Click);
            // 
            // chkEnableNetplay
            // 
            this.chkEnableNetplay.CheckOnClick = true;
            this.chkEnableNetplay.Name = "chkEnableNetplay";
            this.chkEnableNetplay.Size = new System.Drawing.Size(171, 22);
            this.chkEnableNetplay.Text = "Enable Netplay";
            this.chkEnableNetplay.Click += new System.EventHandler(this.chkEnableNetplay_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutraemToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "&About";
            // 
            // aboutraemToolStripMenuItem
            // 
            this.aboutraemToolStripMenuItem.Name = "aboutraemToolStripMenuItem";
            this.aboutraemToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.aboutraemToolStripMenuItem.Text = "About RAEM";
            this.aboutraemToolStripMenuItem.Click += new System.EventHandler(this.aboutraemToolStripMenuItem_Click);
            // 
            // pnlStatusMessage
            // 
            this.pnlStatusMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlStatusMessage.Controls.Add(this.statusStrip1);
            this.pnlStatusMessage.Controls.Add(this.lblStatusMessage);
            this.pnlStatusMessage.Location = new System.Drawing.Point(0, 0);
            this.pnlStatusMessage.Name = "pnlStatusMessage";
            this.pnlStatusMessage.Size = new System.Drawing.Size(636, 488);
            this.pnlStatusMessage.TabIndex = 4;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolstripNetPlay});
            this.statusStrip1.Location = new System.Drawing.Point(0, 466);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(636, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolstripNetPlay
            // 
            this.toolstripNetPlay.Name = "toolstripNetPlay";
            this.toolstripNetPlay.Size = new System.Drawing.Size(99, 17);
            this.toolstripNetPlay.Text = "NetPlay: Disabled";
            // 
            // lblStatusMessage
            // 
            this.lblStatusMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatusMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusMessage.Location = new System.Drawing.Point(6, 140);
            this.lblStatusMessage.Name = "lblStatusMessage";
            this.lblStatusMessage.Size = new System.Drawing.Size(624, 176);
            this.lblStatusMessage.TabIndex = 0;
            this.lblStatusMessage.Text = "STATUS";
            this.lblStatusMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mnuCoreConfig
            // 
            this.mnuCoreConfig.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuiCoreConfig,
            this.configureSystemControlsToolStripMenuItem});
            this.mnuCoreConfig.Name = "mnuCoreConfig";
            this.mnuCoreConfig.Size = new System.Drawing.Size(217, 48);
            // 
            // mnuiCoreConfig
            // 
            this.mnuiCoreConfig.Name = "mnuiCoreConfig";
            this.mnuiCoreConfig.Size = new System.Drawing.Size(216, 22);
            this.mnuiCoreConfig.Text = "Configure Core";
            this.mnuiCoreConfig.Click += new System.EventHandler(this.mnuiCoreConfig_Click);
            // 
            // configureSystemControlsToolStripMenuItem
            // 
            this.configureSystemControlsToolStripMenuItem.Name = "configureSystemControlsToolStripMenuItem";
            this.configureSystemControlsToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.configureSystemControlsToolStripMenuItem.Text = "Configure System Controls";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(7, 27);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lvSystems);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lvGameList);
            this.splitContainer1.Size = new System.Drawing.Size(617, 436);
            this.splitContainer1.SplitterDistance = 203;
            this.splitContainer1.TabIndex = 2;
            // 
            // lvSystems
            // 
            this.lvSystems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvSystems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chSystem});
            this.lvSystems.FullRowSelect = true;
            this.lvSystems.Location = new System.Drawing.Point(3, 3);
            this.lvSystems.MultiSelect = false;
            this.lvSystems.Name = "lvSystems";
            this.lvSystems.Size = new System.Drawing.Size(197, 430);
            this.lvSystems.TabIndex = 1;
            this.lvSystems.UseCompatibleStateImageBehavior = false;
            this.lvSystems.View = System.Windows.Forms.View.Details;
            this.lvSystems.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvSystems_ItemSelectionChanged);
            this.lvSystems.SelectedIndexChanged += new System.EventHandler(this.lvSystems_SelectedIndexChanged);
            // 
            // chSystem
            // 
            this.chSystem.Text = "System";
            this.chSystem.Width = 188;
            // 
            // lvGameList
            // 
            this.lvGameList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvGameList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chTitle});
            this.lvGameList.FullRowSelect = true;
            this.lvGameList.Location = new System.Drawing.Point(3, 3);
            this.lvGameList.MultiSelect = false;
            this.lvGameList.Name = "lvGameList";
            this.lvGameList.Size = new System.Drawing.Size(404, 430);
            this.lvGameList.TabIndex = 0;
            this.lvGameList.UseCompatibleStateImageBehavior = false;
            this.lvGameList.View = System.Windows.Forms.View.Details;
            this.lvGameList.DoubleClick += new System.EventHandler(this.lvGameList_DoubleClick);
            // 
            // chTitle
            // 
            this.chTitle.Text = "Game";
            this.chTitle.Width = 392;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 488);
            this.Controls.Add(this.mnusMain);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.pnlStatusMessage);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnusMain;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RAEM";
            this.Load += new System.EventHandler(this.raemUI_Load);
            this.mnusMain.ResumeLayout(false);
            this.mnusMain.PerformLayout();
            this.pnlStatusMessage.ResumeLayout(false);
            this.pnlStatusMessage.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.mnuCoreConfig.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnusMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutraemToolStripMenuItem;
        private System.Windows.Forms.Panel pnlStatusMessage;
        private System.Windows.Forms.Label lblStatusMessage;
        private System.Windows.Forms.ContextMenuStrip mnuCoreConfig;
        private System.Windows.Forms.ToolStripMenuItem mnuiCoreConfig;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView lvSystems;
        private System.Windows.Forms.ColumnHeader chSystem;
        private System.Windows.Forms.ListView lvGameList;
        private System.Windows.Forms.ColumnHeader chTitle;
        private System.Windows.Forms.ToolStripMenuItem configureSystemControlsToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolstripNetPlay;
        private System.Windows.Forms.ToolStripMenuItem netPlayOptionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mainmenuConfigureNetplay;
        private System.Windows.Forms.ToolStripMenuItem chkEnableNetplay;
        private System.Windows.Forms.ToolStripMenuItem emulatorOptionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mainmenuConfigureCores;
        private System.Windows.Forms.ToolStripMenuItem mainmenuConfigureControls;
    }
}

