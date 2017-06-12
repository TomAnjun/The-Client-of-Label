namespace WareHouseSolution.Client.LablePrintSystem
{
    partial class MainFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrm));
            this.skinPanel1 = new CCWin.SkinControl.SkinPanel();
            this.skinLabel1 = new CCWin.SkinControl.SkinLabel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.barcodePrinfTab = new System.Windows.Forms.TabPage();
            this.settingTab = new System.Windows.Forms.TabPage();
            this.closeLabel = new System.Windows.Forms.Label();
            this.productControl1 = new WareHouseSolution.Client.LablePrintSystem.Controls.ProductControl();
            this.settingControl1 = new WareHouseSolution.Client.LablePrintSystem.Controls.SettingControl();
            this.skinPanel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.barcodePrinfTab.SuspendLayout();
            this.settingTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // skinPanel1
            // 
            this.skinPanel1.BackColor = System.Drawing.Color.SteelBlue;
            this.skinPanel1.Controls.Add(this.closeLabel);
            this.skinPanel1.Controls.Add(this.skinLabel1);
            this.skinPanel1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinPanel1.DownBack = null;
            this.skinPanel1.Location = new System.Drawing.Point(0, 0);
            this.skinPanel1.MouseBack = null;
            this.skinPanel1.Name = "skinPanel1";
            this.skinPanel1.NormlBack = null;
            this.skinPanel1.Size = new System.Drawing.Size(512, 60);
            this.skinPanel1.TabIndex = 3;
            // 
            // skinLabel1
            // 
            this.skinLabel1.AutoSize = true;
            this.skinLabel1.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel1.BorderColor = System.Drawing.Color.White;
            this.skinLabel1.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel1.Location = new System.Drawing.Point(152, 16);
            this.skinLabel1.Name = "skinLabel1";
            this.skinLabel1.Size = new System.Drawing.Size(213, 30);
            this.skinLabel1.TabIndex = 0;
            this.skinLabel1.Text = "海外仓条码打印V1.0";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.barcodePrinfTab);
            this.tabControl1.Controls.Add(this.settingTab);
            this.tabControl1.ItemSize = new System.Drawing.Size(60, 30);
            this.tabControl1.Location = new System.Drawing.Point(2, 61);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(509, 287);
            this.tabControl1.TabIndex = 4;
            // 
            // barcodePrinfTab
            // 
            this.barcodePrinfTab.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.barcodePrinfTab.Controls.Add(this.productControl1);
            this.barcodePrinfTab.ForeColor = System.Drawing.SystemColors.Highlight;
            this.barcodePrinfTab.Location = new System.Drawing.Point(4, 34);
            this.barcodePrinfTab.Name = "barcodePrinfTab";
            this.barcodePrinfTab.Padding = new System.Windows.Forms.Padding(3);
            this.barcodePrinfTab.Size = new System.Drawing.Size(501, 249);
            this.barcodePrinfTab.TabIndex = 0;
            this.barcodePrinfTab.Text = "条码打印";
            // 
            // settingTab
            // 
            this.settingTab.Controls.Add(this.settingControl1);
            this.settingTab.Location = new System.Drawing.Point(4, 34);
            this.settingTab.Name = "settingTab";
            this.settingTab.Padding = new System.Windows.Forms.Padding(3);
            this.settingTab.Size = new System.Drawing.Size(501, 249);
            this.settingTab.TabIndex = 1;
            this.settingTab.Text = "设置";
            this.settingTab.UseVisualStyleBackColor = true;
            // 
            // closeLabel
            // 
            this.closeLabel.AutoSize = true;
            this.closeLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closeLabel.ForeColor = System.Drawing.Color.SteelBlue;
            this.closeLabel.Image = ((System.Drawing.Image)(resources.GetObject("closeLabel.Image")));
            this.closeLabel.Location = new System.Drawing.Point(489, 6);
            this.closeLabel.Name = "closeLabel";
            this.closeLabel.Size = new System.Drawing.Size(17, 12);
            this.closeLabel.TabIndex = 1;
            this.closeLabel.Text = "  ";
            this.closeLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.closeLabel.Click += new System.EventHandler(this.closeLabel_Click);
            // 
            // productControl1
            // 
            this.productControl1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.productControl1.Location = new System.Drawing.Point(-6, 0);
            this.productControl1.Name = "productControl1";
            this.productControl1.Size = new System.Drawing.Size(508, 245);
            this.productControl1.TabIndex = 0;
            // 
            // settingControl1
            // 
            this.settingControl1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.settingControl1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.settingControl1.Location = new System.Drawing.Point(-4, -2);
            this.settingControl1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.settingControl1.Name = "settingControl1";
            this.settingControl1.Size = new System.Drawing.Size(508, 245);
            this.settingControl1.TabIndex = 0;
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(513, 352);
            this.Controls.Add(this.skinPanel1);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainFrm";
            this.skinPanel1.ResumeLayout(false);
            this.skinPanel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.barcodePrinfTab.ResumeLayout(false);
            this.settingTab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CCWin.SkinControl.SkinPanel skinPanel1;
        private System.Windows.Forms.Label closeLabel;
        private CCWin.SkinControl.SkinLabel skinLabel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage barcodePrinfTab;
        private System.Windows.Forms.TabPage settingTab;
        private Controls.ProductControl productControl1;
        private Controls.SettingControl settingControl1;
    }
}