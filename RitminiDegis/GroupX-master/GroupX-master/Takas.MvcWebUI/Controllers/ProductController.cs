using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Takas.Business.Abstract;
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
        
		public async Task<ActionResult> Detail(int id)
        {
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

    }
}