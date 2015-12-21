namespace client
{
    partial class frmGame
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
            this.picBanCo = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnXinThua = new System.Windows.Forms.Button();
            this.btnXinHoa = new System.Windows.Forms.Button();
            this.lblNguoiChoi = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnMoiChoi = new System.Windows.Forms.Button();
            this.lstNguoiChoiOnline = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.picBanCo)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // picBanCo
            // 
            this.picBanCo.Enabled = false;
            this.picBanCo.Image = global::client.Properties.Resources.caro;
            this.picBanCo.Location = new System.Drawing.Point(12, 12);
            this.picBanCo.Name = "picBanCo";
            this.picBanCo.Size = new System.Drawing.Size(578, 482);
            this.picBanCo.TabIndex = 0;
            this.picBanCo.TabStop = false;
            this.picBanCo.Click += new System.EventHandler(this.picBanCo_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnXinThua);
            this.groupBox1.Controls.Add(this.btnXinHoa);
            this.groupBox1.Controls.Add(this.lblNguoiChoi);
            this.groupBox1.Location = new System.Drawing.Point(604, 63);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(222, 71);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Game";
            // 
            // btnXinThua
            // 
            this.btnXinThua.Enabled = false;
            this.btnXinThua.Location = new System.Drawing.Point(87, 39);
            this.btnXinThua.Name = "btnXinThua";
            this.btnXinThua.Size = new System.Drawing.Size(75, 23);
            this.btnXinThua.TabIndex = 2;
            this.btnXinThua.Text = "Xin thua";
            this.btnXinThua.UseVisualStyleBackColor = true;
            // 
            // btnXinHoa
            // 
            this.btnXinHoa.Enabled = false;
            this.btnXinHoa.Location = new System.Drawing.Point(6, 39);
            this.btnXinHoa.Name = "btnXinHoa";
            this.btnXinHoa.Size = new System.Drawing.Size(75, 23);
            this.btnXinHoa.TabIndex = 2;
            this.btnXinHoa.Text = "Xin hòa";
            this.btnXinHoa.UseVisualStyleBackColor = true;
            // 
            // lblNguoiChoi
            // 
            this.lblNguoiChoi.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblNguoiChoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNguoiChoi.Location = new System.Drawing.Point(3, 16);
            this.lblNguoiChoi.Name = "lblNguoiChoi";
            this.lblNguoiChoi.Size = new System.Drawing.Size(216, 20);
            this.lblNguoiChoi.TabIndex = 0;
            this.lblNguoiChoi.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnMoiChoi);
            this.groupBox2.Controls.Add(this.lstNguoiChoiOnline);
            this.groupBox2.Location = new System.Drawing.Point(601, 140);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(222, 236);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Người chơi online";
            // 
            // btnMoiChoi
            // 
            this.btnMoiChoi.Location = new System.Drawing.Point(3, 208);
            this.btnMoiChoi.Name = "btnMoiChoi";
            this.btnMoiChoi.Size = new System.Drawing.Size(75, 23);
            this.btnMoiChoi.TabIndex = 1;
            this.btnMoiChoi.Text = "Mời chơi";
            this.btnMoiChoi.UseVisualStyleBackColor = true;
            this.btnMoiChoi.Click += new System.EventHandler(this.btnMoiChoi_Click);
            // 
            // lstNguoiChoiOnline
            // 
            this.lstNguoiChoiOnline.Dock = System.Windows.Forms.DockStyle.Top;
            this.lstNguoiChoiOnline.FormattingEnabled = true;
            this.lstNguoiChoiOnline.Location = new System.Drawing.Point(3, 16);
            this.lstNguoiChoiOnline.Name = "lstNguoiChoiOnline";
            this.lstNguoiChoiOnline.Size = new System.Drawing.Size(216, 186);
            this.lstNguoiChoiOnline.TabIndex = 0;
            this.lstNguoiChoiOnline.SelectedIndexChanged += new System.EventHandler(this.lstNguoiChoiOnline_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtUsername);
            this.groupBox3.Location = new System.Drawing.Point(604, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(222, 45);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Người chơi";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(7, 19);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.ReadOnly = true;
            this.txtUsername.Size = new System.Drawing.Size(209, 20);
            this.txtUsername.TabIndex = 0;
            // 
            // frmGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 506);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.picBanCo);
            this.Name = "frmGame";
            this.Text = "Game caro online";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmGame_FormClosing);
            this.Load += new System.EventHandler(this.frmGame_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBanCo)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picBanCo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblNguoiChoi;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox lstNguoiChoiOnline;
        private System.Windows.Forms.Button btnMoiChoi;
        private System.Windows.Forms.Button btnXinHoa;
        private System.Windows.Forms.Button btnXinThua;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtUsername;
    }
}