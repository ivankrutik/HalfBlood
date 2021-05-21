// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Bootstrapper.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the Bootstrapper type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Halfblood.Loader
{
    using System;
    using System.ComponentModel.Composition.Hosting;
    using System.Reactive.Concurrency;
    using System.Reactive.Linq;

    using Halfblood.Common;

    using ReactiveUI;

    public class Bootstrapper
    {
        private readonly CompositionContainer _container;

        static Bootstrapper()
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        public Bootstrapper(IScheduler scheduler = null)
        {
            RxExtension.UiSafeScheduler = scheduler ?? DispatcherScheduler.Current;
            _container = new CompositionContainer(GetCatalog());

            Init();
            DependencyResolverConfig(_container);
        }

        public CompositionContainer IoC
        {
            get { return _container; }
        }

        private void Init()
        {
            var profilesLoader = _container.GetExportedValues<IProfileLauncher>();
            profilesLoader.DoForEach(profile => profile.LoadProfiles());

            var mefProfilesLoader = _container.GetExportedValues<IMefProfileLauncher>();
            mefProfilesLoader.DoForEach(profile => profile.LoadProfiles(IoC));
        }
        private AggregateCatalog GetCatalog()
        {
            var catalog = new AggregateCatalog();
            var source = AppDomain.CurrentDomain.BaseDirectory.Replace("Halfblood.AcceptanceTests", "Halfblood.Shell");

            catalog.Catalogs.Add(new DirectoryCatalog(source));
#if !RELEASE
            catalog.Catalogs.Add(new DirectoryCatalog(@"../../../configurations/CommonLib"));
            catalog.Catalogs.Add(new DirectoryCatalog(@"../../../OutLib/CommonLib"));
#endif
#if FAKE
            catalog.Catalogs.Add(new DirectoryCatalog(@"../../../configurations/Fake/"));
            catalog.Catalogs.Add(new DirectoryCatalog(@"../../../OutLib/Fake"));
#elif DEBUG
            catalog.Catalogs.Add(new DirectoryCatalog(@"../../../configurations/Work"));
            catalog.Catalogs.Add(new DirectoryCatalog(@"../../../OutLib/Work"));
#elif RELEASE
            catalog.Catalogs.Add(new DirectoryCatalog(string.Concat(source, "/configurations/CommonLib")));
            catalog.Catalogs.Add(new DirectoryCatalog(string.Concat(source, "/OutLib/CommonLib")));
            catalog.Catalogs.Add(new DirectoryCatalog(string.Concat(source, "/configurations/Work")));
            catalog.Catalogs.Add(new DirectoryCatalog(string.Concat(source, "/OutLib/Work")));
#endif
            return catalog;
        }
        private void DependencyResolverConfig(CompositionContainer ioC)
        {
            var resolver = ioC.GetExportedValue<IMefMutableDependencyResolver>();
            resolver.SetContainer(ioC);
            RxApp.DependencyResolver = resolver;
            RxApp.InitializeCustomResolver((o, type) => resolver.Register(() => o, type));
            resolver.Register(ioC.GetExportedValue<IViewLocator>, typeof(IViewLocator));
        }
    }
}