using System.Collections.Generic;
using System.Web.Http;
using Service.Reference;

namespace WebAPI.Controllers
{
    public class UserController : ApiController
    {
        private readonly UserService _userService;

        public UserController()
        {
            _userService = new UserService();
        }

        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public KeyValuePair<int, string>[] Get()
        {
            return _userService.GetUsersList();
        }
    }
}