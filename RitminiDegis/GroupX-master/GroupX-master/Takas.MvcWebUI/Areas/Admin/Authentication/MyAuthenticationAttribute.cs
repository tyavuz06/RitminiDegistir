using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Takas.MvcWebUI.Areas.Admin.Authentication
{
	public class MyAuthenticationAttribute : ActionFilterAttribute
	{
		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			if (filterContext.HttpContext.Request.Cookies["userAuth"] == null)
			{
				filterContext.Result = new HttpUnauthorizedResult();
			}
			
				
		}
	}
}