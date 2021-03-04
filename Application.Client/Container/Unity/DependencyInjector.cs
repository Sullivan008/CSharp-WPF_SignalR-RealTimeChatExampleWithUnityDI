using Unity;
using Unity.Extension;
using Unity.Lifetime;

namespace Application.Client.Container.Unity
{
    public static class DependencyInjector
    {
        private static readonly UnityContainer UnityContainer = new UnityContainer();

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
