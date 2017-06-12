using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using CCWin.SkinControl;
using ShengXinSolution.Client.LablePrintSystemV2.Models;
using ShengXinSolution.Client.LablePrintSystemV2.Utils;

namespace ShengXinSolution.Client.LablePrintSystemV2.Controls
{
    public partial class IndexControl : UserControl
    {
        private static DataTable dataTable;

        public IndexControl()
        {
            InitializeComponent();
        }

        private void IndexControl_Load(object sender, EventArgs e)
        {
            //初始化快递公司信息
            var expressRows = SxApi.PostJpExpressInfos();
            if (!expressRows.IsNull())
                expressDataGrid.DataSource = expressRows;
            dataTable = new DataTable();
            dataTable.Columns.Add("waybill_id");
            //载入默认长宽高
            lengthTextBox.Text = Properties.Settings.Default.DEFAULT_LENGTH.ToString();
            widthTextBox.Text = Properties.Settings.Default.DEFAULT_WIDTH.ToString();
            heightTextBox.Text = Properties.Settings.Default.DEFAULT_HEIGHT.ToString();
        }

        //打印标签
        private void OnlineLogic()
        {
            //更新当前包裹号对应包裹信息
            var waybillNo = numTextBox.Text.Trim();
            string jpExpSecId = null;
            string excludePackaged = "N";
            string expressCompany = null;
            string store = null;
            var packageInfo = new PackageInfo();
            if (printLabelCheckBox.Checked && expressDataGrid.RowCount > 0 && expressDataGrid.SelectedRows[0] != null)
            {
                jpExpSecId = expressDataGrid.SelectedRows[0].Cells[0].Value.ToString();
                expressCompany = expressDataGrid.SelectedRows[0].Cells[1].Value.ToString();
                store = expressDataGrid.SelectedRows[0].Cells[3].Value.ToString();
            }
            if (packageCheckBox.Checked)
            {
                packageInfo.waybill_id = waybillNo;
                packageInfo.package_id = "1";
                packageInfo.package_size_l = lengthTextBox.Text;
                packageInfo.package_size_w = widthTextBox.Text;
                packageInfo.package_size_h = heightTextBox.Text;
                if (weightTextBox.Text.IsNullOrEmpty())
                {
                    MessageBox.Show("包裹尚未称重！");
                    InitControl();
                    return;
                }
                packageInfo.package_weight = weightTextBox.Text;
            }
            else
                packageInfo = null;
            //更新包裹数据，获取运单信息
            var waybillInfo = SxApi.PostWaybillInfos(waybillNo, packageInfo, jpExpSecId, excludePackaged);
            if (waybillInfo.IsNull() || waybillInfo.packages.IsNull())
            {
                MessageBox.Show("未查询到包裹信息！");
                InitControl();
                return;
            }
            //显示packages详情
            packagesDataGrid.DataSource = waybillInfo.packages;
            if (printLabelCheckBox.Checked)
            {
                AddExtraInfo(waybillInfo, store);
                for (var pacIndex = 0; pacIndex < waybillInfo.packages.Count; pacIndex++)
                {
                    switch (expressCompany)
                    {
                        case "SAGAWA":
                            PrintLabel.SagawaLablePrint(waybillInfo, pacIndex);
                            break;
                        case "JP_EMS":
                            PrintLabel.JapanEmsPrint(waybillInfo, pacIndex);
                            break;
                        case "JP_EMS_SMALL":
                            PrintLabel.JapanEmsSmallPrint(waybillInfo, pacIndex);
                            break;
                        case "SAGAWA_HIKIYAKU":
                            PrintLabel.Test(0);
                            break;
                        case "YAMATO":
                            PrintLabel.YamatoLablePrint(waybillInfo, pacIndex);
                            break;
                        case "SAGAWA_BBC":
                            PrintLabel.SagawaBBCLablePrint(waybillInfo, pacIndex);
                            break;
                        case "SAGAWA_SUK":
                            PrintLabel.SagawaSUKLablePrint(waybillInfo, pacIndex);
                            break;
                    }
                    packagesDataGrid.Rows[pacIndex].Selected = true;
                    packagesDataGrid.Refresh();
                }
            }
            //初始化控件，跳转焦点
            InitControl();
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
            OnlineLogic();
        }

