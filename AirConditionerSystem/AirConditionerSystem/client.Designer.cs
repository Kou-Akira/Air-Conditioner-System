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
            this.swithBtn = new DMSkin.Controls.DM.DMButtonImage();
            this.speedBtn = new DMSkin.Controls.DM.DMButtonImage();
            this.tpBtn = new DMSkin.Controls.DM.DMButtonImage();
            this.coldBtn = new DMSkin.Controls.DM.DMButtonImage();
            this.heatBtn = new DMSkin.Controls.DM.DMButtonImage();
            this.tpText = new System.Windows.Forms.Label();
            this.ShutDownButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.mainIcon)).BeginInit();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainIcon
            // 
            this.mainIcon.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("mainIcon.BackgroundImage")));
            this.mainIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mainIcon.Location = new System.Drawing.Point(54, 126);
            this.mainIcon.Name = "mainIcon";
            this.mainIcon.Size = new System.Drawing.Size(210, 189);
            this.mainIcon.TabIndex = 1;
            this.mainIcon.TabStop = false;
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(221)))), ((int)(((byte)(232)))));
            this.mainPanel.Controls.Add(this.label5);
            this.mainPanel.Controls.Add(this.swithBtn);
            this.mainPanel.Controls.Add(this.speedBtn);
            this.mainPanel.Controls.Add(this.tpBtn);
            this.mainPanel.Controls.Add(this.coldBtn);
            this.mainPanel.Controls.Add(this.heatBtn);
            this.mainPanel.Location = new System.Drawing.Point(0, 450);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(550, 300);
            this.mainPanel.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(111)))), ((int)(((byte)(138)))));
            this.label5.Location = new System.Drawing.Point(221, 207);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 30);
            this.label5.TabIndex = 12;
            this.label5.Text = "Turn On";
            // 
            // swithBtn
            // 
            this.swithBtn.BackColor = System.Drawing.Color.Transparent;
            this.swithBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("swithBtn.BackgroundImage")));
            this.swithBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.swithBtn.DM_DownImage = null;
            this.swithBtn.DM_HoverImage = null;
            this.swithBtn.DM_Mode = false;
            this.swithBtn.DM_NolImage = ((System.Drawing.Image)(resources.GetObject("swithBtn.DM_NolImage")));
            this.swithBtn.Location = new System.Drawing.Point(114, 190);
            this.swithBtn.Name = "swithBtn";
            this.swithBtn.Size = new System.Drawing.Size(316, 65);
            this.swithBtn.State = DMSkin.Controls.DM.DMButtonImage.BtnState.Nol;
            this.swithBtn.TabIndex = 4;
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
            this.speedBtn.Location = new System.Drawing.Point(424, 33);
            this.speedBtn.Name = "speedBtn";
            this.speedBtn.Size = new System.Drawing.Size(80, 80);
            this.speedBtn.State = DMSkin.Controls.DM.DMButtonImage.BtnState.Nol;
            this.speedBtn.TabIndex = 3;
            // 
            // tpBtn
            // 
            this.tpBtn.BackColor = System.Drawing.Color.Transparent;
            this.tpBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tpBtn.BackgroundImage")));
            this.tpBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.tpBtn.DM_DownImage = null;
            this.tpBtn.DM_HoverImage = ((System.Drawing.Image)(resources.GetObject("tpBtn.DM_HoverImage")));
            this.tpBtn.DM_Mode = false;
            this.tpBtn.DM_NolImage = ((System.Drawing.Image)(resources.GetObject("tpBtn.DM_NolImage")));
            this.tpBtn.Location = new System.Drawing.Point(298, 33);
            this.tpBtn.Name = "tpBtn";
            this.tpBtn.Size = new System.Drawing.Size(80, 80);
            this.tpBtn.State = DMSkin.Controls.DM.DMButtonImage.BtnState.Nol;
            this.tpBtn.TabIndex = 2;
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
            this.coldBtn.Location = new System.Drawing.Point(46, 33);
            this.coldBtn.Name = "coldBtn";
            this.coldBtn.Size = new System.Drawing.Size(80, 80);
            this.coldBtn.State = DMSkin.Controls.DM.DMButtonImage.BtnState.Nol;
            this.coldBtn.TabIndex = 1;
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
            this.heatBtn.Location = new System.Drawing.Point(172, 33);
            this.heatBtn.Name = "heatBtn";
            this.heatBtn.Size = new System.Drawing.Size(80, 80);
            this.heatBtn.State = DMSkin.Controls.DM.DMButtonImage.BtnState.Nol;
            this.heatBtn.TabIndex = 0;
            // 
            // tpText
            // 
            this.tpText.AutoSize = true;
            this.tpText.Font = new System.Drawing.Font("微软雅黑", 46F);
            this.tpText.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tpText.Location = new System.Drawing.Point(322, 130);
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
            this.ShutDownButton.Location = new System.Drawing.Point(515, 0);
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
            this.label1.Location = new System.Drawing.Point(320, 220);
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
            this.label2.Location = new System.Drawing.Point(320, 261);
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
            this.label3.Location = new System.Drawing.Point(7, 4);
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
            this.label4.Location = new System.Drawing.Point(250, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 25);
            this.label4.TabIndex = 11;
            this.label4.Text = "23:33";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(141)))), ((int)(((byte)(166)))));
            this.ClientSize = new System.Drawing.Size(550, 750);
            this.ControlBox = false;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ShutDownButton);
            this.Controls.Add(this.tpText);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.mainIcon);
            this.DM_howBorder = false;
            this.Name = "Client";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Client_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mainIcon)).EndInit();
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
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
        private DMSkin.Controls.DM.DMButtonImage swithBtn;
        private DMSkin.Controls.DM.DMButtonImage speedBtn;
        private DMSkin.Controls.DM.DMButtonImage tpBtn;
        private DMSkin.Controls.DM.DMButtonImage coldBtn;
        private DMSkin.Controls.DM.DMButtonImage heatBtn;
        private System.Windows.Forms.Label label5;
    }
}

