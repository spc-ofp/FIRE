using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tufces.Domain
{
    public class SourceDataType
    {
        public virtual int Id { get; set; }
        public virtual Source Source { get; set; }
        public virtual DataType DataType { get; set; }
        public virtual Gear Gear { get; set; }
    }
}
