namespace AirConditionerSystem
{
    partial class MessageBox
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
            this.mainPanel = new System.Windows.Forms.Panel();
            this.TextBox = new System.Windows.Forms.Label();
            this.ConfirmButton = new System.Windows.Forms.Button();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(221)))), ((int)(((byte)(232)))));
            this.mainPanel.Controls.Add(this.TextBox);
            this.mainPanel.Controls.Add(this.ConfirmButton);
            this.mainPanel.Location = new System.Drawing.Point(0, 30);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(300, 120);
            this.mainPanel.TabIndex = 1;
            // 
            // TextBox
            // 
            this.TextBox.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.TextBox.Location = new System.Drawing.Point(0, 27);
            this.TextBox.Name = "TextBox";
            this.TextBox.Size = new System.Drawing.Size(300, 23);
            this.TextBox.TabIndex = 8;
            this.TextBox.Text = "label1";
            this.TextBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ConfirmButton
            // 
            this.ConfirmButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.ConfirmButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(141)))), ((int)(((byte)(166)))));
            this.ConfirmButton.FlatAppearance.BorderSize = 2;
            this.ConfirmButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.ConfirmButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ConfirmButton.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ConfirmButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ConfirmButton.Location = new System.Drawing.Point(113, 71);
            this.ConfirmButton.Name = "ConfirmButton";
            this.ConfirmButton.Size = new System.Drawing.Size(73, 26);
            this.ConfirmButton.TabIndex = 7;
            this.ConfirmButton.TabStop = false;
            this.ConfirmButton.Text = "确定";
            this.ConfirmButton.UseVisualStyleBackColor = false;
            this.ConfirmButton.Click += new System.EventHandler(this.ConfirmButton_Click);
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.BackColor = System.Drawing.Color.Transparent;
            this.TitleLabel.Font = new System.Drawing.Font("黑体", 12F);
            this.TitleLabel.ForeColor = System.Drawing.Color.White;
            this.TitleLabel.Location = new System.Drawing.Point(7, 7);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(104, 16);
            this.TitleLabel.TabIndex = 3;
            this.TitleLabel.Text = "空调管理系统";
            // 
            // MessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(141)))), ((int)(((byte)(166)))));
            this.ClientSize = new System.Drawing.Size(300, 150);
            this.Controls.Add(this.TitleLabel);
            this.Controls.Add(this.mainPanel);
            this.DM_howBorder = false;
            this.DM_ShadowWidth = 5;
            this.Name = "MessageBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MessageBox";
            this.Load += new System.EventHandler(this.MessageBox_Load);
            this.mainPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Label TextBox;
        private System.Windows.Forms.Button ConfirmButton;
        public System.Windows.Forms.Label TitleLabel;
    }
}