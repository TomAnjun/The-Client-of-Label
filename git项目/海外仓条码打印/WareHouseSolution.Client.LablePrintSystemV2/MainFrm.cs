using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WareHouseSolution.Client.LablePrintSystem.Utils;

namespace WareHouseSolution.Client.LablePrintSystem
{
    public partial class MainFrm : Form
    {
        public MainFrm()
        {
            InitializeComponent();
        }

        private void closeLabel_Click(object sender, EventArgs e)
        {
            WhApi.logOut();
            Application.Exit();
        }
    }
}
