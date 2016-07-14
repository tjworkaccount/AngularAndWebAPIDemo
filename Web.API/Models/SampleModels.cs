using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class SamplePostInputModel
    {
        public int StatusId { get; set; }
        public int UserId { get; set; }
        public string Barcode { get; set; }
    }
}