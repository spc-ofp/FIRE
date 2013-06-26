using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tufces.Dal.Repositories;
using Tufces.Domain;
using Tufces.Web.Models;

namespace Tufces.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly Repository _repo;

        public HomeController()
        {
            _repo = new Repository(MvcApplication.UnitOfWork.Session);
        }

        public ActionResult Index()
        {
            var Sources = _repo.Find<Source>(x => x.Type < 3).Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Description }).ToList();
            ViewBag.Sources = Sources;
            return View();
        }

        [HttpPost]
        public PartialViewResult GetReportParams(int? SourceId, int? DataType, string Gear, string Sources, string SubSources)
        {
            //Additional test
            //ModelState.AddModelError()
            if (ModelState.IsValid)
            {
                Source source = _repo.Get<Source>(SourceId.Value);
                DataType dataType = _repo.Get<DataType>(DataType.Value);
                Gear gear = _repo.Get<Gear>(Gear);
                TufmanKernel tufmanKernel = new TufmanKernel() { DataType = dataType, Gear = gear, Source = source };
                KernelViewModel kernelViewModel = new KernelViewModel();
                kernelViewModel.Flags = tufmanKernel.GetFlags();
                kernelViewModel.Species = tufmanKernel.GetSpecies();
                return PartialView("_Kernel", kernelViewModel);
            }
            return PartialView();
        }

        public ActionResult GetDataTypesFromSource(int id)
        {
            var dataTypes = _repo.Find<SourceDataType>(x => x.Source.Id == id).Select(x=>x.DataType).Distinct();
            return Json(dataTypes, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetSubDataSources(int id)
        {
            Source parentSource = _repo.Get<Source>(id);
            if (parentSource.Type!=2)
                return Json(null, JsonRequestBehavior.AllowGet);
            var childrenSources = _repo.Find<Source>(x => x.GroupId == parentSource.GroupId && x.Type == 3);
            return Json(childrenSources, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetGears(int sourceId, int dataTypeId)
        {
            var gears = _repo.Find<SourceDataType>(x => x.Source.Id == sourceId && x.DataType.Id == dataTypeId).Select(x => x.Gear).Distinct();
            return Json(gears, JsonRequestBehavior.AllowGet);
        }
    }
}
