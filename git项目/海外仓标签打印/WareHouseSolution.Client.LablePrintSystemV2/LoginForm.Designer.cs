namespace WareHouseSolution.Client.LablePrintSystem
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.skinLabel1 = new CCWin.SkinControl.SkinLabel();
            this.userIdTextBox = new CCWin.SkinControl.SkinTextBox();
            this.skinLabel2 = new CCWin.SkinControl.SkinLabel();
            this.userPwdTextBox = new CCWin.SkinControl.SkinTextBox();
            this.loginBtn = new CCWin.SkinControl.SkinButton();
            this.SuspendLayout();
            // 
            // skinLabel1
            // 
            this.skinLabel1.AutoSize = true;
            this.skinLabel1.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel1.BorderColor = System.Drawing.Color.White;
            this.skinLabel1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel1.Location = new System.Drawing.Point(12, 43);
            this.skinLabel1.Name = "skinLabel1";
            this.skinLabel1.Size = new System.Drawing.Size(44, 17);
            this.skinLabel1.TabIndex = 4;
            this.skinLabel1.Text = "用户名";
            // 
            // userIdTextBox
            // 
            this.userIdTextBox.BackColor = System.Drawing.Color.Transparent;
            this.userIdTextBox.DownBack = null;
            this.userIdTextBox.Icon = null;
            this.userIdTextBox.IconIsButton = false;
            this.userIdTextBox.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.userIdTextBox.IsPasswordChat = '\0';
            this.userIdTextBox.IsSystemPasswordChar = false;
            this.userIdTextBox.Lines = new string[0];
            this.userIdTextBox.Location = new System.Drawing.Point(65, 39);
            this.userIdTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.userIdTextBox.MaxLength = 20;
            this.userIdTextBox.MinimumSize = new System.Drawing.Size(28, 28);
            this.userIdTextBox.MouseBack = null;
            this.userIdTextBox.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.userIdTextBox.Multiline = false;
            this.userIdTextBox.Name = "userIdTextBox";
            this.userIdTextBox.NormlBack = null;
            this.userIdTextBox.Padding = new System.Windows.Forms.Padding(5);
            this.userIdTextBox.ReadOnly = false;
            this.userIdTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.userIdTextBox.Size = new System.Drawing.Size(185, 28);
            // 
            // 
            // 
            this.userIdTextBox.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.userIdTextBox.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userIdTextBox.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.userIdTextBox.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.userIdTextBox.SkinTxt.MaxLength = 20;
            this.userIdTextBox.SkinTxt.Name = "BaseText";
            this.userIdTextBox.SkinTxt.Size = new System.Drawing.Size(175, 18);
            this.userIdTextBox.SkinTxt.TabIndex = 0;
            this.userIdTextBox.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.userIdTextBox.SkinTxt.WaterText = "";
            this.userIdTextBox.TabIndex = 0;
            this.userIdTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.userIdTextBox.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.userIdTextBox.WaterText = "";
            this.userIdTextBox.WordWrap = true;
            // 
            // skinLabel2
            // 
            this.skinLabel2.AutoSize = true;
            this.skinLabel2.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel2.BorderColor = System.Drawing.Color.White;
            this.skinLabel2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel2.Location = new System.Drawing.Point(12, 96);
            this.skinLabel2.Name = "skinLabel2";
            this.skinLabel2.Size = new System.Drawing.Size(32, 17);
            this.skinLabel2.TabIndex = 6;
            this.skinLabel2.Text = "密码";
            // 
            // userPwdTextBox
            // 
            this.userPwdTextBox.BackColor = System.Drawing.Color.Transparent;
            this.userPwdTextBox.DownBack = null;
            this.userPwdTextBox.Icon = null;
            this.userPwdTextBox.IconIsButton = false;
            this.userPwdTextBox.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.userPwdTextBox.IsPasswordChat = '●';
            this.userPwdTextBox.IsSystemPasswordChar = true;
            this.userPwdTextBox.Lines = new string[0];
            this.userPwdTextBox.Location = new System.Drawing.Point(65, 90);
            this.userPwdTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.userPwdTextBox.MaxLength = 32767;
            this.userPwdTextBox.MinimumSize = new System.Drawing.Size(28, 28);
            this.userPwdTextBox.MouseBack = null;
            this.userPwdTextBox.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.userPwdTextBox.Multiline = false;
            this.userPwdTextBox.Name = "userPwdTextBox";
            this.userPwdTextBox.NormlBack = null;
            this.userPwdTextBox.Padding = new System.Windows.Forms.Padding(5);
            this.userPwdTextBox.ReadOnly = false;
            this.userPwdTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.userPwdTextBox.Size = new System.Drawing.Size(185, 28);
            // 
            // 
            // 
            this.userPwdTextBox.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.userPwdTextBox.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userPwdTextBox.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.userPwdTextBox.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.userPwdTextBox.SkinTxt.Name = "BaseText";
            this.userPwdTextBox.SkinTxt.PasswordChar = '●';
            this.userPwdTextBox.SkinTxt.Size = new System.Drawing.Size(175, 18);
            this.userPwdTextBox.SkinTxt.TabIndex = 0;
            this.userPwdTextBox.SkinTxt.UseSystemPasswordChar = true;
            this.userPwdTextBox.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.userPwdTextBox.SkinTxt.WaterText = "";
            this.userPwdTextBox.SkinTxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.userPwdTextBox_SkinTxt_KeyDown);
            this.userPwdTextBox.TabIndex = 7;
            this.userPwdTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.userPwdTextBox.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.userPwdTextBox.WaterText = "";
            this.userPwdTextBox.WordWrap = true;
            // 
            // loginBtn
            // 
            this.loginBtn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.loginBtn.BaseColor = System.Drawing.SystemColors.ButtonFace;
            this.loginBtn.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.loginBtn.DownBack = null;
            this.loginBtn.Location = new System.Drawing.Point(104, 144);
            this.loginBtn.MouseBack = null;
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.NormlBack = null;
            this.loginBtn.Size = new System.Drawing.Size(75, 23);
            this.loginBtn.TabIndex = 3;
            this.loginBtn.Text = "登陆";
            this.loginBtn.UseVisualStyleBackColor = false;
            this.loginBtn.Click += new System.EventHandler(this.loginBtn_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(268, 193);
            this.Controls.Add(this.loginBtn);
            this.Controls.Add(this.userPwdTextBox);
            this.Controls.Add(this.skinLabel2);
            this.Controls.Add(this.userIdTextBox);
            this.Controls.Add(this.skinLabel1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(284, 232);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(284, 232);
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "海外仓标签打印系统";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Login_FormClosing);
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCWin.SkinControl.SkinLabel skinLabel1;
        private CCWin.SkinControl.SkinTextBox userIdTextBox;
        private CCWin.SkinControl.SkinLabel skinLabel2;
        private CCWin.SkinControl.SkinTextBox userPwdTextBox;
        private CCWin.SkinControl.SkinButton loginBtn;
    }
}