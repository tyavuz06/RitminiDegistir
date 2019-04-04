using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Takas.Entities.Abstract;

namespace Takas.Entities.Concrete
{
    public class SocialUser : IEntity
    {
        [Key]
        public int UserID { get; set; }
        public int SocialType { get; set; }
        public string SOCIALID { get; set; }
        public string Token { get; set; }
        public DateTime CreateDate { get; set; }

        [ForeignKey("UserID")]
        public virtual User User { get; set; }
    }
}
