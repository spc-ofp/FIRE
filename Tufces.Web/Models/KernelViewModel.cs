using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tufces.Web.Models
{
    public class KernelViewModel
    {
        public List<PillboxViewModel> Pillboxes { get; set; }

        public KernelViewModel()
        {
            Pillboxes = new List<PillboxViewModel>();
        }
    }
}