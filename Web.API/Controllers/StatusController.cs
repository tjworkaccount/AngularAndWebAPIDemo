using System.Collections.Generic;
using System.Web.Http;
using Service.Reference;

namespace WebAPI.Controllers
{
    public class StatusController : ApiController
    {
        private readonly StatusService _statusService;

        public StatusController()
        {
            _statusService = new StatusService();
        }

        /// <summary>
        /// Get All Statuses
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public KeyValuePair<int, string>[] Get()
        {
            return _statusService.GetStatusList();
        }
    }
}