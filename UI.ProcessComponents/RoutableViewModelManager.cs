// --------------------------------------------------------------------------------------------------------------------
// <copyright file="routableViewModelManager.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The view model manager.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.ProcessComponents
{
    using System;
    using System.ComponentModel.Composition;
    using System.Diagnostics.Contracts;
    using System.Reactive;
    using System.Reactive.Linq;

    using Halfblood.Common;
    using Halfblood.Common.Helpers;

    using JetBrains.Annotations;

    using ReactiveUI;

    using UI.Infrastructure;

    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    internal class ExportFactoryProvider<T>
    {
        [Import]
        public ExportFactory<T> Factory { get; set; }
    }

    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    internal class ExportFactoryInstantiator<T> : IPartImportsSatisfiedNotification
    {
        private ExportLifetimeContext<T> lifeTime;

        [Import]
        public ExportFactory<T> Factory { get; set; }
        public T Instance { get; private set; }

        public void OnImportsSatisfied()
        {
            lifeTime = Factory.CreateExport();
            Instance = lifeTime.Value;
        }

        public bool DisposeOnDemand()
        {
            if (lifeTime == null)
            {
                return false;
            }

            lifeTime.Dispose();
            return Instance == null;
        }
    }

    /// <summary>
    /// The view model manager.
    /// </summary>
    [Export(typeof(IRoutableViewModelManager))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class RoutableViewModelManager : IRoutableViewModelManager
    {
        private readonly IDependencyResolver _dependencyResolver;
        [Import]
        private IScreen _screen;

        [ImportingConstructor]
        public RoutableViewModelManager(IDependencyResolver dependencyResolver)
        {
            _dependencyResolver = dependencyResolver;
        }

        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="destroyObservable">
        /// The destroy observable.
        /// </param>
        /// <typeparam name="TViewModel">
        /// The type of view model.
        /// </typeparam>
        /// <returns>
        /// The <see cref="TViewModel"/>.
        /// </returns>
        public TViewModel Get<TViewModel>(IObservable<Unit> destroyObservable = null)
            where TViewModel : IRoutableViewModel
        {
            return (TViewModel)Get(typeof(TViewModel), destroyObservable);
        }

        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="viewModelType">
        /// The view model.
        /// </param>
        /// <param name="destroyObservable">
        /// The destroy observable.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        [CanBeNull]
        public object Get(Type viewModelType, [NotNull] IObservable<Unit> destroyObservable = null)
        {
            return GetViewModel(viewModelType, destroyObservable);
        }

        [CanBeNull]
        private object GetViewModel([NotNull] Type viewModelType, IObservable<Unit> _destroyObservable = null)
        {
            Contract.Requires(viewModelType != null);
            Contract.Ensures(Contract.Result<object>() != null);

            if (viewModelType.GetInterface("IDisposable") == null)
            {
                var viewModel = _dependencyResolver.GetService(viewModelType);
                if (viewModel == null)
                {
                    throw new InvalidOperationException(
                        "(RoutableViewModelManager.Get<>) Not resolve {0}".StringFormat(viewModelType));
                }

                return viewModel;
            }

            var exportFactoryInstantiatorType = typeof(ExportFactoryInstantiator<>).MakeGenericType(viewModelType);
            dynamic exportFactoryInstantiator = _dependencyResolver.GetService(exportFactoryInstantiatorType);

            if (exportFactoryInstantiator == null)
            {
                throw new InvalidOperationException(
                    "(RoutableViewModelManager.Get<>) Not resolve {0}".StringFormat(viewModelType));
            }

            var disposable = new DisposableObject();

            Action disposeAction = () =>
            {
                exportFactoryInstantiator.DisposeOnDemand();
                disposable.Dispose();
            };

            if (_destroyObservable != null)
            {
                disposable.Add(_destroyObservable.Subscribe(_ => disposeAction()));
            }
            else
            {
                disposable.Add(
                    _screen.Router.NavigationStack.ItemsRemoved.Where(
                        viewModel => object.ReferenceEquals(viewModel, exportFactoryInstantiator.Instance))
                        .Subscribe(viewModel => disposeAction()));
            }

            var resolvedViewModel = exportFactoryInstantiator.Instance;

            return resolvedViewModel;
        }
    }
}
