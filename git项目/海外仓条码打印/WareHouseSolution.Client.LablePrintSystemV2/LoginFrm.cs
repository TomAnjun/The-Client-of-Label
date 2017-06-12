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
    public partial class LoginFrm : Form
    {
        public LoginFrm()
        {
            InitializeComponent();
        }

        public static string BaseUrl =
          Properties.Settings.Default.API_SERVER_HOST
          + ":"
          + Properties.Settings.Default.API_SERVER_PORT;

        private void closeClick(object sender, EventArgs e)
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

        private void loginBtnClick(object sender, EventArgs e)
        {
            string userId = userIdTextBox.Text.Trim();
            string userPwd = MD5(userPwdTextBox.Text.Trim()).ToLower();
            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(userPwd))
            {
                MessageBox.Show("账户名或密码不可为空");
                new MainFrm().ShowDialog();
            }
            else
            {
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
                        new MainFrm().ShowDialog();
                    }
                    else MessageBox.Show(result.errMsg);

                }
                catch (Exception)
                {
                    MessageBox.Show("登陆失败");
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private Point offset; 

        private void LoginFrm_MouseDown(object sender, MouseEventArgs e)
        {
            if (MouseButtons.Left != e.Button) return;
            Point cur = this.PointToScreen(e.Location);
            offset = new Point(cur.X - this.Left, cur.Y - this.Top); 
        }

        private void LoginFrm_MouseMOve(object sender, MouseEventArgs e)
        {
            if (MouseButtons.Left != e.Button) return;
            Point cur = MousePosition;
            this.Location = new Point(cur.X - offset.X, cur.Y - offset.Y);  
        }
    }
}
