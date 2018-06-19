namespace Host
{
    partial class LoadingBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoadingBox));
            this.closeBtn = new DMSkin.Controls.DMButtonClose();
            this.loadIcon = new System.Windows.Forms.PictureBox();
            this.remindText = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.loadIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // closeBtn
            // 
            this.closeBtn.BackColor = System.Drawing.Color.Transparent;
            this.closeBtn.Location = new System.Drawing.Point(222, -3);
            this.closeBtn.MaximumSize = new System.Drawing.Size(30, 27);
            this.closeBtn.MinimumSize = new System.Drawing.Size(30, 27);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(30, 27);
            this.closeBtn.TabIndex = 15;
            this.closeBtn.Visible = false;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // loadIcon
            // 
            this.loadIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.loadIcon.Image = ((System.Drawing.Image)(resources.GetObject("loadIcon.Image")));
            this.loadIcon.Location = new System.Drawing.Point(41, 9);
            this.loadIcon.Name = "loadIcon";
            this.loadIcon.Size = new System.Drawing.Size(60, 60);
            this.loadIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.loadIcon.TabIndex = 14;
            this.loadIcon.TabStop = false;
            // 
            // remindText
            // 
            this.remindText.AutoSize = true;
            this.remindText.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.remindText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(111)))), ((int)(((byte)(138)))));
            this.remindText.Location = new System.Drawing.Point(112, 27);
            this.remindText.Name = "remindText";
            this.remindText.Size = new System.Drawing.Size(84, 25);
            this.remindText.TabIndex = 13;
            this.remindText.Text = "加载中...";
            // 
            // LoadingBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(221)))), ((int)(((byte)(232)))));
            this.ClientSize = new System.Drawing.Size(250, 80);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.loadIcon);
            this.Controls.Add(this.remindText);
            this.Name = "LoadingBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "LoadingBox";
            this.Load += new System.EventHandler(this.LoadingBox_Load);
            ((System.ComponentModel.ISupportInitialize)(this.loadIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DMSkin.Controls.DMButtonClose closeBtn;
        private System.Windows.Forms.PictureBox loadIcon;
        private System.Windows.Forms.Label remindText;
    }
}