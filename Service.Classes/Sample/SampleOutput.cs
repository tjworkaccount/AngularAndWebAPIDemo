using System;
using System.Runtime.Remoting.Messaging;
using Data.Classes;

namespace Service.Classes.Sample
{
    public class SampleOutput
    {
        public int Id { get; set; }
        public string Barcode { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedById { get; set; }
        public string CreatedBy { get; set; }
        public int StatusId { get; set; }
        public string Status { get; set; }

        public static explicit operator SampleOutput(Samples samples)
        {
            return new SampleOutput
            {
                Id = samples.SampleId,
                Barcode = samples.Barcode,
                CreatedAt = samples.CreatedAt,
                CreatedById = samples.CreatedBy,
                CreatedBy = samples.CreatedByUser.ToString(),
                StatusId = samples.StatusId,
                Status = samples.Status.ToString()
            };
        }
    }
}