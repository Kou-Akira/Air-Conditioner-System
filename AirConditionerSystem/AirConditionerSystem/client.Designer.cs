namespace AirConditionerSystem
{
    partial class Client
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Client));
            this.mainIcon = new System.Windows.Forms.PictureBox();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.speedBtn = new DMSkin.Controls.DM.DMButtonImage();
            this.switchBtn = new DMSkin.Controls.DM.DMButtonImage();
            this.tpText = new System.Windows.Forms.Label();
            this.ShutDownButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tpDownBtn = new DMSkin.Controls.DM.DMButtonImage();
            this.tpUpBtn = new DMSkin.Controls.DM.DMButtonImage();
            this.SpeedPanel = new System.Windows.Forms.Panel();
            this.lowSpeedBtn = new DMSkin.Controls.DM.DMButtonImage();
            this.midSpeedBtn = new DMSkin.Controls.DM.DMButtonImage();
            this.highSpeedBtn = new DMSkin.Controls.DM.DMButtonImage();
            ((System.ComponentModel.ISupportInitialize)(this.mainIcon)).BeginInit();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SpeedPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainIcon
            // 
            this.mainIcon.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("mainIcon.BackgroundImage")));
            this.mainIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mainIcon.Location = new System.Drawing.Point(49, 117);
            this.mainIcon.Name = "mainIcon";
            this.mainIcon.Size = new System.Drawing.Size(184, 156);
            this.mainIcon.TabIndex = 1;
            this.mainIcon.TabStop = false;
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(221)))), ((int)(((byte)(232)))));
            this.mainPanel.Controls.Add(this.SpeedPanel);
            this.mainPanel.Controls.Add(this.tpUpBtn);
            this.mainPanel.Controls.Add(this.tpDownBtn);
            this.mainPanel.Controls.Add(this.pictureBox1);
            this.mainPanel.Controls.Add(this.speedBtn);
            this.mainPanel.Controls.Add(this.switchBtn);
            this.mainPanel.Location = new System.Drawing.Point(0, 350);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(500, 200);
            this.mainPanel.TabIndex = 2;
            // 
            // speedBtn
            // 
            this.speedBtn.BackColor = System.Drawing.Color.Transparent;
            this.speedBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("speedBtn.BackgroundImage")));
            this.speedBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.speedBtn.DM_DownImage = null;
            this.speedBtn.DM_HoverImage = null;
            this.speedBtn.DM_Mode = false;
            this.speedBtn.DM_NolImage = ((System.Drawing.Image)(resources.GetObject("speedBtn.DM_NolImage")));
            this.speedBtn.Location = new System.Drawing.Point(396, 58);
            this.speedBtn.Name = "speedBtn";
            this.speedBtn.Size = new System.Drawing.Size(70, 70);
            this.speedBtn.State = DMSkin.Controls.DM.DMButtonImage.BtnState.Nol;
            this.speedBtn.TabIndex = 3;
            this.speedBtn.Click += new System.EventHandler(this.speedBtn_Click);
            // 
            // switchBtn
            // 
            this.switchBtn.BackColor = System.Drawing.Color.Transparent;
            this.switchBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("switchBtn.BackgroundImage")));
            this.switchBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.switchBtn.DM_DownImage = null;
            this.switchBtn.DM_HoverImage = null;
            this.switchBtn.DM_Mode = false;
            this.switchBtn.DM_NolImage = ((System.Drawing.Image)(resources.GetObject("switchBtn.DM_NolImage")));
            this.switchBtn.Location = new System.Drawing.Point(46, 60);
            this.switchBtn.Name = "switchBtn";
            this.switchBtn.Size = new System.Drawing.Size(70, 70);
            this.switchBtn.State = DMSkin.Controls.DM.DMButtonImage.BtnState.Nol;
            this.switchBtn.TabIndex = 1;
            this.switchBtn.Click += new System.EventHandler(this.switchBtn_Click);
            // 
            // tpText
            // 
            this.tpText.AutoSize = true;
            this.tpText.Font = new System.Drawing.Font("微软雅黑", 46F);
            this.tpText.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tpText.Location = new System.Drawing.Point(290, 108);
            this.tpText.Name = "tpText";
            this.tpText.Size = new System.Drawing.Size(169, 81);
            this.tpText.TabIndex = 3;
            this.tpText.Text = "28℃";
            // 
            // ShutDownButton
            // 
            this.ShutDownButton.BackColor = System.Drawing.Color.Transparent;
            this.ShutDownButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ShutDownButton.BackgroundImage")));
            this.ShutDownButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ShutDownButton.FlatAppearance.BorderSize = 0;
            this.ShutDownButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(42)))), ((int)(((byte)(21)))));
            this.ShutDownButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(65)))), ((int)(((byte)(39)))));
            this.ShutDownButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ShutDownButton.Location = new System.Drawing.Point(465, 0);
            this.ShutDownButton.Name = "ShutDownButton";
            this.ShutDownButton.Size = new System.Drawing.Size(35, 35);
            this.ShutDownButton.TabIndex = 7;
            this.ShutDownButton.TabStop = false;
            this.ShutDownButton.UseVisualStyleBackColor = false;
            this.ShutDownButton.Click += new System.EventHandler(this.ShutDownButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(288, 198);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 30);
            this.label1.TabIndex = 8;
            this.label1.Text = "房间温度：28℃";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(288, 239);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(189, 30);
            this.label2.TabIndex = 9;
            this.label2.Text = "当前费用：2.33元";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(3, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 25);
            this.label3.TabIndex = 10;
            this.label3.Text = "Room 632";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(228, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 25);
            this.label4.TabIndex = 11;
            this.label4.Text = "23:33";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(229, 65);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(60, 60);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // tpDownBtn
            // 
            this.tpDownBtn.BackColor = System.Drawing.Color.Transparent;
            this.tpDownBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tpDownBtn.BackgroundImage")));
            this.tpDownBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.tpDownBtn.DM_DownImage = null;
            this.tpDownBtn.DM_HoverImage = null;
            this.tpDownBtn.DM_Mode = false;
            this.tpDownBtn.DM_NolImage = ((System.Drawing.Image)(resources.GetObject("tpDownBtn.DM_NolImage")));
            this.tpDownBtn.Location = new System.Drawing.Point(177, 70);
            this.tpDownBtn.Name = "tpDownBtn";
            this.tpDownBtn.Size = new System.Drawing.Size(50, 50);
            this.tpDownBtn.State = DMSkin.Controls.DM.DMButtonImage.BtnState.Nol;
            this.tpDownBtn.TabIndex = 5;
            // 
            // tpUpBtn
            // 
            this.tpUpBtn.BackColor = System.Drawing.Color.Transparent;
            this.tpUpBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tpUpBtn.BackgroundImage")));
            this.tpUpBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.tpUpBtn.DM_DownImage = null;
            this.tpUpBtn.DM_HoverImage = null;
            this.tpUpBtn.DM_Mode = false;
            this.tpUpBtn.DM_NolImage = ((System.Drawing.Image)(resources.GetObject("tpUpBtn.DM_NolImage")));
            this.tpUpBtn.Location = new System.Drawing.Point(291, 70);
            this.tpUpBtn.Name = "tpUpBtn";
            this.tpUpBtn.Size = new System.Drawing.Size(50, 50);
            this.tpUpBtn.State = DMSkin.Controls.DM.DMButtonImage.BtnState.Nol;
            this.tpUpBtn.TabIndex = 6;
            // 
            // SpeedPanel
            // 
            this.SpeedPanel.Controls.Add(this.highSpeedBtn);
            this.SpeedPanel.Controls.Add(this.midSpeedBtn);
            this.SpeedPanel.Controls.Add(this.lowSpeedBtn);
            this.SpeedPanel.Location = new System.Drawing.Point(362, 3);
            this.SpeedPanel.Name = "SpeedPanel";
            this.SpeedPanel.Size = new System.Drawing.Size(135, 194);
            this.SpeedPanel.TabIndex = 7;
            this.SpeedPanel.Visible = false;
            // 
            // lowSpeedBtn
            // 
            this.lowSpeedBtn.BackColor = System.Drawing.Color.Transparent;
            this.lowSpeedBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("lowSpeedBtn.BackgroundImage")));
            this.lowSpeedBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.lowSpeedBtn.DM_DownImage = null;
            this.lowSpeedBtn.DM_HoverImage = null;
            this.lowSpeedBtn.DM_Mode = false;
            this.lowSpeedBtn.DM_NolImage = ((System.Drawing.Image)(resources.GetObject("lowSpeedBtn.DM_NolImage")));
            this.lowSpeedBtn.Location = new System.Drawing.Point(43, 11);
            this.lowSpeedBtn.Name = "lowSpeedBtn";
            this.lowSpeedBtn.Size = new System.Drawing.Size(50, 50);
            this.lowSpeedBtn.State = DMSkin.Controls.DM.DMButtonImage.BtnState.Nol;
            this.lowSpeedBtn.TabIndex = 8;
            this.lowSpeedBtn.Click += new System.EventHandler(this.lowSpeedBtn_Click);
            // 
            // midSpeedBtn
            // 
            this.midSpeedBtn.BackColor = System.Drawing.Color.Transparent;
            this.midSpeedBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("midSpeedBtn.BackgroundImage")));
            this.midSpeedBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.midSpeedBtn.DM_DownImage = null;
            this.midSpeedBtn.DM_HoverImage = null;
            this.midSpeedBtn.DM_Mode = false;
            this.midSpeedBtn.DM_NolImage = ((System.Drawing.Image)(resources.GetObject("midSpeedBtn.DM_NolImage")));
            this.midSpeedBtn.Location = new System.Drawing.Point(42, 72);
            this.midSpeedBtn.Name = "midSpeedBtn";
            this.midSpeedBtn.Size = new System.Drawing.Size(50, 50);
            this.midSpeedBtn.State = DMSkin.Controls.DM.DMButtonImage.BtnState.Nol;
            this.midSpeedBtn.TabIndex = 9;
            this.midSpeedBtn.Click += new System.EventHandler(this.midSpeedBtn_Click);
            // 
            // highSpeedBtn
            // 
            this.highSpeedBtn.BackColor = System.Drawing.Color.Transparent;
            this.highSpeedBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("highSpeedBtn.BackgroundImage")));
            this.highSpeedBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.highSpeedBtn.DM_DownImage = null;
            this.highSpeedBtn.DM_HoverImage = null;
            this.highSpeedBtn.DM_Mode = false;
            this.highSpeedBtn.DM_NolImage = ((System.Drawing.Image)(resources.GetObject("highSpeedBtn.DM_NolImage")));
            this.highSpeedBtn.Location = new System.Drawing.Point(43, 131);
            this.highSpeedBtn.Name = "highSpeedBtn";
            this.highSpeedBtn.Size = new System.Drawing.Size(50, 50);
            this.highSpeedBtn.State = DMSkin.Controls.DM.DMButtonImage.BtnState.Nol;
            this.highSpeedBtn.TabIndex = 10;
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(141)))), ((int)(((byte)(166)))));
            this.ClientSize = new System.Drawing.Size(500, 550);
            this.ControlBox = false;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ShutDownButton);
            this.Controls.Add(this.tpText);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.mainIcon);
            this.DM_CanResize = false;
            this.DM_howBorder = false;
            this.DM_ShadowWidth = 5;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Client";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Client_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mainIcon)).EndInit();
            this.mainPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.SpeedPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox mainIcon;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Label tpText;
        private System.Windows.Forms.Button ShutDownButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private DMSkin.Controls.DM.DMButtonImage speedBtn;
        private DMSkin.Controls.DM.DMButtonImage switchBtn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DMSkin.Controls.DM.DMButtonImage tpUpBtn;
        private DMSkin.Controls.DM.DMButtonImage tpDownBtn;
        private System.Windows.Forms.Panel SpeedPanel;
        private DMSkin.Controls.DM.DMButtonImage lowSpeedBtn;
        private DMSkin.Controls.DM.DMButtonImage highSpeedBtn;
        private DMSkin.Controls.DM.DMButtonImage midSpeedBtn;
    }
}

