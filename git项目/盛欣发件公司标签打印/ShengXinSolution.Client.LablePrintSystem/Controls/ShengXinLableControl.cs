using System.Windows.Forms;

namespace ShengXinSolution.Client.LablePrintSystem.Controls
{
    public partial class ShengXinLableControl : UserControl
    {
        public ShengXinLableControl()
        {
            InitializeComponent();
        }

        //获取tabControl的tabPage的Name
        public string getPageName()
        {
            if (PrintTab.SelectedTab == SagawaPage)
                return "sagawa";
            if(PrintTab.SelectedTab == JapanEmsSmallPage)
                return "japanEmsSmall";
            if (PrintTab.SelectedTab == JapanEmsBigPage)
                return "japanEmsBig";
            return "sagawa";
        }
    }
}
