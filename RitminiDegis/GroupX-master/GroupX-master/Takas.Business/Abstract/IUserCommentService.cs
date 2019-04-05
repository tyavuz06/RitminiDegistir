using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Takas.Common.Entities.Concrete;


namespace Takas.Business.Abstract
{
	public interface IUserCommentService
	{
		/// <summary>
		/// Bu Method VeriTabanindaki Tum UserComment Listesini Getitir.
		/// </summary>
		/// <returns>UserComment List</returns>
		Task<List<UserComment>> GetList();

		/// <summary>
		/// Veritabanindan ARANAN UserComment kaydını doner.
		/// </summary>
		/// <param name="id"> Verilen Id parametresine gore veritabaninda arama yapilir</param>
		/// <returns>UserComment</returns>
		UserComment Get(int id);

		/// <summary>
		/// Veritabanina Yeni bir UserComment Eklemek icin bu method kullanilir.
		/// </summary>
		/// <param name="entity">Bu Parametre UserComment Türünde bir nesnedir.</param>
		void Add(UserComment entity);

		/// <summary>
		/// Veritabanindaki kaydi gelen kayida gore gunceller.
		/// </summary>
		/// <param name="entity">UserComment Turunde bir degisken gonderiliyor ve bu degiskene gore UserComment tablosuna ekleme yapmasi isteniyor.</param>
		void Update(UserComment entity);

		/// <summary>
		/// Veritabanindaki UserComment tablosundan tek bir kayit silinmaktadir.
		/// </summary>
		/// <param name="entity">UserComment türünde bir nesne veriyoruz ve veritabanından o nesne siliniyor.</param>
		void Delete(UserComment entity);
	}
}
