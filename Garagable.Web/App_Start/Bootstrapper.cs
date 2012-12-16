using System;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Garagable.Data;
using Garagable.Data.CodeContracts;
using Garagable.Data.Repositories;
using Garagable.Service;
using Garagable.Service.Contract;
using Garagable.Web.Infrastructure;
using Garagable.Web.Properties;
using Microsoft.Practices.Unity;


[assembly: WebActivator.PreApplicationStartMethod(typeof(Garagable.Web.Bootstrapper), "Start")]

namespace Garagable.Web
{
    public static class Bootstrapper {
        public const string ITEM_REPOSTIORY_PROPERTY_NAME           = "ItemRepository";
        public const string GARAGE_SALE_REPOSITORY_PROPERTY_NAME    = "GarageSaleRepository";
        public const string PHOTO_REPOSITORY_PROPERTY_NAME          = "PhotoRepository";
        public const string ROLE_REPOSITORY_PROPERTY_NAME           = "RoleRepository";
        public const string SCHEDULE_REPOSITORY_PROPERTY_NAME       = "ScheduleRepository";
        public const string SEARCH_REPOSITORY_PROPERTY_NAME         = "SearchRepository";

        public static void Start() {
            var container = BuildUnityContainer();

            //register IoC for MVC
            DependencyResolver.SetResolver(new Unity.Mvc3.UnityDependencyResolver(container));

            //register IoC for Api
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);

            //api message handlers
            GlobalConfiguration.Configuration.MessageHandlers.Add(new TokenValidatorMessageHandler(container.Resolve<SecurityService>()));

            //api filters
            GlobalConfiguration.Configuration.Filters.Add(new UpdateLastApiActivityAttribute(container.Resolve<ISecurityService>()));

            //mvc filters
            GlobalFilters.Filters.Add(new UpdateLastApiActivityAttribute.UpdateLastWebActivityAttribute(container.Resolve<ISecurityService>()));

        }

        private static IUnityContainer BuildUnityContainer() {
            var container = new UnityContainer();

            //database
            container.RegisterType<IDatabaseFactory<GaragableContext>, GaragableDatabaseFactory>(
                new HttpContextLifetimeManager<IDatabaseFactory<GaragableContext>>());

            //data contracts (repositories/UoW)
            container.RegisterType<IItemRepository, ItemRepository>(new HttpContextLifetimeManager<IItemRepository>());
            container.RegisterType<IGarageSaleRepository, GarageSaleRepository>(new HttpContextLifetimeManager<IGarageSaleRepository>());
            container.RegisterType<IRoleRepository, RoleRepository>(new HttpContextLifetimeManager<IRoleRepository>());
            container.RegisterType<IScheduleRepository, ScheduleRepository>(new HttpContextLifetimeManager<IScheduleRepository>());
            container.RegisterType<ISearchRepository, SearchRepository>(new HttpContextLifetimeManager<ISearchRepository>());
            container.RegisterType<IUserRepository, UserRepository>(new HttpContextLifetimeManager<IUserRepository>());
            container.RegisterType<IPhotoRepository, PhotoRepository>(new HttpContextLifetimeManager<IPhotoRepository>());
            container.RegisterType<IUnitOfWork, UnitOfWork>(new HttpContextLifetimeManager<IUnitOfWork>(),
                                                                new InjectionProperty(ITEM_REPOSTIORY_PROPERTY_NAME, new ResolvedParameter<IItemRepository>()),
                                                                new InjectionProperty(GARAGE_SALE_REPOSITORY_PROPERTY_NAME, new ResolvedParameter<IGarageSaleRepository>()),
                                                                new InjectionProperty(PHOTO_REPOSITORY_PROPERTY_NAME, new ResolvedParameter<IPhotoRepository>()),
                                                                new InjectionProperty(ROLE_REPOSITORY_PROPERTY_NAME, new ResolvedParameter<IRoleRepository>()),
                                                                new InjectionProperty(SCHEDULE_REPOSITORY_PROPERTY_NAME, new ResolvedParameter<IScheduleRepository>()),
                                                                new InjectionProperty(SEARCH_REPOSITORY_PROPERTY_NAME, new ResolvedParameter<ISearchRepository>())
                                                            );

            //services
            container.RegisterType<ISecurityService, SecurityService>(new HttpContextLifetimeManager<ISecurityService>());
            //container.RegisterType<ISecurityService, FakeSecurityService>(new HttpContextLifetimeManager<ISecurityService>());
            container.RegisterType<IGarageService, GarageService>(new HttpContextLifetimeManager<IGarageService>());
            //container.RegisterType<IGarageService, FakeGarageService>(new HttpContextLifetimeManager<IGarageService>());

            //others
            container.RegisterType<IEncryptor, RijndaelEncryptor>(new HttpContextLifetimeManager<IEncryptor>(),
                                                                  new InjectionConstructor(
                                                                      Settings.Default.EncryptorSalt));
            container.RegisterType<ITokenCreator, TokenCreator>(new HttpContextLifetimeManager<ITokenCreator>());

            return container;
        }

        public class HttpContextLifetimeManager<T> : LifetimeManager, IDisposable {
            public override object GetValue() {
                var assemblyQualifiedName = typeof(T).AssemblyQualifiedName;
                if (HttpContext.Current != null) {
                    return HttpContext.Current.Items.Contains(assemblyQualifiedName) ? HttpContext.Current.Items[assemblyQualifiedName] : null;
                }

                return null;
            }

            public override void RemoveValue() {
                var assemblyQualifiedName = typeof(T).AssemblyQualifiedName;
                if (assemblyQualifiedName != null)
                    HttpContext.Current.Items.Remove(assemblyQualifiedName);
            }

            public override void SetValue(object newValue) {
                var assemblyQualifiedName = typeof(T).AssemblyQualifiedName;
                if (HttpContext.Current != null && assemblyQualifiedName != null)
                    HttpContext.Current.Items[assemblyQualifiedName] = newValue;
            }

            public void Dispose() {
                RemoveValue();
            }
        }
    }
}