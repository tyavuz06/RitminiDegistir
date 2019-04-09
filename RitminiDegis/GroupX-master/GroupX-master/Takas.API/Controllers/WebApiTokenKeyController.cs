using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Takas.Business.Abstract;
using Takas.Common.Entities.Concrete;

namespace Takas.API.Controllers
{
	public class WebApiTokenKeyController : ApiController
	{
		private IWebApiTokenKeyService _apiTokenKeyService;

		public WebApiTokenKeyController(IWebApiTokenKeyService apiTokenKeyService)
		{
			_apiTokenKeyService = apiTokenKeyService;
		}

		public  async Task<IHttpActionResult> Get()
		{
			try
			{
				List<WebApiTokenKey> tokenKeys = await _apiTokenKeyService.GetList();
				return Ok(tokenKeys);

			}
			catch (Exception e)
			{
				return BadRequest();
			}

			

		}

		public IHttpActionResult Post(WebApiTokenKey entity)
		{
			if (ModelState.IsValid)
			{
				try
				{
					_apiTokenKeyService.Add(entity);
					return Ok();
				}
				catch (Exception e)
				{
					return BadRequest(ModelState);
				}
				
			}
			else
			{
				return BadRequest(ModelState);
			}


		}

		public IHttpActionResult Put(WebApiTokenKey entity)
		{


			if (ModelState.IsValid)
			{
				try
				{
					_apiTokenKeyService.Update(entity);
					return Ok();
				}
				catch (Exception e)
				{
					return BadRequest(ModelState);
				}

			}
			else
			{
				return BadRequest(ModelState);
			}

		}

		public IHttpActionResult Delete(WebApiTokenKey entity)
		{
			if (ModelState.IsValid)
			{
				try
				{
					_apiTokenKeyService.Delete(entity);
					return Ok();
				}
				catch (Exception e)
				{
					return BadRequest(ModelState);
				}

			}
			else
			{
				return BadRequest(ModelState);
			}

		}

	}
}
