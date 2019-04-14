using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Takas.Common.Entities.Concrete;

namespace Takas.Common.Response
{
	public class ProductReturnResponse : BaseResponse
	{
		public  List<Product> Products { get; set; }
	}
}
