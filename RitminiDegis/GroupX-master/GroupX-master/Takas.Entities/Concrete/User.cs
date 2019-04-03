using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Takas.Entities.Abstract;

namespace Takas.Entities.Concrete
{
	public class User : IEntity
	{
        public int ID { get; set; }
        //[Required]
        //[StringLength(50)]
        public string Name { get; set; }
        //[Required]
        //[StringLength(50)]
        public string Surname { get; set; }
        //[Required]
        //[StringLength(500)]
        public string Address { get; set; }
        //[Required]
        //[StringLength(100)]
        public string Email { get; set; }
        //[Required]
        //[StringLength(16)]
        public string Password { get; set; }
        //[Required]
        //[StringLength(11)]
        public string PhoneNumber { get; set; }
        //[StringLength(250)]
        public string Image { get; set; }
        public string ValidationKey { get; set; }

        public int RoleID { get; set; }

        public DateTime AccountCreateDate { get; set; }

        public DateTime AccountActiveDate { get; set; }

        public bool isActive { get; set; }

        public int WrongCount { get; set; }

        public bool isBlocked { get; set; }


        //yeni eklendi user ın durumunu belirtiyor
        public int ActiveStatus { get; set; }

        public virtual ICollection<Token> Tokens { get; set; }

    }
}
