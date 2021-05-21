// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InitializationManager.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the InitializationManager type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Halfblood.Common.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Diagnostics.Contracts;
    using System.Reactive.Subjects;
    using System.Threading.Tasks;

    using JetBrains.Annotations;

    /// <summary>
    /// The InitializationMetadata interface.
    /// </summary>
    public interface IInitializationMetadata
    {
        /// <summary>
        /// Gets the strategy for type.
        /// </summary>
        [NotNull]
        Type StrategyForType { get; }
    }

    /// <summary>
    /// The initialization manager interface.
    /// </summary>
    public interface IInitializationManager
    {
        /// <summary>
        /// Gets the is executing.
        /// </summary>
        IObservable<bool> IsExecuting { get; }

        /// <summary>
        /// The add strategy.
        /// </summary>
        /// <param name="strategy">
        /// The strategy.
        /// </param>
        /// <typeparam name="T">
        /// The type object for strategy.
        /// </typeparam>
        void AddStrategy<T>([NotNull] IInitializationStrategy strategy);

        /// <summary>
        /// The execute task set value.
        /// </summary>
        /// <param name="viewModel">
        /// The view model.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task InitViewModel(object viewModel);
    }

    /// <summary>
    /// The InitializationStrategy interface.
    /// </summary>
    public interface IInitializationStrategy
    {
        /// <summary>
        /// The set value.
        /// </summary>
        /// <param name="viewModel">
        /// The view model.
        /// </param>
        Task InitViewModel([NotNull] object viewModel);
    }

    /// <summary>
    /// The initialization strategy interface.
    /// </summary>
    /// <typeparam name="TViewModel">
    /// The type of view model.
    /// </typeparam>
    public interface IInitializationStrategy<in TViewModel> : IInitializationStrategy
    {
        /// <summary>
        /// The init view model.
        /// </summary>
        /// <param name="viewModel">
        /// The view model.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task InitViewModel(TViewModel viewModel);
    }

    /// <summary>
    /// The initialization for attribute.
    /// </summary>
    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public sealed class InitializationForAttribute : ExportAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InitializationForAttribute"/> class.
        /// </summary>
        /// <param name="strategyForType">
        /// The strategy for type.
        /// </param>
        public InitializationForAttribute([NotNull] Type strategyForType)
            : base(typeof(IInitializationStrategy))
        {
            StrategyForType = strategyForType;
        }

        /// <summary>
        /// Gets the strategy for type.
        /// </summary>
        [NotNull]
        public Type StrategyForType { get; private set; }
    }

    /// <summary>
    /// The initialization manager.
    /// </summary>
    [Export(typeof(IInitializationManager))]
    public class InitializationManager :
        MefLoaderBase<IInitializationStrategy, IInitializationMetadata, Type, Func<IInitializationStrategy>>,
        IInitializationManager
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InitializationManager"/> class.
        /// </summary>
        public InitializationManager()
        {
            IsExecuting = new Subject<bool>();
        }

        /// <summary>
        /// Gets the is executing.
        /// </summary>
        public IObservable<bool> IsExecuting { get; private set; }

        /// <summary>
        /// The add strategy.
        /// </summary>
        /// <param name="strategy">
        /// The strategy.
        /// </param>
        /// <typeparam name="T">
        /// The type object for strategy.
        /// </typeparam>
        public void AddStrategy<T>(IInitializationStrategy strategy)
        {
            this.Contents.Add(typeof(T), () => strategy);
        }

        /// <summary>
        /// The execute task set value.
        /// </summary>
        /// <param name="viewModel">
        /// The view model.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public Task InitViewModel(object viewModel)
        {
            Contract.Requires(viewModel != null);
            Contract.Ensures(Contract.Result<Task>() != null);

            Type viewModelType = viewModel.GetType();
            Func<IInitializationStrategy> strategyFunc = this.TryGetContent(viewModelType);

            if (strategyFunc != null)
            {
                return strategyFunc().InitViewModel(viewModel);
            }

            throw new KeyNotFoundException(
                "The strategy of initialization view model for {0} not found".StringFormat(viewModelType));
        }

        /// <summary>
        /// The imports.
        /// </summary>
        /// <param name="lazy">
        /// The lazy.
        /// </param>
        protected override void Imports(Lazy<IInitializationStrategy, IInitializationMetadata> lazy)
        {
            this.Contents.Add(lazy.Metadata.StrategyForType, () => lazy.Value);
        }
    }
}
