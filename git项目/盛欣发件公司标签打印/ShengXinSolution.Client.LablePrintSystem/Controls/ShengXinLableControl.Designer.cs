namespace ShengXinSolution.Client.LablePrintSystem.Controls
{
    partial class ShengXinLableControl
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
            CCWin.SkinControl.Animation animation1 = new CCWin.SkinControl.Animation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShengXinLableControl));
            this.PrintTab = new CCWin.SkinControl.SkinTabControl();
            this.SagawaPage = new CCWin.SkinControl.SkinTabPage();
            this.SagawaPanel = new CCWin.SkinControl.SkinPanel();
            this.JapanEmsSmallPage = new CCWin.SkinControl.SkinTabPage();
            this.JapanEmsBigPage = new CCWin.SkinControl.SkinTabPage();
            this.JapanEmsPanel = new CCWin.SkinControl.SkinPanel();
            this.SagawaHikiyakuPage = new CCWin.SkinControl.SkinTabPage();
            this.SagawaHikiyakuPanel = new CCWin.SkinControl.SkinPanel();
            this.PrintTab.SuspendLayout();
            this.SagawaPage.SuspendLayout();
            this.JapanEmsBigPage.SuspendLayout();
            this.SagawaHikiyakuPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // PrintTab
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
            this.PrintTab.Animation = animation1;
            this.PrintTab.AnimationStart = false;
            this.PrintTab.AnimatorType = CCWin.SkinControl.AnimationType.HorizSlide;
            this.PrintTab.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PrintTab.BackgroundImage")));
            this.PrintTab.CloseRect = new System.Drawing.Rectangle(2, 2, 12, 12);
            this.PrintTab.Controls.Add(this.SagawaPage);
            this.PrintTab.Controls.Add(this.JapanEmsSmallPage);
            this.PrintTab.Controls.Add(this.JapanEmsBigPage);
            this.PrintTab.Controls.Add(this.SagawaHikiyakuPage);
            this.PrintTab.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.PrintTab.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PrintTab.HeadBack = null;
            this.PrintTab.ImgTxtOffset = new System.Drawing.Point(0, 0);
            this.PrintTab.ImgTxtSpace = 0;
            this.PrintTab.ItemSize = new System.Drawing.Size(109, 30);
            this.PrintTab.Location = new System.Drawing.Point(3, 3);
            this.PrintTab.Name = "PrintTab";
            this.PrintTab.PageArrowDown = ((System.Drawing.Image)(resources.GetObject("PrintTab.PageArrowDown")));
            this.PrintTab.PageArrowHover = ((System.Drawing.Image)(resources.GetObject("PrintTab.PageArrowHover")));
            this.PrintTab.PageBackRectangle = new System.Drawing.Rectangle(5, 5, 5, 5);
            this.PrintTab.PageCloseHover = ((System.Drawing.Image)(resources.GetObject("PrintTab.PageCloseHover")));
            this.PrintTab.PageCloseNormal = ((System.Drawing.Image)(resources.GetObject("PrintTab.PageCloseNormal")));
            this.PrintTab.PageDown = ((System.Drawing.Image)(resources.GetObject("PrintTab.PageDown")));
            this.PrintTab.PageHover = ((System.Drawing.Image)(resources.GetObject("PrintTab.PageHover")));
            this.PrintTab.PageImagePosition = CCWin.SkinControl.SkinTabControl.ePageImagePosition.Top;
            this.PrintTab.PageNorml = ((System.Drawing.Image)(resources.GetObject("PrintTab.PageNorml")));
            this.PrintTab.PagePalace = true;
            this.PrintTab.SelectedIndex = 0;
            this.PrintTab.Size = new System.Drawing.Size(401, 525);
            this.PrintTab.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.PrintTab.TabIndex = 5;
            // 
            // SagawaPage
            // 
            this.SagawaPage.BackColor = System.Drawing.Color.White;
            this.SagawaPage.Controls.Add(this.SagawaPanel);
            this.SagawaPage.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SagawaPage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.SagawaPage.Location = new System.Drawing.Point(0, 30);
            this.SagawaPage.Margin = new System.Windows.Forms.Padding(0);
            this.SagawaPage.Name = "SagawaPage";
            this.SagawaPage.Size = new System.Drawing.Size(401, 495);
            this.SagawaPage.TabIndex = 0;
            this.SagawaPage.Text = "佐川急便";
            // 
            // SagawaPanel
            // 
            this.SagawaPanel.BackColor = System.Drawing.Color.Transparent;
            this.SagawaPanel.BackgroundImage = global::ShengXinSolution.Client.LablePrintSystem.Properties.Resources.SagawaLabel;
            this.SagawaPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.SagawaPanel.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.SagawaPanel.DownBack = null;
            this.SagawaPanel.Location = new System.Drawing.Point(-5, 3);
            this.SagawaPanel.MouseBack = null;
            this.SagawaPanel.Name = "SagawaPanel";
            this.SagawaPanel.NormlBack = null;
            this.SagawaPanel.Size = new System.Drawing.Size(412, 489);
            this.SagawaPanel.TabIndex = 1;
            // 
            // JapanEmsSmallPage
            // 
            this.JapanEmsSmallPage.BackColor = System.Drawing.Color.White;
            this.JapanEmsSmallPage.BackgroundImage = global::ShengXinSolution.Client.LablePrintSystem.Properties.Resources.japanEmsSmallLabel;
            this.JapanEmsSmallPage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.JapanEmsSmallPage.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.JapanEmsSmallPage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(81)))), ((int)(((byte)(81)))));
            this.JapanEmsSmallPage.Location = new System.Drawing.Point(0, 30);
            this.JapanEmsSmallPage.Margin = new System.Windows.Forms.Padding(0);
            this.JapanEmsSmallPage.Name = "JapanEmsSmallPage";
            this.JapanEmsSmallPage.Size = new System.Drawing.Size(401, 495);
            this.JapanEmsSmallPage.TabIndex = 2;
            this.JapanEmsSmallPage.Text = "日本邮政(小)";
            // 
            // JapanEmsBigPage
            // 
            this.JapanEmsBigPage.BackColor = System.Drawing.Color.White;
            this.JapanEmsBigPage.Controls.Add(this.JapanEmsPanel);
            this.JapanEmsBigPage.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.JapanEmsBigPage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.JapanEmsBigPage.Location = new System.Drawing.Point(0, 30);
            this.JapanEmsBigPage.Margin = new System.Windows.Forms.Padding(0);
            this.JapanEmsBigPage.Name = "JapanEmsBigPage";
            this.JapanEmsBigPage.Size = new System.Drawing.Size(401, 495);
            this.JapanEmsBigPage.TabIndex = 1;
            this.JapanEmsBigPage.Text = "日本邮政(大)";
            // 
            // JapanEmsPanel
            // 
            this.JapanEmsPanel.BackColor = System.Drawing.Color.Transparent;
            this.JapanEmsPanel.BackgroundImage = global::ShengXinSolution.Client.LablePrintSystem.Properties.Resources.JapanEmsBigLabel;
            this.JapanEmsPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.JapanEmsPanel.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.JapanEmsPanel.DownBack = null;
            this.JapanEmsPanel.Location = new System.Drawing.Point(-6, 3);
            this.JapanEmsPanel.MouseBack = null;
            this.JapanEmsPanel.Name = "JapanEmsPanel";
            this.JapanEmsPanel.NormlBack = null;
            this.JapanEmsPanel.Size = new System.Drawing.Size(412, 489);
            this.JapanEmsPanel.TabIndex = 2;
            // 
            // SagawaHikiyakuPage
            // 
            this.SagawaHikiyakuPage.BackColor = System.Drawing.Color.White;
            this.SagawaHikiyakuPage.Controls.Add(this.SagawaHikiyakuPanel);
            this.SagawaHikiyakuPage.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SagawaHikiyakuPage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.SagawaHikiyakuPage.Location = new System.Drawing.Point(0, 30);
            this.SagawaHikiyakuPage.Margin = new System.Windows.Forms.Padding(0);
            this.SagawaHikiyakuPage.Name = "SagawaHikiyakuPage";
            this.SagawaHikiyakuPage.Size = new System.Drawing.Size(401, 495);
            this.SagawaHikiyakuPage.TabIndex = 2;
            this.SagawaHikiyakuPage.Text = "佐川飞脚";
            // 
            // SagawaHikiyakuPanel
            // 
            this.SagawaHikiyakuPanel.BackColor = System.Drawing.Color.Transparent;
            this.SagawaHikiyakuPanel.BackgroundImage = global::ShengXinSolution.Client.LablePrintSystem.Properties.Resources.SagawaLabel;
            this.SagawaHikiyakuPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.SagawaHikiyakuPanel.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.SagawaHikiyakuPanel.DownBack = null;
            this.SagawaHikiyakuPanel.Location = new System.Drawing.Point(-5, 3);
            this.SagawaHikiyakuPanel.MouseBack = null;
            this.SagawaHikiyakuPanel.Name = "SagawaHikiyakuPanel";
            this.SagawaHikiyakuPanel.NormlBack = null;
            this.SagawaHikiyakuPanel.Size = new System.Drawing.Size(412, 489);
            this.SagawaHikiyakuPanel.TabIndex = 2;
            // 
            // ShengXinLableControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.PrintTab);
            this.Name = "ShengXinLableControl";
            this.Size = new System.Drawing.Size(408, 533);
            this.PrintTab.ResumeLayout(false);
            this.SagawaPage.ResumeLayout(false);
            this.JapanEmsBigPage.ResumeLayout(false);
            this.SagawaHikiyakuPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public CCWin.SkinControl.SkinTabControl PrintTab;
        public CCWin.SkinControl.SkinTabPage SagawaPage;
        public CCWin.SkinControl.SkinPanel SagawaPanel;
        public CCWin.SkinControl.SkinTabPage JapanEmsBigPage;
        public CCWin.SkinControl.SkinPanel JapanEmsPanel;
        public CCWin.SkinControl.SkinTabPage SagawaHikiyakuPage;
        public CCWin.SkinControl.SkinPanel SagawaHikiyakuPanel;
        public CCWin.SkinControl.SkinTabPage JapanEmsSmallPage;
    }
}
