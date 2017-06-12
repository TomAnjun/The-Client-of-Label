using Newtonsoft.Json;
using ShengXinSolution.Client.LablePrintSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShengXinSolution.Client.LablePrintSystem.Utils
{
    class ShengXinAPI
    {
        public static List<SagawaLabel> getSagawaLableByShengXinNo(string shengXinNo)
        {
            List<SagawaLabel> sagawaLableList = new List<SagawaLabel>();
            string data = ApiHelper.Get("/sxn/printFileDownload?order=" + shengXinNo, null);
            if (!string.IsNullOrEmpty(data))
            {
                data = ApiHelper.DeserializeJson<Dictionary<string, string>>(data)["pInfo"];
                //将分割后的数据放入数组中
                string[] tmpData = data.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var item in tmpData)
	            {
		            SagawaLabel sagawaLabel = new SagawaLabel();
                    sagawaLabel.parsing(item);
                    sagawaLableList.Add(sagawaLabel);
	            }
            }
            return sagawaLableList;
        }

        public static CargoDetail getCargoDetailEc(string shengXinNo)
        {
            string data = ApiHelper.Get("/sxn/eb/paddingWeightAndSizeForEc?id=" + shengXinNo, null);
            if (!string.IsNullOrEmpty(data))
            {
                return ApiHelper.DeserializeJson<CargoDetail>(data);
            }
            else
                return null;
        }

        public static List<CargoDetail> getCargoDetailGm(string shengXinNo)
        {
            string data = ApiHelper.Get("/sxn/eb/paddingWeightAndSizeForGm?id=" + shengXinNo, null);
            if (!string.IsNullOrEmpty(data))
            {
                return ApiHelper.DeserializeJson<List<CargoDetail>>(data);
            }
            else
                return null;
        }

        public static bool postCargoInfoEc(CargoDetail cargoDetail, string shengXinNo)
        {
            Dictionary<string, object> postData = new Dictionary<string, object>();
            postData.Add("shengxinNo", shengXinNo);
            postData.Add("weight", cargoDetail.weight);
            postData.Add("length", cargoDetail.length);
            postData.Add("width", cargoDetail.width);
            postData.Add("height", cargoDetail.height);
            postData.Add("type", "EC");

            string data = ApiHelper.Post("/sxn/eb/updateWeightAndSizeForEc", postData);

            //System.Diagnostics.Debug.WriteLine(data);

            Dictionary<string, object> result = ApiHelper.DeserializeJson<Dictionary<string, object>>(data);

            if (result["success"] != null && (bool)result["success"])
                return true;

            return false;
        }

        public static bool postCargoInfoGm(List<CargoDetail> cargoDetails, string shengXinNo)
        {
            Dictionary<string, object> shengXinInfo = new Dictionary<string, object>();
            shengXinInfo.Add("shengxinNo", shengXinNo);
            shengXinInfo.Add("expresses", cargoDetails);

            Dictionary<string, object> postData = new Dictionary<string, object>();
            postData.Add("data", JsonConvert.SerializeObject(shengXinInfo));
            postData.Add("type", "GM");

            string data = ApiHelper.Post("/sxn/eb/updateWeightAndSizeForGm", postData);

            //System.Diagnostics.Debug.WriteLine(data);

            Dictionary<string, object> result = ApiHelper.DeserializeJson<Dictionary<string, object>>(data);

            if (result["success"] != null && (bool)result["success"])
                return true;

            return false;
        }


    }
}
