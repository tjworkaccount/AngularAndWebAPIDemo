using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Classes
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<Samples> Samples { get; set; }
    }
}
