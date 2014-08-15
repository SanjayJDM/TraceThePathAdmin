using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TraceThePathAdmin.Models
{
    public class RouteDetails
    {
        public string routeName { get; set; }

        public List<Cordinate> cordinates{ get; set; }

    }
}