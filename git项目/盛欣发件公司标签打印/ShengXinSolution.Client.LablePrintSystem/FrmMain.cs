using CCWin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CCWin.SkinControl;
using System.Deployment.Application;
using ShengXinSolution.Client.LablePrintSystem.Models;
using ShengXinSolution.Client.LablePrintSystem.Utils;
using System.IO;

namespace ShengXinSolution.Client.LablePrintSystem
{
    public partial class FrmMain : CCSkinMain
    {
        //SagawaLabel labelData = null;//存放读取到txt内容的bean
        //private List<SagawaLabel> fileBeanList = null;//存放需要打印数据的list
        //private List<SagawaLabel> gunBeanList = null;//http请求返回数据Bean的List
        private List<SagawaLabel> offLineList = null;//离线打印读取到的文件存储的List By Zhangsong

        public FrmMain()
        {
            InitializeComponent();
            this.desComboBoxEc.SelectedIndex = 0;
            this.flightDateTextBox.Text = DateTime.Now.ToString("yyyy-M-d");
        }

        //如果点击的是工具菜单按钮
        private void FrmMain_SysBottomClick(object sender, SysButtonEventArgs e)
        {
            Point l = PointToScreen(e.SysButton.Location);
            l.Y += e.SysButton.Size.Height + 1;
            switch (e.SysButton.Name)
            {
                case "SysTool":
                    ToolMenu.Show(l);
                    break;
                case "SysMsg":
                    FrmFeedBack frmFeedBack = new FrmFeedBack();
                    frmFeedBack.ShowDialog();
                    break;
                default:
                    break;
            }
           
        }

        private void ToolStripMenuItem_SysConfig_Click(object sender, EventArgs e)
        {
            FrmAbout frmAbout = new FrmAbout();
            frmAbout.ShowDialog();
        }

