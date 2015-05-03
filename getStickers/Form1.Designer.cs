namespace getStickers
{
    partial class frmMain
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.fbd = new System.Windows.Forms.FolderBrowserDialog();
            this.btnSelectFolder = new System.Windows.Forms.Button();
            this.btnDownload = new System.Windows.Forms.Button();
            this.txtId = new System.Windows.Forms.TextBox();
            this.prgDownload = new System.Windows.Forms.ProgressBar();
            this.grbInfo = new System.Windows.Forms.GroupBox();
            this.txtInfo = new System.Windows.Forms.TextBox();
            this.statBar = new System.Windows.Forms.StatusStrip();
            this.statLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblStickerId = new System.Windows.Forms.Label();
            this.grbInfo.SuspendLayout();
            this.statBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSelectFolder
            // 
            this.btnSelectFolder.Location = new System.Drawing.Point(12, 12);
            this.btnSelectFolder.Name = "btnSelectFolder";
            this.btnSelectFolder.Size = new System.Drawing.Size(152, 23);
            this.btnSelectFolder.TabIndex = 0;
            this.btnSelectFolder.Text = "Select Download Folder";
            this.btnSelectFolder.UseVisualStyleBackColor = true;
            this.btnSelectFolder.Click += new System.EventHandler(this.btnSelectFolder_Click);
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(12, 83);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(152, 23);
            this.btnDownload.TabIndex = 1;
            this.btnDownload.Text = "Download";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(12, 57);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(152, 20);
            this.txtId.TabIndex = 2;
            // 
            // prgDownload
            // 
            this.prgDownload.Location = new System.Drawing.Point(12, 118);
            this.prgDownload.Name = "prgDownload";
            this.prgDownload.Size = new System.Drawing.Size(405, 23);
            this.prgDownload.TabIndex = 3;
            // 
            // grbInfo
            // 
            this.grbInfo.Controls.Add(this.txtInfo);
            this.grbInfo.Location = new System.Drawing.Point(170, 12);
            this.grbInfo.Name = "grbInfo";
            this.grbInfo.Size = new System.Drawing.Size(247, 100);
            this.grbInfo.TabIndex = 4;
            this.grbInfo.TabStop = false;
            this.grbInfo.Text = "Info";
            // 
            // txtInfo
            // 
            this.txtInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtInfo.Enabled = false;
            this.txtInfo.Location = new System.Drawing.Point(6, 19);
            this.txtInfo.Multiline = true;
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.ReadOnly = true;
            this.txtInfo.Size = new System.Drawing.Size(188, 75);
            this.txtInfo.TabIndex = 0;
            // 
            // statBar
            // 
            this.statBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statLabel});
            this.statBar.Location = new System.Drawing.Point(0, 150);
            this.statBar.Name = "statBar";
            this.statBar.Size = new System.Drawing.Size(429, 22);
            this.statBar.TabIndex = 6;
            this.statBar.Text = "statusStrip1";
            // 
            // statLabel
            // 
            this.statLabel.Name = "statLabel";
            this.statLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // lblStickerId
            // 
            this.lblStickerId.AutoSize = true;
            this.lblStickerId.Location = new System.Drawing.Point(13, 42);
            this.lblStickerId.Name = "lblStickerId";
            this.lblStickerId.Size = new System.Drawing.Size(24, 13);
            this.lblStickerId.TabIndex = 7;
            this.lblStickerId.Text = "ID: ";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 172);
            this.Controls.Add(this.lblStickerId);
            this.Controls.Add(this.statBar);
            this.Controls.Add(this.grbInfo);
            this.Controls.Add(this.prgDownload);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.btnSelectFolder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Text = "Form1";
            this.grbInfo.ResumeLayout(false);
            this.grbInfo.PerformLayout();
            this.statBar.ResumeLayout(false);
            this.statBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog fbd;
        private System.Windows.Forms.Button btnSelectFolder;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.ProgressBar prgDownload;
        private System.Windows.Forms.GroupBox grbInfo;
        private System.Windows.Forms.TextBox txtInfo;
        private System.Windows.Forms.StatusStrip statBar;
        private System.Windows.Forms.ToolStripStatusLabel statLabel;
        private System.Windows.Forms.Label lblStickerId;
    }
}

