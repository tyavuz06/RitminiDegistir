using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Takas.Common.Entities.Abstract;

namespace Takas.Common.Entities.Concrete
{
	public class Favorite :IEntity
	{
		public int ID { get; set; }
		//[Required]
		public DateTime Date { get; set; }
		//[Required]
		public int Product_ID { get; set; }
		//[Required]
		public int User_ID { get; set; }
	}
}
