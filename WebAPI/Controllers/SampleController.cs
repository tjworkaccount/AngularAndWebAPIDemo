using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Service.Classes.Sample;
using Service.Sample;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class SampleController : ApiController
    {
        private readonly SampleService _sampleService;

        public SampleController()
        {
            _sampleService = new SampleService();
        }

        /// <summary>
        /// Get All Samples That Match Corresponding Parameters
        /// 
        /// Note: Null is the default value for a parameter.
        /// </summary>
        /// <param name="userCreatedContains">Get all samples with a user's first or last name that matches the string userCreatedContains. Null prevents search.</param>
        /// <param name="statusId">Get all samples with a status that matches the id of the statusId. Null prevents search.</param>
        /// <param name="barcodeContains">Get all samples with a barcode that matchs the string barcodeContains. Null prevents search.</param>
        /// <returns></returns>
        [HttpGet]
        public SampleOutput[] Get(string userCreatedContains = null, int? statusId = null, string barcodeContains = null)
        {
            return _sampleService.GetSamples(userCreatedContains, statusId, barcodeContains);
        }

        /// <summary>
        /// Posts a new sample using a predefined object in the body
        /// </summary>
        /// <param name="input">
        ///     <param name="StatusId"> Status Id of new Sample</param>
        ///     <param name="UserId"> User Id of new Sample</param>
        ///     <param name="Barcode"> Barcode of new Sample</param>
        /// </param>
        /// <returns>HttpResponseMessage</returns>
        [HttpPost]
        public HttpResponseMessage Post([FromBody]SamplePostInputModel input)
        {
            try
            {
                _sampleService.CreateSample(input.UserId, input.StatusId, input.Barcode);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exception);
            }
        }
    }
}