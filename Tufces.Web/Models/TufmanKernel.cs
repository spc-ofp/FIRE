using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

        public List<String> GetFlags() {
            //List<String> Flags = new List<String>();
            //Flags.Add("Belize");
            //Flags.Add("China");
            //Flags.Add("Cook Islands");
            //Flags.Add("Fiji");
            ISessionFactory sessionFactory =  DynamicNHibernateHelper.CreateSessionFactory(String.Format("Server={0};Database={1};Trusted_Connection=True", Source.Server, Source.Database));
            UnitOfWork unit = new UnitOfWork(sessionFactory);
            Repository repo = new Repository(unit.Session);
            return repo.GetAll<Vessel>().Select(x=>x.Flag).Distinct().ToList();
            //return (Flags);
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

        public List<String> GetSpecies()
        {
            List<String> Species = new List<String>();
            Species.Add("Albacore (ALB)");
            Species.Add("Bigeye (BET)");
            Species.Add("Skipjack (SKJ)");
            Species.Add("Yellowfin (YFT)");
            return (Species);
        }


    }
}