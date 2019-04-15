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
    public class BrandController : ApiController
    {
        IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpPost]
        [Route("api/Brand/GetBrands")]
        public async Task<object> GetBrands()
        {
            GetBrandListResponse response = new GetBrandListResponse();
            try
            {
                List<Brand> brands = await _brandService.GetList();
                response.Brands = brands;
                if (brands != null)
                    response.setError(Common.SystemConstants.SystemConstannts.ERROR_CODES.SUCCESS);
                else
                    response.setError(Common.SystemConstants.SystemConstannts.ERROR_CODES.NOTFOUND);
            }
            catch
            {
                response.setError(Common.SystemConstants.SystemConstannts.ERROR_CODES.SYSTEMERROR);
            }
            return response;
        }
    }
}
