using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Takas.Common.Entities.Concrete;


namespace Takas.Business.Abstract
{
    public interface IProductService
    {
		/// <summary>
		/// Bu Method VeriTabanindaki Tum Product larin Listesini Getitir.
		/// </summary>
		/// <returns></returns>
		Task<List<Product>> GetList();

		/// <summary>
		/// Veritabanindan ARANAN Product Kaydi doner.
		/// </summary>
		/// <param name="id"> Verilen Id parametresine gore veritabaninda arama yapilir</param>
		/// <returns>Product</returns>
		Product Get(int id);

		/// <summary>
		/// Veritabanina Yeni bir Product Eklemek icin bu method kullanilir.
		/// </summary>
		/// <param name="yeniProduct"></param>
		void Add(Product yeniProduct);

		/// <summary>
		/// Veritabanindaki kaydi gelen kayida gore gunceller.
		/// </summary>
		/// <param name="yeniProduct">PRoduct Turunde bir degisken gonderiliyor ve bu degiskene gore Product tablosuna ekleme yapmasi isteniyor.</param>
		void Update(Product yeniProduct);

		/// <summary>
		/// Veritabanindaki Product tablosundan tek bir kayit silinmaktadir.
		/// </summary>
		/// <param name="yeniProduct">Girilen bir Entity degeri ve burada Id ile oldurmeyp daha dogru yontemler kullanilabilir.</param>
		void Delete(Product yeniProduct);

		/// <summary>
		/// Gelen UserId ye gore Kullaniciya ait Productlari listeliyoruz.
		/// </summary>
		/// <param name="userId">Kullaniciya ait UserId bilgisini gonderiyoruz</param>
		List<Product> GetListByUserId(int userId);
    }
}
