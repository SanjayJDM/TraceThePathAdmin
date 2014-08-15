using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
//using System.Web.Http;

using System.Web.Mvc;
using System.Xml.Linq;
using TraceThePathAdmin.Models;

namespace TraceThePathAdmin.Controllers
{
    public class SetRouteController : Controller
    {
        public ActionResult SetRoute()
        {
            ViewData["RouteInfo"] = GetRouteInformation();
            ViewData["AssetInfo"] = GetAssetInformation();
            return View();
        }

        [HttpGet]
        public ActionResult GetRouteCoordinates(string routeId)
        {
            ViewData["RouteCoordinates"] = GetRouteCoordinatesInformation(routeId);
            return View();
        }
        


        public List<RoutesInfo> GetRouteInformation()
        {
            List<RoutesInfo> routeInfoList = new List<RoutesInfo>();
            try
            {
                using (HttpClient httpClient1 = new HttpClient())
                {
                    httpClient1.BaseAddress = new Uri("http://sanjayjdm.apphb.com/");
                    httpClient1.DefaultRequestHeaders.Accept.Clear();
                    httpClient1.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
                    string jsonResponseString = httpClient1.GetStringAsync("api/getroutes?appKey=ttpapikey.asxc123nju89mno0").Result;
                    string jsonwithDouble = jsonResponseString.Replace("'", "\"");
                    XDocument doc = XDocument.Parse(jsonwithDouble);
                    string pureJson = doc.Root.Value;

                    var routeList = Newtonsoft.Json.Linq.JObject.Parse(pureJson).SelectToken("Routes").ToObject<List<RoutesInfo>>();

                    foreach (var route in routeList)
                    {
                        RoutesInfo routeInfo = new RoutesInfo();
                        routeInfo.routeid = route.routeid;
                        routeInfo.routeName = route.routeName;
                        routeInfoList.Add(routeInfo);
                    }
                }
            }
            catch (Exception exep)
            {
                throw new Exception(exep.Message);
            }
            return routeInfoList;
        }

        public string GetRouteIdFromRouteName(string routeName)
        {
            int routeIdFromRouteName = 0; ;
            try
            {
                using (HttpClient httpClient1 = new HttpClient())
                {
                    httpClient1.BaseAddress = new Uri("http://sanjayjdm.apphb.com/");
                    httpClient1.DefaultRequestHeaders.Accept.Clear();
                    httpClient1.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
                    string jsonResponseString = httpClient1.GetStringAsync("api/getroutes?appKey=ttpapikey.asxc123nju89mno0").Result;
                    string jsonwithDouble = jsonResponseString.Replace("'", "\"");
                    XDocument doc = XDocument.Parse(jsonwithDouble);
                    string pureJson = doc.Root.Value;

                    var routeList = Newtonsoft.Json.Linq.JObject.Parse(pureJson).SelectToken("Routes").ToObject<List<RoutesInfo>>();

                    foreach (var route in routeList)
                    {
                        if (route.routeName.Trim() == routeName.Trim())
                        {
                            routeIdFromRouteName = route.routeid;
                        }
                        else
                        {
                            routeIdFromRouteName = 0;
                        }
                    }
                }
            }
            catch (Exception exep)
            {
                throw new Exception(exep.Message);
            }
            return routeIdFromRouteName.ToString();
        }

        public void AssignAssetTotheRoute(string routeId, string assetId)
        {
            try
            {
                using (HttpClient httpClient1 = new HttpClient())
                {
                    httpClient1.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                   

                    var client = new HttpClient { BaseAddress = new Uri("http://sanjayjdm.apphb.com") };

                    var response = client.PostAsync("/api/Route2Asset?appKey=ttpapikey.asxc123nju89mno0&routeid=" + routeId.ToString().Trim() + "&assetid=" + assetId.ToString().Trim(), null).Result;
                }
            }
            catch (Exception exe)
            {
                throw new Exception(exe.Message);
            }

            return;
        }

        public List<AssetInfo> GetAssetInformation()
        {
            List<AssetInfo> assetInfoList = new List<AssetInfo>();
            try
            {
                /*using (HttpClient httpClient1 = new HttpClient())
                {
                    httpClient1.BaseAddress = new Uri("http://sanjayjdm.apphb.com/");
                    httpClient1.DefaultRequestHeaders.Accept.Clear();
                    httpClient1.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
                    string jsonResponseString = httpClient1.GetStringAsync("api/getroutes?appKey=ttpapikey.asxc123nju89mno0").Result;
                    string jsonwithDouble = jsonResponseString.Replace("'", "\"");
                    XDocument doc = XDocument.Parse(jsonwithDouble);
                    string pureJson = doc.Root.Value;

                    var routeList = Newtonsoft.Json.Linq.JObject.Parse(pureJson).SelectToken("Routes").ToObject<List<RoutesInfo>>();

                    foreach (var route in routeList)
                    {
                        RoutesInfo routeInfo = new RoutesInfo();
                        routeInfo.routeid = route.routeid;
                        routeInfo.routeName = route.routeName;
                        routeInfoList.Add(routeInfo);
                    }
                }*/

                AssetInfo assetInfo1 = new AssetInfo();
                assetInfo1.assetid = 1;
                assetInfo1.assetName = "testassetname1";
                AssetInfo assetInfo2 = new AssetInfo();
                assetInfo2.assetid = 2;
                assetInfo2.assetName = "testassetname2";
                assetInfoList.Add(assetInfo1);
                assetInfoList.Add(assetInfo2);

            }
            catch (Exception exep)
            {
                throw new Exception(exep.Message);
            }
            return assetInfoList;
        }


