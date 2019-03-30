using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Takas.Entities.Abstract;
using static Takas.Common.SystemConstants.SystemConstannts;

namespace Takas.Entities.Concrete
{
	public class Exchange :IEntity
	{
		public int ID { get; set; }
		//[Required]
		public DateTime Date { get; set; }
		//[Required]
		public Situation Situation { get; set; }
		//[Required]
		public int UserRequest_ID { get; set; }

		public int UserRequested_ID { get; set; }
	}
}
