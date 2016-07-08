using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Classes.Reference
{
    [Table("Samples")]
    public class SampleReference
    {
        public int SampleId { get; set; }
        public string Barcode { get; set; }
        public DateTime CreatedAt { get; set; }        
        public UserReference CreatedBy { get; set; }
        public StatusReference Status { get; set; }
    }
}