using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Classes.Reference
{
    [Table("Statuses")]
    public class StatusReference
    {
        public int StatusId { get; set; }
        public string Status { get; set; }
    }
}