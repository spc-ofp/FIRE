using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tufces.Dal.Configuration;
using Tufces.Dal.Repositories;
using Tufces.Domain;
using TUFMAN.Domain.Ves;
using TUFMAN.Domain.Log;

namespace Tufces.Web.Models
{
    public class TufmanKernel
    {
        public Source Source { get; set; }
        public DataType DataType { get; set; }
        public Gear Gear { get; set; }

        public PillboxViewModel GetFlags()
        {
            List<System.Collections.DictionaryEntry> flagList;

            ISessionFactory sessionFactory = DynamicNHibernateHelper.CreateSessionFactory(String.Format("Server={0};Database={1};Trusted_Connection=True", Source.Server, Source.Database));
            UnitOfWork unit = new UnitOfWork(sessionFactory);
            Repository repo = new Repository(unit.Session);
            IQuery query;
            string tablename;

            PillboxViewModel pillBox = new PillboxViewModel();
            pillBox.ModuleName = "VesselFlag";
            pillBox.HasImages = true;
            pillBox.ImagePath = "~/Content/images/flags/";

            // gets the list of flags from the trips table
            switch (Gear.Code)
            {
                case "P":
                    //flagList = repo.GetAll<TripsPL>().Select(x => new System.Collections.DictionaryEntry { Key = x.vessels.flag_code, Value = x.vessels.flag_country.country_name }).Distinct().OrderBy(x => x.Value).ToList();
                    tablename = "TripsPL";
                    break;
                case "S":
                    tablename = "TripsPS";

                    break;
                default:    // make LL the default
                    tablename = "TripsLL";
                    break;
            }
            query = unit.Session.CreateQuery("Select distinct c.country_code,c.country_name from " + tablename + " as t inner join t.vessels as v inner join v.flag_country c order by c.country_name");
            flagList = (from object[] x in query.List()
                        select new System.Collections.DictionaryEntry { Key = x[0], Value = x[1] }).ToList();

            foreach (System.Collections.DictionaryEntry flag in flagList) 
                pillBox.PillboxValues.Add(flag.Key.ToString(),flag.Value.ToString());

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

        public PillboxViewModel GetVessels()
        {
            List<System.Collections.DictionaryEntry> vesselList;

            ISessionFactory sessionFactory = DynamicNHibernateHelper.CreateSessionFactory(String.Format("Server={0};Database={1};Trusted_Connection=True", Source.Server, Source.Database));
            UnitOfWork unit = new UnitOfWork(sessionFactory);
            Repository repo = new Repository(unit.Session);
            IQuery query;
            string tablename;

            PillboxViewModel pillBox = new PillboxViewModel();
            pillBox.ModuleName = "Vessels";
            pillBox.HasImages = false;

            // gets the list of vessels from the trips table
            switch (Gear.Code)
            {
                case "P":
                    tablename = "TripsPL";
                    break;
                case "S":
                    tablename = "TripsPS";

                    break;
                default:    // make LL the default
                    tablename = "TripsLL";
                    break;
            }
            query = unit.Session.CreateQuery("Select distinct v.vessel_id,v.vessel_name from " + tablename + " as t inner join t.vessels as v order by v.vessel_name");
            vesselList = (from object[] x in query.List()
                        select new System.Collections.DictionaryEntry { Key = x[0], Value = x[1] }).ToList();

            foreach (System.Collections.DictionaryEntry vessel in vesselList)
                pillBox.PillboxValues.Add(vessel.Key.ToString(), vessel.Value.ToString());

            pillBox.GroupingList = new List<SelectListItem>();
            pillBox.GroupingList.Add(new SelectListItem() { Value = "AllVessels", Text = "All vessels combined" });
            pillBox.GroupingList.Add(new SelectListItem() { Value = "Vessel", Text = "Vessel" });
            return pillBox;
        }

        public PillboxViewModel GetSpecies()
        {
            List<System.Collections.DictionaryEntry> speciesList;

            ISessionFactory sessionFactory = DynamicNHibernateHelper.CreateSessionFactory(String.Format("Server={0};Database={1};Trusted_Connection=True", Source.Server, Source.Database));
            UnitOfWork unit = new UnitOfWork(sessionFactory);
            Repository repo = new Repository(unit.Session);
            IQuery query;
            string tablename;

            PillboxViewModel pillBox = new PillboxViewModel();
            pillBox.ModuleName = "Species";
            pillBox.HasImages = false;

            //pillBox.PillboxValues.Add("ALB", "Albacore (ALB)");
            //pillBox.PillboxValues.Add("BET", "Bigeye (BET)");
            //pillBox.PillboxValues.Add("SKJ", "Skipjack (SKJ)");
            //pillBox.PillboxValues.Add("YFT", "Yellowfin (YFT)");

            switch (Gear.Code)
            {
                case "P":
                    tablename = "CatchPL";
                    break;
                case "S":
                    tablename = "CatchPS";
                    break;
                default:    // make LL the default
                    tablename = "CatchLL";
                    break;
            }
            //speciesList = repo.GetAll<CatchLL>().Select(x => new System.Collections.DictionaryEntry { Key = x.species.sp_code, Value = x.species.sp_name }).Distinct().OrderBy(x => x.Value).ToList();
            query = unit.Session.CreateQuery("Select distinct s.sp_code,s.sp_name from " + tablename + " as c inner join c.species as s order by s.sp_name");
            speciesList = (from object[] x in query.List()
                        select new System.Collections.DictionaryEntry { Key = x[0], Value = x[1] }).ToList();

            foreach (System.Collections.DictionaryEntry species in speciesList)
                pillBox.PillboxValues.Add(species.Key.ToString(), species.Value.ToString());

            pillBox.GroupingList = new List<SelectListItem>();
            pillBox.GroupingList.Add(new SelectListItem() { Value = "AllSpecies", Text = "All species combined" });
            pillBox.GroupingList.Add(new SelectListItem() { Value = "Species", Text = "Species" });
            return (pillBox);
        }

        public PillboxViewModel GetCatchOptions()
        {
            PillboxViewModel pillBox = new PillboxViewModel();
            pillBox.ModuleName = "CatchReporting";
            pillBox.HasImages = false;


            //pillBox.PillboxValues.Add("SKJ", "Skipjack (SKJ)");
            //pillBox.PillboxValues.Add("YFT", "Yellowfin (YFT)");

            switch (Gear.Code)
            {
                case "P":   // same as S
                case "S":
                    pillBox.PillboxValues.Add(((int)Tufces.Domain.Enum.CatchReportingType.Kilograms).ToString(), "Kilograms");
                    pillBox.PillboxValues.Add(((int)Tufces.Domain.Enum.CatchReportingType.MetricTonnes).ToString(), "Metric tonnes");
                    break;
                default:    // make LL the default
                    pillBox.PillboxValues.Add(((int)Tufces.Domain.Enum.CatchReportingType.Kilograms).ToString(), "Kilograms");
                    pillBox.PillboxValues.Add(((int)Tufces.Domain.Enum.CatchReportingType.MetricTonnes).ToString(), "Metric tonnes");
                    pillBox.PillboxValues.Add(((int)Tufces.Domain.Enum.CatchReportingType.NumbersOfFish).ToString(), "Numbers of fish");
                    break;
            }


            return (pillBox);
        }

        public PillboxViewModel GetCPUEOptions()
        {
            PillboxViewModel pillBox = new PillboxViewModel();
            pillBox.ModuleName = "CPUEReporting";
            pillBox.HasImages = false;

            switch (Gear.Code)
            {
                case "P": 
                    pillBox.PillboxValues.Add(((int)Tufces.Domain.Enum.CPUEReportingType.MetricTonnesPerDay).ToString(), "Metric tonnes per day");
                    break;
                case "S":
                    pillBox.PillboxValues.Add(((int)Tufces.Domain.Enum.CPUEReportingType.MetricTonnesPerDay).ToString(), "Metric tonnes per day");
                    pillBox.PillboxValues.Add(((int)Tufces.Domain.Enum.CPUEReportingType.MetricTonnesPerSet).ToString(), "Metric tonnes per set");
                    break;
                default:    // make LL the default
                    pillBox.PillboxValues.Add(((int)Tufces.Domain.Enum.CPUEReportingType.KilogramsPer100Hooks).ToString(), "Kilograms per 100 hooks");
                    pillBox.PillboxValues.Add(((int)Tufces.Domain.Enum.CPUEReportingType.MetricTonnesPerDay).ToString(), "Metric tonnes per day");
                    pillBox.PillboxValues.Add(((int)Tufces.Domain.Enum.CPUEReportingType.NumbersOfFishPerDay).ToString(), "Numbers of fish per day");
                    pillBox.PillboxValues.Add(((int)Tufces.Domain.Enum.CPUEReportingType.NumbersOfFishPer100Hooks).ToString(), "Numbers of fish per 100 hooks");
                    break;
            }

            return (pillBox);
        }

        public PillboxViewModel GetEffortOptions()
        {
            PillboxViewModel pillBox = new PillboxViewModel();
            pillBox.ModuleName = "EffortReporting";
            pillBox.HasImages = false;

            switch (Gear.Code)
            {
                case "P":
                    pillBox.PillboxValues.Add(((int)Tufces.Domain.Enum.EffortReportingType.DaysFishing).ToString(), "Days fishing");
                    pillBox.PillboxValues.Add(((int)Tufces.Domain.Enum.EffortReportingType.NumberOfTrips).ToString(), "Number of trips");
                    pillBox.PillboxValues.Add(((int)Tufces.Domain.Enum.EffortReportingType.NumberOfVessels).ToString(), "Number of vessels");
                    break;
                case "S":
                    pillBox.PillboxValues.Add(((int)Tufces.Domain.Enum.EffortReportingType.DaysFishing).ToString(), "Days fishing");
                    pillBox.PillboxValues.Add(((int)Tufces.Domain.Enum.EffortReportingType.NumberOfSets).ToString(), "Number of sets");
                    pillBox.PillboxValues.Add(((int)Tufces.Domain.Enum.EffortReportingType.NumberOfTrips).ToString(), "Number of trips");
                    pillBox.PillboxValues.Add(((int)Tufces.Domain.Enum.EffortReportingType.NumberOfVessels).ToString(), "Number of vessels");
                    break;
                default:    // make LL the default
                    pillBox.PillboxValues.Add(((int)Tufces.Domain.Enum.EffortReportingType.DaysFishing).ToString(), "Days fishing");
                    pillBox.PillboxValues.Add(((int)Tufces.Domain.Enum.EffortReportingType.HundredsOfHooks).ToString(), "Hundreds of hooks");
                    pillBox.PillboxValues.Add(((int)Tufces.Domain.Enum.EffortReportingType.NumberOfSets).ToString(), "Number of sets");
                    pillBox.PillboxValues.Add(((int)Tufces.Domain.Enum.EffortReportingType.NumberOfTrips).ToString(), "Number of trips");
                    pillBox.PillboxValues.Add(((int)Tufces.Domain.Enum.EffortReportingType.NumberOfVessels).ToString(), "Number of vessels");
                    break;
            }


            return (pillBox);
        }
    }
}