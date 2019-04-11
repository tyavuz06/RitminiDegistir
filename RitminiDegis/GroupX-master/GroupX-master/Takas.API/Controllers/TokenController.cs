using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Takas.Business.Abstract;
using Takas.Common.Entities.Concrete;
using Takas.Common.Response;

namespace Takas.API.Controllers
{
    [EnableCors(origins: "http://localhost:50903/", headers: "*", methods: "*")]
    public class TokenController : ApiController
    {
        ITokenService _tokenService;

        public TokenController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost]
        [Route("api/Token/GetUserFromTokenValue")]
        public object GetUserFromTokenValue(Token token)
        {
            TokenResponse tokenResponse = new TokenResponse();
            try
            {
                tokenResponse.Token=_tokenService.GetWithToken(token.TokenValue);
                if (tokenResponse.Token == null)
                    tokenResponse.setError(Common.SystemConstants.SystemConstannts.ERROR_CODES.NOTFOUND);
                else
                tokenResponse.setError(Common.SystemConstants.SystemConstannts.ERROR_CODES.SUCCESS);
            }
            catch(Exception ex)
            {
                tokenResponse.Token = null;
                tokenResponse.setError(Common.SystemConstants.SystemConstannts.ERROR_CODES.SYSTEMERROR);
            }
            return tokenResponse;
        }
    }
}
