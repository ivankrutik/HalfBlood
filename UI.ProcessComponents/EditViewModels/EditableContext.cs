// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EditableContext.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The editable context.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.ProcessComponents.EditViewModels
{
    using System;
    using System.Reactive;
    using System.Reactive.Linq;

    using Halfblood.Common.Helpers;

    using ReactiveUI;

    using UI.Infrastructure.ViewModels;

    public abstract class EditableContext<TEditObject> : ReactiveObject
        where TEditObject : class
    {
        private readonly object _locker = new object();
        private readonly IAyncRunner _runner;
        private bool _isBusy;
        protected CopyContext<TEditObject> EditableObjectContext;

        protected EditableContext()
        {
            this._runner = AsyncRunner<Unit>.Create(() => this.ApplyAction(EditableObject));
            this._runner.CompletedNotification.ObserveOnUiSafeScheduler()
                .Subscribe(_ => this.OnCompleteAction(this.EditableObject));
            this._runner.IsExecuting.Subscribe(
                isExecuting =>
                    {
                        lock (_locker)
                        {
                            this.IsBusy = isExecuting;
                        }
                    });
            _runner.ThrownExceptions.ObserveOnUiSafeScheduler().Subscribe(this.OnError);
        }

        public TEditObject EditableObject
        {
            get
            {
                if (EditableObjectContext == null)
                {
                    return null;
                }

                return EditableObjectContext.Value;
            }
            private set
            {
                OnEditableObjectChanging(EditableObject, value);
                EditableObjectContext = new CopyContext<TEditObject>(value);
                this.RaisePropertyChanged();
            }
        }
        public bool IsBusy
        {
            get { return _isBusy; }
            protected set { this.RaiseAndSetIfChanged(ref _isBusy, value); }
        }

        public void SetEditableObject(TEditObject edit)
        {
            if (edit == null)
            {
                throw new ArgumentNullException("edit");
            }

            EditableObject = edit;
        }
        public void Apply()
        {
            lock(_locker)
            {
                if (IsBusy)
                {
                    return;
                }
            }

            this._runner.Load();
        }
        public void Wait()
        {
            _runner.Wait();
        }

        protected abstract void ApplyAction(TEditObject editObject);
        protected virtual void CompleteAction(TEditObject instance) { /*TO DO*/ }
        protected virtual void OnError(Exception exception)
        {
            throw exception;
        }
        protected virtual void OnEditableObjectChanging(TEditObject oldObject, TEditObject newObject) { /*TO DO*/}

        private void OnCompleteAction(TEditObject instance)
        {
            if (EditableObjectContext != null)
            {
                EditableObjectContext.Commit();
            }

            CompleteAction(instance);
        }
    }
}
