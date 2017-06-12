using CCWin;
using ShengXinSolution.Client.LablePrintSystem.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ShengXinSolution.Client.LablePrintSystem
{
    public partial class Main : CCSkinMain
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            // this is a test by xuliguo used win10.

            //if (!Properties.Settings.Default.UPDATE_LOG_READ_YN)
            //{
            //    MessageBox.Show(Properties.Settings.Default.UPDATE_LOG);
            //    Properties.Settings.Default.UPDATE_LOG_READ_YN = true;
            //    Properties.Settings.Default.Save();
            //}
            //MessageBoxEx.Show(ApiHelper.Get("/sxn/transOrderInfoCompany/padding1", null));

            skinTextBox1.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void skinButton1_Click(object sender, EventArgs e)
        {
            //shengXinLableControl1.skinPanel2.
        }
    }
}
