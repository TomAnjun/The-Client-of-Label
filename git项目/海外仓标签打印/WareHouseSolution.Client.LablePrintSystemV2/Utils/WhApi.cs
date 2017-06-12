//文件名         WhApi.cs
//
//作者           anjun
//
//日期           2016-07-12
//
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CCWin.SkinControl;
using Newtonsoft.Json;
using WareHouseSolution.Client.LablePrintSystem.Models;
namespace WareHouseSolution.Client.LablePrintSystem.Utils
{
    class WhApi
    {
        //获取快递号段信息
        public static List<JpExpressInfo> PostJpExpressInfos()
        {
            List<JpExpressInfo> expressRows = null;
            var resData = ApiHelper.Post("/v1/api/sys-conf/jpexpress/jpexpresses.json?page=1&rows=100", null);
            try
            {
                var durianJson = ApiHelper.DeserializeJson<DurianResult<Grid<JpExpressInfo>>>(resData);
                if (durianJson.errCd == 0)
                    expressRows = durianJson.result.rows;
                else
                {
                    MessageBox.Show(durianJson.errMsg);
                    if (durianJson.errCd == -600 || durianJson.errCd == -601)
                    {
                        Properties.Settings.Default.ACCESS_TOKEN = "";
                        Properties.Settings.Default.Save();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("快递公司信息解析错误.");
            }

            return expressRows;
        }

        //获取打印标签所需数据
        public static OrderInfo PostOrderInfos(string orderNo)
        {
            OrderInfo orderInfo = null;
            var resData = ApiHelper.Post("/v1/api/print/order-label.json?product_order_no=" + orderNo, null);
            try
            {
                var durianJson = ApiHelper.DeserializeJson<DurianResult<OrderInfo>>(resData);
                if (durianJson.errCd == 0)
                    orderInfo = durianJson.result;
                else
                {
                    MessageBox.Show(durianJson.errMsg);
                    if (durianJson.errCd == -600 || durianJson.errCd == -601)
                    {
                        Properties.Settings.Default.ACCESS_TOKEN = "";
                        Properties.Settings.Default.Save();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("数据解析错误.");
            }

            return orderInfo;
        }

        //分配日本号
        public static Boolean DistributionJpNo(String order_no, String sectionId, String operation_flag = "distribution")
        {
            var resData = ApiHelper.Post("/v1/api/delivery/district-jpnos.json?product_order_nos=[\"" + order_no + "\"]&jp_express_section_id=" + sectionId + "&operation_flag=" + operation_flag, null);
            var durianJson = ApiHelper.DeserializeJson<DurianResult<Success<String>>>(resData);
            if (durianJson.errCd == 0) return true;
            else
            {
                MessageBox.Show(durianJson.errMsg);
                if (durianJson.errCd == -600 || durianJson.errCd == -601)
                {
                    Properties.Settings.Default.ACCESS_TOKEN = "";
                    Properties.Settings.Default.Save();
                }
            }
            return false;
        }

        //获取商品登记号
        public static List<String> GetProductRegNo(String order_no,String product_code) {
            List<String> productRegNos = new List<string>();
            var resData = ApiHelper.Post("/v1/api/print/getProductRegNo.json?product_order_no=" + order_no + "&product_code=" + product_code,null);
            var durianJson = ApiHelper.DeserializeJson<DurianResult<List<String>>>(resData);
            if (durianJson.errCd == 0)
                productRegNos = durianJson.result;
            else
            {
                MessageBox.Show(durianJson.errMsg);
                if (durianJson.errCd == -600 || durianJson.errCd == -601)
                {
                    Properties.Settings.Default.ACCESS_TOKEN = "";
                    Properties.Settings.Default.Save();
                }
            }

            return productRegNos;
        }

        //出库
        public static Boolean StockOut(String orderNo,String productInfoList,String productRegNoList) {
            var resData = ApiHelper.Post("/v1/api/stockout/stockOutOrder.json?product_order_no=" + orderNo + "&product_regno_list=" + productRegNoList + "&productsInfo_list=" + productInfoList,null);
            var durianJson = ApiHelper.DeserializeJson<DurianResult<Success<String>>>(resData);
            if (durianJson.errCd == 0) return true;
            else
            {
                MessageBox.Show(durianJson.errMsg);
                if (durianJson.errCd == -600 || durianJson.errCd == -601)
                {
                    Properties.Settings.Default.ACCESS_TOKEN = "";
                    Properties.Settings.Default.Save();
                }
            }
            return false;
        }
        //退出系统
        public static void logOut()
        {
            ApiHelper.Post("/v1/api/user/logout.json", null);
        }
    }
}
