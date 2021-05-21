// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IAyncRunner.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the IAyncRunner type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Infrastructure.ViewModels
{
    using System;
    using System.Reactive;
    using System.Threading.Tasks;

    public interface ILoader
    {
        void Load();
        void Abort();        
    }

    /// <summary>
    /// The Loader interface.
    /// </summary>
    public interface IAyncRunner : ILoader
    {
        bool IsBusy { get; }
        IObservable<bool> IsExecuting { get; }
        IObservable<Exception> ThrownExceptions { get; }
        IObservable<Unit> CompletedNotification { get; }
        bool Wait();
        Task GetInvokedTask();
    }

    /// <summary>
    /// The loader. Executing sync operation in async mode.
    /// </summary>
    /// <typeparam name="TLoadType">
    /// The type, which will be loaded.
    /// </typeparam>
    public interface IAyncRunner<TLoadType> : IAyncRunner
    {
        TLoadType Result { get; }
        Task<TLoadType> GetInvokedTask();
        IAyncRunner<TLoadType> SetConverter(Func<TLoadType, TLoadType> conFunc);
        IObservable<TLoadType> LoadCompletedNotification { get; }
    }
}