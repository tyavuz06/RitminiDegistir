using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using Takas.Common.Entities.Concrete;
using Takas.Common.Response;
using System.Web;
using System.IO;
using Takas.Business.Abstract;
using Takas.Common.SystemConstants;

namespace Takas.API.Controllers
{
	[EnableCors(origins: "http://localhost:50903/", headers: "*", methods: "*")]
	public class ProductController : ApiController
	{
		IProductService _productService;
		private IUserService _userService;
		public ProductController(IProductService productService, IUserService userService)
		{
			_productService = productService;
			_userService = userService;
		}

		[HttpPost]
		[Route("api/Product/AddProductImageToFolder")]
		public HttpResponseMessage AddProductImageToFolder()
		{
			string path = HttpContext.Current.Server.MapPath("~/Uploads");
			if (!Directory.Exists(path))
			{
				Directory.CreateDirectory(path);
			}
			HttpResponseMessage result = null;
			var httpRequest = HttpContext.Current.Request;
			if (httpRequest.Files.Count > 0)
			{
				var docfiles = new List<string>();
                foreach (string file in httpRequest.Files)
                {
                    var postedFile = httpRequest.Files[file];
                    var filePath = HttpContext.Current.Server.MapPath("~/Uploads/" + postedFile.FileName);
                    postedFile.SaveAs(filePath);
					docfiles.Add(filePath);
				}
				result = Request.CreateResponse(HttpStatusCode.OK, docfiles);
			}
			else
			{
				result = Request.CreateResponse(HttpStatusCode.BadRequest);
			}
			return result;
		}
		[HttpPost]
		[Route("api/Product/AddProduct")]
		public object AddProduct(Product product)
		{
			ProductAddResponse addResponse = new ProductAddResponse();
			try
			{
				_productService.Add(product);
				addResponse.setError(Common.SystemConstants.SystemConstannts.ERROR_CODES.SUCCESS);
				addResponse.Product = product;
			}
			catch (Exception ex)
			{
				addResponse.setError(Common.SystemConstants.SystemConstannts.ERROR_CODES.SYSTEMERROR);
				addResponse.Product = null;
			}

			return addResponse;
		}
    }
}
