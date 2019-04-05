using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Takas.Business.Abstract;
using Takas.Common.Entities.Concrete;


namespace Takas.API.Controllers
{
	public class AdminController : ApiController
	{
		private IUserService _userService;

		public AdminController(IUserService userService)
		{
			_userService = userService;
		}

		[ResponseType(typeof(List<User>))]
		public IHttpActionResult Get()
		{
			try
			{
				var user = _userService.GetList();
				if (user != null)
				{
					return Ok(user);
				}
				else
				{
					return NotFound();
				}
			}
			catch (Exception e)
			{
				return BadRequest();
			}
		}


	}
}
