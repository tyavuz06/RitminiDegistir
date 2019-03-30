using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Takas.Business.Abstract;
using Takas.Entities.Concrete;

namespace Takas.API.Controllers
{
	public class UserProfilController : ApiController
	{
		private IProductService _productService;

		public UserProfilController(IProductService productService)
		{
			_productService = productService;
		}

		public List<Product> ListUserProducts(int UserId)
		{
			var UserList = _productService.GetListByUserId(UserId);

			return null;
		}
	}
}
