using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Takas.Entities.Abstract;
using Takas.Common;
using static Takas.Common.SystemConstants.SystemConstannts;

namespace Takas.Entities.Concrete
{
	public class UserComment : IEntity
	{
		public int ID { get; set; }

		//[Required]
		//[StringLength(500)]
		public string Comment { get; set; }
		//[Required]
		public DateTime Date { get; set; }
		//[Required]
		public Situation Situation { get; set; }

		//[StringLength(30)]
		//[Required]
		public string IP { get; set; }
		//[Required]
		public int FromUser_ID { get; set; }
		//[Required]
		public int ToUser_ID { get; set; }
        
	}
}
