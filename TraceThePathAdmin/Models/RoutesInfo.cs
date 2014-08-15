using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TraceThePathAdmin.Models
{
    [JsonObject]
    public class RoutesInfo
    {
        //public string appKey { get; set; }
        [JsonProperty("routeid")]
        public int routeid { get; set; }

        [JsonProperty("routeName")]
        public string routeName { get; set; }

        
    }
}