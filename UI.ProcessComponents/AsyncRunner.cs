// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AsyncRunner.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the loader base type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.ProcessComponents
{
    using System;
    using System.Diagnostics.Contracts;
    using System.Reactive;
    using System.Reactive.Disposables;
    using System.Reactive.Subjects;
    using System.Threading;
    using System.Threading.Tasks;

    using ReactiveUI;

    using UI.Infrastructure.ViewModels;

    /// <summary>
    /// The loader. Executing sync operation in async mode.
    /// </summary>
    /// <typeparam name="TLoadType">
    /// The type, which will be loaded.
    /// </typeparam>
    public class AsyncRunner<TLoadType> : ReactiveObject, IAyncRunner<TLoadType>
    {
        #region private fields
        private readonly object _locker = new object();
        private readonly Subject<Unit> _loaderCompletedNotificationBase = new Subject<Unit>();
        private readonly Subject<bool> _isExecuting = new Subject<bool>();
        private readonly Subject<Exception> _thrownExceptions = new Subject<Exception>();
        private readonly Subject<TLoadType> _loadCompletedNotification = new Subject<TLoadType>();

        private Task<bool> _taskForWait;
        private IDisposable _cancelContext;
        private Func<TLoadType> _function;
        private Task<TLoadType> _task;
        private TLoadType _result;
        private Func<TLoadType, TLoadType> _converterFunc = result => result;
        private bool _isBusy;
        #endregion

        public AsyncRunner()
        {
            _cancelContext = Disposable.Empty;
            IsExecuting.Subscribe(isExecuting => IsBusy = isExecuting);
            LoadCompletedNotification.Subscribe(_ => _loaderCompletedNotificationBase.OnNext(Unit.Default));
        }
      
        public new IObservable<Exception> ThrownExceptions
        {
            get { return _thrownExceptions; }
        }
        public bool IsBusy
        {
            get { return this._isBusy; }
            private set { this.RaiseAndSetIfChanged(ref _isBusy, value); }
        }
        public IObservable<bool> IsExecuting
        {
            get { return _isExecuting; }
        }
        public TLoadType Result
        {
            get { return this._result; }
            protected set { this.RaiseAndSetIfChanged(ref _result, value); }
        }
        public IObservable<TLoadType> LoadCompletedNotification
        {
            get { return _loadCompletedNotification; }
        }

        public static IAyncRunner Create(Action action)
        {
            var runner = new AsyncRunner<Unit>();
            runner.RegisterFunction(
                () =>
                {
                    action();
                    return Unit.Default;
                });

            return runner;
        }

        public Task<TLoadType> GetInvokedTask()
        {
            lock (_locker)
            {
                if (_task != null && !_task.IsCompleted)
                {
                    return _task;
                }

                _cancelContext.Dispose();

                var cancellationTokenSource = new CancellationTokenSource();
                _cancelContext = Disposable.Create(() =>
                {
                    cancellationTokenSource.Cancel();
                    cancellationTokenSource.Dispose();
                });

                _task = Task.Factory.StartNew(
                    () =>
                    {
                        _isExecuting.OnNext(true);
                        return _function();
                    },
                    cancellationTokenSource.Token);

                _task.ContinueWith(t => _isExecuting.OnNext(false));

                // Эту штуку нужно выполнить в потоке, который вызвал GetInvokedTask
                _taskForWait = _task.ContinueWith(
                    t =>
                    {
                        if (t.IsFaulted)
                        {
                            _thrownExceptions.OnNext(t.Exception.InnerException);
                            return false;
                        }

                        Result = _converterFunc(t.Result);
                        OnComplete(Result);
                        return true;
                    });

                return _task;
            }
        }
        public IAyncRunner<TLoadType> SetConverter(Func<TLoadType, TLoadType> converterFunc)
        {
            Contract.Requires(converterFunc != null, "The converter must be not null");
            _converterFunc = converterFunc;

            return this;
        }
        public IAyncRunner<TLoadType> RegisterFunction(Func<TLoadType> function)
        {
            Contract.Requires(function != null, "The function mest be not null");

            Abort();
            _function = function;
            return this;
        }
        public void Load()
        {
            GetInvokedTask();
        }
        public void Abort()
        {
            _cancelContext.Dispose();
            lock (_locker)
            {
                _task = null;
                _taskForWait = null;
            }
        }
        public bool Wait()
        {
            this.Load();

            lock (_locker)
            {
                _taskForWait.Wait();
                return _taskForWait.Result;
            }
        }

        IObservable<Unit> IAyncRunner.CompletedNotification
        {
            get { return this._loaderCompletedNotificationBase; }
        }
        Task IAyncRunner.GetInvokedTask()
        {
            return this.GetInvokedTask();
        }
        protected virtual void Complete() { /*to do*/ }

        private void OnComplete(TLoadType loadObject)
        {
            _isExecuting.OnNext(false);
            _loadCompletedNotification.OnNext(loadObject);
            Complete();
        }
    }
}