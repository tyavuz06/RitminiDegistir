using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Takas.Common.Entities.Concrete;


namespace Takas.Business.Abstract
{
	public interface IRoleService
	{/// <summary>
	 /// Bu Method VeriTabanindaki Tum Role Listesini Getitir.
	 /// </summary>
	 /// <returns>Role List</returns>
		Task<List<Role>> GetList();

		/// <summary>
		/// Veritabanindan ARANAN Role kaydını doner.
		/// </summary>
		/// <param name="id"> Verilen Id parametresine gore veritabaninda arama yapilir</param>
		/// <returns>Role</returns>
		Role Get(int id);

		/// <summary>
		/// Veritabanina Yeni bir Role Eklemek icin bu method kullanilir.
		/// </summary>
		/// <param name="entity">Bu Parametre Role Türünde bir nesnedir.</param>
		void Add(Role entity);

		/// <summary>
		/// Veritabanindaki kaydi gelen kayida gore gunceller.
		/// </summary>
		/// <param name="entity">Role Turunde bir degisken gonderiliyor ve bu degiskene gore Role tablosuna ekleme yapmasi isteniyor.</param>
		void Update(Role entity);

		/// <summary>
		/// Veritabanindaki Role tablosundan tek bir kayit silinmaktadir.
		/// </summary>
		/// <param name="entity">Role türünde bir nesne veriyoruz ve veritabanından o nesne siliniyor.</param>
		void Delete(Role entity);
	}
}
