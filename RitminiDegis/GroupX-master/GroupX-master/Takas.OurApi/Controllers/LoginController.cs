using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Takas.Entities.Concrete;
using Takas.OurApi.Models;

namespace Takas.OurApi.Controllers
{
    public class LoginController : ApiController
    {
        [Route("api/Login/GetUser")]
        public User GetUser(LoginRequestModel UserRequest)
        {
            return null;
        }
    }
}
