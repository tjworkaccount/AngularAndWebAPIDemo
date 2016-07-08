using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Classes.Reference
{
    [Table("Users")]
    public class UserReference
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}