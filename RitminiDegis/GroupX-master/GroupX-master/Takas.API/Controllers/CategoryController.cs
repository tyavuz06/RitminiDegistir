using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using Takas.Business.Abstract;
using Takas.Common.Entities.Concrete;
using Takas.Common.Response;

namespace Takas.API.Controllers
{
    [EnableCors(origins: "http://localhost:50903/", headers: "*", methods: "*")]
    public class CategoryController : ApiController
    {
        ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        [Route("api/Category/GetCategories")]
        public async Task<object> GetCategories()
        {
            GetCategoryListResponse response = new GetCategoryListResponse();
            try
            {
                List<Category> categories = await _categoryService.GetList();
                response.Categories = categories;
                if (categories == null)
                    response.setError(Common.SystemConstants.SystemConstannts.ERROR_CODES.NOTFOUND);
                else
                    response.setError(Common.SystemConstants.SystemConstannts.ERROR_CODES.SUCCESS);
            }
            catch
            {
                response.setError(Common.SystemConstants.SystemConstannts.ERROR_CODES.SYSTEMERROR);
            }
          
            return response;
        }
    }
}
