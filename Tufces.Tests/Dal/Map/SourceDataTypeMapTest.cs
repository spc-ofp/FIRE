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
    public class SourceDataTypeMapTest
    {
        [TestMethod]
        public void SourceDataTypeMap_TufmanFM_GearPS_ReturnsLogsheetDataType()
        {
            UnitOfWork unitOfWork = new UnitOfWork(NHibernateHelper.SessionFactory);
            Repository repo = new Repository(unitOfWork.Session);
            List<SourceDataType> sourceDataTypes = repo.Find<SourceDataType>(x => x.Gear.Code == "S" && x.Source.Id == 12).ToList();
            repo.GetAll<Gear>();
            Assert.IsNotNull(sourceDataTypes);
            Assert.IsTrue(sourceDataTypes.Count == 1);
            Assert.IsTrue(sourceDataTypes[0].DataType.Id==1);
        }
    }
}
