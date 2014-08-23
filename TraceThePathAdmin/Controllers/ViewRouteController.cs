using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Runtime.Serialization;
using TraceThePathAdmin.Models;
using System.Xml.Linq;
using Newtonsoft.Json;

namespace TraceThePathAdmin.Controllers
{
    public class ViewRouteController : Controller
    {
        //
        // GET: /ViewRoute/

        public ActionResult ViewRoute()
        {
            //ViewData["RouteInfo"] = GetRouteInformation();
            ViewData["AssetInfo"] = GetAssetInformation();
            //ViewData["RouteCoordinates"] = GetRouteCoordinatesInformation(1);
            ViewData["Points"] = GetLocationInfo();
            

            return View();
        }

        public ActionResult GetLocationCoordinatesByAssetId(int assetId)
        {
            //ViewData["RouteCoordinates"] = GetRouteCoordinatesInformation(1);
            ViewData["PointsByAssetId"] = GetLocationInfoByAssetId(assetId);


            return View();
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
                assetInfo1.assetName = "UKCarforDemo";
                AssetInfo assetInfo2 = new AssetInfo();
                assetInfo2.assetid = 2;
                assetInfo2.assetName = "AssetNotForDemo";
                AssetInfo assetInfo3 = new AssetInfo();
                assetInfo3.assetid = 3;
                assetInfo3.assetName = "AssetNotForDemo";
                AssetInfo assetInfo4 = new AssetInfo();
                assetInfo4.assetid = 4;
                assetInfo4.assetName = "BglCarForDemo";
                assetInfoList.Add(assetInfo1);
                assetInfoList.Add(assetInfo2);
                assetInfoList.Add(assetInfo3);
                assetInfoList.Add(assetInfo4);

            }
            catch (Exception exep)
            {
                throw new Exception(exep.Message);
            }
            return assetInfoList;
        }
        public List<RoutesInfo> GetRouteInformation()
        {
            List<RoutesInfo> routeInfoList = new List<RoutesInfo>();
            Routes routes = new Routes();
            try
            {
                using (HttpClient httpClient1 = new HttpClient())
                {
                    httpClient1.BaseAddress = new Uri("http://sanjayjdm.apphb.com/");
                    httpClient1.DefaultRequestHeaders.Accept.Clear();
                    httpClient1.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
                    string jsonResponseString = httpClient1.GetStringAsync("api/getroutes?appKey=ttpapikey.asxc123nju89mno0").Result;
                    string jsonwithDouble = jsonResponseString.Replace("'","\"");
                    XDocument doc = XDocument.Parse(jsonwithDouble);
                    string pureJson = doc.Root.Value;
                    
                    var routeList = Newtonsoft.Json.Linq.JObject.Parse(pureJson).SelectToken("Routes").ToObject<List<RoutesInfo>>();

                    foreach(var route in routeList)
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

        public List<Cordinate> GetRouteCoordinatesInformation(int routeId)
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
                        coordinates.Add(cordinate);
                    }
                }
            }
            catch (Exception exep)
            {
                throw new Exception(exep.Message);
            }
            return cordinates;
        }
        public Point GetLocationInfo()
        {
            Point point = new Point();
            string response = string.Empty;
            XmlReader xReader = XmlReader.Create(new StringReader(response));
            try
            {
                
                using (var httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri("http://sanjayjdm.apphb.com/");
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));


                    response = httpClient.GetStringAsync("http://sanjayjdm.apphb.com/api/getlocation?appKey=ttpapikey.asxc123nju89mno0&assetId=1000").Result;
                }
                var serializer = new DataContractSerializer(typeof(string[]));
                var reader = new XmlTextReader(new StringReader(response));
                var GenreList = new List<string>((string[])serializer.ReadObject(reader));

                point.lat = GenreList[0].Substring(4);
                point.lon = GenreList[1].Substring(4);

            }   
            catch (Exception exec)
            {
                throw new Exception(exec.Message);
            }
            finally
            {
                xReader.Close();
            }
            return point;
        }

        public Point GetLocationInfoByAssetId(int assetId)
        {
            Point point = new Point();
            string response = string.Empty;
            XmlReader xReader = XmlReader.Create(new StringReader(response));
            try
            {

                using (var httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri("http://sanjayjdm.apphb.com/");
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));


                    response = httpClient.GetStringAsync("http://sanjayjdm.apphb.com/api/getlocation?appKey=ttpapikey.asxc123nju89mno0&assetId="+assetId.ToString().Trim()).Result;
                }
                var serializer = new DataContractSerializer(typeof(string[]));
                var reader = new XmlTextReader(new StringReader(response));
                var GenreList = new List<string>((string[])serializer.ReadObject(reader));

                point.lat = GenreList[0].Substring(4);
                point.lon = GenreList[1].Substring(4);
                point.assetId = assetId;
            }
            catch (Exception exec)
            {
                throw new Exception(exec.Message);
            }
            finally
            {
                xReader.Close();
            }
            return point;
        }

    }
}
