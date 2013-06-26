using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tufces.Web.Models
{
    public class PillboxViewModel
    {
        public String ModuleName { get; set; }
        public Dictionary<String, String> PillboxValues { get; set; }
        public List<SelectListItem> GroupingList { get; set; }
        public Boolean HasImages { get; set; }
        public String ImagePath { get; set; }

        public PillboxViewModel()
        {
            PillboxValues = new Dictionary<String, String>();
        }
    }
}