using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TraceThePathAdmin.Models
{
    public class Point
    {
        public int assetId { get; set; }
        [Required, MaxLength(100)]

        public string lat { get; set; }
        [Required]

        public string lon { get; set; }
        [Required]

        public Guid deviceId { get; set; }
        
    }   
}