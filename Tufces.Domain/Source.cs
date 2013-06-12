using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tufces.Domain
{
    public class Source
    {
        public virtual int Id { get; set; }
        public virtual String Description { get; set; }
        public virtual int Type { get; set; }
        public virtual int GroupId { get; set; }
        public virtual String Server { get; set; }
        public virtual String SqlDriver { get; set; }
        public virtual String Database { get; set; }
        public virtual Boolean SqlLogin { get; set; }
        public virtual String SqlUserName { get; set; }
        public virtual String SqlPassword { get; set; }
        //public virtual IList<Gear> Gears { get; set; }
        //public virtual IList<DataType> DataTypes { get; set; }
    }
}
