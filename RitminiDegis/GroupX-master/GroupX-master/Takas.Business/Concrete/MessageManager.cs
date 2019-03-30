using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Takas.Business.Abstract;
using Takas.DataAccess.Abstract;
using Takas.Entities.Concrete;

namespace Takas.Business.Concrete
{
	public class MessageManager : IMessageService
	{
		private IMessageDal _messageDal;

		public MessageManager(IMessageDal messageDal)
		{
			_messageDal = messageDal;
		}

		public Task<List<Message>> GetList()
		{
			return _messageDal.GetList();
		}

		public Message Get(int id)
		{
			return _messageDal.Get(x => x.ID == id);
		}

		public void Add(Message entity)
		{
			_messageDal.Add(entity);
		}

		public void Update(Message entity)
		{
			_messageDal.Update(entity);
		}

		public void Delete(Message entity)
		{
			_messageDal.Delete(entity);
		}
	}
}
