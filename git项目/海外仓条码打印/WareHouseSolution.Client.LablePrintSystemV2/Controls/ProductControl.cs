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
            if (waybillNOTextBox.Text.Trim().IsNullOrEmpty())
            {
                MessageBox.Show("请输入订单号");
                return;
            }
            //如果输入回车跳转到输入商品编码输入框
            productRegCodeTextBox.Focus();
        }

        private void productCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            if (productRegCodeTextBox.Text.Trim().IsNullOrEmpty())
            {
                MessageBox.Show("请输入商品编码");
                return;
            }
        }

        private void printBtn_Click(object sender, EventArgs e)
        {
            String waybill_no = waybillNOTextBox.Text.Trim();
            String product_reg_code = productRegCodeTextBox.Text.Trim();
            String endRegNo = endRegNoTextBox.Text.Trim();
            List<ProductRegInfo> productRegNo = WhApi.GetProductRegNo(waybill_no, product_reg_code, endRegNo);
            //打印商品登记号，每次打印两个
            if (productRegNo != null && productRegNo.Count > 0) {
                for (int i = 0; i < productRegNo.Count; i += 2)
                {
                    ProductRegInfo leftProductReg = productRegNo[i];
                    string rightNum = "";
                    string rightComCode = "";
                    string leftNum = leftProductReg.product_reg_code;
                    string leftComCode = leftProductReg.company_product_code;
                    if (i < productRegNo.Count - 1) {
                        ProductRegInfo rightProductReg = productRegNo[i + 1];
                        rightComCode = productRegNo[i + 1].company_product_code;
                        rightNum = productRegNo[i + 1].product_reg_code;
                    }
                    PrintLabel.ProductRegNoBarcodePrint(leftNum, rightNum, leftComCode, rightComCode);
                }
                PrintLabel.ProductRegNoBarcodePrint("", "", "", "");
            }
            MessageBox.Show("条码打印完成。");
            Init();
        }

        //初始化
        private void Init() {
            waybillNOTextBox.Text = "";
            productRegCodeTextBox.Text = "";
            endRegNoTextBox.Text = "";
            waybillNOTextBox.Focus();
        }
    }
}
