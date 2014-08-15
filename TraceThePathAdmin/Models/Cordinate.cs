using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TraceThePathAdmin.Models
{
    public class Cordinate
    {
        public int seqNo { get; set; }
        public string startLat { get; set; }
        public string startLon { get; set; }
        public string endLat { get; set; }
        public string endLon { get; set; }

    }
   
}