using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Takas.MvcWebUI.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.title = "Ürünler";

            return View();

        }
        
		public async Task<ActionResult> Detail(int id)
        {
            ProductDetailViewModel productModel = new ProductDetailViewModel();
            productModel.Product = _productService.GetProductById(id);
            if (productModel.Product != null)
            {
                productModel.productImageGalleries = await _productImageGalleryService.GetImageGallery(productModel.Product.ID);
            }
            else
            {
                return View("/Views/Shared/NotFound.cshtml");
            }
            ViewBag.title = "Ürün Detay | Ürün1";
            return View(productModel);
        }

    }
}