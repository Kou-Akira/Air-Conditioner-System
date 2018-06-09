namespace AirConditionerSystem
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
            this.remindText = new System.Windows.Forms.Label();
            this.loadIcon = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.closeBtn = new DMSkin.Controls.DMButtonClose();
            ((System.ComponentModel.ISupportInitialize)(this.loadIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // remindText
            // 
            this.remindText.AutoSize = true;
            this.remindText.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.remindText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(111)))), ((int)(((byte)(138)))));
            this.remindText.Location = new System.Drawing.Point(111, 28);
            this.remindText.Name = "remindText";
            this.remindText.Size = new System.Drawing.Size(84, 25);
            this.remindText.TabIndex = 9;
            this.remindText.Text = "加载中...";
            // 
            // loadIcon
            // 
            this.loadIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.loadIcon.Image = ((System.Drawing.Image)(resources.GetObject("loadIcon.Image")));
            this.loadIcon.Location = new System.Drawing.Point(40, 10);
            this.loadIcon.Name = "loadIcon";
            this.loadIcon.Size = new System.Drawing.Size(60, 60);
            this.loadIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.loadIcon.TabIndex = 10;
            this.loadIcon.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(225, 62);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(25, 18);
            this.panel1.TabIndex = 11;
            // 
            // closeBtn
            // 
            this.closeBtn.BackColor = System.Drawing.Color.Transparent;
            this.closeBtn.Location = new System.Drawing.Point(222, -1);
            this.closeBtn.MaximumSize = new System.Drawing.Size(30, 27);
            this.closeBtn.MinimumSize = new System.Drawing.Size(30, 27);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(30, 27);
            this.closeBtn.TabIndex = 12;
            this.closeBtn.Visible = false;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // LoadingBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(221)))), ((int)(((byte)(232)))));
            this.ClientSize = new System.Drawing.Size(250, 80);
            this.ControlBox = false;
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.loadIcon);
            this.Controls.Add(this.remindText);
            this.DM_CanResize = false;
            this.DM_howBorder = false;
            this.DM_RoundStyle = DMSkin.SkinClass.RoundStyle.None;
            this.DM_ShadowWidth = 6;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoadingBox";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "LoadingBox";
            this.Load += new System.EventHandler(this.LoadingBox_Load);
            ((System.ComponentModel.ISupportInitialize)(this.loadIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label remindText;
        private System.Windows.Forms.PictureBox loadIcon;
        private System.Windows.Forms.Panel panel1;
        private DMSkin.Controls.DMButtonClose closeBtn;
    }
}