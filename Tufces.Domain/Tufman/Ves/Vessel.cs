using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tufces.Domain.Tufman.Ves
{
    public class Vessel
    {
        public virtual int VesselId { get; set; }
        public virtual string Name { get; set; }
        public virtual string Flag { get; set; }
    }
}
