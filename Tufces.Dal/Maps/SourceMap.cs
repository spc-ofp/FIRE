using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tufces.Domain;

namespace Tufces.Dal.Maps
{
    public class SourceMap : ClassMap<Source>
    {
        public SourceMap()
        {
            Schema("tufces");
            Table("sources");
            Id(x => x.Id).Column("source_id");
            Map(x => x.Description).Column("source_desc");
            Map(x => x.Type).Column("source_type");
            Map(x => x.GroupId).Column("source_group_id");
            Map(x => x.SqlDriver).Column("sql_driver");
            Map(x => x.Server).Column("source_server");
            Map(x => x.Database).Column("source_db");
            Map(x => x.SqlLogin).Column("sql_userlogin");
            Map(x => x.SqlUserName).Column("sql_username");
            Map(x => x.SqlPassword).Column("sql_password");
            //HasManyToMany<Gear>(x => x.Gears).Schema("tufces").Table("source_data_types").ParentKeyColumn("source_id").ChildKeyColumn("gear_code").LazyLoad();
            //HasManyToMany<DataType>(x => x.DataTypes).Schema("tufces").Table("source_data_types").ParentKeyColumn("source_id").ChildKeyColumn("data_type_id");
        }
    }
}
