using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Takas.Common.Entities.Concrete;


namespace Takas.Business.Abstract
{
	public interface IProductImageGalleryService
	{
		/// <summary>
		/// Bu Method VeriTabanindaki Tum ProductImageGallery Listesini Getitir.
		/// </summary>
		/// <returns>ProductImageGallery List</returns>
		Task<List<ProductImageGallery>> GetList();
		
		/// <summary>
		/// Bu Method VeriTabanindaki Tum ProductImageGallery Listesini Getitir.
		/// </summary>
		/// <returns>ProductImageGallery List</returns>
		Task<List<ProductImageGallery>> GetImageGallery(int ID);

		/// <summary>
		/// Veritabanindan ARANAN ProductImageGallery kaydını doner.
		/// </summary>
		/// <param name="id"> Verilen Id parametresine gore veritabaninda arama yapilir</param>
		/// <returns>ProductImageGallery</returns>
		ProductImageGallery Get(int id);

		/// <summary>
		/// Veritabanina Yeni bir ProductImageGallery Eklemek icin bu method kullanilir.
		/// </summary>
		/// <param name="entity">Bu Parametre ProductImageGallery Türünde bir nesnedir.</param>
		void Add(ProductImageGallery entity);

		/// <summary>
		/// Veritabanindaki kaydi gelen kayida gore gunceller.
		/// </summary>
		/// <param name="entity">ProductImageGallery Turunde bir degisken gonderiliyor ve bu degiskene gore ProductImageGallery tablosuna ekleme yapmasi isteniyor.</param>
		void Update(ProductImageGallery entity);

		/// <summary>
		/// Veritabanindaki ProductImageGallery tablosundan tek bir kayit silinmaktadir.
		/// </summary>
		/// <param name="entity">ProductImageGallery türünde bir nesne veriyoruz ve veritabanından o nesne siliniyor.</param>
		void Delete(ProductImageGallery entity);
	}
}
