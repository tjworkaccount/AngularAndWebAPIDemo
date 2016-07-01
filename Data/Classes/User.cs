using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Classes
{
    public class User:BaseClass
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<Sample> Samples { get; set; }
    }
}
