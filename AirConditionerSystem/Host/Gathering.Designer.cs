namespace Host
{
    partial class Gathering
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Gathering));
            this.mainPanel = new System.Windows.Forms.Panel();
            this.IDTextBox = new System.Windows.Forms.TextBox();
            this.LoginButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.IDBg = new System.Windows.Forms.PictureBox();
            this.UserBg = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ShutDownButton = new System.Windows.Forms.Button();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IDBg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserBg)).BeginInit();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(221)))), ((int)(((byte)(232)))));
            this.mainPanel.Controls.Add(this.IDTextBox);
            this.mainPanel.Controls.Add(this.LoginButton);
            this.mainPanel.Controls.Add(this.textBox1);
            this.mainPanel.Controls.Add(this.IDBg);
            this.mainPanel.Controls.Add(this.UserBg);
            this.mainPanel.Controls.Add(this.label2);
            this.mainPanel.Controls.Add(this.label1);
            this.mainPanel.Location = new System.Drawing.Point(0, 35);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(422, 236);
            this.mainPanel.TabIndex = 18;
            // 
            // IDTextBox
            // 
            this.IDTextBox.BackColor = System.Drawing.Color.White;
            this.IDTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.IDTextBox.Font = new System.Drawing.Font("黑体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.IDTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.IDTextBox.Location = new System.Drawing.Point(174, 105);
            this.IDTextBox.Name = "IDTextBox";
            this.IDTextBox.Size = new System.Drawing.Size(209, 22);
            this.IDTextBox.TabIndex = 40;
            // 
            // LoginButton
            // 
            this.LoginButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(141)))), ((int)(((byte)(166)))));
            this.LoginButton.FlatAppearance.BorderSize = 2;
            this.LoginButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoginButton.Font = new System.Drawing.Font("等线", 12F, System.Drawing.FontStyle.Bold);
            this.LoginButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(141)))), ((int)(((byte)(166)))));
            this.LoginButton.Location = new System.Drawing.Point(33, 169);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(356, 36);
            this.LoginButton.TabIndex = 41;
            this.LoginButton.Text = "确认收费";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("黑体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.textBox1.Location = new System.Drawing.Point(174, 35);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(209, 22);
            this.textBox1.TabIndex = 0;
            // 
            // IDBg
            // 
            this.IDBg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(221)))), ((int)(((byte)(232)))));
            this.IDBg.Image = ((System.Drawing.Image)(resources.GetObject("IDBg.Image")));
            this.IDBg.Location = new System.Drawing.Point(137, 98);
            this.IDBg.Name = "IDBg";
            this.IDBg.Size = new System.Drawing.Size(258, 42);
            this.IDBg.TabIndex = 39;
            this.IDBg.TabStop = false;
            // 
            // UserBg
            // 
            this.UserBg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(221)))), ((int)(((byte)(232)))));
            this.UserBg.Enabled = false;
            this.UserBg.Image = ((System.Drawing.Image)(resources.GetObject("UserBg.Image")));
            this.UserBg.Location = new System.Drawing.Point(138, 27);
            this.UserBg.Name = "UserBg";
            this.UserBg.Size = new System.Drawing.Size(258, 42);
            this.UserBg.TabIndex = 38;
            this.UserBg.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(141)))), ((int)(((byte)(166)))));
            this.label2.Location = new System.Drawing.Point(29, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 27);
            this.label2.TabIndex = 2;
            this.label2.Text = "收费金额:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(141)))), ((int)(((byte)(166)))));
            this.label1.Location = new System.Drawing.Point(34, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "房 间 号 :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(2, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 25);
            this.label3.TabIndex = 19;
            this.label3.Text = "房间收费";
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
            this.ShutDownButton.Location = new System.Drawing.Point(389, 2);
            this.ShutDownButton.Name = "ShutDownButton";
            this.ShutDownButton.Size = new System.Drawing.Size(30, 30);
            this.ShutDownButton.TabIndex = 20;
            this.ShutDownButton.TabStop = false;
            this.ShutDownButton.UseVisualStyleBackColor = false;
            this.ShutDownButton.Click += new System.EventHandler(this.ShutDownButton_Click);
            // 
            // Gathering
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(141)))), ((int)(((byte)(166)))));
            this.ClientSize = new System.Drawing.Size(422, 271);
            this.Controls.Add(this.ShutDownButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.mainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Gathering";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Gathering";
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IDBg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserBg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox IDTextBox;
        private System.Windows.Forms.PictureBox IDBg;
        private System.Windows.Forms.PictureBox UserBg;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button ShutDownButton;
    }
}