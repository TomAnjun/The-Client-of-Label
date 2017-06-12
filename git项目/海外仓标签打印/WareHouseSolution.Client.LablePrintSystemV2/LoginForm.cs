using CCWin;
using RestSharp;
using WareHouseSolution.Client.LablePrintSystem.Models;
using WareHouseSolution.Client.LablePrintSystem.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace WareHouseSolution.Client.LablePrintSystem
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        public static string BaseUrl =
          Properties.Settings.Default.API_SERVER_HOST
          + ":"
          + Properties.Settings.Default.API_SERVER_PORT;

        private void userPwdTextBox_SkinTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loginBtn_Click(sender, e);
            }
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            string userId = userIdTextBox.Text.Trim();
            string userPwd = MD5(userPwdTextBox.Text.Trim()).ToLower();
            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(userPwd)){
                MessageBox.Show("请输入用户名和密码！");
                new IndexForm1().ShowDialog();
            }
            else
            {
                LoginInfo.user_id = userId;
                var client = new RestClient(BaseUrl);
                var request = new RestRequest
                {
                    Method = Method.POST,
                    Resource = "/v1/api/user/accessToken.json?user_id=" + userId + "&user_pw=" + userPwd + "&remeber_me=N"
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
                        new IndexForm1().ShowDialog();
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
                WhApi.logOut();
            }
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        //md5加密
        public static string MD5(string encryptString)
        {
            byte[] result = Encoding.Default.GetBytes(encryptString);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] output = md5.ComputeHash(result);
            string encryptResult = BitConverter.ToString(output).Replace("-", "");
            return encryptResult;
        }
    }
}
