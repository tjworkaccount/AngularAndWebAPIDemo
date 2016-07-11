using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public SampleOutput[] GetSamples()
        {
            return Array.ConvertAll(_sampleRepository.GetSamples().ToArray(), item => (SampleOutput) item);
        }
    }
}