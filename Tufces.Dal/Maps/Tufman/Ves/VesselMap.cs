using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tufces.Domain.Tufman.Ves;

namespace Tufces.Dal.Maps.Tufman.Ves
{
    public class VesselMap : ClassMap<Vessel>
    {
        public VesselMap()
        {
            Schema("ves");
            Table("vessels");
            Id(x => x.VesselId).Column("vessel_id");
            Map(x => x.Flag).Column("flag_code");
            Map(x => x.Name).Column("vessel_name");
        }
    }
}