        private void weightTextBox_TextChanged(object sender, EventArgs e)
        {
            var weightStr = weightTextBox.Text.Trim();
            if (weightStr.IsNullOrEmpty()) return;
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

        //初始化控件
        private void InitControl()
        {
            weightTextBox.Text = "";
            numTextBox.Text = "";
            //载入默认长宽高
            lengthTextBox.Text = Properties.Settings.Default.DEFAULT_LENGTH.ToString();
            widthTextBox.Text = Properties.Settings.Default.DEFAULT_WIDTH.ToString();
            heightTextBox.Text = Properties.Settings.Default.DEFAULT_HEIGHT.ToString();
            if (packageCheckBox.Checked)
            {
                weightTextBox.Parent.Select();
                weightTextBox.Focus();
            }
            else
            {
                numTextBox.Parent.Select();
                numTextBox.Focus();
            }
        }

        //增加额外信息
        private void AddExtraInfo(WaybillInfo waybillInfo, string store)
        {
            //着店号-条码
            if (!waybillInfo.fandi_no_big.IsNullOrEmpty() && waybillInfo.fandi_no_big.Trim().Length < 4)
            {
                var tmpFandiNoBig = waybillInfo.fandi_no_big.Trim();
                var len = waybillInfo.fandi_no_big.Trim().Length;
                for (var i = 0; i < 4 - len; i++)
                    tmpFandiNoBig = "$" + tmpFandiNoBig;
                waybillInfo.ArrivalShopNo = "C" + tmpFandiNoBig + waybillInfo.fandi_no_small + "D";
            }
            else
                waybillInfo.ArrivalShopNo = "C" + waybillInfo.fandi_no_big + waybillInfo.fandi_no_small + "D";
            //配送会社信息
            switch (store)
            {
                case "NRT":
                    waybillInfo.StoreHouseShort = "成田店";
                    waybillInfo.StoreHouseTel = "0476-49-7727";
                    waybillInfo.StoreHouseFax = "";
                    waybillInfo.StoreHouseCd = "7054";
                    waybillInfo.StoreCompanyTel = "0476-49-7727";
                    waybillInfo.StoreCompanyFax = "0476-35-6194";
                    waybillInfo.StoreHouseLong = "エムオーエアロジスティックス(株)/SX  成田営業所";
                    break;
                case "OSK":
                    waybillInfo.StoreHouseShort = "佐川急便(株)りんくう";
                    waybillInfo.StoreHouseTel = "072-458-1500";
                    waybillInfo.StoreHouseFax = "";
                    waybillInfo.StoreHouseCd = "3104";
                    waybillInfo.StoreCompanyTel = "06-6777-1823";
                    waybillInfo.StoreCompanyFax = "06-6777-1824";
                    waybillInfo.StoreHouseLong = "HYジャパンエクスプレス(株)/SX  岸和田営業所";
                    break;
                case "TOKYO":
                    waybillInfo.StoreHouseShort = "东京店";
                    waybillInfo.StoreHouseTel = "东京电话";
                    waybillInfo.StoreHouseFax = "东京传真";
                    waybillInfo.StoreHouseCd = "东京出荷场";
                    waybillInfo.StoreCompanyTel = "会社电话";
                    waybillInfo.StoreCompanyFax = "会社传真";
                    waybillInfo.StoreHouseLong = "エムオーエアロジスティックス(株)/SX  东京営業所";
                    break;
                case "SUK":
                    waybillInfo.StoreHouseShort = "未知";
                    waybillInfo.StoreHouseTel = "";
                    waybillInfo.StoreHouseFax = "";
                    waybillInfo.StoreHouseCd = "";
                    waybillInfo.StoreCompanyTel = "81-476356118";
                    waybillInfo.StoreCompanyFax = "81-476356194";
                    waybillInfo.StoreHouseLong = "エムオーエアロジスティックス（株式会社）";
                    break;
                default:
                    waybillInfo.StoreHouseShort = "默认店";
                    waybillInfo.StoreHouseTel = "默认电话";
                    waybillInfo.StoreHouseFax = "默认传真";
                    waybillInfo.StoreHouseCd = "默认出荷场";
                    waybillInfo.StoreCompanyTel = "默认会社电话";
                    waybillInfo.StoreCompanyFax = "默认会社传真";
                    waybillInfo.StoreHouseLong = "エムオーエアロジスティックス(株)/SX  默认営業所";
                    break;
            }
        }
    }
}
