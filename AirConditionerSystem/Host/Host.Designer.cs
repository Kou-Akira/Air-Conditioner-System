namespace Host
{
    partial class Host
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Host));
            this.timeText = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ShutDownButton = new System.Windows.Forms.Button();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lowText = new System.Windows.Forms.Label();
            this.registBtn = new DMSkin.Controls.DM.DMButtonImage();
            this.logoutBtn = new DMSkin.Controls.DM.DMButtonImage();
            this.logBtn = new DMSkin.Controls.DM.DMButtonImage();
            this.payBtn = new DMSkin.Controls.DM.DMButtonImage();
            this.watchBtn = new DMSkin.Controls.DM.DMButtonImage();
            this.coldBtn = new DMSkin.Controls.DM.DMButtonImage();
            this.heatBtn = new DMSkin.Controls.DM.DMButtonImage();
            this.switchBtn = new DMSkin.Controls.DM.DMButtonImage();
            this.workModeText = new System.Windows.Forms.Label();
            this.connectCountText = new System.Windows.Forms.Label();
            this.mainIcon = new System.Windows.Forms.PictureBox();
            this.settingBtn = new System.Windows.Forms.Button();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // timeText
            // 
            this.timeText.AutoSize = true;
            this.timeText.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.timeText.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.timeText.Location = new System.Drawing.Point(218, 2);
            this.timeText.Name = "timeText";
            this.timeText.Size = new System.Drawing.Size(61, 25);
            this.timeText.TabIndex = 14;
            this.timeText.Text = "23:33";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(7, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 24);
            this.label3.TabIndex = 13;
            this.label3.Text = "中央机";
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
            this.ShutDownButton.Location = new System.Drawing.Point(470, 0);
            this.ShutDownButton.Name = "ShutDownButton";
            this.ShutDownButton.Size = new System.Drawing.Size(30, 30);
            this.ShutDownButton.TabIndex = 12;
            this.ShutDownButton.TabStop = false;
            this.ShutDownButton.UseVisualStyleBackColor = false;
            this.ShutDownButton.Click += new System.EventHandler(this.ShutDownButton_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(221)))), ((int)(((byte)(232)))));
            this.mainPanel.Controls.Add(this.label8);
            this.mainPanel.Controls.Add(this.label7);
            this.mainPanel.Controls.Add(this.label6);
            this.mainPanel.Controls.Add(this.label5);
            this.mainPanel.Controls.Add(this.label4);
            this.mainPanel.Controls.Add(this.label2);
            this.mainPanel.Controls.Add(this.label1);
            this.mainPanel.Controls.Add(this.lowText);
            this.mainPanel.Controls.Add(this.registBtn);
            this.mainPanel.Controls.Add(this.logoutBtn);
            this.mainPanel.Controls.Add(this.logBtn);
            this.mainPanel.Controls.Add(this.payBtn);
            this.mainPanel.Controls.Add(this.watchBtn);
            this.mainPanel.Controls.Add(this.coldBtn);
            this.mainPanel.Controls.Add(this.heatBtn);
            this.mainPanel.Controls.Add(this.switchBtn);
            this.mainPanel.Location = new System.Drawing.Point(0, 300);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(500, 200);
            this.mainPanel.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("黑体", 10F);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(111)))), ((int)(((byte)(138)))));
            this.label8.Location = new System.Drawing.Point(379, 165);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 14);
            this.label8.TabIndex = 19;
            this.label8.Text = "从机信息";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("黑体", 10F);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(111)))), ((int)(((byte)(138)))));
            this.label7.Location = new System.Drawing.Point(284, 165);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 14);
            this.label7.TabIndex = 18;
            this.label7.Text = "报表";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("黑体", 10F);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(111)))), ((int)(((byte)(138)))));
            this.label6.Location = new System.Drawing.Point(174, 165);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 14);
            this.label6.TabIndex = 17;
            this.label6.Text = "注销";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("黑体", 10F);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(111)))), ((int)(((byte)(138)))));
            this.label5.Location = new System.Drawing.Point(65, 165);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 14);
            this.label5.TabIndex = 16;
            this.label5.Text = "登记";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("黑体", 10F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(111)))), ((int)(((byte)(138)))));
            this.label4.Location = new System.Drawing.Point(393, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 14);
            this.label4.TabIndex = 15;
            this.label4.Text = "收款";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("黑体", 10F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(111)))), ((int)(((byte)(138)))));
            this.label2.Location = new System.Drawing.Point(283, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 14);
            this.label2.TabIndex = 14;
            this.label2.Text = "制热";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("黑体", 10F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(111)))), ((int)(((byte)(138)))));
            this.label1.Location = new System.Drawing.Point(174, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 14);
            this.label1.TabIndex = 13;
            this.label1.Text = "制冷";
            // 
            // lowText
            // 
            this.lowText.AutoSize = true;
            this.lowText.Font = new System.Drawing.Font("黑体", 10F);
            this.lowText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(111)))), ((int)(((byte)(138)))));
            this.lowText.Location = new System.Drawing.Point(65, 81);
            this.lowText.Name = "lowText";
            this.lowText.Size = new System.Drawing.Size(35, 14);
            this.lowText.TabIndex = 12;
            this.lowText.Text = "开关";
            // 
            // registBtn
            // 
            this.registBtn.BackColor = System.Drawing.Color.Transparent;
            this.registBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("registBtn.BackgroundImage")));
            this.registBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.registBtn.DM_DownImage = null;
            this.registBtn.DM_HoverImage = null;
            this.registBtn.DM_Mode = false;
            this.registBtn.DM_NolImage = ((System.Drawing.Image)(resources.GetObject("registBtn.DM_NolImage")));
            this.registBtn.Location = new System.Drawing.Point(57, 112);
            this.registBtn.Name = "registBtn";
            this.registBtn.Size = new System.Drawing.Size(50, 50);
            this.registBtn.State = DMSkin.Controls.DM.DMButtonImage.BtnState.Nol;
            this.registBtn.TabIndex = 8;
            // 
            // logoutBtn
            // 
            this.logoutBtn.BackColor = System.Drawing.Color.Transparent;
            this.logoutBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("logoutBtn.BackgroundImage")));
            this.logoutBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.logoutBtn.DM_DownImage = null;
            this.logoutBtn.DM_HoverImage = null;
            this.logoutBtn.DM_Mode = false;
            this.logoutBtn.DM_NolImage = ((System.Drawing.Image)(resources.GetObject("logoutBtn.DM_NolImage")));
            this.logoutBtn.Location = new System.Drawing.Point(169, 112);
            this.logoutBtn.Name = "logoutBtn";
            this.logoutBtn.Size = new System.Drawing.Size(50, 50);
            this.logoutBtn.State = DMSkin.Controls.DM.DMButtonImage.BtnState.Nol;
            this.logoutBtn.TabIndex = 7;
            // 
            // logBtn
            // 
            this.logBtn.BackColor = System.Drawing.Color.Transparent;
            this.logBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("logBtn.BackgroundImage")));
            this.logBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.logBtn.DM_DownImage = null;
            this.logBtn.DM_HoverImage = null;
            this.logBtn.DM_Mode = false;
            this.logBtn.DM_NolImage = ((System.Drawing.Image)(resources.GetObject("logBtn.DM_NolImage")));
            this.logBtn.Location = new System.Drawing.Point(277, 112);
            this.logBtn.Name = "logBtn";
            this.logBtn.Size = new System.Drawing.Size(50, 50);
            this.logBtn.State = DMSkin.Controls.DM.DMButtonImage.BtnState.Nol;
            this.logBtn.TabIndex = 6;
            // 
            // payBtn
            // 
            this.payBtn.BackColor = System.Drawing.Color.Transparent;
            this.payBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("payBtn.BackgroundImage")));
            this.payBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.payBtn.DM_DownImage = null;
            this.payBtn.DM_HoverImage = null;
            this.payBtn.DM_Mode = false;
            this.payBtn.DM_NolImage = ((System.Drawing.Image)(resources.GetObject("payBtn.DM_NolImage")));
            this.payBtn.Location = new System.Drawing.Point(385, 25);
            this.payBtn.Name = "payBtn";
            this.payBtn.Size = new System.Drawing.Size(50, 50);
            this.payBtn.State = DMSkin.Controls.DM.DMButtonImage.BtnState.Nol;
            this.payBtn.TabIndex = 5;
            // 
            // watchBtn
            // 
            this.watchBtn.BackColor = System.Drawing.Color.Transparent;
            this.watchBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("watchBtn.BackgroundImage")));
            this.watchBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.watchBtn.DM_DownImage = null;
            this.watchBtn.DM_HoverImage = null;
            this.watchBtn.DM_Mode = false;
            this.watchBtn.DM_NolImage = ((System.Drawing.Image)(resources.GetObject("watchBtn.DM_NolImage")));
            this.watchBtn.Location = new System.Drawing.Point(384, 112);
            this.watchBtn.Name = "watchBtn";
            this.watchBtn.Size = new System.Drawing.Size(50, 50);
            this.watchBtn.State = DMSkin.Controls.DM.DMButtonImage.BtnState.Nol;
            this.watchBtn.TabIndex = 4;
            this.watchBtn.Click += new System.EventHandler(this.watchBtn_Click);
            // 
            // coldBtn
            // 
            this.coldBtn.BackColor = System.Drawing.Color.Transparent;
            this.coldBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("coldBtn.BackgroundImage")));
            this.coldBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.coldBtn.DM_DownImage = null;
            this.coldBtn.DM_HoverImage = null;
            this.coldBtn.DM_Mode = false;
            this.coldBtn.DM_NolImage = ((System.Drawing.Image)(resources.GetObject("coldBtn.DM_NolImage")));
            this.coldBtn.Location = new System.Drawing.Point(166, 25);
            this.coldBtn.Name = "coldBtn";
            this.coldBtn.Size = new System.Drawing.Size(50, 50);
            this.coldBtn.State = DMSkin.Controls.DM.DMButtonImage.BtnState.Nol;
            this.coldBtn.TabIndex = 3;
            // 
            // heatBtn
            // 
            this.heatBtn.BackColor = System.Drawing.Color.Transparent;
            this.heatBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("heatBtn.BackgroundImage")));
            this.heatBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.heatBtn.DM_DownImage = null;
            this.heatBtn.DM_HoverImage = null;
            this.heatBtn.DM_Mode = false;
            this.heatBtn.DM_NolImage = ((System.Drawing.Image)(resources.GetObject("heatBtn.DM_NolImage")));
            this.heatBtn.Location = new System.Drawing.Point(275, 25);
            this.heatBtn.Name = "heatBtn";
            this.heatBtn.Size = new System.Drawing.Size(50, 50);
            this.heatBtn.State = DMSkin.Controls.DM.DMButtonImage.BtnState.Nol;
            this.heatBtn.TabIndex = 2;
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
            this.switchBtn.Location = new System.Drawing.Point(57, 25);
            this.switchBtn.Name = "switchBtn";
            this.switchBtn.Size = new System.Drawing.Size(50, 50);
            this.switchBtn.State = DMSkin.Controls.DM.DMButtonImage.BtnState.Nol;
            this.switchBtn.TabIndex = 1;
            this.switchBtn.Click += new System.EventHandler(this.switchBtn_Click);
            // 
            // workModeText
            // 
            this.workModeText.AutoSize = true;
            this.workModeText.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.workModeText.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.workModeText.Location = new System.Drawing.Point(284, 163);
            this.workModeText.Name = "workModeText";
            this.workModeText.Size = new System.Drawing.Size(167, 30);
            this.workModeText.TabIndex = 19;
            this.workModeText.Text = "工作模式：制冷";
            // 
            // connectCountText
            // 
            this.connectCountText.AutoSize = true;
            this.connectCountText.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.connectCountText.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.connectCountText.Location = new System.Drawing.Point(284, 122);
            this.connectCountText.Name = "connectCountText";
            this.connectCountText.Size = new System.Drawing.Size(136, 30);
            this.connectCountText.TabIndex = 18;
            this.connectCountText.Text = "连接数量：2";
            // 
            // mainIcon
            // 
            this.mainIcon.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("mainIcon.BackgroundImage")));
            this.mainIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mainIcon.Location = new System.Drawing.Point(45, 81);
            this.mainIcon.Name = "mainIcon";
            this.mainIcon.Size = new System.Drawing.Size(184, 156);
            this.mainIcon.TabIndex = 16;
            this.mainIcon.TabStop = false;
            // 
            // settingBtn
            // 
            this.settingBtn.BackColor = System.Drawing.Color.Transparent;
            this.settingBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("settingBtn.BackgroundImage")));
            this.settingBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.settingBtn.FlatAppearance.BorderSize = 0;
            this.settingBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(42)))), ((int)(((byte)(21)))));
            this.settingBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(65)))), ((int)(((byte)(39)))));
            this.settingBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.settingBtn.Location = new System.Drawing.Point(74, 7);
            this.settingBtn.Name = "settingBtn";
            this.settingBtn.Size = new System.Drawing.Size(20, 20);
            this.settingBtn.TabIndex = 20;
            this.settingBtn.TabStop = false;
            this.settingBtn.UseVisualStyleBackColor = false;
            this.settingBtn.Click += new System.EventHandler(this.settingBtn_Click);
            // 
            // Host
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(141)))), ((int)(((byte)(166)))));
            this.ClientSize = new System.Drawing.Size(500, 500);
            this.Controls.Add(this.settingBtn);
            this.Controls.Add(this.workModeText);
            this.Controls.Add(this.connectCountText);
            this.Controls.Add(this.mainIcon);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.timeText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ShutDownButton);
            this.DM_CanResize = false;
            this.DM_howBorder = false;
            this.DM_ShadowWidth = 5;
            this.Name = "Host";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label timeText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button ShutDownButton;
        private System.Windows.Forms.Panel mainPanel;
        private DMSkin.Controls.DM.DMButtonImage switchBtn;
        private DMSkin.Controls.DM.DMButtonImage registBtn;
        private DMSkin.Controls.DM.DMButtonImage logoutBtn;
        private DMSkin.Controls.DM.DMButtonImage logBtn;
        private DMSkin.Controls.DM.DMButtonImage payBtn;
        private DMSkin.Controls.DM.DMButtonImage watchBtn;
        private DMSkin.Controls.DM.DMButtonImage coldBtn;
        private DMSkin.Controls.DM.DMButtonImage heatBtn;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lowText;
        private System.Windows.Forms.Label workModeText;
        private System.Windows.Forms.Label connectCountText;
        private System.Windows.Forms.PictureBox mainIcon;
        private System.Windows.Forms.Button settingBtn;
    }
}

