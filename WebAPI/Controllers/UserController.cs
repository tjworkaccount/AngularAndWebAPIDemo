using System.Collections.Generic;
using System.Web.Http;
using Service.Reference;

namespace WebAPI.Controllers
{
    public class UserController : ApiController
    {
        private readonly UserService userService;

        public UserController()
        {
            userService = new UserService();
        }

        [HttpGet]
        public KeyValuePair<int, string>[] Get()
        {
            return userService.GetUsersList();
        }
    }
}