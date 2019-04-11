using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;
using Takas.Business.Abstract;
using Takas.Business.ValidationRules.FluentValidation.FluentValidationRules;
using Takas.Business.ValidationRules.FluentValidation.ValidationTool;
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
                //user = _userDal.Get(t => t.Email == user.Email && t.Password == user.Password);
                user = _userDal.EagerLoadingWithParams(t => t.Email == user.Email && t.Password == user.Password, t => t.Tokens).FirstOrDefault();
                return user;
            }
            catch
            {
                return user;
            }

        }

        public async Task<bool> AddUser(User user)
        {
            try
            {
				UserValidator validator =  new UserValidator();
				ValidationResult result = validator.Validate(user);
			//	ValidationTool.Validate(new UserValidator(), user);
                return await _userDal.AddAsync(user);

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
        public async Task<bool> UpdateAsync(User entity)
        {
            try
            {
                return await _userDal.UpdateAsync(entity);
            }
            catch
            {
                return false;
            }
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