        private void ToolStripMenuItem_HomePage_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Properties.Settings.Default.API_SERVER_HOST
                + ":" + Properties.Settings.Default.API_SERVER_PORT + Properties.Settings.Default.API_BASE_URL);
        }

        private void ToolStripMenuItem_UpdateLog_Click(object sender, EventArgs e)
        {
            FrmAbout frmAbout = new FrmAbout();
            frmAbout.ShowDialog();
        }

        private void ToolStripMenuItem_CheckUpdate_Click(object sender, EventArgs e)
        {
            //System.Diagnostics.Process.Start(Properties.Settings.Default.CLIENT_UPDATE_URL);
            InstallUpdateSyncWithInfo();
        }

        private void ToolStripMenuItem_About_Click(object sender, EventArgs e)
        {
            FrmAbout frmAbout = new FrmAbout();
            frmAbout.ShowDialog();
        }

        #region 程序升级
        private void InstallUpdateSyncWithInfo()
        {
            UpdateCheckInfo info = null;

            if (ApplicationDeployment.IsNetworkDeployed)
            {
                ApplicationDeployment ad = ApplicationDeployment.CurrentDeployment;

                try
                {
                    info = ad.CheckForDetailedUpdate();

                }
                catch (DeploymentDownloadException dde)
                {
                    //The new version of the application cannot be downloaded at this time. \n\nPlease check your network connection, or try again later. Error
                    MessageBox.Show("无法下载新版本的应用程序。\n\n请检查您的网络连接，或稍后再试。错误信息：" + dde.Message);
                    return;
                }
                catch (InvalidDeploymentException ide)
                {
                    //Cannot check for a new version of the application. The ClickOnce deployment is corrupt. Please redeploy the application and try again. Error
                    MessageBox.Show("无法检查应用程序的新版本,请重新部署应用程序并重试。错误信息：" + ide.Message);
                    return;
                }
                catch (InvalidOperationException ioe)
                {
                    //This application cannot be updated. It is likely not a ClickOnce application. Error
                    MessageBox.Show("无法更新此应用程序。错误信息：" + ioe.Message);
                    return;
                }

                if (info.UpdateAvailable)
                {
                    Boolean doUpdate = true;

                    if (!info.IsUpdateRequired)
                    {
                        //An update is available. Would you like to update the application now?", "Update Available
                        DialogResult dr = MessageBox.Show("发现可用更新，您是否现在更新？", "可用更新", MessageBoxButtons.OKCancel);
                        if (!(DialogResult.OK == dr))
                        {
                            doUpdate = false;
                        }
                    }
                    else
                    {
                        // Display a message that the app MUST reboot. Display the minimum required version.
                        //This application has detected a mandatory update from your current version to version . The application will now install the update and restart.
                        MessageBox.Show("应用程序将更新至 " +
                            "版本 " + info.MinimumRequiredVersion.ToString() +
                            ". 现在应用程序将重启并自动更新.",
                            "可用更新", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }

                    if (doUpdate)
                    {
                        try
                        {
                            ad.Update();
                            //The application has been upgraded, and will now restart
                            MessageBox.Show("应用程序更新完毕，现在将重新启动。");
                            Application.Restart();
                        }
                        catch (DeploymentDownloadException dde)
                        {
                            //Cannot install the latest version of the application. \n\nPlease check your network connection, or try again later. Error
                            MessageBox.Show("无法获取最新版本的应用程序。\n\n请检查网络是否正常，或者请稍后重试。错误信息：" + dde);
                            return;
                        }
                    }
                }
                else {
                    MessageBox.Show("当前已是最新版本.");
                }
            }
        }
        #endregion

        private void skinCheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            initSys();

        }

        private void initSys()
        {
            skinComboBox1.Text = Properties.Settings.Default.API_SERVER_HOST;
            skinComboBox2.Text = Properties.Settings.Default.API_SERVER_PORT;
            skinTextBox1.Text = Properties.Settings.Default.HTTP_REQUEST_TIMEOUT.ToString();
            skinTextBox2.Text = Properties.Settings.Default.CLIENT_UPDATE_URL;
            skinTextBox3.Text = Properties.Settings.Default.WEIGHT_PRECISION.ToString();

            menuTabControl.SelectedIndex = 0;
            cargoWeightTextBox.Focus();

            bool updateLogRemind = Properties.Settings.Default.UPDATE_LOG_READ_YN;
            if (!updateLogRemind)
                MessageBox.Show(Properties.Settings.Default.UPDATE_LOG);
            Properties.Settings.Default.UPDATE_LOG_READ_YN = true;
            Properties.Settings.Default.Save();

            //SendKeys.SendWait("{TAB}");
        }

        private void weithtTabPrintBtn_Click(object sender, EventArgs e)
        {
            if (postWeightTabData())
                printLable();
        }

        private bool getShengXinInfoByShengXinNo()
        {
            string shengXinNo = shengXinNoEcTabTextBox.Text;
            if (shengXinNo.IsNullOrEmpty()) MessageBox.Show("运单号不可为空");
            else 
            {
               //MessageBox.Show( ShengXinAPI.getSagawaLableByShengXinNo(shengXinNo));
                CargoDetail cargoDtail = ShengXinAPI.getCargoDetailEc(shengXinNo);
                if (cargoDtail != null)
                {
                    //cargoWeightTextBox.Text = cargoDtail.weight;
                    cargoHeightTextBox.Text = cargoDtail.height;
                    cargoLengthTextBox.Text = cargoDtail.length;
                    cargoWidthTextBox.Text = cargoDtail.width;
                    return true;
                }
                else
                {
                    MessageBox.Show("未查到该单号任何信息!");
                }
            }
            return false;
        }
          
        private bool postWeightTabData()
        {
            //设定仅打印按钮 By Zhangsong
            if (onlyPrintCheckBoxEc.CheckState == CheckState.Checked)
                return true;
            
            Console.WriteLine(cargoWeightTextBox.Text);

            CargoDetail cargoDetail = new CargoDetail() { 
                weight = cargoWeightTextBox.Text.Trim(),
                height = cargoHeightTextBox.Text.Trim(),
                width = cargoWidthTextBox.Text.Trim(),
                length = cargoLengthTextBox.Text.Trim()
            };

            string shengXinNo = shengXinNoEcTabTextBox.Text.Trim() ;

            if (cargoDetail.isNull() || string.IsNullOrEmpty(shengXinNo)) 
                MessageBox.Show("请检查是否有空项!");
            else {
                bool flag = ShengXinAPI.postCargoInfoEc(cargoDetail, shengXinNo);
                if (!flag)
                    MessageBox.Show("更新货物信息失败!");
                else
                    return true;
            }
            return false;
        }

        private void printLable()
        {
            string shengXinNo = shengXinNoEcTabTextBox.Text.Trim();
            if (string.IsNullOrEmpty(shengXinNo)) MessageBox.Show("运单号不可为空!");
            else
            {
                string orderNo = shengXinLableControl1.getPageName() + "|" + shengXinNo;
                List<SagawaLabel> sagawaList = ShengXinAPI.getSagawaLableByShengXinNo(orderNo);
                if (sagawaList != null && sagawaList.Count > 0)
                {
                    foreach (var item in sagawaList)
                    {
                        if (item != null && onlyCustomsCheckBox.Checked == false)
                        {
                            switch (item.LabelType)
                            {
                                case "sagawa":
                                    ArgoxPrintUtil.SagawaLablePrint(item);
                                    break;
                                case "japanEmsBig":
                                    ArgoxPrintUtil.JapanEmsPrint(item);
                                    break;
                                case "japanEmsSmall":
                                    ArgoxPrintUtil.JapanEmsSmallPrint(item);
                                    break;
                                default: break;
                            }
                        }
                        //判断是否需要打印海关标签
                        if (item != null && (customsCheckBoxEc.Checked || onlyCustomsCheckBox.Checked))
                        {
                            if (eComCheckBoxEc.Checked)
                                item.eCommerce = "Y";
                            item.destination = desComboBoxEc.SelectedItem.ToString();
                            item.flightDate = flightDateTextBox.Text;
                            item.AgentSendCompany = item.AgentSendCompany+" 店铺";
                            ArgoxPrintUtil.CustomsPrint(item);
                        }
                    }
                    initEc();
                }

            }
        }

        private void weithtTabSearchBtn_Click(object sender, EventArgs e)
        {
            getShengXinInfoByShengXinNo();
        }

        private void shengXinNoTextBox_SkinTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //MessageBox.Show("enter");
                if (autoPrintCheckBoxEc.CheckState == CheckState.Checked)
                {
                    if (getShengXinInfoByShengXinNo())
                        if (postWeightTabData())
                            printLable();
                }
            }
        }

        private void menuTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (menuTabControl.SelectedIndex == 0) 
                cargoWeightTextBox.Focus();
            else if (menuTabControl.SelectedIndex == 1)
                shengXinNoGmTabTextBox.Focus();

            initEc();
            initGm();

        }

        private void shengXinNoGmTabTextBox_SkinTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                /*   //MessageBox.Show("enter");
                   if (autoPrintCheckBoxGm.CheckState == CheckState.Checked)
                   {
                       if (getShengXinInfoByShengXinNoGm())
                           if (postWeightTabDataGm())
                               printLableGm();
                   }*/
                printBtnGmTab.Focus();
                printBtnGmTab.PerformClick();
            }
        }



        private bool getShengXinInfoByShengXinNoGm()
        {
            string shengXinNo = shengXinNoGmTabTextBox.Text.Trim();
            if (string.IsNullOrEmpty(shengXinNo)) MessageBox.Show("运单号不可为空!");
            List<CargoDetail> cargoDetails = ShengXinAPI.getCargoDetailGm(shengXinNo);
            if (cargoDetails != null && cargoDetails.Count > 0)
            {
                gridViewGmTab.DataSource = cargoDetails;
                return true;
            }
            else
                MessageBox.Show("没有查找到该运单!");

            return false;
        }
        private bool postWeightTabDataGm()
        {
            //设定仅打印操作  By Zhangsong
            if (onlyPrintCheckBoxGm.CheckState == CheckState.Checked)
            {
                return true;
            }
            string shengXinNo = shengXinNoGmTabTextBox.Text.Trim();
            if (gridViewGmTab.Rows.Count > 0 && !string.IsNullOrEmpty(shengXinNo))
            {
                List<CargoDetail> cargoDetails = (List<CargoDetail>)gridViewGmTab.DataSource;

                //foreach (var item in cargoDetails)
                //{
                //    System.Diagnostics.Debug.WriteLine(item.height);
                //}

                bool flag = ShengXinAPI.postCargoInfoGm(cargoDetails, shengXinNo);
                if (flag)
                    return true;
                else MessageBox.Show("更新货物信息失败!");
            }
            else MessageBox.Show("请检查是否有空项!");
            return false;

            
        }

        private void printLableGm()
        {
             string shengXinNo = shengXinNoGmTabTextBox.Text.Trim();
            if (string.IsNullOrEmpty(shengXinNo)) MessageBox.Show("运单号不可为空!");
            else
            {
                string orderNo = shengXinLableControl2.getPageName() + "|" + shengXinNo;
                List<SagawaLabel> sagawaList = ShengXinAPI.getSagawaLableByShengXinNo(orderNo);
                if (sagawaList != null && sagawaList.Count > 0)
                {
                    foreach (var item in sagawaList)
                    {
                        if (item != null)
                        {
                            item.emptyStyle = "Y";
                            switch (item.LabelType)
                            {
                                case "sagawa":
                                    ArgoxPrintUtil.SagawaLablePrint(item);
                                    break;
                                case "japanEmsBig":
                                    ArgoxPrintUtil.JapanEmsPrint(item);
                                    break;
                                case "japanEmsSmall":
                                    ArgoxPrintUtil.JapanEmsSmallPrint(item);
                                    break;
                                default: break;
                            }
                        }
                    }
                    initGm();
                }

            }
        }


        private void initEc()
        {
            cargoWeightTextBox.Text = "";
            shengXinNoEcTabTextBox.Text = "";
            cargoLengthTextBox.Text = "30";
            cargoLengthTextBox.Text = "20";
            cargoHeightTextBox.Text = "1";
            cargoWeightTextBox.Focus();
        }

        private void initGm()
        {
            shengXinNoGmTabTextBox.Text = "";
            shengXinNoGmTabTextBox.Focus();
            gridViewGmTab.DataSource = null;
       }

        //离线打印重置单号,并聚焦  By Zhangsong
        private void initOffLIne()
        {
            offLineShengxinNoTextBox.Text = "";
            offLineShengxinNoTextBox.Focus();
        }


        private void GmTabSearchBtn_Click(object sender, EventArgs e)
        {
            getShengXinInfoByShengXinNoGm();
        }

        private void printBtnGmTab_Click(object sender, EventArgs e)
        {
            if (postWeightTabDataGm())
                printLableGm();
        }

        private void offlineTabOpenFileBtn_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                printPrivewOfflineTabLable.Text = "";
                string path = openFileDialog.FileName.ToString();//获取用户选择的文件完整路径
                offLineFileUrl.Text =  path;
                printOffline(path);
            }
        }

        private void printOffline(string path)
        {
            if (File.Exists(path))
            {
                offLineList = new List<SagawaLabel>();
                //如果文件存在读文件里的内容
                StreamReader lineText = new StreamReader(path, Encoding.UTF8);
                string line = "";
                while ((line = lineText.ReadLine()) != null)
                {
                    printPrivewOfflineTabLable.Text += line + "\n\n";
                    //System.Diagnostics.Debug.WriteLine(line);
                    SagawaLabel sagawaLabel = new SagawaLabel();
                    sagawaLabel.parsing(line);
                    offLineList.Add(sagawaLabel);
                }
                //取消自动打印,只保留读取文件操作  By Zhangsong
               /* if (offLineList != null && offLineList.Count > 0)
                    foreach (var item in offLineList)
                    {
                        if (item != null)
                        {
                            switch (item.LabelType)
                            {
                                case "sagawa":
                                    ArgoxPrintUtil.SagawaLablePrint(item);
                                    break;
                                default: break;
                            }
                        }
                    }*/

            }
            else
            {
                MessageBox.Show("文件不存在");
            }
        }

        private void offlineTabPrintBtn_Click(object sender, EventArgs e)
        {
            //取消打印全部，只打印满足条件的  By Zhangsong
            //printOffline(offLineFileUrl.Text.Trim());
            printOfflineByShengxinNo();//把离线打印的的操作分离到一个单独的方法中
            initOffLIne();

        }

        private void cargoLengthTextBox_SkinTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.';
        }

        private void cargoWidthTextBox_SkinTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.';
        }

        private void cargoHeightTextBox_SkinTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.';
        }

        private void cargoWeightTextBox_SkinTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.';
           
        }

        private void SettingTabSaveBtn_Click(object sender, EventArgs e)
        {
            string host = skinComboBox1.Text.Trim();
            string port = skinComboBox2.Text.Trim();
            int timeout = Int32.Parse(skinTextBox1.Text.Trim());
            string updateUrl = skinTextBox2.Text.Trim();
            int weightPrecision = Int32.Parse(skinTextBox3.Text.Trim());
            Properties.Settings.Default.API_SERVER_HOST = host;
            Properties.Settings.Default.API_SERVER_PORT = port;
            Properties.Settings.Default.HTTP_REQUEST_TIMEOUT = timeout;
            Properties.Settings.Default.CLIENT_UPDATE_URL = updateUrl;
            Properties.Settings.Default.WEIGHT_PRECISION = weightPrecision;
            Properties.Settings.Default.Save();

            MessageBox.Show("保存成功!");
        }

        private void cargoWeightTextBox_SkinTxt_TextChanged(object sender, EventArgs e)
        {
            string weight = cargoWeightTextBox.Text.Trim();
            if (!weight.IsNullOrEmpty())
            {
                int index = weight.IndexOf(".");
                if (index != -1 && weight.Substring(index + 1).Length >= Properties.Settings.Default.WEIGHT_PRECISION)
                {
                    shengXinNoEcTabTextBox.Focus();
                }
            }

        }


        private void printOfflineByShengxinNo()
        {
            String shengxinNo = offLineShengxinNoTextBox.Text;
            String sagawaNo = "A" + shengxinNo + "A";
            if (shengxinNo == null)
            {
                MessageBox.Show("请输入运单号!");
            }
            else
            {
                if (offLineList != null && offLineList.Count > 0)
                {
                    foreach (var item in offLineList)
                    {
                        if (item != null)
                        {
                            if (string.Equals(item.CnPackNum, shengxinNo))
                            {
                                switch (item.LabelType)
                                {
                                    case "sagawa":
                                        ArgoxPrintUtil.SagawaLablePrint(item);
                                        break;
                                    default: break;
                                }
                            }
                            else if (string.Equals(item.JpPackNum, sagawaNo))
                            {
                                switch (item.LabelType)
                                {
                                    case "sagawa":
                                        ArgoxPrintUtil.SagawaLablePrint(item);
                                        break;
                                    default: break;
                                }
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("文件未打开!");
                }
            }
        }

        private void offLineShengxinNoTextBox_SkinTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                printOfflineByShengxinNo();
                initOffLIne();
            }
        }

        private void shengXinLableControl2_Load(object sender, EventArgs e)
        {

        }
    }
}
