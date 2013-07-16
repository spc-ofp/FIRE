﻿using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tufces.Domain;

namespace Tufces.Dal.Maps
{
    public class SourceDataTypeMap : ClassMap<SourceDataType>
    {
        public SourceDataTypeMap()
        {
            Schema("tufces");
            Table("source_data_types");
            Id(x => x.Id).Column("source_data_type_id");
            References<Source>(x => x.Source, "source_id");
            References<DataType>(x => x.DataType, "data_type_id");
            References<Gear>(x => x.Gear, "gear_code");
        }
    }
}
