using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Takas.Common.Entities.Abstract;
using Takas.Common.SystemConstants;

namespace Takas.Common.Entities.Concrete
{
    public class Product : IEntity
    {
        public int ID { get; set; }
        //[Required]
        //[StringLength(50)]
        public int BrandID { get; set; }
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
        public DateTime Date { get; set; }
        //[Required]
        //[StringLength(200)]
        public string Image { get; set; }
        //[Required]
        public SystemConstannts.Situation Situation { get; set; }
        //[Required]
        public int Category_ID { get; set; }
        //[Required]
        public int User_ID { get; set; }
        [ForeignKey("Category_ID")]
        public virtual Category Category { get; set; }
        [ForeignKey("BrandID")]
        public virtual Brand Brand { get; set; }
        [ForeignKey("User_ID")]
        public virtual User User { get; set; }
    }
}
