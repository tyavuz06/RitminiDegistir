using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Takas.Entities.Concrete;

namespace Takas.MvcWebUI.Models
{
    public class ProductDetailViewModel
    {
        public Product Product { get; set; }
        public List<ProductImageGallery> productImageGalleries { get; set; }
    }
}