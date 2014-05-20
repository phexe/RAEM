namespace raem
{
    partial class frmCoreConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCoreConfig));
            this.gbSystemName = new System.Windows.Forms.GroupBox();
            this.lvCoreOptions = new System.Windows.Forms.ListView();
            this.colCoreOptionName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCoreOptionValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.gbOptionName = new System.Windows.Forms.GroupBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.gbSystemName.SuspendLayout();
            this.gbOptionName.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbSystemName
            // 
            this.gbSystemName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbSystemName.Controls.Add(this.lvCoreOptions);
            this.gbSystemName.Location = new System.Drawing.Point(12, 12);
            this.gbSystemName.Name = "gbSystemName";
            this.gbSystemName.Size = new System.Drawing.Size(545, 309);
            this.gbSystemName.TabIndex = 0;
            this.gbSystemName.TabStop = false;
            // 
            // lvCoreOptions
            // 
            this.lvCoreOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvCoreOptions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colCoreOptionName,
            this.colCoreOptionValue});
            this.lvCoreOptions.FullRowSelect = true;
            this.lvCoreOptions.Location = new System.Drawing.Point(6, 18);
            this.lvCoreOptions.Name = "lvCoreOptions";
            this.lvCoreOptions.Size = new System.Drawing.Size(533, 285);
            this.lvCoreOptions.TabIndex = 0;
            this.lvCoreOptions.UseCompatibleStateImageBehavior = false;
            this.lvCoreOptions.View = System.Windows.Forms.View.Details;
            this.lvCoreOptions.SelectedIndexChanged += new System.EventHandler(this.lvCoreOptions_SelectedIndexChanged);
            this.lvCoreOptions.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvCoreOptions_MouseDoubleClick);
            // 
            // colCoreOptionName
            // 
            this.colCoreOptionName.Text = "Option";
            this.colCoreOptionName.Width = 302;
            // 
            // colCoreOptionValue
            // 
            this.colCoreOptionValue.Text = "Value";
            this.colCoreOptionValue.Width = 222;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(12, 404);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Location = new System.Drawing.Point(482, 404);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // gbOptionName
            // 
            this.gbOptionName.Controls.Add(this.lblDescription);
            this.gbOptionName.Location = new System.Drawing.Point(12, 327);
            this.gbOptionName.Name = "gbOptionName";
            this.gbOptionName.Size = new System.Drawing.Size(545, 71);
            this.gbOptionName.TabIndex = 3;
            this.gbOptionName.TabStop = false;
            // 
            // lblDescription
            // 
            this.lblDescription.Location = new System.Drawing.Point(6, 16);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(533, 52);
            this.lblDescription.TabIndex = 0;
            // 
            // frmCoreConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 439);
            this.Controls.Add(this.gbOptionName);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.gbSystemName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCoreConfig";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "RAEM :: Configure Emulation Core";
            this.Load += new System.EventHandler(this.frmCoreConfig_Load);
            this.gbSystemName.ResumeLayout(false);
            this.gbOptionName.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbSystemName;
        private System.Windows.Forms.ListView lvCoreOptions;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ColumnHeader colCoreOptionName;
        private System.Windows.Forms.ColumnHeader colCoreOptionValue;
        private System.Windows.Forms.GroupBox gbOptionName;
        private System.Windows.Forms.Label lblDescription;
    }
}