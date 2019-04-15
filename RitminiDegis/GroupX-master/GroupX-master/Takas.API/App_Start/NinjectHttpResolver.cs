using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dependencies;
using Ninject;
using Takas.Business.Abstract;
using Takas.Business.Concrete;
using Takas.DataAccess.Abstract;
using Takas.DataAccess.Concrete.EntityFramework;

namespace Takas.API.App_Start
{
    public class NinjectHttpResolver : IDependencyResolver, IDependencyScope
    {
        public IKernel Kernel { get; private set; }
        public NinjectHttpResolver(params NinjectModule[] modules)
        {
            Kernel = new StandardKernel(modules);
        }

        public NinjectHttpResolver(Assembly assembly)
        {
            Kernel = new StandardKernel();
            Kernel.Load(assembly);
        }

        public object GetService(Type serviceType)
        {
            return Kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return Kernel.GetAll(serviceType);
        }

        public void Dispose()
        {
            //Do Nothing
        }

        public IDependencyScope BeginScope()
        {
            return this;
        }
    }

    public class NinjectHttpModules
    {
        //Return Lists of Modules in the Application
        public static NinjectModule[] Modules
        {
            get
            {
                return new[] { new MainModule() };
            }
        }

        //Main Module For Application
        public class MainModule : NinjectModule
        {
            public override void Load()
            {
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

                Bind<IProductImageGalleryDal>().To<EfProductImageGallery>().InSingletonScope();

                Bind<IProductService>().To<ProductManager>().InSingletonScope();

                Bind<IProductDal>().To<EfProductDal>().InSingletonScope();

                Bind<IRoleService>().To<RoleManager>().InSingletonScope();

                Bind<IBrandService>().To<BrandManager>().InSingletonScope();

                Bind<IBrandDal>().To<EfBrandDal>().InSingletonScope();

                Bind<IRoleDal>().To<EfRoleDal>().InSingletonScope();

                Bind<ITokenService>().To<TokenManager>().InSingletonScope();

                Bind<ITokenDal>().To<EfTokenDal>().InSingletonScope();

                Bind<IUserCommentService>().To<UserCommentManager>().InSingletonScope();

                Bind<IUserCommentDal>().To<EfUserCommentDal>().InSingletonScope();

                Bind<IUserService>().To<UserManager>().InSingletonScope();

                Bind<IUserDal>().To<EfUserDal>().InSingletonScope();

                Bind<IWebApiTokenKeyService>().To<WebApiTokenKeyManager>().InSingletonScope();

                Bind<IWebApiTokenKeyDal>().To<EfWebApiTokenKey>().InSingletonScope();
            } /// Ninject icin burada Bind Islemi yapiyoruz
		}
    }
    public class NinjectHttpContainer
    {
        private static NinjectHttpResolver _resolver;

        //Register Ninject Modules
        public static void RegisterModules(NinjectModule[] modules)
        {
            _resolver = new NinjectHttpResolver(modules);
            GlobalConfiguration.Configuration.DependencyResolver = _resolver;
        }

        public static void RegisterAssembly()
        {
            _resolver = new NinjectHttpResolver(Assembly.GetExecutingAssembly());
            //This is where the actual hookup to the Web API Pipeline is done.
            GlobalConfiguration.Configuration.DependencyResolver = _resolver;
        }

        //Manually Resolve Dependencies
        public static T Resolve<T>()
        {
            return _resolver.Kernel.Get<T>();
        }
    }
}