namespace GameGK
{
    partial class Menu
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
            this.ptTetris = new System.Windows.Forms.PictureBox();
            this.ptLogin = new System.Windows.Forms.PictureBox();
            this.ptPlayNow = new System.Windows.Forms.PictureBox();
            this.ptCancel = new System.Windows.Forms.PictureBox();
            this.ptInfo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ptTetris)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptLogin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptPlayNow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // ptTetris
            // 
            this.ptTetris.BackColor = System.Drawing.Color.Transparent;
            this.ptTetris.Location = new System.Drawing.Point(176, 44);
            this.ptTetris.Name = "ptTetris";
            this.ptTetris.Size = new System.Drawing.Size(448, 137);
            this.ptTetris.TabIndex = 0;
            this.ptTetris.TabStop = false;
            // 
            // ptLogin
            // 
            this.ptLogin.BackColor = System.Drawing.Color.Transparent;
            this.ptLogin.Location = new System.Drawing.Point(309, 296);
            this.ptLogin.Name = "ptLogin";
            this.ptLogin.Size = new System.Drawing.Size(183, 52);
            this.ptLogin.TabIndex = 1;
            this.ptLogin.TabStop = false;
            this.ptLogin.Click += new System.EventHandler(this.ptLogin_Click);
            // 
            // ptPlayNow
            // 
            this.ptPlayNow.BackColor = System.Drawing.Color.Transparent;
            this.ptPlayNow.Location = new System.Drawing.Point(309, 227);
            this.ptPlayNow.Name = "ptPlayNow";
            this.ptPlayNow.Size = new System.Drawing.Size(183, 52);
            this.ptPlayNow.TabIndex = 1;
            this.ptPlayNow.TabStop = false;
            this.ptPlayNow.Click += new System.EventHandler(this.ptPlayNow_Click);
            // 
            // ptCancel
            // 
            this.ptCancel.BackColor = System.Drawing.Color.Transparent;
            this.ptCancel.Location = new System.Drawing.Point(309, 432);
            this.ptCancel.Name = "ptCancel";
            this.ptCancel.Size = new System.Drawing.Size(183, 52);
            this.ptCancel.TabIndex = 1;
            this.ptCancel.TabStop = false;
            this.ptCancel.Click += new System.EventHandler(this.ptCancel_Click);
            // 
            // ptInfo
            // 
            this.ptInfo.BackColor = System.Drawing.Color.Transparent;
            this.ptInfo.Location = new System.Drawing.Point(309, 364);
            this.ptInfo.Name = "ptInfo";
            this.ptInfo.Size = new System.Drawing.Size(183, 52);
            this.ptInfo.TabIndex = 1;
            this.ptInfo.TabStop = false;
            this.ptInfo.Click += new System.EventHandler(this.ptInfo_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 573);
            this.Controls.Add(this.ptPlayNow);
            this.Controls.Add(this.ptInfo);
            this.Controls.Add(this.ptCancel);
            this.Controls.Add(this.ptLogin);
            this.Controls.Add(this.ptTetris);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.Menu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ptTetris)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptLogin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptPlayNow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox ptTetris;
        private System.Windows.Forms.PictureBox ptLogin;
        private System.Windows.Forms.PictureBox ptPlayNow;
        private System.Windows.Forms.PictureBox ptCancel;
        private System.Windows.Forms.PictureBox ptInfo;
    }
}