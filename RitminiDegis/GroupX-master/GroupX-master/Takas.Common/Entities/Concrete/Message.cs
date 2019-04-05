using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Takas.Common.Entities.Abstract;

namespace Takas.Common.Entities.Concrete
{
	public class Message :IEntity
	{
		public int ID { get; set; }

		//[Required]
		//[StringLength(500)]
		public string MessageContent { get; set; }
		//[Required]
		public DateTime Date { get; set; }

		//[Required]
		//[StringLength(30)]
		public string IP { get; set; }
		//[Required]
		public int FromUser_ID { get; set; }
		//[Required]
		public int ToUser_ID { get; set; }
	}
}
