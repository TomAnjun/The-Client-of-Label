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
            this.orderNoTextBox = new CCWin.SkinControl.SkinTextBox();
            this.skinLabel1 = new CCWin.SkinControl.SkinLabel();
            this.productCodeTextBox = new CCWin.SkinControl.SkinTextBox();
            this.PrintBtn = new CCWin.SkinControl.SkinButton();
            this.SuspendLayout();
            // 
            // skinLabel3
            // 
            this.skinLabel3.AutoSize = true;
            this.skinLabel3.BackColor = System.Drawing.Color.White;
            this.skinLabel3.BorderColor = System.Drawing.Color.White;
            this.skinLabel3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel3.ForeColorSuit = true;
            this.skinLabel3.Location = new System.Drawing.Point(148, 67);
            this.skinLabel3.Name = "skinLabel3";
            this.skinLabel3.Size = new System.Drawing.Size(32, 17);
            this.skinLabel3.TabIndex = 24;
            this.skinLabel3.Text = "单号";
            // 
            // orderNoTextBox
            // 
            this.orderNoTextBox.BackColor = System.Drawing.Color.LightGray;
            this.orderNoTextBox.DownBack = null;
            this.orderNoTextBox.Icon = null;
            this.orderNoTextBox.IconIsButton = false;
            this.orderNoTextBox.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.orderNoTextBox.IsPasswordChat = '\0';
            this.orderNoTextBox.IsSystemPasswordChar = false;
            this.orderNoTextBox.Lines = new string[0];
            this.orderNoTextBox.Location = new System.Drawing.Point(228, 63);
            this.orderNoTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.orderNoTextBox.MaxLength = 32767;
            this.orderNoTextBox.MinimumSize = new System.Drawing.Size(28, 28);
            this.orderNoTextBox.MouseBack = null;
            this.orderNoTextBox.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.orderNoTextBox.Multiline = false;
            this.orderNoTextBox.Name = "orderNoTextBox";
            this.orderNoTextBox.NormlBack = null;
            this.orderNoTextBox.Padding = new System.Windows.Forms.Padding(5);
            this.orderNoTextBox.ReadOnly = false;
            this.orderNoTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.orderNoTextBox.Size = new System.Drawing.Size(309, 28);
            // 
            // 
            // 
            this.orderNoTextBox.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.orderNoTextBox.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.orderNoTextBox.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.orderNoTextBox.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.orderNoTextBox.SkinTxt.Name = "BaseText";
            this.orderNoTextBox.SkinTxt.Size = new System.Drawing.Size(299, 16);
            this.orderNoTextBox.SkinTxt.TabIndex = 0;
            this.orderNoTextBox.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.orderNoTextBox.SkinTxt.WaterText = "";
            this.orderNoTextBox.SkinTxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.orderNo_KeyDown);
            this.orderNoTextBox.TabIndex = 25;
            this.orderNoTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.orderNoTextBox.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.orderNoTextBox.WaterText = "";
            this.orderNoTextBox.WordWrap = true;
            // 
            // skinLabel1
            // 
            this.skinLabel1.AutoSize = true;
            this.skinLabel1.BackColor = System.Drawing.Color.White;
            this.skinLabel1.BorderColor = System.Drawing.Color.White;
            this.skinLabel1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel1.ForeColorSuit = true;
            this.skinLabel1.Location = new System.Drawing.Point(148, 136);
            this.skinLabel1.Name = "skinLabel1";
            this.skinLabel1.Size = new System.Drawing.Size(56, 17);
            this.skinLabel1.TabIndex = 26;
            this.skinLabel1.Text = "商品代码";
            // 
            // productCodeTextBox
            // 
            this.productCodeTextBox.BackColor = System.Drawing.Color.LightGray;
            this.productCodeTextBox.DownBack = null;
            this.productCodeTextBox.Icon = null;
            this.productCodeTextBox.IconIsButton = false;
            this.productCodeTextBox.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.productCodeTextBox.IsPasswordChat = '\0';
            this.productCodeTextBox.IsSystemPasswordChar = false;
            this.productCodeTextBox.Lines = new string[0];
            this.productCodeTextBox.Location = new System.Drawing.Point(228, 129);
            this.productCodeTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.productCodeTextBox.MaxLength = 32767;
            this.productCodeTextBox.MinimumSize = new System.Drawing.Size(28, 28);
            this.productCodeTextBox.MouseBack = null;
            this.productCodeTextBox.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.productCodeTextBox.Multiline = false;
            this.productCodeTextBox.Name = "productCodeTextBox";
            this.productCodeTextBox.NormlBack = null;
            this.productCodeTextBox.Padding = new System.Windows.Forms.Padding(5);
            this.productCodeTextBox.ReadOnly = false;
            this.productCodeTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.productCodeTextBox.Size = new System.Drawing.Size(309, 28);
            // 
            // 
            // 
            this.productCodeTextBox.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.productCodeTextBox.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.productCodeTextBox.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.productCodeTextBox.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.productCodeTextBox.SkinTxt.Name = "BaseText";
            this.productCodeTextBox.SkinTxt.Size = new System.Drawing.Size(299, 16);
            this.productCodeTextBox.SkinTxt.TabIndex = 0;
            this.productCodeTextBox.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.productCodeTextBox.SkinTxt.WaterText = "";
            this.productCodeTextBox.SkinTxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.productCode_KeyDown);
            this.productCodeTextBox.TabIndex = 26;
            this.productCodeTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.productCodeTextBox.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.productCodeTextBox.WaterText = "";
            this.productCodeTextBox.WordWrap = true;
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
            this.PrintBtn.Location = new System.Drawing.Point(228, 224);
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
            // ProductControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.PrintBtn);
            this.Controls.Add(this.productCodeTextBox);
            this.Controls.Add(this.skinLabel1);
            this.Controls.Add(this.orderNoTextBox);
            this.Controls.Add(this.skinLabel3);
            this.Name = "ProductControl";
            this.Size = new System.Drawing.Size(703, 338);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCWin.SkinControl.SkinLabel skinLabel3;
        private CCWin.SkinControl.SkinTextBox orderNoTextBox;
        private CCWin.SkinControl.SkinLabel skinLabel1;
        private CCWin.SkinControl.SkinTextBox productCodeTextBox;
        private CCWin.SkinControl.SkinButton PrintBtn;
    }
}
