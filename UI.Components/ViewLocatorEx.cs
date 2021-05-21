// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ViewLocatorEx.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   ViewLocatorEx.cs
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Components
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.Composition;
    using System.Diagnostics.Contracts;
    using System.Linq;
    using System.Reflection;

    using ReactiveUI;

    [Export(typeof(IViewLocator))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class ViewLocatorEx : IViewLocator
    {
        private static readonly Assembly ReactiveUiAssembly = Assembly.GetAssembly(typeof(RxApp));
        private readonly IDependencyResolver _dependencyResolver;
        private readonly ConcurrentDictionary<Type, Type> _viewModelToViewDictionary =
            new ConcurrentDictionary<Type, Type>();

        [ImportingConstructor]
        public ViewLocatorEx(IDependencyResolver dependencyResolver)
        {
            _dependencyResolver = dependencyResolver;
        }

        public IViewFor ResolveView<T>(T viewModel, string contract = null) where T : class
        {
            Contract.Requires(viewModel != null, "The view model must be not null");
            Contract.Ensures(Contract.Result<IViewFor>() != null, "The view must be not null");

            Type viewModelType = viewModel.GetType();

            if (_viewModelToViewDictionary.ContainsKey(viewModelType))
            {
                var viewFor =
                    (IViewFor)_dependencyResolver.GetService(_viewModelToViewDictionary[viewModelType], contract);

                if (viewFor == null)
                {
                    throw new ArgumentNullException(string.Format("View for {0} not found", viewModelType));
                }

                return viewFor;
            }

            var defaultViewFor = this.TryResolveViewWithDefaultLocator(viewModel, contract);
            if (defaultViewFor != null)
            {
                return defaultViewFor;
            }

            IEnumerable<Type> interfaces =
                viewModelType.GetInterfaces()
                    .Where(type => type.Assembly != ReactiveUiAssembly)
                    .Except(new List<Type> { typeof(INotifyPropertyChanged), });

            foreach (Type @interface in interfaces)
            {
                Type expectedType = typeof(IViewFor<>).MakeGenericType(@interface);
                var viewFor = _dependencyResolver.GetService(expectedType, contract) as IViewFor;

                if (viewFor != null)
                {
                    _viewModelToViewDictionary.TryAdd(viewModelType, expectedType);
                    return viewFor;
                }
            }

            throw new ArgumentNullException(string.Format("View for {0} not found", viewModelType));
        }

        private IViewFor TryResolveViewWithDefaultLocator<TViewModel>(TViewModel viewModel, string contract = null)
            where TViewModel : class
        {
            try
            {
                return RxRouting.ResolveView(viewModel);
            }
            catch
            {
                return null;
            }
        }
    }
}
