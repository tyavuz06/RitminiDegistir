using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Takas.Common.Entities.Abstract;

namespace Takas.Common.Entities.Concrete
{
	public class Category : IEntity
	{
		public int ID { get; set; }

		//[Required]
		//[StringLength(50)]
		public string Name { get; set; }
	}
}
