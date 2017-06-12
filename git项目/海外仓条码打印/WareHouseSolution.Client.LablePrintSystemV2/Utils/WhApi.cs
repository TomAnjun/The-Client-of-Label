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
        //获取商品登记号
        public static List<ProductRegInfo> GetProductRegNo(String waybill_no, String product_reg_code, String end_reg_no)
        {
            List<ProductRegInfo> productRegNos = new List<ProductRegInfo>();
            var resData = ApiHelper.Post("/v1/api/print/getProductRegNo.json?waybill_no=" + waybill_no + "&product_reg_code=" + product_reg_code + "&end_reg_no=" + end_reg_no, null);
            var durianJson = ApiHelper.DeserializeJson<DurianResult<List<ProductRegInfo>>>(resData);
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

        //退出系统
        public static void logOut()
        {
            ApiHelper.Post("/v1/api/user/logout.json", null);
        }
    }
}
