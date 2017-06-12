namespace ShengXinSolution.Client.LablePrintSystemV2
{
    partial class IndexForm
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
            this.orderTabPage = new System.Windows.Forms.TabControl();
            this.orderPage = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.orderTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // orderTabPage
            // 
            this.orderTabPage.Controls.Add(this.orderPage);
            this.orderTabPage.Controls.Add(this.tabPage2);
            this.orderTabPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.orderTabPage.Location = new System.Drawing.Point(0, 0);
            this.orderTabPage.Name = "orderTabPage";
            this.orderTabPage.SelectedIndex = 0;
            this.orderTabPage.Size = new System.Drawing.Size(389, 706);
            this.orderTabPage.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.orderPage.Location = new System.Drawing.Point(4, 22);
            this.orderPage.Name = "tabPage1";
            this.orderPage.Padding = new System.Windows.Forms.Padding(3);
            this.orderPage.Size = new System.Drawing.Size(381, 680);
            this.orderPage.TabIndex = 0;
            this.orderPage.Text = "tabPage1";
            this.orderPage.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(381, 680);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // IndexForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 706);
            this.Controls.Add(this.orderTabPage);
            this.Name = "IndexForm";
            this.Text = "IndexForm";
            this.orderTabPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl orderTabPage;
        private System.Windows.Forms.TabPage orderPage;
        private System.Windows.Forms.TabPage tabPage2;
    }
}