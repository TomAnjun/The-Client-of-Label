using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using CCWin.SkinControl;
using WareHouseSolution.Client.LablePrintSystem.Utils;
using WareHouseSolution.Client.LablePrintSystem.Models;

namespace WareHouseSolution.Client.LablePrintSystem.Controls
{
    public partial class ProductControl : UserControl
    {
        public ProductControl()
        {
            InitializeComponent();
        }

        private void orderNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            if (orderNoTextBox.Text.Trim().IsNullOrEmpty())
            {
                MessageBox.Show("请输入订单号");
                return;
            }
            //如果输入回车跳转到输入商品编码输入框
            productCodeTextBox.Focus();
        }

        private void productCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            if (productCodeTextBox.Text.Trim().IsNullOrEmpty())
            {
                MessageBox.Show("请输入商品编码");
                return;
            }
        }

        private void printBtn_Click(object sender, EventArgs e)
        {
            String order_no = orderNoTextBox.Text.Trim();
            String product_code = productCodeTextBox.Text.Trim();
            List<String> productRegNo = WhApi.GetProductRegNo(order_no,product_code);
            //打印商品登记号，每次打印两个
            if (productRegNo != null && productRegNo.Count > 0) {
                for (int i = 0; i < productRegNo.Count; i += 2)
                {
                    string rightNum = "";
                    string leftNum = productRegNo[i];
                    if (i < productRegNo.Count - 1)
                        rightNum = productRegNo[i + 1];
                    PrintLabel.BarcodePrint(leftNum, rightNum);
                }
            }
        }
    }
}
