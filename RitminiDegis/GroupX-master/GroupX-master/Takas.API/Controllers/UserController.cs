using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Takas.Business.Abstract;
using Takas.Common.Entities.Concrete;
using Takas.Common.Response;

namespace Takas.API.Controllers
{
    [EnableCors(origins: "http://localhost:50903/", headers: "*", methods: "*")]
    public class UserController : ApiController
    {
        IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public object GetUserFromID(int ID)
        {
            UserResponse userResponse = new UserResponse();
            try
            {
                userResponse.User = _userService.Get(ID);
                userResponse.setError(Common.SystemConstants.SystemConstannts.ERROR_CODES.SUCCESS);
                return userResponse;
            }
            catch
            {
                userResponse.User = null;
                userResponse.setError(Common.SystemConstants.SystemConstannts.ERROR_CODES.SYSTEMERROR);
                return userResponse;
            }
        }
    }
}
