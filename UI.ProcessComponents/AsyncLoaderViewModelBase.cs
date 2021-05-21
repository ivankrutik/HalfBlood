// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AsyncLoaderViewModelBase.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   The async loader view model base.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.ProcessComponents
{
    using System;
    using System.Reactive.Linq;
    using System.Windows.Input;

    using ReactiveUI;

    using UI.Infrastructure.ViewModels;

    public abstract class AsyncLoaderViewModelBase<TLoadObject> : AsyncRunner<TLoadObject>, IInvokerViewModel
    {
        private ReactiveCommand _invokeCommand;
        private ReactiveCommand _abortCommand;

        protected AsyncLoaderViewModelBase()
        {
            this.RegisterFunction(this.DoLoad);
            ThrownExceptions.ObserveOnUiSafeScheduler().Subscribe(OnError);
        }

        public ICommand InvokeCommand
        {
            get
            {
                if (_invokeCommand == null)
                {
                    _invokeCommand = new ReactiveCommand(CanExecuteToInvoke());
                    _invokeCommand.Subscribe(_ => Load());
                }

                return _invokeCommand;
            }
        }
        public ICommand AbortCommand
        {
            get
            {
                if (_abortCommand == null)
                {
                    _abortCommand = new ReactiveCommand(CanExecuteToAbort());
                    _abortCommand.Subscribe(_ => Abort());
                }

                return _abortCommand;
            }
        }

        protected virtual IObservable<bool> CanExecuteToInvoke()
        {
            return Observable.Return(true);
        }
        protected virtual IObservable<bool> CanExecuteToAbort()
        {
            return Observable.Return(true);
        }
        protected abstract TLoadObject DoLoad();
        protected virtual void OnError(Exception exception)
        {
            UserError.Throw("Не удалось загрузить данные", exception);
        }
    }
}