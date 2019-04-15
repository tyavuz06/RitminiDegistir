using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Takas.Common.Entities.Concrete;

namespace Takas.Common.Response
{
    public class GetBrandListResponse:BaseResponse
    {
        public List<Brand> Brands { get; set; }
    }
}