        public List<Cordinate> GetRouteCoordinatesInformation(string routeId)
        {
            List<Cordinate> cordinates = new List<Cordinate>();
            try
            {


                using (HttpClient httpClient1 = new HttpClient())
                {
                    httpClient1.BaseAddress = new Uri("http://sanjayjdm.apphb.com/");
                    httpClient1.DefaultRequestHeaders.Accept.Clear();
                    httpClient1.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
                    string jsonResponseString = httpClient1.GetStringAsync("api/getroutecordinates?appKey=ttpapikey.asxc123nju89mno0&routeId=" + routeId.ToString()).Result;
                    string jsonwithDouble = jsonResponseString.Replace("'", "\"");
                    XDocument doc = XDocument.Parse(jsonwithDouble);
                    string pureJson = doc.Root.Value;

                    var coordinates = Newtonsoft.Json.Linq.JObject.Parse(pureJson).SelectToken("cordinates").ToObject<List<Cordinate>>();

                    foreach (var coordinate in coordinates)
                    {
                        Cordinate cordinate = new Cordinate();
                        cordinate.seqNo = coordinate.seqNo;
                        cordinate.startLat = coordinate.startLat;
                        cordinate.startLon = coordinate.startLon;
                        cordinates.Add(cordinate);
                    }
                }
            }
            catch (Exception exep)
            {
                throw new Exception(exep.Message);
            }

            IEnumerable<Cordinate> sortAscendingQuery =
            from cordinate in cordinates
            orderby cordinate.seqNo //"ascending" is default 
            select cordinate;

            return cordinates;
        }

        [HttpPost]
        public ActionResult CreateRoute(string routeId, string routeName, string assetId, List<Cordinate> cordinates)
        {

            try
            {
                using (HttpClient httpClient1 = new HttpClient())
                {
                    if (routeName.Trim().Length > 0)
                    {

                        httpClient1.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        var pairs = new List<KeyValuePair<string, string>>
                                            {
                                                new KeyValuePair<string, string>("appKey", "ttpapikey.asxc123nju89mno0"),
                                                new KeyValuePair<string, string>("routeName", routeName),
                                                new KeyValuePair<string, string>("userName", "admin"),

                                            };
                        var content = new FormUrlEncodedContent(pairs);

                        var client = new HttpClient { BaseAddress = new Uri("http://sanjayjdm.apphb.com") };

                        var response = client.PostAsync("/api/createroute?appKey=ttpapikey.asxc123nju89mno0&routeName=" + routeName.Trim() + "&userName=admin", null).Result;
                        routeId = GetRouteIdFromRouteName(routeName);

                    }


                    AssignAssetTotheRoute(routeId, assetId);
                    var routeCordinates = new RouteCordinates();

                    routeCordinates.routeId = routeId;
                    routeCordinates.cordinates = new List<Cordinate>();
                    routeCordinates.cordinates = cordinates;


                    string jsonStringUsingJconvert = "="+JsonConvert.SerializeObject(routeCordinates);

                    HttpWebRequest HttpWReq =
                    (HttpWebRequest)WebRequest.Create("http://sanjayjdm.apphb.com/api/setroutecordinates?appkey=ttpapikey.asxc123nju89mno0");

                    ASCIIEncoding encoding = new ASCIIEncoding();
                    byte[] data = encoding.GetBytes(jsonStringUsingJconvert);
                    HttpWReq.ContentType = "application/x-www-form-urlencoded";

                    HttpWReq.Method = "POST";
                    HttpWReq.ContentLength = data.Length;

                    Stream newStream = HttpWReq.GetRequestStream();
                    newStream.Write(data, 0, data.Length);
                    newStream.Close();
                    WebResponse myWebResponse = HttpWReq.GetResponse();

                    

                }
            }
            catch (WebException wex)
            {
                var httpResponse = wex.Response as HttpWebResponse;
                if (httpResponse != null)
                {
                    throw new ApplicationException(string.Format(
                        "Remote server call {0} {1} resulted in a http error {2} {3}.",
                        "POST",
                        "set route coorinates API",
                        httpResponse.StatusCode,
                        httpResponse.StatusDescription), wex);
                }
                else
                {
                    throw new ApplicationException(string.Format(
                        "Remote server call {0} {1} resulted in an error.",
                        "POST",
                        "set route coorinates API"), wex);
                }
            }

            catch (Exception exep)
            {
                throw new Exception(exep.Message);
            }


            /*MemoryStream stream1 = new MemoryStream();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(RouteDetails));

            ser.WriteObject(stream1, routeDetails);

            stream1.Position = 0;
            StreamReader sr = new StreamReader(stream1);
            string jsonString = sr.ReadToEnd();
            return Content(jsonString);*/
            return Content("success");
        }

        public ActionResult UpdateRoute()
        {
            return View();
        }
    }
}
