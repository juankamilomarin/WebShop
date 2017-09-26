using System.Configuration;
using System.Data.SqlClient;
using WebShop.DataAccess.Interfaces;
using WebShop.DataAccess.Repositories.Database;
using WebShop.DataAccess.Repositories.Memory;
using WebShop.Models;
using WebShop.Services;
using WebShop.Services.Interfaces;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(WebShop.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(WebShop.App_Start.NinjectWebCommon), "Stop")]

namespace WebShop.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            //Gets sql connection
            string connectionString = ConfigurationManager.ConnectionStrings["WebShop"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Services
            kernel.Bind<IProductService>().To<ProductService>();

            //Repositories
            kernel.Bind<IDatabaseRepository<Product>>().To<ProductDatabaseRepository>().InRequestScope()
                .WithConstructorArgument("connection", sqlConnection)
                .WithConstructorArgument("connectionString", connectionString);
            kernel.Bind<IMemoryRepository<Product>>().To<ProductMemoryRepository>();

        }        
    }
}
