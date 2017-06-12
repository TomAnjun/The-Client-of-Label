using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CCWin.SkinControl;
using Newtonsoft.Json;
using ShengXinSolution.Client.LablePrintSystemV2.Models;

namespace ShengXinSolution.Client.LablePrintSystemV2.Utils
{
    static class SxApi
    {
        //获取打印标签所需数据
        public static WaybillInfo PostWaybillInfos(string waybillId, PackageInfo packageInfo, string jpExpressSec, string excludePackaged)
        {
            WaybillInfo waybillInfo = null;
            string packageInfoJson = null;
            string jpExpSecId = null;
            if (!packageInfo.IsNull())
                packageInfoJson = JsonConvert.SerializeObject(packageInfo, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
            if (!jpExpressSec.IsNullOrEmpty())
                jpExpSecId = jpExpressSec;
            var resData = ApiHelper.Post("/v1/api/print/waybill-label.json?waybill_id=" + waybillId + "&packages=" + packageInfoJson + "&jp_express_section_id=" + jpExpSecId + "&excludePackaged=" + excludePackaged, null);
            try
            {
                var durianJson = ApiHelper.DeserializeJson<DurianResult<WaybillInfo>>(resData);
                if (durianJson.errCd == 0)
                    waybillInfo = durianJson.result;
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
           
            return waybillInfo;
        }

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

        //入袋
        public static bool JoinAirBag(string air_bag_id, string airbag_type, string waybills)
        {
            if (string.IsNullOrEmpty(air_bag_id) || string.IsNullOrEmpty(waybills)) return false;
            var resData = ApiHelper.Post("/v1/api/stock/airbag/join-airbag.json?air_bag_id=" + air_bag_id + "&waybills=" + waybills + "&airbag_type=" + airbag_type, null);
            var durianJson = ApiHelper.DeserializeJson<DurianResult<Success<object>>>(resData);
            if (durianJson.errCd == 0)
            {
                MessageBox.Show(durianJson.result.msg);
                if (durianJson.result.success) return true;
            }
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

        //出袋
        public static bool TakeOutOfBag(string waybill_ids)
        {
            if (string.IsNullOrEmpty(waybill_ids)) return false;
            var resData = ApiHelper.Post("/v1/api/stock/airbag/takeout-of-airbag.json?waybill_ids=" + waybill_ids, null);
            var durianJson = ApiHelper.DeserializeJson<DurianResult<Success<object>>>(resData);
            if (durianJson.errCd == 0)
            {
                MessageBox.Show(durianJson.result.msg);
                if (durianJson.result.success) return true;
            }
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

        //入Master
        public static bool JoinMaster(string master_id, string air_bag_ids)
        {
            if (string.IsNullOrEmpty(master_id) || string.IsNullOrEmpty(air_bag_ids)) return false;
            var resData = ApiHelper.Post("/v1/api/stock/master/join-master.json?master_id=" + master_id + "&air_bag_ids=" + air_bag_ids, null);
            var durianJson = ApiHelper.DeserializeJson<DurianResult<Success<object>>>(resData);
            if (durianJson.errCd == 0)
            {
                MessageBox.Show(durianJson.result.msg);
                if (durianJson.result.success) return true;
            }
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

        //出主单
        public static bool TakeOutOfMaster(string airbag_ids)
        {
            if (string.IsNullOrEmpty(airbag_ids)) return false;
            var resData = ApiHelper.Post("/v1/api/stock/master/takeout-of-master.json?master_item_ids=" + airbag_ids, null);
            var durianJson = ApiHelper.DeserializeJson<DurianResult<Success<object>>>(resData);
            if (durianJson.errCd == 0)
            {
                MessageBox.Show(durianJson.result.msg);
                if (durianJson.result.success) return true;
            }
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


        //获取SX号
        public static List<string> getSxNos(int cnt)
        {
            var resData = ApiHelper.Post("/v1/api/waybill/get-sx-nos.json?cnt=" + cnt, null);
            var durianJson = ApiHelper.DeserializeJson<DurianResult<List<string>>>(resData);
            if (durianJson.errCd == 0) return durianJson.result;
            else
            {
                MessageBox.Show(durianJson.errMsg);
                if (durianJson.errCd == -600 || durianJson.errCd == -601)
                {
                    Properties.Settings.Default.ACCESS_TOKEN = "";
                    Properties.Settings.Default.Save();
                }
            }
            return null;
        }

        //获取JP号
        public static List<string> getJpNos(string sectionId, int cnt)
        {
            var resData = ApiHelper.Post("/v1/api/print/jp-express-lable.json?jp_express_section_id="+sectionId+"&cnt=" + cnt, null);
            var durianJson = ApiHelper.DeserializeJson<DurianResult<List<string>>>(resData);
            if (durianJson.errCd == 0) return durianJson.result;
            else
            {
                MessageBox.Show(durianJson.errMsg);
                if (durianJson.errCd == -600 || durianJson.errCd == -601)
                {
                    Properties.Settings.Default.ACCESS_TOKEN = "";
                    Properties.Settings.Default.Save();
                }
            }
            return null;
        }

        //获取袋子号
        public static List<string> getAirBagNos(int cnt)
        {
            var resData = ApiHelper.Post("/v1/api/stock/airbag/get-airbag-nos.json?cnt=" + cnt, null);
            var durianJson = ApiHelper.DeserializeJson<DurianResult<List<string>>>(resData);
            if (durianJson.errCd == 0) return durianJson.result;
            else
            {
                MessageBox.Show(durianJson.errMsg);
                if (durianJson.errCd == -600 || durianJson.errCd == -601)
                {
                    Properties.Settings.Default.ACCESS_TOKEN = "";
                    Properties.Settings.Default.Save();
                }
            }
            return null;
        }

        //获取Master信息
        public static MasterInfo getMasterInfo(string airbag_id)
        {
            var resData = ApiHelper.Post("/v1/api/print/master-label.json?airbag_id=" + airbag_id, null);
            var durianJson = ApiHelper.DeserializeJson<DurianResult<MasterInfo>>(resData);

            if (durianJson.errCd == 0) return durianJson.result;
            else
            {
                MessageBox.Show(durianJson.errMsg);
                if (durianJson.errCd == -600 || durianJson.errCd == -601)
                {
                    Properties.Settings.Default.ACCESS_TOKEN = "";
                    Properties.Settings.Default.Save();
                }
            }
            return null;
        }

        //匹配打包货
        public static bool matchPwayBill(string parent_waybill_id, string waybill_ids)
        {
            if (string.IsNullOrEmpty(parent_waybill_id) || string.IsNullOrEmpty(waybill_ids)) return false;
            var resData = ApiHelper.Post("/v1/api/waybill/match-pwaybill.json?parent_waybill_id=" + parent_waybill_id + "&waybill_ids=" + waybill_ids, null);
            var durianJson = ApiHelper.DeserializeJson<DurianResult<Success<object>>>(resData);
            if (durianJson.errCd == 0)
            {
                if (durianJson.result.success) return true;
                else MessageBox.Show(durianJson.result.msg);
            }
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

        //取消匹配打包货
        public static bool releaseMatchPwayBill(string waybill_ids)
        {
            if (string.IsNullOrEmpty(waybill_ids)) return false;
            var resData = ApiHelper.Post("/v1/api/waybill/release-pwaybill.json?waybill_ids=" + waybill_ids, null);
            var durianJson = ApiHelper.DeserializeJson<DurianResult<Success<object>>>(resData);
            if (durianJson.errCd == 0)
            {
                if (durianJson.result.success) return true;
                else MessageBox.Show(durianJson.result.msg);
            }
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

        public static void logOut()
        {
            ApiHelper.Post("/v1/api/user/logout.json", null);
        }

    }
}
