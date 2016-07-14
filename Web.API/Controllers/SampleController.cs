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
        /// <param name="page">The current page being searched. Default is first page.</param>
        /// <param name="size">The current size of the page. Default is 10 records.</param>
        /// <param name="user">Get all samples with a user's first or last name that matches the string userCreatedContains. Null prevents search.</param>
        /// <param name="statusId">Get all samples with a status that matches the id of the statusId. Null prevents search.</param>
        /// <param name="barcode">Get all samples with a barcode that matchs the string barcodeContains. Null prevents search.</param>
        /// <returns></returns>
        [HttpGet]
        public SampleOutput[] Get(int page = 1, int size = 10, string user = null, int? statusId = null, string barcode = null)
        {
            return _sampleService.GetSamples(page, size, user, statusId, barcode);
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