using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TraceThePathAdmin.Models
{
    [JsonObject]
    public class AssetInfo
    {
        //public string appKey { get; set; }
        [JsonProperty("assetid")]
        public int assetid { get; set; }

        [JsonProperty("assetName")]
        public string assetName { get; set; }

        
    }
}