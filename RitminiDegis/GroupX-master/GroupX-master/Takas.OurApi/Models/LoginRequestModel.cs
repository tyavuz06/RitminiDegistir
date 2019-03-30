using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Takas.OurApi.Models
{
    public class LoginRequestModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}