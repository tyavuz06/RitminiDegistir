using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Takas.Entities.Concrete;

namespace Takas.Business.Abstract
{
	public interface IMessageService
	{

		/// <summary>
		/// Bu Method VeriTabanindaki Tum Message Listesini Getitir.
		/// </summary>
		/// <returns>Message List</returns>
		Task<List<Message>> GetList();

		/// <summary>
		/// Veritabanindan ARANAN Message kaydını doner.
		/// </summary>
		/// <param name="id"> Verilen Id parametresine gore veritabaninda arama yapilir</param>
		/// <returns>Message</returns>
		Message Get(int id);

		/// <summary>
		/// Veritabanina Yeni bir Message Eklemek icin bu method kullanilir.
		/// </summary>
		/// <param name="entity">Bu Parametre Message Türünde bir nesnedir.</param>
		void Add(Message entity);

		/// <summary>
		/// Veritabanindaki kaydi gelen kayida gore gunceller.
		/// </summary>
		/// <param name="entity">Message Turunde bir degisken gonderiliyor ve bu degiskene gore Message tablosuna ekleme yapmasi isteniyor.</param>
		void Update(Message entity);

		/// <summary>
		/// Veritabanindaki Message tablosundan tek bir kayit silinmaktadir.
		/// </summary>
		/// <param name="entity">Message türünde bir nesne veriyoruz ve veritabanından o nesne siliniyor.</param>
		void Delete(Message entity);
	}
}
