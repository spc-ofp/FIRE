using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tufces.Dal.Configuration;
using Tufces.Dal.Repositories;
using Tufces.Domain;
using Tufces.Domain.Tufman.Ves;

namespace Tufces.Web.Models
{
    public class TufmanKernel
    {
        public Source Source { get; set; }
        public DataType DataType { get; set; }
        public Gear Gear { get; set; }

        public PillboxViewModel GetFlags()
        {
            ISessionFactory sessionFactory = DynamicNHibernateHelper.CreateSessionFactory(String.Format("Server={0};Database={1};Trusted_Connection=True", Source.Server, Source.Database));
            UnitOfWork unit = new UnitOfWork(sessionFactory);
            Repository repo = new Repository(unit.Session);
            PillboxViewModel pillBox = new PillboxViewModel();
            pillBox.ModuleName = "VesselFlag";
            pillBox.HasImages = true;
            pillBox.ImagePath = "~/Content/images/flags/";
            foreach (String flag in repo.GetAll<Vessel>().Select(x => x.Flag).Distinct().ToList())
                pillBox.PillboxValues.Add(flag, flag);
            pillBox.GroupingList = new List<SelectListItem>();
            pillBox.GroupingList.Add(new SelectListItem() { Value = "AllFlag", Text = "All flags combined" });
            pillBox.GroupingList.Add(new SelectListItem() { Value = "Flag", Text = "Flag" });
            return pillBox;
        }

        public List<String> GetCatchNationalities()
        {

            List<String> CatchNationalities = new List<String>();
            CatchNationalities.Add("Belize");
            CatchNationalities.Add("China");
            CatchNationalities.Add("Cook Islands");
            CatchNationalities.Add("Fiji");
            return (CatchNationalities);
        }

        public PillboxViewModel GetSpecies()
        {
            PillboxViewModel pillBox = new PillboxViewModel();
            pillBox.ModuleName = "Species";
            pillBox.HasImages = false;
            pillBox.PillboxValues.Add("ALB", "Albacore (ALB)");
            pillBox.PillboxValues.Add("BET", "Bigeye (BET)");
            pillBox.PillboxValues.Add("SKJ", "Skipjack (SKJ)");
            pillBox.PillboxValues.Add("YFT", "Yellowfin (YFT)");
            pillBox.GroupingList = new List<SelectListItem>();
            pillBox.GroupingList.Add(new SelectListItem() { Value = "AllSpecies", Text = "All species combined" });
            pillBox.GroupingList.Add(new SelectListItem() { Value = "Species", Text = "Species" });
            return (pillBox);
        }


    }
}