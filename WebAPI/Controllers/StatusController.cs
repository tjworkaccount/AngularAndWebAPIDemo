using System.Collections.Generic;
using System.Web.Http;
using Service.Reference;

namespace WebAPI.Controllers
{
    public class StatusController : ApiController
    {
        private readonly StatusService statusService;

        public StatusController()
        {
            statusService = new StatusService();
        }

        [HttpGet]
        public KeyValuePair<int, string>[] Get()
        {
            return statusService.GetStatusList();
        }
    }
}