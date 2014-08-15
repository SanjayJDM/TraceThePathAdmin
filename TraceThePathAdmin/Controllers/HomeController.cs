using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TraceThePathAdmin.Models;

namespace TraceThePathAdmin.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public async Task<ActionResult> homepage()
        {
            
            try
            {

                using (var httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri("http://sanjayjdm.apphb.com/");
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));


                    HttpResponseMessage response = await httpClient.GetAsync("http://sanjayjdm.apphb.com/api/getlocation?appKey=ttpapikey.asxc123nju89mno0&assetId=1000");
                    if (response.IsSuccessStatusCode)
                    {

                    }
                }

            }
            catch (Exception exec)
            {
                throw new Exception(exec.Message);
            }
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }

    }
}
