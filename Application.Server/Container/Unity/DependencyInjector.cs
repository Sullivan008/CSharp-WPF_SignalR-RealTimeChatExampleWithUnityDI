using System;
using Microsoft.AspNet.SignalR.Hubs;
using Unity;
using Unity.Extension;
using Unity.Lifetime;

namespace Application.Server.Container.Unity
{
    public static class DependencyInjector
    {
        public static readonly UnityContainer UnityContainer = new UnityContainer();

        public static void RegisterSingleton<TInterface, TClass>() where TClass : TInterface
        {
            UnityContainer.RegisterType<TInterface, TClass>(new ContainerControlledLifetimeManager());
        }

        public static void RegisterTransient<TInterface, TClass>() where TClass : TInterface
        {
            UnityContainer.RegisterType<TInterface, TClass>(new ContainerControlledTransientManager());
        }

        public static void RegisterInstance<TInstance>(TInstance instance)
        {
            UnityContainer.RegisterInstance(instance, new ContainerControlledLifetimeManager());
        }

        public static void RegisterHubActivator<TInstance>() where TInstance : IHubActivator
        {
            UnityContainer.RegisterInstance<IHubActivator>((TInstance)Activator.CreateInstance(typeof(TInstance), UnityContainer), new ContainerControlledLifetimeManager());
        }

        public static void AddExtension<TExtension>() where TExtension : UnityContainerExtension
        {
            UnityContainer.AddNewExtension<TExtension>();
        }

        public static TClass Retrieve<TClass>()
        {
            return UnityContainer.Resolve<TClass>();
        }
    }
}
