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
    public class DataTypeMapTest
    {
        [TestMethod]
        public void DataTypeMap_Simple_Test()
        {
            UnitOfWork unitOfWork = new UnitOfWork(NHibernateHelper.SessionFactory);
            Repository repo = new Repository(unitOfWork.Session);
            List<DataType> list = repo.GetAll<DataType>().ToList();
            Assert.AreEqual(8, list.Count);
            unitOfWork.Rollback();
        }
    }
}
