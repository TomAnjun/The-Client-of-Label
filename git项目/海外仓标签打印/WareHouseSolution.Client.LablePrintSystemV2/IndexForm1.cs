using System.Windows.Forms;
using CCWin;
using CCWin.SkinControl;

namespace WareHouseSolution.Client.LablePrintSystem
{
    public partial class IndexForm1 : Form
    {
        public IndexForm1()
        {
            InitializeComponent();
            if (!Properties.Settings.Default.UPDATE_LOG_READ_YN && !Properties.Settings.Default.UPDATE_LOG.IsNullOrEmpty())
                MessageBox.Show(Properties.Settings.Default.UPDATE_LOG);
            Properties.Settings.Default.UPDATE_LOG_READ_YN = true;
            Properties.Settings.Default.Save();
        }

        private void IndexForm_Closed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void numTextBox_SkinTxt_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
