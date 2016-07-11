using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Classes
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public virtual ICollection<Samples> Samples { get; set; }

        public override string ToString()
        {
            return this.LastName + ", " + this.FirstName;
        }
    }
}