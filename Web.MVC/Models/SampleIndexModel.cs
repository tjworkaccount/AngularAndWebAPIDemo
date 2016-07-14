using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Service.Classes.Sample;

namespace Web.MVC.Models
{
    public class SampleIndexModel
    {
        public List<SampleIndexRecord> SampleIndexRecords { get; set; }

        [Range(1,int.MaxValue)]
        public int Page { get; set; }

        [Range(1, 100, ErrorMessage = "100 Records Max Per Page")]
        public int Size { get; set; }

        [Display(Name = "User Search")]
        public string User { get; set; }

        [Display(Name = "Status")]
        public int? Status { get; set; }

        [Display(Name = "Barcode Search")]
        public string Barcode { get; set; }

        public SampleIndexModel()
        {
            SampleIndexRecords = new List<SampleIndexRecord>();
        }

        public void InsertRecords(SampleOutput[] sampleOutputs)
        {
            SampleIndexRecords = Array.ConvertAll(sampleOutputs, item => (SampleIndexRecord)item).ToList();
        }
    }

    public class SampleIndexRecord
    {
        //public int Id { get; set; }
        [Display(Name = "Barcode")]
        public string Barcode { get; set; }
        [Display(Name = "Date Created"), DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime CreatedAt { get; set; }
        //public int CreatedById { get; set; }
        [Display(Name = "User Created")]
        public string CreatedBy { get; set; }
        //public int StatusId { get; set; }
        [Display(Name = "Sample Status")]
        public string Status { get; set; }

        public static explicit operator SampleIndexRecord (SampleOutput samples)
        {
            return new SampleIndexRecord()
            {
                //Id = samples.Id,
                Barcode = samples.Barcode,
                CreatedAt = samples.CreatedAt,
                //CreatedById = samples.CreatedById,
                CreatedBy = samples.CreatedBy,
                //StatusId = samples.StatusId,
                Status = samples.Status
            };
        }
    }
}