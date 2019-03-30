using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject.Modules;
using Takas.Business.Abstract;
using Takas.Business.Concrete;
using Takas.DataAccess.Abstract;
using Takas.DataAccess.Concrete.EntityFramework;

namespace Takas.MvcWebUI.DependencyInjection.Ninject
{
	public class InsanceFactory : NinjectModule
	{
		public override void Load()
		{
			// ICategoryService Istenince CategoryManager veriliyor
			Bind<ICategoryService>().To<CategoryManager>().InSingletonScope();
			// ICategoryDal istenince EfCategoryDal veriliyor
			Bind<ICategoryDal>().To<EfCategoryDal>().InSingletonScope();

			Bind<IExchangeService>().To<ExchangeManager>().InSingletonScope();

			Bind<IExchangeDal>().To<EfExchangeDal>().InSingletonScope();

			Bind<IFavoriteService>().To<FavoriteManager>().InSingletonScope();

			Bind<IFavoriteDal>().To<EfFavoriteDal>().InSingletonScope();

			Bind<IMessageService>().To<MessageManager>().InSingletonScope();

			Bind<IMessageDal>().To<EfMessageDal>().InSingletonScope();

			Bind<IProductImageGalleryService>().To<ProductImageGalleryManager>().InSingletonScope();

			Bind<IProductService>().To<ProductManager>().InSingletonScope();

			Bind<IProductDal>().To<EfProductDal>().InSingletonScope();

			Bind<IRoleService>().To<RoleManager>().InSingletonScope();

			Bind<IRoleDal>().To<EfRoleDal>().InSingletonScope();

			Bind<ITokenService>().To<TokenManager>().InSingletonScope();

			Bind<ITokenDal>().To<EfTokenDal>().InSingletonScope();

			Bind<IUserCommentService>().To<UserCommentManager>().InSingletonScope();

			Bind<IUserCommentDal>().To<EfUserCommentDal>().InSingletonScope();

			Bind<IUserService>().To<UserManager>().InSingletonScope();

			Bind<IUserDal>().To<EfUserDal>().InSingletonScope();

		}
	}
}