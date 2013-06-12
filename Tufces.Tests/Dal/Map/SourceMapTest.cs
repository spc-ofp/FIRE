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
    public class SourceMapTest
    {
        [TestMethod]
        public void SourceMap_Simple_Test()
        {
            UnitOfWork unitOfWork = new UnitOfWork(NHibernateHelper.SessionFactory);
            Repository repo = new Repository(unitOfWork.Session);
            List<Source> list = repo.GetAll<Source>().ToList();
            Assert.AreEqual(17, list.Count);
            unitOfWork.Rollback();
        }

        //[TestMethod]
        //public void SourceMap_CheckTufmanFM_Gears_DataTypes()
        //{
        //    UnitOfWork unitOfWork = new UnitOfWork(NHibernateHelper.SessionFactory);
        //    Repository repo = new Repository(unitOfWork.Session);
        //    Source tufmanFm = repo.Get<Source>(12);
        //    Assert.IsNotNull(tufmanFm);
        //    Assert.IsNotNull(tufmanFm.Gears);
        //    Assert.IsTrue(tufmanFm.Gears.Count>0);
        //    Assert.IsNotNull(tufmanFm.DataTypes);
        //    Assert.IsTrue(tufmanFm.DataTypes.Count > 0);
        //    unitOfWork.Rollback();
        //}

        //[TestMethod]
        //public void SourceMap_ByName()
        //{
        //    UnitOfWork unitOfWork = new UnitOfWork(NHibernateHelper.SessionFactory);
        //    Repository repo = new Repository(unitOfWork.Session);
        //    Source tufmanFm = repo.Find<Source>(x => x.Description == "Tufman FM").FirstOrDefault();
        //    Assert.IsNotNull(tufmanFm);
        //    Assert.IsNotNull(tufmanFm.Gears);
        //    Assert.IsTrue(tufmanFm.Gears.Count > 0);
        //    Assert.IsNotNull(tufmanFm.DataTypes);
        //    Assert.IsTrue(tufmanFm.DataTypes.Count > 0);
        //    unitOfWork.Rollback();
        //}

    }
}
