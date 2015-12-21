namespace server
{
    partial class frmServer
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
            this.rLog = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.userToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolThemNguoiDung = new System.Windows.Forms.ToolStripMenuItem();
            this.toolDanhSach = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rLog
            // 
            this.rLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rLog.Location = new System.Drawing.Point(0, 24);
            this.rLog.Name = "rLog";
            this.rLog.Size = new System.Drawing.Size(352, 413);
            this.rLog.TabIndex = 0;
            this.rLog.Text = "";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(352, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // userToolStripMenuItem
            // 
            this.userToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolThemNguoiDung,
            this.toolDanhSach});
            this.userToolStripMenuItem.Name = "userToolStripMenuItem";
            this.userToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.userToolStripMenuItem.Text = "Tài khoản";
            // 
            // toolThemNguoiDung
            // 
            this.toolThemNguoiDung.Name = "toolThemNguoiDung";
            this.toolThemNguoiDung.Size = new System.Drawing.Size(194, 22);
            this.toolThemNguoiDung.Text = "Thêm người dùng";
            this.toolThemNguoiDung.Click += new System.EventHandler(this.toolThemNguoiDung_Click);
            // 
            // toolDanhSach
            // 
            this.toolDanhSach.Name = "toolDanhSach";
            this.toolDanhSach.Size = new System.Drawing.Size(194, 22);
            this.toolDanhSach.Text = "Danh sách người dùng";
            this.toolDanhSach.Click += new System.EventHandler(this.toolDanhSach_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.aboutToolStripMenuItem.Text = "Giới thiệu";
            // 
            // frmServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 437);
            this.Controls.Add(this.rLog);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmServer";
            this.Text = "Caro server";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rLog;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem userToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolThemNguoiDung;
        private System.Windows.Forms.ToolStripMenuItem toolDanhSach;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}

