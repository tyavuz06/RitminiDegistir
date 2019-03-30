using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Takas.Entities.Concrete;

namespace Takas.Business.Abstract
{
	public interface IExchangeService
	{

		/// <summary>
		/// Bu Method VeriTabanindaki Tum Exchange Listesini Getitir.
		/// </summary>
		/// <returns>Exchange List</returns>
		Task<List<Exchange>> GetList();

		/// <summary>
		/// Veritabanindan ARANAN Exchange kaydını doner.
		/// </summary>
		/// <param name="id"> Verilen Id parametresine gore veritabaninda arama yapilir</param>
		/// <returns>Exchange</returns>
		Exchange Get(int id);

		/// <summary>
		/// Veritabanina Yeni bir Exchange Eklemek icin bu method kullanilir.
		/// </summary>
		/// <param name="entity">Bu Parametre Exchange Türünde bir nesnedir.</param>
		void Add(Exchange entity);

		/// <summary>
		/// Veritabanindaki kaydi gelen kayida gore gunceller.
		/// </summary>
		/// <param name="entity">Exchange Turunde bir degisken gonderiliyor ve bu degiskene gore Exchange tablosuna ekleme yapmasi isteniyor.</param>
		void Update(Exchange entity);

		/// <summary>
		/// Veritabanindaki Exchange tablosundan tek bir kayit silinmaktadir.
		/// </summary>
		/// <param name="entity">Exchange türünde bir nesne veriyoruz ve veritabanından o nesne siliniyor.</param>
		void Delete(Exchange entity);
	}
}
