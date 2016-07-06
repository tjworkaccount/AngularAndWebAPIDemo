using System;
using System.ComponentModel.DataAnnotations;

namespace Data.Classes
{
    public class Samples
    {
        [Key]
        public int SampleId { get; set; }
        public string Barcode { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int CreatedBy { get; set; }
        public virtual Users CreatedByUser { get; set; }
        public int StatusId { get; set; }
        public virtual Statuses Status { get; set; }
    }
}
