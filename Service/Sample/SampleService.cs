using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Classes;
using Repository.Sample;
using Service.Classes.Sample;

namespace Service.Sample
{
    public class SampleService
    {
        private readonly ISampleRepository _sampleRepository;

        public SampleService()
        {
            _sampleRepository = new SampleRepository();
        }

        public SampleOutput[] GetSamples(int pageNumber = 1, int pageSize = 10, string userCreated = null, int? statusId = null, string barcode = null)
        {
            return Array.ConvertAll(_sampleRepository.GetSamples(pageNumber, pageSize, userCreated, statusId, barcode).ToArray(), item => (SampleOutput)item);
        }

        public int GetTotalCount(string userCreated, int? statusId, string barcode)
        {
            return _sampleRepository.GetTotalCount(userCreated, statusId, barcode);
        }

        public bool IsValid(int pageNumber, int pageSize, string userCreated, int? statusId, string barcode)
        {
            return _sampleRepository.IsValid(pageNumber, pageSize, userCreated, statusId, barcode);
        }

        public bool CreateSample(int userId, int statusId, string barcode)
        {
            return _sampleRepository.InsertSample(userId, statusId, barcode);
        }

    }
}