// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ModernDependencyResolverEx.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the ModernDependencyResolverEx type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Halfblood.Loader
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.ComponentModel.Composition.Hosting;
    using System.Linq;
    using System.Reactive.Linq;
    using System.Reflection;

    using Halfblood.Common.Helpers;
    using Halfblood.Common.Interceptors;

    using ReactiveUI;

    public interface IMefMutableDependencyResolver : IMutableDependencyResolver
    {
        void SetContainer(CompositionContainer container);
    }

    [Export(typeof(IDependencyResolver))]
    [Export(typeof(IMutableDependencyResolver))]
    [Export(typeof(IMefMutableDependencyResolver))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class ModernDependencyResolverEx : IMefMutableDependencyResolver
    {
        [Import]
        private IInterceptorManager _interceptorManager;
        private Dictionary<Tuple<Type, string>, List<Func<object>>> _registry;
        private CompositionContainer _container;
        private static readonly Assembly ReactiveUiAssembly = Assembly.GetAssembly(typeof(RxApp));
        private static readonly Assembly ReactiveUiXamlAssembly = Assembly.Load("ReactiveUI.Xaml");

        public ModernDependencyResolverEx()
        {
            _registry = new Dictionary<Tuple<Type, string>, List<Func<object>>>();
        }

        public void SetContainer(CompositionContainer container)
        {
            _container = container;
        }
        public void Register(Func<object> factory, Type serviceType, string contract = null)
        {
            var pair = Tuple.Create(serviceType, contract ?? string.Empty);
            if (!_registry.ContainsKey(pair))
            {
                _registry[pair] = new List<Func<object>>();
            }

            _registry[pair].Add(factory);
        }
        public object GetService(Type serviceType, string contract = null)
        {
            var pair = Tuple.Create(serviceType, contract ?? string.Empty);
            if (!_registry.ContainsKey(pair))
            {
                var res = _container.TryGetExportedValue(serviceType);
                Intercept(res);
                return res;
            }

            var ret = _registry[pair].Last()();
            Intercept(ret);
            return ret;
        }

        private void Intercept(object res)
        {
            if (res != null) {
                Assembly assembly = res.GetType().Assembly;
                if (assembly != ReactiveUiAssembly && assembly != ReactiveUiXamlAssembly) {
                    _interceptorManager.Intercept(res);
                }
            }
        }

        public IEnumerable<object> GetServices(Type serviceType, string contract = null)
        {
            var pair = Tuple.Create(serviceType, contract ?? string.Empty);
            if (!_registry.ContainsKey(pair)) return Enumerable.Empty<object>();

            return _registry[pair].Select(x => x()).ToList();
        }
        public void Dispose()
        {
            _registry = null;
        }
    }
}