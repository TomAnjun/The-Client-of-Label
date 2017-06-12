namespace WareHouseSolution.Client.LablePrintSystem.Controls
{
    partial class ProductControl
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.skinLabel3 = new CCWin.SkinControl.SkinLabel();
            this.waybillNOTextBox = new CCWin.SkinControl.SkinTextBox();
            this.skinLabel1 = new CCWin.SkinControl.SkinLabel();
            this.productRegCodeTextBox = new CCWin.SkinControl.SkinTextBox();
            this.PrintBtn = new CCWin.SkinControl.SkinButton();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.skinLabel2 = new CCWin.SkinControl.SkinLabel();
            this.endRegNoTextBox = new CCWin.SkinControl.SkinTextBox();
            this.SuspendLayout();
            // 
            // skinLabel3
            // 
            this.skinLabel3.AutoSize = true;
            this.skinLabel3.BackColor = System.Drawing.Color.White;
            this.skinLabel3.BorderColor = System.Drawing.Color.White;
            this.skinLabel3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel3.ForeColorSuit = true;
            this.skinLabel3.Location = new System.Drawing.Point(44, 36);
            this.skinLabel3.Name = "skinLabel3";
            this.skinLabel3.Size = new System.Drawing.Size(68, 17);
            this.skinLabel3.TabIndex = 24;
            this.skinLabel3.Text = "运   单   号";
            // 
            // waybillNOTextBox
            // 
            this.waybillNOTextBox.BackColor = System.Drawing.Color.LightGray;
            this.waybillNOTextBox.DownBack = null;
            this.waybillNOTextBox.Icon = null;
            this.waybillNOTextBox.IconIsButton = false;
            this.waybillNOTextBox.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.waybillNOTextBox.IsPasswordChat = '\0';
            this.waybillNOTextBox.IsSystemPasswordChar = false;
            this.waybillNOTextBox.Lines = new string[0];
            this.waybillNOTextBox.Location = new System.Drawing.Point(139, 36);
            this.waybillNOTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.waybillNOTextBox.MaxLength = 32767;
            this.waybillNOTextBox.MinimumSize = new System.Drawing.Size(28, 28);
            this.waybillNOTextBox.MouseBack = null;
            this.waybillNOTextBox.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.waybillNOTextBox.Multiline = false;
            this.waybillNOTextBox.Name = "waybillNOTextBox";
            this.waybillNOTextBox.NormlBack = null;
            this.waybillNOTextBox.Padding = new System.Windows.Forms.Padding(5);
            this.waybillNOTextBox.ReadOnly = false;
            this.waybillNOTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.waybillNOTextBox.Size = new System.Drawing.Size(309, 28);
            // 
            // 
            // 
            this.waybillNOTextBox.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.waybillNOTextBox.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.waybillNOTextBox.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.waybillNOTextBox.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.waybillNOTextBox.SkinTxt.Name = "BaseText";
            this.waybillNOTextBox.SkinTxt.Size = new System.Drawing.Size(299, 16);
            this.waybillNOTextBox.SkinTxt.TabIndex = 0;
            this.waybillNOTextBox.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.waybillNOTextBox.SkinTxt.WaterText = "";
            this.waybillNOTextBox.SkinTxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.orderNo_KeyDown);
            this.waybillNOTextBox.TabIndex = 25;
            this.waybillNOTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.waybillNOTextBox.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.waybillNOTextBox.WaterText = "";
            this.waybillNOTextBox.WordWrap = true;
            // 
            // skinLabel1
            // 
            this.skinLabel1.AutoSize = true;
            this.skinLabel1.BackColor = System.Drawing.Color.White;
            this.skinLabel1.BorderColor = System.Drawing.Color.White;
            this.skinLabel1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel1.ForeColorSuit = true;
            this.skinLabel1.Location = new System.Drawing.Point(44, 86);
            this.skinLabel1.Name = "skinLabel1";
            this.skinLabel1.Size = new System.Drawing.Size(68, 17);
            this.skinLabel1.TabIndex = 26;
            this.skinLabel1.Text = "商品登记码";
            // 
            // productRegCodeTextBox
            // 
            this.productRegCodeTextBox.BackColor = System.Drawing.Color.LightGray;
            this.productRegCodeTextBox.DownBack = null;
            this.productRegCodeTextBox.Icon = null;
            this.productRegCodeTextBox.IconIsButton = false;
            this.productRegCodeTextBox.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.productRegCodeTextBox.IsPasswordChat = '\0';
            this.productRegCodeTextBox.IsSystemPasswordChar = false;
            this.productRegCodeTextBox.Lines = new string[0];
            this.productRegCodeTextBox.Location = new System.Drawing.Point(139, 83);
            this.productRegCodeTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.productRegCodeTextBox.MaxLength = 32767;
            this.productRegCodeTextBox.MinimumSize = new System.Drawing.Size(28, 28);
            this.productRegCodeTextBox.MouseBack = null;
            this.productRegCodeTextBox.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.productRegCodeTextBox.Multiline = false;
            this.productRegCodeTextBox.Name = "productRegCodeTextBox";
            this.productRegCodeTextBox.NormlBack = null;
            this.productRegCodeTextBox.Padding = new System.Windows.Forms.Padding(5);
            this.productRegCodeTextBox.ReadOnly = false;
            this.productRegCodeTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.productRegCodeTextBox.Size = new System.Drawing.Size(309, 28);
            // 
            // 
            // 
            this.productRegCodeTextBox.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.productRegCodeTextBox.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.productRegCodeTextBox.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.productRegCodeTextBox.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.productRegCodeTextBox.SkinTxt.Name = "BaseText";
            this.productRegCodeTextBox.SkinTxt.Size = new System.Drawing.Size(299, 16);
            this.productRegCodeTextBox.SkinTxt.TabIndex = 0;
            this.productRegCodeTextBox.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.productRegCodeTextBox.SkinTxt.WaterText = "";
            this.productRegCodeTextBox.SkinTxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.productCode_KeyDown);
            this.productRegCodeTextBox.TabIndex = 26;
            this.productRegCodeTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.productRegCodeTextBox.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.productRegCodeTextBox.WaterText = "";
            this.productRegCodeTextBox.WordWrap = true;
            // 
            // PrintBtn
            // 
            this.PrintBtn.BackColor = System.Drawing.Color.White;
            this.PrintBtn.BaseColor = System.Drawing.Color.SteelBlue;
            this.PrintBtn.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.PrintBtn.DownBack = null;
            this.PrintBtn.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PrintBtn.ForeColor = System.Drawing.Color.White;
            this.PrintBtn.GlowColor = System.Drawing.Color.SteelBlue;
            this.PrintBtn.IsDrawBorder = false;
            this.PrintBtn.IsDrawGlass = false;
            this.PrintBtn.Location = new System.Drawing.Point(222, 191);
            this.PrintBtn.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.PrintBtn.MouseBack = null;
            this.PrintBtn.Name = "PrintBtn";
            this.PrintBtn.NormlBack = null;
            this.PrintBtn.Radius = 20;
            this.PrintBtn.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.PrintBtn.Size = new System.Drawing.Size(94, 32);
            this.PrintBtn.TabIndex = 27;
            this.PrintBtn.Text = "打印";
            this.PrintBtn.UseVisualStyleBackColor = false;
            this.PrintBtn.Click += new System.EventHandler(this.printBtn_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.LinkColor = System.Drawing.Color.SteelBlue;
            this.linkLabel1.Location = new System.Drawing.Point(326, 233);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(173, 12);
            this.linkLabel1.TabIndex = 28;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "http://www.nssoftware.com.cn";
            // 
            // skinLabel2
            // 
            this.skinLabel2.AutoSize = true;
            this.skinLabel2.BackColor = System.Drawing.Color.White;
            this.skinLabel2.BorderColor = System.Drawing.Color.White;
            this.skinLabel2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel2.ForeColorSuit = true;
            this.skinLabel2.Location = new System.Drawing.Point(44, 134);
            this.skinLabel2.Name = "skinLabel2";
            this.skinLabel2.Size = new System.Drawing.Size(68, 17);
            this.skinLabel2.TabIndex = 29;
            this.skinLabel2.Text = "末尾登记号";
            // 
            // endRegNoTextBox
            // 
            this.endRegNoTextBox.BackColor = System.Drawing.Color.LightGray;
            this.endRegNoTextBox.DownBack = null;
            this.endRegNoTextBox.Icon = null;
            this.endRegNoTextBox.IconIsButton = false;
            this.endRegNoTextBox.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.endRegNoTextBox.IsPasswordChat = '\0';
            this.endRegNoTextBox.IsSystemPasswordChar = false;
            this.endRegNoTextBox.Lines = new string[0];
            this.endRegNoTextBox.Location = new System.Drawing.Point(139, 129);
            this.endRegNoTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.endRegNoTextBox.MaxLength = 32767;
            this.endRegNoTextBox.MinimumSize = new System.Drawing.Size(28, 28);
            this.endRegNoTextBox.MouseBack = null;
            this.endRegNoTextBox.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.endRegNoTextBox.Multiline = false;
            this.endRegNoTextBox.Name = "endRegNoTextBox";
            this.endRegNoTextBox.NormlBack = null;
            this.endRegNoTextBox.Padding = new System.Windows.Forms.Padding(5);
            this.endRegNoTextBox.ReadOnly = false;
            this.endRegNoTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.endRegNoTextBox.Size = new System.Drawing.Size(309, 28);
            // 
            // 
            // 
            this.endRegNoTextBox.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.endRegNoTextBox.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.endRegNoTextBox.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.endRegNoTextBox.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.endRegNoTextBox.SkinTxt.Name = "BaseText";
            this.endRegNoTextBox.SkinTxt.Size = new System.Drawing.Size(299, 16);
            this.endRegNoTextBox.SkinTxt.TabIndex = 0;
            this.endRegNoTextBox.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.endRegNoTextBox.SkinTxt.WaterText = "";
            this.endRegNoTextBox.SkinTxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.productCode_KeyDown);
            this.endRegNoTextBox.TabIndex = 27;
            this.endRegNoTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.endRegNoTextBox.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.endRegNoTextBox.WaterText = "";
            this.endRegNoTextBox.WordWrap = true;
            // 
            // ProductControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.endRegNoTextBox);
            this.Controls.Add(this.skinLabel2);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.PrintBtn);
            this.Controls.Add(this.productRegCodeTextBox);
            this.Controls.Add(this.skinLabel1);
            this.Controls.Add(this.waybillNOTextBox);
            this.Controls.Add(this.skinLabel3);
            this.Name = "ProductControl";
            this.Size = new System.Drawing.Size(508, 245);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCWin.SkinControl.SkinLabel skinLabel3;
        private CCWin.SkinControl.SkinTextBox waybillNOTextBox;
        private CCWin.SkinControl.SkinLabel skinLabel1;
        private CCWin.SkinControl.SkinTextBox productRegCodeTextBox;
        private CCWin.SkinControl.SkinButton PrintBtn;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private CCWin.SkinControl.SkinLabel skinLabel2;
        private CCWin.SkinControl.SkinTextBox endRegNoTextBox;
    }
}
