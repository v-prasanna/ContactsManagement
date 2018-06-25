using System.Web.Http;
using Unity;
using Unity.WebApi;
using ContactsDBDataAccess;
using ContactsDBDataAccess.Repositories;
using ContactsDBDataAccess.Interfaces;

namespace ContactsManagement
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType(typeof(IEntityBaseRepository<>), typeof(EntityBaseRepository<>));
            container.RegisterType<ContactsDBEntities, ContactsDBEntities>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}