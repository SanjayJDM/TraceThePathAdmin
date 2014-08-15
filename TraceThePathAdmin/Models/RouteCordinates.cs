using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TraceThePathAdmin.Models
{
    public class RouteCordinates
    {
        public string routeId { get; set; }

        public List<Cordinate> cordinates { get; set; }

    }

   
   
}