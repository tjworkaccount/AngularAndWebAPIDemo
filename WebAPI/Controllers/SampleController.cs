using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Service.Classes.Sample;
using Service.Sample;

namespace WebAPI.Controllers
{
    public class SampleController : ApiController
    {
        private readonly SampleService _sampleService;

        public SampleController()
        {
            _sampleService = new SampleService();
        }

        [HttpGet]
        public SampleOutput[] Get()
        {
            return _sampleService.GetSamples();
        }
    }
}