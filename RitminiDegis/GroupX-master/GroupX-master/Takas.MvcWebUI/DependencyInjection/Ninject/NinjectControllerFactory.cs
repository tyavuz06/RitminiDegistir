using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;

namespace Takas.MvcWebUI.DependencyInjection.Ninject
{
	public class NinjectControllerFactory : DefaultControllerFactory
	{
		private IKernel _kernal;

		public NinjectControllerFactory()
		{
			_kernal = new StandardKernel(new InsanceFactory());
		}

		protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
		{
			return (IController)_kernal.Get(controllerType);
		}
	}
}