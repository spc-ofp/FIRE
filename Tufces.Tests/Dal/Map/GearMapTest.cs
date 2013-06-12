using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tufces.Dal.Configuration;
using Tufces.Dal.Repositories;
using Tufces.Domain;

namespace Tufces.Tests.Dal.Map
{
    [TestClass]
    public class GearMapTest
    {
        [TestMethod]
        public void GearMap_Simple_Test()
        {
            UnitOfWork unitOfWork = new UnitOfWork(NHibernateHelper.SessionFactory);
            Repository repo = new Repository(unitOfWork.Session);
            List<Gear> list = repo.GetAll<Gear>().ToList();
            Assert.AreEqual(6, list.Count);
            unitOfWork.Rollback();
        }

        //[TestMethod]
        //public void GetGears_From_TufmanFM_Source_Should_Return_3()
        //{
        //    UnitOfWork unitOfWork = new UnitOfWork(NHibernateHelper.SessionFactory);
        //    Repository repo = new Repository(unitOfWork.Session);
        //    Source tufmanFm = repo.Find<Source>(x => x.Description == "Tufman FM").FirstOrDefault();
        //    Assert.IsNotNull(tufmanFm);
        //    Assert.IsNotNull(tufmanFm.Gears);
        //    Assert.IsTrue(tufmanFm.Gears.Count == 3);
        //    Assert.IsTrue(tufmanFm.Gears.Where(x => x.Code == "L").Count()==1);
        //    Assert.IsTrue(tufmanFm.Gears.Where(x => x.Code == "P").Count() == 1);
        //    Assert.IsTrue(tufmanFm.Gears.Where(x => x.Code == "S").Count() == 1);
        //    unitOfWork.Rollback();
        //}

        //[TestMethod]
        //public void GetGears_From_TufmanCK_Source_Should_Return_2()
        //{
        //    UnitOfWork unitOfWork = new UnitOfWork(NHibernateHelper.SessionFactory);
        //    Repository repo = new Repository(unitOfWork.Session);
        //    Source tufmanFm = repo.Find<Source>(x => x.Description == "Tufman CK").FirstOrDefault();
        //    Assert.IsNotNull(tufmanFm);
        //    Assert.IsNotNull(tufmanFm.Gears);
        //    Assert.IsTrue(tufmanFm.Gears.Count == 2);
        //    Assert.IsTrue(tufmanFm.Gears.Where(x => x.Code == "L").Count() == 1);
        //    Assert.IsTrue(tufmanFm.Gears.Where(x => x.Code == "P").Count() == 0);
        //    Assert.IsTrue(tufmanFm.Gears.Where(x => x.Code == "S").Count() == 1);
        //    unitOfWork.Rollback();
        //}
    }
}
