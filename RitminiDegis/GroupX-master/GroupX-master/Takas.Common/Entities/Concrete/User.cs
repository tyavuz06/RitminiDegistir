using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Takas.Common.Entities.Abstract;

namespace Takas.Common.Entities.Concrete
{
	public class User :IEntity
	{
		public int ID { get; set; }
		//[Required]
		//[StringLength(50)]
		[DisplayName("Ad")]
		public string Name { get; set; }
		//[Required]
		//[StringLength(50)]
		[DisplayName("Soyad")]
		public string Surname { get; set; }
		//[Required]
		//[StringLength(500)]
		[DisplayName("Adres")]
		public string Address { get; set; }
		//[Required]
		//[StringLength(100)]
		[DisplayName("Email")]
		public string Email { get; set; }
		//[Required]
		//[StringLength(16)]
		[DisplayName("Sifre")]
		public string Password { get; set; }
		//[Required]
		//[StringLength(11)]
		[DisplayName("Telefon")]
		public string PhoneNumber { get; set; }
		//[StringLength(250)]
		[DisplayName("Resim")]
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
