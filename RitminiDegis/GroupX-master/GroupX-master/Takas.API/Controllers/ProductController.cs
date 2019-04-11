﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Takas.Common.Entities.Concrete;

namespace Takas.API.Controllers
{
    [EnableCors(origins: "http://localhost:50903/", headers: "*", methods: "*")]
    public class ProductController : ApiController
    {
        [HttpPost]
        [Route("api/Product/AddProduct")]
        public object AddProduct(Product product)
        {
            return null;
        }
    }
}
