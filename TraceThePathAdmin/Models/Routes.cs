using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TraceThePathAdmin.Models
{
    [JsonObject]
    public class Routes
    {
        //public string appKey { get; set; }
        [JsonProperty("routeid")]
        public List<string> routeid { get; set; }

        [JsonProperty("routeName")]
        public List<string> routeName { get; set; }

        
    }
}