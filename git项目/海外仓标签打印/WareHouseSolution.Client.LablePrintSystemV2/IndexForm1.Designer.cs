namespace WareHouseSolution.Client.LablePrintSystem
{
    partial class IndexForm1
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
            CCWin.SkinControl.Animation animation1 = new CCWin.SkinControl.Animation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IndexForm1));
            this.tabControl1 = new CCWin.SkinControl.SkinTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.orderInfoControl1 = new WareHouseSolution.Client.LablePrintSystem.Controls.OrderInfoControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.settingControl1 = new WareHouseSolution.Client.LablePrintSystem.Controls.SettingControl();
            this.regOcdePrint = new System.Windows.Forms.TabPage();
            this.productControl1 = new WareHouseSolution.Client.LablePrintSystem.Controls.ProductControl();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.regOcdePrint.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            animation1.AnimateOnlyDifferences = false;
            animation1.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.BlindCoeff")));
            animation1.LeafCoeff = 0F;
            animation1.MaxTime = 1F;
            animation1.MinTime = 0F;
            animation1.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicCoeff")));
            animation1.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicShift")));
            animation1.MosaicSize = 0;
            animation1.Padding = new System.Windows.Forms.Padding(0);
            animation1.RotateCoeff = 0F;
            animation1.RotateLimit = 0F;
            animation1.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.ScaleCoeff")));
            animation1.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.SlideCoeff")));
            animation1.TimeCoeff = 2F;
            animation1.TransparencyCoeff = 0F;
            this.tabControl1.Animation = animation1;
            this.tabControl1.AnimatorType = CCWin.SkinControl.AnimationType.HorizSlide;
            this.tabControl1.CloseRect = new System.Drawing.Rectangle(2, 2, 12, 12);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.regOcdePrint);
            this.tabControl1.HeadBack = null;
            this.tabControl1.ImgTxtOffset = new System.Drawing.Point(0, 0);
            this.tabControl1.ItemSize = new System.Drawing.Size(70, 36);
            this.tabControl1.Location = new System.Drawing.Point(1, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.PageArrowDown = ((System.Drawing.Image)(resources.GetObject("tabControl1.PageArrowDown")));
            this.tabControl1.PageArrowHover = ((System.Drawing.Image)(resources.GetObject("tabControl1.PageArrowHover")));
            this.tabControl1.PageCloseHover = ((System.Drawing.Image)(resources.GetObject("tabControl1.PageCloseHover")));
            this.tabControl1.PageCloseNormal = ((System.Drawing.Image)(resources.GetObject("tabControl1.PageCloseNormal")));
            this.tabControl1.PageDown = ((System.Drawing.Image)(resources.GetObject("tabControl1.PageDown")));
            this.tabControl1.PageHover = ((System.Drawing.Image)(resources.GetObject("tabControl1.PageHover")));
            this.tabControl1.PageImagePosition = CCWin.SkinControl.SkinTabControl.ePageImagePosition.Left;
            this.tabControl1.PageNorml = null;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(724, 671);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.orderInfoControl1);
            this.tabPage1.Location = new System.Drawing.Point(0, 36);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(724, 635);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "订单打印";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // orderInfoControl1
            // 
            this.orderInfoControl1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.orderInfoControl1.Location = new System.Drawing.Point(0, 0);
            this.orderInfoControl1.Name = "orderInfoControl1";
            this.orderInfoControl1.Size = new System.Drawing.Size(703, 338);
            this.orderInfoControl1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.settingControl1);
            this.tabPage2.Location = new System.Drawing.Point(0, 36);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(724, 635);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "设置";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // settingControl1
            // 
            this.settingControl1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.settingControl1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.settingControl1.Location = new System.Drawing.Point(-4, 0);
            this.settingControl1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.settingControl1.Name = "settingControl1";
            this.settingControl1.Size = new System.Drawing.Size(600, 336);
            this.settingControl1.TabIndex = 0;
            // 
            // regOcdePrint
            // 
            this.regOcdePrint.Controls.Add(this.productControl1);
            this.regOcdePrint.Location = new System.Drawing.Point(0, 36);
            this.regOcdePrint.Name = "regOcdePrint";
            this.regOcdePrint.Padding = new System.Windows.Forms.Padding(3);
            this.regOcdePrint.Size = new System.Drawing.Size(724, 635);
            this.regOcdePrint.TabIndex = 2;
            this.regOcdePrint.Text = "登记码打印";
            this.regOcdePrint.UseVisualStyleBackColor = true;
            // 
            // productControl1
            // 
            this.productControl1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.productControl1.Location = new System.Drawing.Point(3, 0);
            this.productControl1.Name = "productControl1";
            this.productControl1.Size = new System.Drawing.Size(703, 338);
            this.productControl1.TabIndex = 0;
            // 
            // IndexForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(711, 363);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "IndexForm1";
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "海外仓打印";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.IndexForm_Closed);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.regOcdePrint.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private Controls.OrderInfoControl orderInfoControl1;
        private Controls.SettingControl settingControl1;
        private System.Windows.Forms.TabPage regOcdePrint;
        private CCWin.SkinControl.SkinTabControl tabControl1;
        private Controls.ProductControl productControl1;


    }
}