using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tufces.Domain;

namespace Tufces.Dal.Maps
{
    public class DataTypeMap : ClassMap<DataType>
    {
        public DataTypeMap()
        {
            Schema("tufces");
            Table("data_types");
            Id(x => x.Id).Column("data_type_id");
            Map(x => x.Description).Column("data_type_desc");
        }
    }
}
