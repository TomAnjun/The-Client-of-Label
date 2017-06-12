namespace WareHouseSolution.Client.LablePrintSystem.Controls
{
    partial class SettingControl
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.saveButton = new CCWin.SkinControl.SkinButton();
            this.UpdateButton = new CCWin.SkinControl.SkinButton();
            this.timeoutTextBox = new CCWin.SkinControl.SkinTextBox();
            this.updateUrlTextBox = new CCWin.SkinControl.SkinTextBox();
            this.hostTextBox = new CCWin.SkinControl.SkinTextBox();
            this.portTextBox = new CCWin.SkinControl.SkinTextBox();
            this.skinLabel6 = new CCWin.SkinControl.SkinLabel();
            this.skinLabel1 = new CCWin.SkinControl.SkinLabel();
            this.skinLabel2 = new CCWin.SkinControl.SkinLabel();
            this.skinLabel3 = new CCWin.SkinControl.SkinLabel();
            this.SuspendLayout();
            // 
            // saveButton
            // 
            this.saveButton.BackColor = System.Drawing.Color.White;
            this.saveButton.BaseColor = System.Drawing.Color.SteelBlue;
            this.saveButton.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.saveButton.DownBack = null;
            this.saveButton.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.saveButton.ForeColor = System.Drawing.Color.White;
            this.saveButton.GlowColor = System.Drawing.Color.SteelBlue;
            this.saveButton.IsDrawBorder = false;
            this.saveButton.IsDrawGlass = false;
            this.saveButton.Location = new System.Drawing.Point(310, 185);
            this.saveButton.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.saveButton.MouseBack = null;
            this.saveButton.Name = "saveButton";
            this.saveButton.NormlBack = null;
            this.saveButton.Radius = 20;
            this.saveButton.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.saveButton.Size = new System.Drawing.Size(94, 32);
            this.saveButton.TabIndex = 15;
            this.saveButton.Text = "保存";
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // UpdateButton
            // 
            this.UpdateButton.BackColor = System.Drawing.Color.White;
            this.UpdateButton.BaseColor = System.Drawing.Color.SteelBlue;
            this.UpdateButton.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.UpdateButton.DownBack = null;
            this.UpdateButton.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.UpdateButton.ForeColor = System.Drawing.Color.White;
            this.UpdateButton.GlowColor = System.Drawing.Color.SteelBlue;
            this.UpdateButton.IsDrawBorder = false;
            this.UpdateButton.IsDrawGlass = false;
            this.UpdateButton.Location = new System.Drawing.Point(188, 185);
            this.UpdateButton.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.UpdateButton.MouseBack = null;
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.NormlBack = null;
            this.UpdateButton.Radius = 20;
            this.UpdateButton.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.UpdateButton.Size = new System.Drawing.Size(94, 32);
            this.UpdateButton.TabIndex = 16;
            this.UpdateButton.Text = "更新";
            this.UpdateButton.UseVisualStyleBackColor = false;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // timeoutTextBox
            // 
            this.timeoutTextBox.BackColor = System.Drawing.Color.LightGray;
            this.timeoutTextBox.DownBack = null;
            this.timeoutTextBox.Icon = null;
            this.timeoutTextBox.IconIsButton = false;
            this.timeoutTextBox.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.timeoutTextBox.IsPasswordChat = '\0';
            this.timeoutTextBox.IsSystemPasswordChar = false;
            this.timeoutTextBox.Lines = new string[0];
            this.timeoutTextBox.Location = new System.Drawing.Point(135, 131);
            this.timeoutTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.timeoutTextBox.MaxLength = 32767;
            this.timeoutTextBox.MinimumSize = new System.Drawing.Size(28, 28);
            this.timeoutTextBox.MouseBack = null;
            this.timeoutTextBox.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.timeoutTextBox.Multiline = false;
            this.timeoutTextBox.Name = "timeoutTextBox";
            this.timeoutTextBox.NormlBack = null;
            this.timeoutTextBox.Padding = new System.Windows.Forms.Padding(5);
            this.timeoutTextBox.ReadOnly = false;
            this.timeoutTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.timeoutTextBox.Size = new System.Drawing.Size(309, 28);
            // 
            // 
            // 
            this.timeoutTextBox.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.timeoutTextBox.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.timeoutTextBox.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.timeoutTextBox.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.timeoutTextBox.SkinTxt.Name = "BaseText";
            this.timeoutTextBox.SkinTxt.Size = new System.Drawing.Size(299, 16);
            this.timeoutTextBox.SkinTxt.TabIndex = 0;
            this.timeoutTextBox.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.timeoutTextBox.SkinTxt.WaterText = "";
            this.timeoutTextBox.TabIndex = 18;
            this.timeoutTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.timeoutTextBox.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.timeoutTextBox.WaterText = "";
            this.timeoutTextBox.WordWrap = true;
            // 
            // updateUrlTextBox
            // 
            this.updateUrlTextBox.BackColor = System.Drawing.Color.LightGray;
            this.updateUrlTextBox.DownBack = null;
            this.updateUrlTextBox.Icon = null;
            this.updateUrlTextBox.IconIsButton = false;
            this.updateUrlTextBox.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.updateUrlTextBox.IsPasswordChat = '\0';
            this.updateUrlTextBox.IsSystemPasswordChar = false;
            this.updateUrlTextBox.Lines = new string[0];
            this.updateUrlTextBox.Location = new System.Drawing.Point(135, 94);
            this.updateUrlTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.updateUrlTextBox.MaxLength = 32767;
            this.updateUrlTextBox.MinimumSize = new System.Drawing.Size(28, 28);
            this.updateUrlTextBox.MouseBack = null;
            this.updateUrlTextBox.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.updateUrlTextBox.Multiline = false;
            this.updateUrlTextBox.Name = "updateUrlTextBox";
            this.updateUrlTextBox.NormlBack = null;
            this.updateUrlTextBox.Padding = new System.Windows.Forms.Padding(5);
            this.updateUrlTextBox.ReadOnly = false;
            this.updateUrlTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.updateUrlTextBox.Size = new System.Drawing.Size(309, 28);
            // 
            // 
            // 
            this.updateUrlTextBox.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.updateUrlTextBox.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.updateUrlTextBox.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.updateUrlTextBox.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.updateUrlTextBox.SkinTxt.Name = "BaseText";
            this.updateUrlTextBox.SkinTxt.Size = new System.Drawing.Size(299, 16);
            this.updateUrlTextBox.SkinTxt.TabIndex = 0;
            this.updateUrlTextBox.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.updateUrlTextBox.SkinTxt.WaterText = "";
            this.updateUrlTextBox.TabIndex = 18;
            this.updateUrlTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.updateUrlTextBox.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.updateUrlTextBox.WaterText = "";
            this.updateUrlTextBox.WordWrap = true;
            // 
            // hostTextBox
            // 
            this.hostTextBox.BackColor = System.Drawing.Color.LightGray;
            this.hostTextBox.DownBack = null;
            this.hostTextBox.Icon = null;
            this.hostTextBox.IconIsButton = false;
            this.hostTextBox.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.hostTextBox.IsPasswordChat = '\0';
            this.hostTextBox.IsSystemPasswordChar = false;
            this.hostTextBox.Lines = new string[0];
            this.hostTextBox.Location = new System.Drawing.Point(135, 23);
            this.hostTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.hostTextBox.MaxLength = 32767;
            this.hostTextBox.MinimumSize = new System.Drawing.Size(28, 28);
            this.hostTextBox.MouseBack = null;
            this.hostTextBox.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.hostTextBox.Multiline = false;
            this.hostTextBox.Name = "hostTextBox";
            this.hostTextBox.NormlBack = null;
            this.hostTextBox.Padding = new System.Windows.Forms.Padding(5);
            this.hostTextBox.ReadOnly = false;
            this.hostTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.hostTextBox.Size = new System.Drawing.Size(309, 28);
            // 
            // 
            // 
            this.hostTextBox.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.hostTextBox.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hostTextBox.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.hostTextBox.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.hostTextBox.SkinTxt.Name = "BaseText";
            this.hostTextBox.SkinTxt.Size = new System.Drawing.Size(299, 16);
            this.hostTextBox.SkinTxt.TabIndex = 0;
            this.hostTextBox.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.hostTextBox.SkinTxt.WaterText = "";
            this.hostTextBox.TabIndex = 19;
            this.hostTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.hostTextBox.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.hostTextBox.WaterText = "";
            this.hostTextBox.WordWrap = true;
            // 
            // portTextBox
            // 
            this.portTextBox.BackColor = System.Drawing.Color.LightGray;
            this.portTextBox.DownBack = null;
            this.portTextBox.Icon = null;
            this.portTextBox.IconIsButton = false;
            this.portTextBox.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.portTextBox.IsPasswordChat = '\0';
            this.portTextBox.IsSystemPasswordChar = false;
            this.portTextBox.Lines = new string[0];
            this.portTextBox.Location = new System.Drawing.Point(135, 57);
            this.portTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.portTextBox.MaxLength = 32767;
            this.portTextBox.MinimumSize = new System.Drawing.Size(28, 28);
            this.portTextBox.MouseBack = null;
            this.portTextBox.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.portTextBox.Multiline = false;
            this.portTextBox.Name = "portTextBox";
            this.portTextBox.NormlBack = null;
            this.portTextBox.Padding = new System.Windows.Forms.Padding(5);
            this.portTextBox.ReadOnly = false;
            this.portTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.portTextBox.Size = new System.Drawing.Size(309, 28);
            // 
            // 
            // 
            this.portTextBox.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.portTextBox.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.portTextBox.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.portTextBox.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.portTextBox.SkinTxt.Name = "BaseText";
            this.portTextBox.SkinTxt.Size = new System.Drawing.Size(299, 16);
            this.portTextBox.SkinTxt.TabIndex = 0;
            this.portTextBox.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.portTextBox.SkinTxt.WaterText = "";
            this.portTextBox.TabIndex = 19;
            this.portTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.portTextBox.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.portTextBox.WaterText = "";
            this.portTextBox.WordWrap = true;
            // 
            // skinLabel6
            // 
            this.skinLabel6.AutoSize = true;
            this.skinLabel6.BackColor = System.Drawing.Color.White;
            this.skinLabel6.BorderColor = System.Drawing.Color.White;
            this.skinLabel6.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel6.ForeColorSuit = true;
            this.skinLabel6.Location = new System.Drawing.Point(51, 29);
            this.skinLabel6.Name = "skinLabel6";
            this.skinLabel6.Size = new System.Drawing.Size(68, 17);
            this.skinLabel6.TabIndex = 20;
            this.skinLabel6.Text = "服务器地址";
            // 
            // skinLabel1
            // 
            this.skinLabel1.AutoSize = true;
            this.skinLabel1.BackColor = System.Drawing.Color.White;
            this.skinLabel1.BorderColor = System.Drawing.Color.White;
            this.skinLabel1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel1.ForeColorSuit = true;
            this.skinLabel1.Location = new System.Drawing.Point(51, 61);
            this.skinLabel1.Name = "skinLabel1";
            this.skinLabel1.Size = new System.Drawing.Size(68, 17);
            this.skinLabel1.TabIndex = 21;
            this.skinLabel1.Text = "服务器端口";
            // 
            // skinLabel2
            // 
            this.skinLabel2.AutoSize = true;
            this.skinLabel2.BackColor = System.Drawing.Color.White;
            this.skinLabel2.BorderColor = System.Drawing.Color.White;
            this.skinLabel2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel2.ForeColorSuit = true;
            this.skinLabel2.Location = new System.Drawing.Point(50, 135);
            this.skinLabel2.Name = "skinLabel2";
            this.skinLabel2.Size = new System.Drawing.Size(80, 17);
            this.skinLabel2.TabIndex = 22;
            this.skinLabel2.Text = "请求超时时间";
            // 
            // skinLabel3
            // 
            this.skinLabel3.AutoSize = true;
            this.skinLabel3.BackColor = System.Drawing.Color.White;
            this.skinLabel3.BorderColor = System.Drawing.Color.White;
            this.skinLabel3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel3.ForeColorSuit = true;
            this.skinLabel3.Location = new System.Drawing.Point(51, 97);
            this.skinLabel3.Name = "skinLabel3";
            this.skinLabel3.Size = new System.Drawing.Size(56, 17);
            this.skinLabel3.TabIndex = 23;
            this.skinLabel3.Text = "更新地址";
            // 
            // SettingControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.skinLabel3);
            this.Controls.Add(this.skinLabel2);
            this.Controls.Add(this.skinLabel1);
            this.Controls.Add(this.skinLabel6);
            this.Controls.Add(this.portTextBox);
            this.Controls.Add(this.hostTextBox);
            this.Controls.Add(this.updateUrlTextBox);
            this.Controls.Add(this.timeoutTextBox);
            this.Controls.Add(this.UpdateButton);
            this.Controls.Add(this.saveButton);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "SettingControl";
            this.Size = new System.Drawing.Size(508, 245);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private CCWin.SkinControl.SkinButton saveButton;
        private CCWin.SkinControl.SkinButton UpdateButton;
        private CCWin.SkinControl.SkinTextBox timeoutTextBox;
        private CCWin.SkinControl.SkinTextBox updateUrlTextBox;
        private CCWin.SkinControl.SkinTextBox hostTextBox;
        private CCWin.SkinControl.SkinTextBox portTextBox;
        private CCWin.SkinControl.SkinLabel skinLabel6;
        private CCWin.SkinControl.SkinLabel skinLabel1;
        private CCWin.SkinControl.SkinLabel skinLabel2;
        private CCWin.SkinControl.SkinLabel skinLabel3;
    }
}
