using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Takas.Business.Abstract;
using Takas.Common.Entities.Concrete;
using Takas.DataAccess.Abstract;
using Takas.DataAccess.Concrete.EntityFramework;

namespace Takas.Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
	        _userDal = userDal;
        }


        public User CheckUser(User user)
        {
            try
            {
                return _userDal.Get(t => t.Email == user.Email && t.Password == user.Password);
            }
            catch (Exception ex)
            {
                return user;
            }

        }

        public async Task<bool> AddUser(User user)
        {
            try
            {
               return  await _userDal.AddAsync(user);
                
            }
            catch
            {
                return false;
            }
        }

        public Task<List<User>> GetList()
        {
	        return _userDal.GetList();
        }

        public User Get(int id)
        {
	        return _userDal.Get(x => x.ID == id);
        }

        public void Add(User entity)
        {
	        _userDal.Add(entity);
        }

        public void Update(User entity)
        {
	       _userDal.Update(entity);
        }

        public void Delete(User entity)
        {
	       _userDal.Delete(entity);
        }
		
		public User GetUserByEmail(string email)
        {
            return _userDal.Get(t => t.Email == email);
        }

		
    }
}
