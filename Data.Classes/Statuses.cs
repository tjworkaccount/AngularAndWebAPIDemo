using System.Collections.Generic;

namespace Data.Classes
{
    public class Statuses
    {
        public int StatusId { get; set; }
        public string Status { get; set; }
        public virtual ICollection<Samples> Samples { get; set; }
    }
}