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
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SpeedPanel = new System.Windows.Forms.Panel();
            this.highText = new System.Windows.Forms.Label();
            this.midText = new System.Windows.Forms.Label();
            this.lowText = new System.Windows.Forms.Label();
            this.highSpeedBtn = new DMSkin.Controls.DM.DMButtonImage();
            this.midSpeedBtn = new DMSkin.Controls.DM.DMButtonImage();
            this.lowSpeedBtn = new DMSkin.Controls.DM.DMButtonImage();
            this.tpUpBtn = new DMSkin.Controls.DM.DMButtonImage();
            this.tpDownBtn = new DMSkin.Controls.DM.DMButtonImage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.speedBtn = new DMSkin.Controls.DM.DMButtonImage();
            this.switchBtn = new DMSkin.Controls.DM.DMButtonImage();
            this.label6 = new System.Windows.Forms.Label();
            this.tpText = new System.Windows.Forms.Label();
            this.ShutDownButton = new System.Windows.Forms.Button();
            this.roomTpText = new System.Windows.Forms.Label();
            this.nowPayText = new System.Windows.Forms.Label();
            this.roomText = new System.Windows.Forms.Label();
            this.timeText = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.mainIcon)).BeginInit();
            this.mainPanel.SuspendLayout();
            this.SpeedPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // mainIcon
            // 
            this.mainIcon.BackgroundImage = global::AirConditionerSystem.Properties.Resources.C0;
            this.mainIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mainIcon.Location = new System.Drawing.Point(38, 112);
            this.mainIcon.Name = "mainIcon";
            this.mainIcon.Size = new System.Drawing.Size(165, 152);
            this.mainIcon.TabIndex = 1;
            this.mainIcon.TabStop = false;
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(221)))), ((int)(((byte)(232)))));
            this.mainPanel.Controls.Add(this.label5);
            this.mainPanel.Controls.Add(this.label4);
            this.mainPanel.Controls.Add(this.SpeedPanel);
            this.mainPanel.Controls.Add(this.tpUpBtn);
            this.mainPanel.Controls.Add(this.tpDownBtn);
            this.mainPanel.Controls.Add(this.pictureBox1);
            this.mainPanel.Controls.Add(this.speedBtn);
            this.mainPanel.Controls.Add(this.switchBtn);
            this.mainPanel.Controls.Add(this.label6);
            this.mainPanel.Location = new System.Drawing.Point(0, 350);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(450, 200);
            this.mainPanel.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("黑体", 10F);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(111)))), ((int)(((byte)(138)))));
            this.label5.Location = new System.Drawing.Point(216, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 14);
            this.label5.TabIndex = 14;
            this.label5.Text = "温度";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("黑体", 10F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(111)))), ((int)(((byte)(138)))));
            this.label4.Location = new System.Drawing.Point(55, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 14);
            this.label4.TabIndex = 13;
            this.label4.Text = "开关";
            // 
            // SpeedPanel
            // 
            this.SpeedPanel.Controls.Add(this.highText);
            this.SpeedPanel.Controls.Add(this.midText);
            this.SpeedPanel.Controls.Add(this.lowText);
            this.SpeedPanel.Controls.Add(this.highSpeedBtn);
            this.SpeedPanel.Controls.Add(this.midSpeedBtn);
            this.SpeedPanel.Controls.Add(this.lowSpeedBtn);
            this.SpeedPanel.Location = new System.Drawing.Point(315, 3);
            this.SpeedPanel.Name = "SpeedPanel";
            this.SpeedPanel.Size = new System.Drawing.Size(135, 194);
            this.SpeedPanel.TabIndex = 7;
            this.SpeedPanel.Visible = false;
            // 
            // highText
            // 
            this.highText.AutoSize = true;
            this.highText.Font = new System.Drawing.Font("黑体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.highText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(111)))), ((int)(((byte)(138)))));
            this.highText.Location = new System.Drawing.Point(87, 147);
            this.highText.Name = "highText";
            this.highText.Size = new System.Drawing.Size(29, 19);
            this.highText.TabIndex = 13;
            this.highText.Text = "强";
            // 
            // midText
            // 
            this.midText.AutoSize = true;
            this.midText.Font = new System.Drawing.Font("黑体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.midText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(111)))), ((int)(((byte)(138)))));
            this.midText.Location = new System.Drawing.Point(87, 89);
            this.midText.Name = "midText";
            this.midText.Size = new System.Drawing.Size(29, 19);
            this.midText.TabIndex = 12;
            this.midText.Text = "中";
            // 
            // lowText
            // 
            this.lowText.AutoSize = true;
            this.lowText.Font = new System.Drawing.Font("黑体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lowText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(111)))), ((int)(((byte)(138)))));
            this.lowText.Location = new System.Drawing.Point(87, 28);
            this.lowText.Name = "lowText";
            this.lowText.Size = new System.Drawing.Size(29, 19);
            this.lowText.TabIndex = 11;
            this.lowText.Text = "弱";
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
            this.highSpeedBtn.Location = new System.Drawing.Point(31, 131);
            this.highSpeedBtn.Name = "highSpeedBtn";
            this.highSpeedBtn.Size = new System.Drawing.Size(50, 50);
            this.highSpeedBtn.State = DMSkin.Controls.DM.DMButtonImage.BtnState.Nol;
            this.highSpeedBtn.TabIndex = 10;
            this.highSpeedBtn.Click += new System.EventHandler(this.highSpeedBtn_Click);
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
            this.midSpeedBtn.Location = new System.Drawing.Point(30, 72);
            this.midSpeedBtn.Name = "midSpeedBtn";
            this.midSpeedBtn.Size = new System.Drawing.Size(50, 50);
            this.midSpeedBtn.State = DMSkin.Controls.DM.DMButtonImage.BtnState.Nol;
            this.midSpeedBtn.TabIndex = 9;
            this.midSpeedBtn.Click += new System.EventHandler(this.midSpeedBtn_Click);
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
            this.lowSpeedBtn.Location = new System.Drawing.Point(31, 11);
            this.lowSpeedBtn.Name = "lowSpeedBtn";
            this.lowSpeedBtn.Size = new System.Drawing.Size(50, 50);
            this.lowSpeedBtn.State = DMSkin.Controls.DM.DMButtonImage.BtnState.Nol;
            this.lowSpeedBtn.TabIndex = 8;
            this.lowSpeedBtn.Click += new System.EventHandler(this.lowSpeedBtn_Click);
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
            this.tpUpBtn.Location = new System.Drawing.Point(265, 70);
            this.tpUpBtn.Name = "tpUpBtn";
            this.tpUpBtn.Size = new System.Drawing.Size(50, 50);
            this.tpUpBtn.State = DMSkin.Controls.DM.DMButtonImage.BtnState.Nol;
            this.tpUpBtn.TabIndex = 6;
            this.tpUpBtn.Click += new System.EventHandler(this.tpUpBtn_Click);
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
            this.tpDownBtn.Location = new System.Drawing.Point(151, 70);
            this.tpDownBtn.Name = "tpDownBtn";
            this.tpDownBtn.Size = new System.Drawing.Size(50, 50);
            this.tpDownBtn.State = DMSkin.Controls.DM.DMButtonImage.BtnState.Nol;
            this.tpDownBtn.TabIndex = 5;
            this.tpDownBtn.Click += new System.EventHandler(this.tpDownBtn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(203, 65);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(60, 60);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
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
            this.speedBtn.Location = new System.Drawing.Point(353, 58);
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
            this.switchBtn.Location = new System.Drawing.Point(37, 60);
            this.switchBtn.Name = "switchBtn";
            this.switchBtn.Size = new System.Drawing.Size(70, 70);
            this.switchBtn.State = DMSkin.Controls.DM.DMButtonImage.BtnState.Nol;
            this.switchBtn.TabIndex = 1;
            this.switchBtn.Click += new System.EventHandler(this.switchBtn_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("黑体", 10F);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(111)))), ((int)(((byte)(138)))));
            this.label6.Location = new System.Drawing.Point(376, 134);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 14);
            this.label6.TabIndex = 15;
            this.label6.Text = "风力";
            // 
            // tpText
            // 
            this.tpText.AutoSize = true;
            this.tpText.Font = new System.Drawing.Font("微软雅黑", 46F);
            this.tpText.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tpText.Location = new System.Drawing.Point(240, 101);
            this.tpText.Name = "tpText";
            this.tpText.Size = new System.Drawing.Size(151, 81);
            this.tpText.TabIndex = 3;
            this.tpText.Text = "--℃";
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
            this.ShutDownButton.Location = new System.Drawing.Point(420, 0);
            this.ShutDownButton.Name = "ShutDownButton";
            this.ShutDownButton.Size = new System.Drawing.Size(30, 30);
            this.ShutDownButton.TabIndex = 7;
            this.ShutDownButton.TabStop = false;
            this.ShutDownButton.UseVisualStyleBackColor = false;
            this.ShutDownButton.Click += new System.EventHandler(this.ShutDownButton_Click);
            // 
            // roomTpText
            // 
            this.roomTpText.AutoSize = true;
            this.roomTpText.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.roomTpText.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.roomTpText.Location = new System.Drawing.Point(238, 191);
            this.roomTpText.Name = "roomTpText";
            this.roomTpText.Size = new System.Drawing.Size(165, 30);
            this.roomTpText.TabIndex = 8;
            this.roomTpText.Text = "房间温度：--℃";
            // 
            // nowPayText
            // 
            this.nowPayText.AutoSize = true;
            this.nowPayText.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.nowPayText.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.nowPayText.Location = new System.Drawing.Point(238, 232);
            this.nowPayText.Name = "nowPayText";
            this.nowPayText.Size = new System.Drawing.Size(180, 30);
            this.nowPayText.TabIndex = 9;
            this.nowPayText.Text = "当前费用：-.--元";
            // 
            // roomText
            // 
            this.roomText.AutoSize = true;
            this.roomText.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.roomText.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.roomText.Location = new System.Drawing.Point(3, 4);
            this.roomText.Name = "roomText";
            this.roomText.Size = new System.Drawing.Size(96, 25);
            this.roomText.TabIndex = 10;
            this.roomText.Text = "Room ---";
            // 
            // timeText
            // 
            this.timeText.AutoSize = true;
            this.timeText.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.timeText.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.timeText.Location = new System.Drawing.Point(191, 4);
            this.timeText.Name = "timeText";
            this.timeText.Size = new System.Drawing.Size(61, 25);
            this.timeText.TabIndex = 11;
            this.timeText.Text = "23:33";
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(141)))), ((int)(((byte)(166)))));
            this.ClientSize = new System.Drawing.Size(450, 550);
            this.ControlBox = false;
            this.Controls.Add(this.timeText);
            this.Controls.Add(this.roomText);
            this.Controls.Add(this.nowPayText);
            this.Controls.Add(this.roomTpText);
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
            this.mainPanel.PerformLayout();
            this.SpeedPanel.ResumeLayout(false);
            this.SpeedPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox mainIcon;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Label tpText;
        private System.Windows.Forms.Button ShutDownButton;
        private System.Windows.Forms.Label roomTpText;
        private System.Windows.Forms.Label nowPayText;
        private System.Windows.Forms.Label roomText;
        private System.Windows.Forms.Label timeText;
        private DMSkin.Controls.DM.DMButtonImage speedBtn;
        private DMSkin.Controls.DM.DMButtonImage switchBtn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DMSkin.Controls.DM.DMButtonImage tpUpBtn;
        private DMSkin.Controls.DM.DMButtonImage tpDownBtn;
        private System.Windows.Forms.Panel SpeedPanel;
        private DMSkin.Controls.DM.DMButtonImage lowSpeedBtn;
        private DMSkin.Controls.DM.DMButtonImage highSpeedBtn;
        private DMSkin.Controls.DM.DMButtonImage midSpeedBtn;
        private System.Windows.Forms.Label highText;
        private System.Windows.Forms.Label midText;
        private System.Windows.Forms.Label lowText;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
    }
}

