using System.Collections.Generic;

namespace Data.Classes
{
    public class Users
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<Samples> Samples { get; set; }
    }
}
