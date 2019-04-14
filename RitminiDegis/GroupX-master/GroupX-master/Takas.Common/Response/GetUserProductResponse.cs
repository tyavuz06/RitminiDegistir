using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Takas.Common.Entities.Concrete;

namespace Takas.Common.Response
{
    public class GetUserProductResponse : BaseResponse
    {
        string deneme; //burası recepte tam gitmediği için eklendi
        public List<Product> Products { get; set; }
    }
}
