using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Takas.Business.Abstract;

namespace Takas.API.Controllers
{
	public class UserProfileController : ApiController
	{
		private IProductService _productService;

		public UserProfileController(IProductService productService)
		{
			_productService = productService;
		}

		[HttpGet]
		[Route("api/ahmet")]
		public string ahmet()
		{
			var deger =_productService.Get(5);

			return "RMA";
		}
	}
}
