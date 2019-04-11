using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Takas.Business.Abstract;
using Takas.Common.Entities.Concrete;

namespace Takas.MvcWebUI.Controllers
{
    public class OrnekController : Controller
    {

        // Arkadaslar HomeController Constructor inda neyle calismak istiyorsak onlari yaziyoruz. Ben Burada hem IUserService hemde IProductService ile calisacagimi soyluyorum
        //Bu Isleme DependencyInjection Diyoruz bunlarıda Ioc Container denilen araçlarla yapıyoruz biz bu projede Ninject Ioc Container ını kullandık. dependencyinjection klasörü
        // Altında Ninject ile ilgili class lara erişebilirsiniz.	
        private IUserService _userService;
        private IProductService _productService;


        public OrnekController(IProductService productService, IUserService userService) // Dışarıdan Constructor da bunları set etmiş oluyoruz. Burayı ninject yapcak dert etmemize gerek yok. Siz Kendi Controller larınızde üstteki kullanım gibi bir (Alt tire _) ile başlayan İnterface bir de constructor da normal yazılmış interface oluşturarak bunu constructor bloğu içerisinde set etmeniz gerekir aşağıda yaptığım gibi.
        {
            _productService = productService; // Buradaki _ ile baslayan degerler sizin kullanacaginiz degerler. Paranter icindekiler ise Ninject ile bind edilecek olan degerlerdir.
            _userService = userService;

            // Arkadaşlar Bu Nesnelerimizi kullanarak biz katmanlar arasında geçiş yaparak veritabanı işlemlerini gerçekleştiriyoruz.



        }

        // GET: Ornek
        public ActionResult Index()
        {
            var gelenListe = _productService.GetList(); // Tum Productlarin Listesini Getirir

            int id = 5; // Bu Id değişkenini biz dışarıdan almış olacağız. Yani Kullanıcı birşeyi güncellemek istediğinde onun ıd sini göndererek o kayıdı cekip güncelleme yapacağız gibi düşünün.

            var gelenTekProduct = _productService.Get(id); // Tek bir Aranan Kaydi Doner => Kullanici Id si 5 olan kullanici bul gibi mesela

            Product yeniProduct = new Product // Product Türünde Nesne oluşturdum. İşte Veritabanındaki Prdocut Tablosundaki Tekbir Satır veriye denk gelir bu.
            {
                //Address = "Bursa",
                Category_ID = 5,
                Date = DateTime.Now,
                Description = "rma"
            };

            _productService.Add(yeniProduct); // Ekleme Islemi yapiyoruz. Vertabanina Ekleme islemi yapiliyor // Önce Business(SERVİCE) katmanına gidiyor değer sonra oradan DataAccess katmanına aktarılacak ve orada veritabanına ekleme işlemi yapılacak.

            _productService.Update(yeniProduct); // Guncelleme Islemi Yapiyorz


            // Silme islemi yapilacaktir. Silme islemi id ye gore yapilmamaktadir. Tablodaki degeri komple cekiyoruz sonsa bunuu sil diyerek veritabanina yolluyorz oda Bizim yerimize siliyor.
            _productService.Delete(yeniProduct); // Product turunde bir instance yolladim silme islemi icin


            return View();
        }
    }
}