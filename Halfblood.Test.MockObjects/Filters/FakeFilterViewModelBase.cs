// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FakeFilterViewModelBase.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the FakeFilterViewModelBase type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Halfblood.Test.MockObjects.Filters
{
    using System;
    using System.Collections.Generic;
    using System.Reactive;
    using System.Reactive.Linq;
    using System.Threading.Tasks;
    using System.Windows.Input;

    using FizzWare.NBuilder;

    using ReactiveUI;

    using UI.Infrastructure.ViewModels;

    /// <summary>
    /// The fake filter view model base.
    /// </summary>
    /// <typeparam name="TFilter">
    /// </typeparam>
    /// <typeparam name="TObject">
    /// </typeparam>
    public abstract class FakeFilterViewModelBase<TFilter, TObject> : ReactiveObject, IFilterViewModel<TFilter, TObject>
    {
        private bool isBusy;

        public bool IsBusy
        {
            get { return this.isBusy; }
            private set
            {
                this.RaiseAndSetIfChanged(ref isBusy, value);
            }
        }

        public IObservable<bool> IsExecuting { get; private set; }
        public ICommand ClearFilterCommand { get; private set; }
        public TFilter Filter { get; private set; }

        public IFilterViewModel<TFilter, TObject> SetFilter(TFilter filter)
        {
            Filter = filter;
            return this;
        }

        public bool Wait()
        {
            throw new NotImplementedException();
        }

        public Task<IList<TObject>> GetInvokedTask()
        {
            throw new NotImplementedException();
        }

        IAyncRunner<IList<TObject>> IAyncRunner<IList<TObject>>.SetConverter(Func<IList<TObject>, IList<TObject>> converterFunction)
        {
            throw new NotImplementedException();
        }

        public void SetConverter(Func<IList<TObject>, IList<TObject>> converterFunction)
        {
            throw new NotImplementedException();
        }

        public ICommand InvokeCommand { get; private set; }
        public ICommand AbortCommand { get; private set; }

        public void SetCanExecuteToInvoke(IObservable<bool> observable)
        {
            throw new NotImplementedException();
        }

        public void SetCanExecuteToAbort(IObservable<bool> observable)
        {
            throw new NotImplementedException();
        }

        public IList<TObject> Result { get; private set; }
        public IObservable<IList<TObject>> LoadCompletedNotification { get; private set; }

        public Task<IList<TObject>> GetTaskLoad()
        {
            throw new NotImplementedException();
        }

        IObservable<Unit> IAyncRunner.CompletedNotification
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Load()
        {
            this.IsBusy = true;
            Observable.ToAsync(() => Generate())()
                .ObserveOnUiSafeScheduler()
                .Finally(() => IsBusy = false)
                .Subscribe(res => Result = res);
        }

        public void Abort()
        {
        }

        Task IAyncRunner.GetInvokedTask()
        {
            return this.GetInvokedTask();
        }

        public virtual IList<TObject> Generate()
        {
            return Builder<TObject>.CreateListOfSize(10).Build();
        }

        public FakeFilterViewModelBase()
        {
            this.InvokeCommand = new ReactiveCommand(
                Observable.Empty<bool>());
            ((ReactiveCommand)InvokeCommand).Subscribe(_ => Load());
        }

        public void Dispose()
        {
            
        }
    }
}