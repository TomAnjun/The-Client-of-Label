using CCWin;
using RestSharp;
using ShengXinSolution.Client.LablePrintSystemV2.Models;
using ShengXinSolution.Client.LablePrintSystemV2.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ShengXinSolution.Client.LablePrintSystemV2
{
    public partial class Login : CCSkinMain
    {
        public Login()
        {
            InitializeComponent();
        }

        public static string BaseUrl =
          Properties.Settings.Default.API_SERVER_HOST
          + ":"
          + Properties.Settings.Default.API_SERVER_PORT;

        private void loginBtn_Click(object sender, EventArgs e)
        {
            string userId = userIdTextBox.Text.Trim();
            string userPwd = userPwdTextBox.Text.Trim();

            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(userPwd))
                MessageBox.Show("用户名或密码不能为空！");
            else
            {
                var client = new RestClient(BaseUrl);
                var request = new RestRequest
                {
                    Method = Method.POST,
                    Resource = "/v1/api/user/access-token.json?user_id=" + userId + "&user_pw=" + userPwd + "&remeber_me=N"
                };

                client.Timeout = Properties.Settings.Default.HTTP_REQUEST_TIMEOUT;
                request.ReadWriteTimeout = Properties.Settings.Default.HTTP_REQUEST_TIMEOUT;

                var resData = client.Execute(request).Content;
                try
                {
                    var result = ApiHelper.DeserializeJson<DurianResult<Success<AccessToken>>>(resData);

                    if (result.errCd == 0 && result.result.success)
                    {
                        Properties.Settings.Default.ACCESS_TOKEN = result.result.result.access_token;
                        Properties.Settings.Default.Save();
                        this.Dispose();
                        new IndexForm().ShowDialog();
                    }
                    else MessageBox.Show(result.errMsg);

                }
                catch (Exception)
                {
                    MessageBox.Show("登陆失败");
                }
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            string accessToken = Properties.Settings.Default.ACCESS_TOKEN;
            if (!string.IsNullOrEmpty(accessToken))
            {
                SxApi.logOut();
               //this.Close();
               //new MainForm().ShowDialog();
            }
        }

        private void userPwdTextBox_SkinTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loginBtn_Click(sender, e);
            }
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

    }
}
