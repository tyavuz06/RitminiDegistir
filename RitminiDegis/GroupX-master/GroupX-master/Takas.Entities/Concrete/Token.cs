﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Takas.Entities.Abstract;

namespace Takas.Entities.Concrete
{
	public class Token : IEntity
	{
		public int ID { get; set; }
        //[Required]
        public int User_ID { get; set; }
        //[Required]
        //[StringLength(150)]
        public string TokenValue { get; set; }
		//[Required]
		public DateTime StartDate { get; set; }
		//[Required]
		public DateTime ExpireDate { get; set; }
		//[StringLength(30)]
		public string IP { get; set; }
		//[StringLength(30)]
		public string OS { get; set; }
		//[StringLength(50)]
		public string Browser { get; set; }
    }
}
