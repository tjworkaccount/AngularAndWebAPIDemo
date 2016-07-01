using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Classes
{
    public class Status:BaseClass
    {
        public string Value { get; set; }
        public virtual ICollection<Sample> Samples { get; set; }
    }
}
