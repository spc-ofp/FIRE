using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tufces.Web.Models
{
    public class HeaderModel
    {
        [Required]
        public int? SourceId { get; set; }
        [Required]
        public int? DataType { get; set; }
        [Required]
        public string Gear { get; set; }
    }
}