namespace WareHouseSolution.Client.LablePrintSystem
{
    partial class LoginFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginFrm));
            this.skinPanel1 = new CCWin.SkinControl.SkinPanel();
            this.skinLabel1 = new CCWin.SkinControl.SkinLabel();
            this.loginBtn = new CCWin.SkinControl.SkinButton();
            this.userPwdTextBox = new CCWin.SkinControl.SkinWaterTextBox();
            this.userIdTextBox = new CCWin.SkinControl.SkinWaterTextBox();
            this.skinLabel3 = new CCWin.SkinControl.SkinLabel();
            this.skinLabel2 = new CCWin.SkinControl.SkinLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.skinPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // skinPanel1
            // 
            this.skinPanel1.BackColor = System.Drawing.Color.SteelBlue;
            this.skinPanel1.Controls.Add(this.label1);
            this.skinPanel1.Controls.Add(this.skinLabel1);
            this.skinPanel1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinPanel1.DownBack = null;
            this.skinPanel1.Location = new System.Drawing.Point(0, 0);
            this.skinPanel1.MouseBack = null;
            this.skinPanel1.Name = "skinPanel1";
            this.skinPanel1.NormlBack = null;
            this.skinPanel1.Size = new System.Drawing.Size(412, 60);
            this.skinPanel1.TabIndex = 30;
            // 
            // skinLabel1
            // 
            this.skinLabel1.AutoSize = true;
            this.skinLabel1.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel1.BorderColor = System.Drawing.Color.White;
            this.skinLabel1.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel1.Location = new System.Drawing.Point(148, 13);
            this.skinLabel1.Name = "skinLabel1";
            this.skinLabel1.Size = new System.Drawing.Size(92, 27);
            this.skinLabel1.TabIndex = 0;
            this.skinLabel1.Text = "登录界面";
            // 
            // loginBtn
            // 
            this.loginBtn.BackColor = System.Drawing.Color.White;
            this.loginBtn.BaseColor = System.Drawing.Color.SteelBlue;
            this.loginBtn.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.loginBtn.DownBack = null;
            this.loginBtn.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.loginBtn.ForeColor = System.Drawing.Color.White;
            this.loginBtn.GlowColor = System.Drawing.Color.SteelBlue;
            this.loginBtn.IsDrawBorder = false;
            this.loginBtn.IsDrawGlass = false;
            this.loginBtn.Location = new System.Drawing.Point(154, 220);
            this.loginBtn.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.loginBtn.MouseBack = null;
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.NormlBack = null;
            this.loginBtn.Radius = 20;
            this.loginBtn.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.loginBtn.Size = new System.Drawing.Size(86, 32);
            this.loginBtn.TabIndex = 35;
            this.loginBtn.Text = "登录";
            this.loginBtn.UseVisualStyleBackColor = false;
            this.loginBtn.Click += new System.EventHandler(this.loginBtnClick);
            // 
            // userPwdTextBox
            // 
            this.userPwdTextBox.Location = new System.Drawing.Point(153, 165);
            this.userPwdTextBox.Name = "userPwdTextBox";
            this.userPwdTextBox.PasswordChar = '*';
            this.userPwdTextBox.Size = new System.Drawing.Size(169, 21);
            this.userPwdTextBox.TabIndex = 34;
            this.userPwdTextBox.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.userPwdTextBox.WaterText = "";
            // 
            // userIdTextBox
            // 
            this.userIdTextBox.Location = new System.Drawing.Point(153, 118);
            this.userIdTextBox.Name = "userIdTextBox";
            this.userIdTextBox.Size = new System.Drawing.Size(169, 21);
            this.userIdTextBox.TabIndex = 33;
            this.userIdTextBox.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.userIdTextBox.WaterText = "";
            // 
            // skinLabel3
            // 
            this.skinLabel3.AutoSize = true;
            this.skinLabel3.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel3.BorderColor = System.Drawing.Color.White;
            this.skinLabel3.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel3.Location = new System.Drawing.Point(78, 165);
            this.skinLabel3.Name = "skinLabel3";
            this.skinLabel3.Size = new System.Drawing.Size(47, 20);
            this.skinLabel3.TabIndex = 32;
            this.skinLabel3.Text = "密  码";
            // 
            // skinLabel2
            // 
            this.skinLabel2.AutoSize = true;
            this.skinLabel2.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel2.BorderColor = System.Drawing.Color.White;
            this.skinLabel2.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel2.Location = new System.Drawing.Point(78, 118);
            this.skinLabel2.Name = "skinLabel2";
            this.skinLabel2.Size = new System.Drawing.Size(54, 20);
            this.skinLabel2.TabIndex = 31;
            this.skinLabel2.Text = "用户名";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.Location = new System.Drawing.Point(384, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "  ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // LoginFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(411, 268);
            this.Controls.Add(this.skinPanel1);
            this.Controls.Add(this.loginBtn);
            this.Controls.Add(this.userPwdTextBox);
            this.Controls.Add(this.userIdTextBox);
            this.Controls.Add(this.skinLabel3);
            this.Controls.Add(this.skinLabel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LoginFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoginFrm";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LoginFrm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.LoginFrm_MouseMOve);
            this.skinPanel1.ResumeLayout(false);
            this.skinPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCWin.SkinControl.SkinPanel skinPanel1;
        private System.Windows.Forms.Label label1;
        private CCWin.SkinControl.SkinLabel skinLabel1;
        private CCWin.SkinControl.SkinButton loginBtn;
        private CCWin.SkinControl.SkinWaterTextBox userPwdTextBox;
        private CCWin.SkinControl.SkinWaterTextBox userIdTextBox;
        private CCWin.SkinControl.SkinLabel skinLabel3;
        private CCWin.SkinControl.SkinLabel skinLabel2;
    }
}