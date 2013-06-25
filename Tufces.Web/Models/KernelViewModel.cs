using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tufces.Web.Models
{
    public class KernelViewModel
    {
        public List<String> Flags { get; set; }
        public List<SelectListItem> FlagsGroupingList { get; set; }
        public String FlagsGrouping { get; set; }

        public KernelViewModel()
        {
            FlagsGroupingList = new List<SelectListItem>();
            FlagsGroupingList.Add(new SelectListItem() { Value = "AllFlag", Text = "All flags combined" });
            FlagsGroupingList.Add(new SelectListItem() { Value = "Flag", Text = "Flag" });
        }
    }
}