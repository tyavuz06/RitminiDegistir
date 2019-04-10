using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Takas.Common.Entities.Concrete;


namespace Takas.Business.Abstract
{
	public interface ITokenService
	{
		/// <summary>
		/// Bu Method VeriTabanindaki Tum Token Listesini Getitir.
		/// </summary>
		/// <returns>Token List</returns>
		Task<List<Token>> GetList();

		/// <summary>
		/// Veritabanindan ARANAN Token kaydını doner.
		/// </summary>
		/// <param name="id"> Verilen Id parametresine gore veritabaninda arama yapilir</param>
		/// <returns>Token</returns>
		Token Get(int id);
        Token GetWithToken(string tokenValue);

        /// <summary>
        /// Veritabanina Yeni bir Token Eklemek icin bu method kullanilir.
        /// </summary>
        /// <param name="entity">Bu Parametre Token Türünde bir nesnedir.</param>
        void Add(Token entity);

		/// <summary>
		/// Veritabanindaki kaydi gelen kayida gore gunceller.
		/// </summary>
		/// <param name="entity">Token Turunde bir degisken gonderiliyor ve bu degiskene gore Token tablosuna ekleme yapmasi isteniyor.</param>
		void Update(Token entity);

		/// <summary>
		/// Veritabanindaki Token tablosundan tek bir kayit silinmaktadir.
		/// </summary>
		/// <param name="entity">Token türünde bir nesne veriyoruz ve veritabanından o nesne siliniyor.</param>
		void Delete(Token entity);
	}
}
