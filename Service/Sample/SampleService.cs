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

        public SampleOutput[] GetSamples(string userCreated = null, int? statusId = null)
        {
            try
            {
                var temp = _sampleRepository.GetSamples(userCreated, statusId).ToArray();
                return Array.ConvertAll(temp, item => (SampleOutput)item);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}