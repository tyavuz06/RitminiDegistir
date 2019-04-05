using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Takas.Common.Entities.Concrete;


namespace Takas.Business.Abstract
{
	public interface IFavoriteService
	{

		/// <summary>
		/// Bu Method VeriTabanindaki Tum Favorite Listesini Getitir.
		/// </summary>
		/// <returns>Favorite List</returns>
		Task<List<Favorite>> GetList();

		/// <summary>
		/// Veritabanindan ARANAN Favorite kaydını doner.
		/// </summary>
		/// <param name="id"> Verilen Id parametresine gore veritabaninda arama yapilir</param>
		/// <returns>Favorite</returns>
		Favorite Get(int id);

		/// <summary>
		/// Veritabanina Yeni bir Favorite Eklemek icin bu method kullanilir.
		/// </summary>
		/// <param name="entity">Bu Parametre Favorite Türünde bir nesnedir.</param>
		void Add(Favorite entity);

		/// <summary>
		/// Veritabanindaki kaydi gelen kayida gore gunceller.
		/// </summary>
		/// <param name="entity">Favorite Turunde bir degisken gonderiliyor ve bu degiskene gore Favorite tablosuna ekleme yapmasi isteniyor.</param>
		void Update(Favorite entity);

		/// <summary>
		/// Veritabanindaki Favorite tablosundan tek bir kayit silinmaktadir.
		/// </summary>
		/// <param name="entity">Favorite türünde bir nesne veriyoruz ve veritabanından o nesne siliniyor.</param>
		void Delete(Favorite entity);
	}
}
