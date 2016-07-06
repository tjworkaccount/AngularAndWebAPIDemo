using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Classes
{
    public class Statuses
    {
        [Key]
        public int StatusId { get; set; }
        public string Status { get; set; }
        public virtual ICollection<Samples> Samples { get; set; }
    }
}
