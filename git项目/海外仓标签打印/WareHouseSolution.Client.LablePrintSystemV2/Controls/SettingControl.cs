using System;
using System.Deployment.Application;
using System.Windows.Forms;

namespace WareHouseSolution.Client.LablePrintSystem.Controls
{
    public partial class SettingControl : UserControl
    {
        public SettingControl()
        {
            InitializeComponent();
            hostTextBox.Text = Properties.Settings.Default.API_SERVER_HOST;
            portTextBox.Text = Properties.Settings.Default.API_SERVER_PORT;
            timeoutTextBox.Text = Properties.Settings.Default.HTTP_REQUEST_TIMEOUT.ToString();
            updateUrlTextBox.Text = Properties.Settings.Default.CLIENT_UPDATE_URL;
            precisionTextBox.Text = Properties.Settings.Default.WEIGHT_PRECISION.ToString();
            defaultLTextBox.Text = Properties.Settings.Default.DEFAULT_LENGTH.ToString();
            defaultWTextBox.Text = Properties.Settings.Default.DEFAULT_WIDTH.ToString();
            defaultHTextBox.Text = Properties.Settings.Default.DEFAULT_HEIGHT.ToString();
            
        }

        private void UpdateButton_Click(object sender, System.EventArgs e)
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
                else
                {
                    MessageBox.Show("当前已是最新版本.");
                }
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.API_SERVER_HOST = hostTextBox.Text.Trim();
            Properties.Settings.Default.API_SERVER_PORT = portTextBox.Text.Trim();
            Properties.Settings.Default.HTTP_REQUEST_TIMEOUT = int.Parse(timeoutTextBox.Text.Trim());
            Properties.Settings.Default.CLIENT_UPDATE_URL = updateUrlTextBox.Text.Trim();
            Properties.Settings.Default.WEIGHT_PRECISION = int.Parse(precisionTextBox.Text.Trim());
            Properties.Settings.Default.DEFAULT_LENGTH = decimal.Parse(defaultLTextBox.Text.Trim());
            Properties.Settings.Default.DEFAULT_WIDTH = decimal.Parse(defaultWTextBox.Text.Trim());
            Properties.Settings.Default.DEFAULT_HEIGHT = decimal.Parse(defaultHTextBox.Text.Trim());
            Properties.Settings.Default.Save();

            MessageBox.Show("保存成功,请重启应用程序使其生效");
        }
    }
}
