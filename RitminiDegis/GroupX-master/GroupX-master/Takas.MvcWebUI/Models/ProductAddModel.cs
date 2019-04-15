using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Takas.Common.Entities.Concrete;

namespace Takas.MvcWebUI.Models
{
    public class ProductAddModel
    {
        public Product Product { get; set; }
        public List<Brand> Brands { get; set; }
        public List<Category> Categories { get; set; }
    }
}