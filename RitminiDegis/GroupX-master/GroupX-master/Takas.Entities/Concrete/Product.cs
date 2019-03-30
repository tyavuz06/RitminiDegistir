using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Takas.Entities.Abstract;
using static Takas.Common.SystemConstants.SystemConstannts;

namespace Takas.Entities.Concrete
{
	public class Product :IEntity
	{
		public Product()
		{
			Favourites = new HashSet<Favorite>();
			ProductImageGalleries = new HashSet<ProductImageGallery>();
		}

		public int ID { get; set; }
        //[Required]
        //[StringLength(50)]
        public string Brand { get; set; }
        //[Required]
        //[StringLength(50)]
        public string Model { get; set; }
        //[Required]
        //[StringLength(50)]
        public string Name { get; set; }

		//[Required]
		//[StringLength(500)]
		public string Description { get; set; }

		//[Required]
		//[StringLength(500)]
		public string Address { get; set; }
		//[Required]
		public DateTime Date { get; set; }

		//[Required]
		//[StringLength(200)]
		public string Image { get; set; }
		//[Required]
		public Situation Situation { get; set; }
		//[Required]
		public int Category_ID { get; set; }
		//[Required]
		public int User_ID { get; set; }

		public virtual Category Category { get; set; }

	
		public virtual ICollection<Favorite> Favourites { get; set; }

	
		public virtual ICollection<ProductImageGallery> ProductImageGalleries { get; set; }

		public virtual User User { get; set; }
	}
}
