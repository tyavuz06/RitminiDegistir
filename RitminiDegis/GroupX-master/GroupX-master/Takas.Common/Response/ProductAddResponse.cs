using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Takas.Common.Entities.Concrete;

namespace Takas.Common.Response
{
    public class ProductAddResponse:BaseResponse
    {
        public Product Product { get; set; }
    }
}
