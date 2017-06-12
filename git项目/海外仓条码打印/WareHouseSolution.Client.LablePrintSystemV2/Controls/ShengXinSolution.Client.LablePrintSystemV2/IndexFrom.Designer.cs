namespace ShengXinSolution.Client.LablePrintSystemV2
{
    partial class IndexFrom
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IndexFrom));
            this.iconList = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControlAnjun1 = new ShengXinSolution.Client.LablePrintSystemV2.TabControlAnjun();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.indexControl1 = new ShengXinSolution.Client.LablePrintSystemV2.Controls.IndexControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.settingControl1 = new ShengXinSolution.Client.LablePrintSystemV2.Controls.SettingControl();
            this.panel1.SuspendLayout();
            this.tabControlAnjun1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // iconList
            // 
            this.iconList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("iconList.ImageStream")));
            this.iconList.TransparentColor = System.Drawing.Color.Transparent;
            this.iconList.Images.SetKeyName(0, "printer1_48px_43647_easyicon.net.png");
            this.iconList.Images.SetKeyName(1, "package_settings_components_48px_1078291_easyicon.net.png");
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::ShengXinSolution.Client.LablePrintSystemV2.Properties.Resources.background;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(608, 68);
            this.panel1.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(134, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "发件公司专用";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(562, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "关闭";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(1, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "盛欣标签打印-";
            // 
            // tabControlAnjun1
            // 
            this.tabControlAnjun1.Controls.Add(this.tabPage1);
            this.tabControlAnjun1.Controls.Add(this.tabPage2);
            this.tabControlAnjun1.ImageList = this.iconList;
            this.tabControlAnjun1.ItemSize = new System.Drawing.Size(55, 66);
            this.tabControlAnjun1.Location = new System.Drawing.Point(1, 69);
            this.tabControlAnjun1.Name = "tabControlAnjun1";
            this.tabControlAnjun1.SelectedIndex = 0;
            this.tabControlAnjun1.Size = new System.Drawing.Size(607, 426);
            this.tabControlAnjun1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControlAnjun1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.indexControl1);
            this.tabPage1.ImageIndex = 0;
            this.tabPage1.Location = new System.Drawing.Point(4, 70);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(599, 352);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "打印";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // indexControl1
            // 
            this.indexControl1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.indexControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.indexControl1.Location = new System.Drawing.Point(0, 0);
            this.indexControl1.Name = "indexControl1";
            this.indexControl1.Size = new System.Drawing.Size(599, 348);
            this.indexControl1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.settingControl1);
            this.tabPage2.ImageIndex = 1;
            this.tabPage2.Location = new System.Drawing.Point(4, 70);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(599, 352);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "设置";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // settingControl1
            // 
            this.settingControl1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.settingControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.settingControl1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.settingControl1.Location = new System.Drawing.Point(0, 0);
            this.settingControl1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.settingControl1.Name = "settingControl1";
            this.settingControl1.Size = new System.Drawing.Size(597, 348);
            this.settingControl1.TabIndex = 0;
            // 
            // IndexFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 498);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControlAnjun1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "IndexFrom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "盛欣打印标签程序";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControlAnjun1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TabControlAnjun tabControlAnjun1;
        private System.Windows.Forms.TabPage tabPage1;
        private Controls.IndexControl indexControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private Controls.SettingControl settingControl1;
        private System.Windows.Forms.ImageList iconList;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;

    }
}