using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Takas.Common.Entities.Abstract;

namespace Takas.Common.Entities.Concrete
{
	public class ProductImageGallery :IEntity
	{
		public int ID { get; set; }

		//[Required]
		//[StringLength(200)]
		public string Image { get; set; }
		//[Required]
		public int Product_ID { get; set; }
	}
}
