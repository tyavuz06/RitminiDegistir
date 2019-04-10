using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Takas.Business.Abstract;
using Takas.Common.Entities.Concrete;
using Takas.MvcWebUI.Models;

namespace Takas.MvcWebUI.Controllers
{
    public class ProductController : Controller
    {
        IProductService _productService;
        IProductImageGalleryService _productImageGalleryService;

        public ProductController(IProductService productService, IProductImageGalleryService productImageGalleryService)
        {
            _productService = productService;
            _productImageGalleryService = productImageGalleryService;
        }

        public ActionResult Index()
        {
            ViewBag.title = "Ürünler";

            return View();

        }
        
        // Ürün detay sayfasın ıcın method
		public async Task<ActionResult> Detail(int id)
        {
			// Burada Model kullanmak istedik
            ProductDetailViewModel productModel = new ProductDetailViewModel();
            productModel.Product = _productService.Get(id);
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
        public ActionResult AddProduct()
        {
            ViewBag.PageInfo = "ÜRÜN EKLE";
            return View();
        }
        [HttpPost]
        public ActionResult ProductAddComplete(Product product)
        {
            ViewBag.PageInfo = "ÜRÜN EKLE";
            return View();
        }

    }
}