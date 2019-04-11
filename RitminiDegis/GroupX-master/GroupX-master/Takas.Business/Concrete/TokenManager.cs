using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Takas.Business.Abstract;
using Takas.Common.Entities.Concrete;
using Takas.DataAccess.Abstract;

namespace Takas.Business.Concrete
{
	public class TokenManager : ITokenService
	{
		private ITokenDal _tokenDal;

		public TokenManager(ITokenDal tokenDal)
		{
			_tokenDal = tokenDal;
		}

		public Task<List<Token>> GetList()
		{
			return _tokenDal.GetList();
		}

		public Token Get(int id)
		{
			return _tokenDal.Get(x => x.ID == id);
		}

		public void Add(Token entity)
		{
			_tokenDal.Add(entity);
		}

		public void Update(Token entity)
		{
			_tokenDal.Update(entity);
		}

		public void Delete(Token entity)
		{
			_tokenDal.Delete(entity);
		}

        public Token GetWithToken(string tokenValue)
        {
            Token token = _tokenDal.EagerLoadingWithParams(t => t.TokenValue == tokenValue && t.ExpireDate > DateTime.Now, x => x.User.Tokens).FirstOrDefault();
            return token;
        }
    }
}
