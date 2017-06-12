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
    public partial class OrderInfoControl : UserControl
    {
        //订单号
        private String order_no;
        //登记号List
        private List<String> product_regno_list;
        //出库商品信息List
        private List<ProductInfo> productsInfo_list;

        public OrderInfoControl()
        {
            InitializeComponent();
            numTextBox.Focus();
        }

        private void heightTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.';
        }

        private void widthTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.';
        }

        private void lengthTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.';
        }

        private void numTextBox_SkinTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            if (numTextBox.Text.Trim().IsNullOrEmpty())
            {
                MessageBox.Show("请输入订单号");
                return;
            }
            var product_order_no = numTextBox.Text.Trim();
            productRegNoTextBox.Text = null;
            var orderInfo = WhApi.PostOrderInfos(product_order_no);
            if (orderInfo != null)
            {
                productsDataGrid.DataSource = orderInfo.products;
                productRegNoTextBox.Focus();
                product_regno_list = new List<string>();
                productsInfo_list = new List<ProductInfo>();
                order_no = numTextBox.Text.Trim();
            }
            else
            {
                productRegNoTextBox.Focus();
                numTextBox.Focus();
            }
            if (expressDataGrid.SelectedRows.Count != 0)
            {
                //快递公司默认不选中
                expressDataGrid.SelectedRows[0].Selected = false;
            }
        }



        private void weightTextBox_TextChanged(object sender, EventArgs e)
        {
            var weightStr = weightTextBox.Text.Trim();
            if (weightStr == null) return;
            var index = weightStr.IndexOf(".", StringComparison.Ordinal);
            if (index != -1 && weightStr.Substring(index + 1).Length >= Properties.Settings.Default.WEIGHT_PRECISION)
            {
                numTextBox.Focus();
            }
        }

        private void weightTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                numTextBox.Focus();
            }

            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.';
        }

        //初始化
        private void InitControl()
        {
            weightTextBox.Text = "";
            numTextBox.Text = "";
            numTextBox.Parent.Select();
            numTextBox.Focus();
        }

        //在线打印
        private Boolean OnlineLogic()
        {
            var product_order_no = numTextBox.Text.Trim();
            string jpExpSecId = null;
            string expressCompany = null;
            string store = null;
            //获取订单详情
            var orderInfo = WhApi.PostOrderInfos(product_order_no);
            var pacIndex = 0;
            //不能打印出库状态的订单
            if (orderInfo.delivery_state.Equals("24"))
            {
                MessageBox.Show("打印出库失败。（订单状态错误）");
                InitControl();
                return false;
            }
            if (orderInfo.IsNull())
            {
                InitControl();
            }
            else if (orderInfo.products.IsNull() || orderInfo.products.Count == 0)
            {
                MessageBox.Show("没查询到订单的商品信息。");
            }
            else
            {
                //判断是否有日本号，如果有直接打印，如果没有先分配日本号再打印
                if (orderInfo.jp_express_no.IsNullOrEmpty())
                {
                    //判断是否有默认快递公司
                    if (orderInfo.jp_express_section_id.IsNullOrEmpty() || orderInfo.products.Count > 1)
                    {
                        if (jpExpSecId.IsNullOrEmpty() && expressDataGrid.SelectedRows.Count == 0)
                        {
                            MessageBox.Show("请选择快递公司再进行操作。");
                            return false;
                        }
                        else
                        {
                            if (expressDataGrid.SelectedRows.Count != 0)
                            {
                                jpExpSecId = expressDataGrid.SelectedRows[0].Cells[0].Value.ToString();
                                store = expressDataGrid.SelectedRows[0].Cells[3].Value.ToString();
                                expressCompany = expressDataGrid.SelectedRows[0].Cells[1].Value.ToString();
                            }
                            if (WhApi.DistributionJpNo(product_order_no, jpExpSecId))
                            {
                                orderInfo = WhApi.PostOrderInfos(product_order_no);
                            }
                        }
                    }
                    else
                    {
                        if (WhApi.DistributionJpNo(product_order_no, orderInfo.jp_express_section_id))
                        {
                            orderInfo = WhApi.PostOrderInfos(product_order_no);
                            expressCompany = orderInfo.jp_express_company;
                            store = orderInfo.city_code;

                        }
                    }
                }
                else
                {
                    store = orderInfo.city_code;
                    expressCompany = orderInfo.jp_express_company;
                }
                for (int c = 0; c < orderInfo.products.Count; c++)
                {
                    if (orderInfo.products[c].check_flag.Equals("N"))
                    {
                        MessageBox.Show("商品[" + orderInfo.products[c].product_code + "]，未审查派送公司。操作失败！");
                        return false;
                    }
                }
                //添加额外信息
                AddExtraInfo(orderInfo, store);
                switch (expressCompany)
                {
                    case "SAGAWA":
                        PrintLabel.OWHSagawaLablePrint(orderInfo, pacIndex);
                        break;
                    case "JP_EMS":
                        PrintLabel.JapanEmsPrint(orderInfo, pacIndex);
                        break;
                    case "JP_EMS_SMALL":
                        PrintLabel.JapanEmsSmallPrint(orderInfo, pacIndex);
                        break;
                    case "SAGAWA_HIKIYAKU":
                        PrintLabel.SagawaHikiyakuPrint(orderInfo, pacIndex);
                        break;
                    case "YAMATO":
                        PrintLabel.YamatoLablePrint(orderInfo, pacIndex);
                        break;
                }
            }
            return true;
        }

        //离线打印
        private void OfflineLogic()
        {
            MessageBox.Show("未开发");
        }

        //添加打印标签额外信息
        private void AddExtraInfo(OrderInfo orderInfo, string store)
        {
            //着店号-条码
            if (!orderInfo.fandi_no_big.IsNullOrEmpty() && orderInfo.fandi_no_big.Trim().Length < 4)
            {
                var tmpFandiNoBig = orderInfo.fandi_no_big.Trim();
                var len = orderInfo.fandi_no_big.Trim().Length;
                for (var i = 0; i < 4 - len; i++)
                    tmpFandiNoBig = "$" + tmpFandiNoBig;
                orderInfo.ArrivalShopNo = "C" + tmpFandiNoBig + orderInfo.fandi_no_small + "D";
            }
            else
                orderInfo.ArrivalShopNo = "C" + orderInfo.fandi_no_big + orderInfo.fandi_no_small + "D";
            //配送会社信息
            switch (store)
            {
                case "NRT":
                    orderInfo.StoreHouseShort = "成田店";
                    orderInfo.StoreHouseTel = "0476-49-7727";
                    orderInfo.StoreHouseFax = "";
                    orderInfo.StoreHouseCd = "7054";
                    orderInfo.StoreCompanyTel = "0476-35-6180";
                    //orderInfo.StoreCompanyTel = "0476-49-7727";
                    orderInfo.StoreCompanyFax = "0476-35-6194";
                    orderInfo.StoreHouseLong = "エムオーエアロジスティックス(株)/MO  通販倉庫";
                    //orderInfo.StoreHouseLong = "エムオーエアロジスティックス(株)/SX  成田営業所";
                    break;
                case "OSK":
                    orderInfo.StoreHouseShort = "佐川急便(株)りんくう";
                    orderInfo.StoreHouseTel = "072-458-1500";
                    orderInfo.StoreHouseFax = "";
                    orderInfo.StoreHouseCd = "3104";
                    orderInfo.StoreCompanyTel = "0476-35-6180";
                    orderInfo.StoreCompanyFax = "06-6777-1824";
                    orderInfo.StoreHouseLong = "HYジャパンエクスプレス(株)/MO  通販倉庫";
                    break;
                case "TOKYO":
                    orderInfo.StoreHouseShort = "东京店";
                    orderInfo.StoreHouseTel = "东京电话";
                    orderInfo.StoreHouseFax = "东京传真";
                    orderInfo.StoreHouseCd = "东京出荷场";
                    orderInfo.StoreCompanyTel = "会社电话";
                    orderInfo.StoreCompanyFax = "会社传真";
                    orderInfo.StoreHouseLong = "エムオーエアロジスティックス(株)/MO  通販倉庫";
                    break;
                default:
                    orderInfo.StoreHouseShort = "默认店";
                    orderInfo.StoreHouseTel = "默认电话";
                    orderInfo.StoreHouseFax = "默认传真";
                    orderInfo.StoreHouseCd = "默认出荷场";
                    orderInfo.StoreCompanyTel = "默认会社电话";
                    orderInfo.StoreCompanyFax = "默认会社传真";
                    orderInfo.StoreHouseLong = "エムオーエアロジスティックス(株)/MO  通販倉庫";
                    break;
            }
        }

        private void OrderInfoControl_Load(object sender, EventArgs e)
        {
            //初始化快递公司信息
            var expressRows = WhApi.PostJpExpressInfos();
            if (!expressRows.IsNull())
                expressDataGrid.DataSource = expressRows;
        }

        private void OutStockBtn_Click(object sender, EventArgs e)
        {

        }

        private void productRegNoTextBox_SkinTxt_KeyDown(object sender, KeyEventArgs e)
        {
            Boolean flag = false;
            if (e.KeyCode != Keys.Enter) return;
            if (numTextBox.Text.Trim().IsNullOrEmpty())
            {
                MessageBox.Show("请输入登记号");
                return;
            }
            if (productRegNoTextBox.Text.Trim().ToString().Length < 8)
            {
                DialogResult dr = MessageBox.Show("请输入合法的登记号(至少8位)");
                InitProductRegTextBox(dr);
                return;
            }
            //限制登记号
            for (var i = 0; i < productsDataGrid.RowCount; i++)
            {
                if (productsDataGrid.Rows[i].Cells[0].Value.ToString() == productRegNoTextBox.Text.Trim().ToString().Substring(0, 8))
                {
                    flag = true;
                }
            }
            if (!flag)
            {
                DialogResult dr = MessageBox.Show("登记号[" + productRegNoTextBox.Text.Trim().ToString() + "]有错（无法匹配对应商品）");
                InitProductRegTextBox(dr);
                return;
            }
            //限制登记号不能重复
            if (product_regno_list != null)
            {
                for (var i = 0; i < product_regno_list.Count; i++)
                {
                    if (product_regno_list[i].ToString() == productRegNoTextBox.Text.Trim().ToString())
                    {
                        DialogResult dr = MessageBox.Show("商品号[" + product_regno_list[i].ToString() + "]重复，请注意");
                        InitProductRegTextBox(dr);
                        return;
                    }
                }
            }
            for (var i = 0; i < productsDataGrid.RowCount; i++)
            {
                if (productsDataGrid.Rows[i].Cells[0].Value.ToString() == productRegNoTextBox.Text.Trim().ToString().Substring(0, 8))
                {
                    if (Convert.ToInt32(productsDataGrid.Rows[i].Cells[7].Value) >= Convert.ToInt32(productsDataGrid.Rows[i].Cells[6].Value))
                    {
                        DialogResult dr = MessageBox.Show("商品[" + productsDataGrid.Rows[i].Cells[0].Value + "]已达到数量，请勿再次扫描。");
                        InitProductRegTextBox(dr);
                        return;
                    }
                    else
                    {
                        productsDataGrid.Rows[i].Cells[7].Value = Convert.ToInt32(productsDataGrid.Rows[i].Cells[7].Value) + 1;
                    }
                    product_regno_list.Add(productRegNoTextBox.Text.Trim().ToString());
                }
            }
            InitProductRegTextBox();
        }

        //初始化登记号输入框(非正常)
        private void InitProductRegTextBox(DialogResult dr)
        {
            if (dr == DialogResult.OK)
            {
                productRegNoTextBox.Text = "";
                //跳转焦点问题，暂时没有找到比较好的方法解决，暂时这样先
                weightTextBox.Focus();
                productRegNoTextBox.Focus();
            }
        }

        //初始化登记号输入框(正常)
        private void InitProductRegTextBox()
        {
            productRegNoTextBox.Text = "";
            //跳转焦点问题，暂时没有找到比较好的方法解决，暂时这样先
            weightTextBox.Focus();
            productRegNoTextBox.Focus();
        }

        private void printButton_Click(object sender, EventArgs e)
        {


        }

        private void outStockButton_Click(object sender, EventArgs e)
        {
            //打印标签
            if (OnlineLogic())
            {
                //向后台传入扫描商品信息
                for (var i = 0; i < productsDataGrid.RowCount; i++)
                {
                    ProductInfo product = new ProductInfo();
                    product.product_code = productsDataGrid.Rows[i].Cells[0].Value.ToString();
                    product.scanned_no = productsDataGrid.Rows[i].Cells[7].Value.ToString();
                    product.product_amount = productsDataGrid.Rows[i].Cells[6].Value.ToString();
                    productsInfo_list.Add(product);
                }
                //出库操作
                Boolean flag = WhApi.StockOut(order_no, Newtonsoft.Json.JsonConvert.SerializeObject(productsInfo_list), Newtonsoft.Json.JsonConvert.SerializeObject(product_regno_list));

                if (flag)
                {
                    MessageBox.Show("出库成功。");
                    //初始化
                    InitControl();
                }
                else
                {
                    //初始化
                    InitControl();
                }
            };
        }
    }
}
