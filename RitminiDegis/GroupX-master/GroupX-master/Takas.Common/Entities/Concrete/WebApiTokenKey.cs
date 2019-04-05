using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Takas.Common.Entities.Abstract;

namespace Takas.Common.Entities.Concrete
{
	public class WebApiTokenKey : IEntity
	{
		public int ID { get; set; }

		public string UserName { get; set; }

		public string UserKey { get; set; }

		public string UserRole { get; set; }
	}
}
