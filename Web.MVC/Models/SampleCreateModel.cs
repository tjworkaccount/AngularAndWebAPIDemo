using System.ComponentModel.DataAnnotations;

namespace Web.MVC.Models
{
    public class SampleCreateModel
    {
        [Required, Display(Name = "Status")]
        public int? StatusId { get; set; }

        [Required, Display(Name = "Creator")]
        public int? UserId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Empty Barcodes Are Invalid"), Display(Name = "Barcode")]
        public string Barcode { get; set; }

    }
}