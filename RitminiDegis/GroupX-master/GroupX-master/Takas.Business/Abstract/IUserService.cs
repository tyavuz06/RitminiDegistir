using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Takas.Common.Entities.Concrete;


namespace Takas.Business.Abstract
{
    public interface IUserService
    {
		/// <summary>
		/// Kullanıcının verdıği User Parametresine göre Böyle bir kullanıcının olum olmadığının kontrolü yapılır
		/// </summary>
		/// <param name="user">User türünde parametre geri dönüş tiği gene User olacaktır</param>
		/// <returns>User</returns>
        User CheckUser(User user);
        
		/// <summary>
		/// Async Olarak User Ekleme Islemı yapar Gerıye Boolean türünde değer döner
		/// </summary>
		/// <param name="user"> Usur türünde bir kullanıcı</param>
		/// <returns>Boolean</returns>
        Task<bool> AddUser(User user);
		
		/// <summary>
		/// Verilen Email Adresine Göre Kullanıcıyı Geri Döner
		/// </summary>
		/// <param name="email"> String türünde bir email</param>
		/// <returns>User</returns>
		User GetUserByEmail(string email);


        /// <summary>
        /// Bu Method VeriTabanindaki Tum User Listesini Getitir.
        /// </summary>
        /// <returns>User List</returns>
        Task<List<User>> GetList();

		/// <summary>
		/// Veritabanindan ARANAN User kaydını doner.
		/// </summary>
		/// <param name="id"> Verilen Id parametresine gore veritabaninda arama yapilir</param>
		/// <returns>User</returns>
		User Get(int id);

		/// <summary>
		/// Veritabanina Yeni bir User Eklemek icin bu method kullanilir.
		/// </summary>
		/// <param name="entity">Bu Parametre User Türünde bir nesnedir.</param>
		void Add(User entity);

		/// <summary>
		/// Veritabanindaki kaydi gelen kayida gore gunceller.
		/// </summary>
		/// <param name="entity">User Turunde bir degisken gonderiliyor ve bu degiskene gore User tablosuna ekleme yapmasi isteniyor.</param>
		void Update(User entity);
        Task<bool> UpdateAsync(User entity);

        /// <summary>
        /// Veritabanindaki User tablosundan tek bir kayit silinmaktadir.
        /// </summary>
        /// <param name="entity">User türünde bir nesne veriyoruz ve veritabanından o nesne siliniyor.</param>
        void Delete(User entity);


		/// <summary>
		/// Async Olarak User Ekleme Islemı yapar Gerıye Boolean türünde değer döner, Bizden method ismi isteceyecktir.
		/// </summary>
		/// <param name="user"> User turunde User</param>
		/// <param name="methodName"> hangi method tan geldigimizi soyleyen bir olay</param>
		/// <returns>boolen turunde </returns>
		Task<bool> AddUserWithDataAnnotation(User user,string methodName);
	}
}
