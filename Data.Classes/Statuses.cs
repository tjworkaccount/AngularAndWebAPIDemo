using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Classes
{
    public class Statuses
    {
        [Key]
        public int StatusId { get; set; }
        [Required]
        public string Status { get; set; }
        public virtual ICollection<Samples> Samples { get; set; }

        public override string ToString()
        {
            return this.Status;
        }
    }
}