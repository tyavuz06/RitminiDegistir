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

        [HttpPost]
        [Route("api/UserProfile/GetMyProducts")]
        public object GetMyProducts(User user)
        {
            // List<Product> myProducts = _productService.GetListByUserId(user.ID);
            GetUserProductResponse response = new GetUserProductResponse();
            try
            {
               
                var List = _productService.GetProductList(user.ID);
                if(List == null)
                {
                    response.Products = null;
                    response.setError(Common.SystemConstants.SystemConstannts.ERROR_CODES.NOTFOUND);
                }
                response.Products = List;
                response.setError(Common.SystemConstants.SystemConstannts.ERROR_CODES.SUCCESS);
            }catch(Exception ex)
            {
                response.setError(Common.SystemConstants.SystemConstannts.ERROR_CODES.SYSTEMERROR);
                response.Products = null;
            }
           
            return response;
        }
    }
}
