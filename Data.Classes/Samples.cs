using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Classes
{
    public class Samples
    {
        [Key]
        public int SampleId { get; set; }
        [Required]
        public string Barcode { get; set; }
        [Column(TypeName = "date")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        [Required]
        public int CreatedBy { get; set; }
        [Required]
        public int StatusId { get; set; }
        [ForeignKey("CreatedBy")]
        public virtual Users CreatedByUser { get; set; }
        [ForeignKey("StatusId")]
        public virtual Statuses Status { get; set; }
    }
}