using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Classes
{
    public class Sample:BaseClass
    {
        public string Barcode { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int CreatedBy { get; set; }
        public virtual User CreatedByUser { get; set; }
        public int StatusId { get; set; }
        public virtual Status Status { get; set; }
    }
}
