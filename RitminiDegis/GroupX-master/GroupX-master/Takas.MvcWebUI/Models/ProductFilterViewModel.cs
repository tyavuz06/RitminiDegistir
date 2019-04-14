using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Takas.Common.Entities.Concrete;

namespace Takas.MvcWebUI.Models
{
	public class ProductFilterViewModel
	{
		public List<Product> Products { get; set; }

		public List<Category> Categories { get; set; }

	}
}