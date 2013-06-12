using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tufces.Domain;

namespace Tufces.Dal.Maps
{
    public class GearMap : ClassMap<Gear>
    {
        public GearMap()
        {
            Schema("tufces");
            Table("gears");
            Id(x => x.Code).Column("gear_code");
            Map(x => x.Description).Column("gear_desc");
        }
    }
}
