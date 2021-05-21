// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EditableViewModelBase.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the EditableViewModelBase type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.ProcessComponents.EditViewModels
{
    using System;
    using System.ComponentModel;
    using System.Reactive.Linq;
    using System.Windows.Input;
    using FluentValidation;
    using ReactiveUI;
    using UI.Infrastructure;
    using UI.Infrastructure.Messages;
    using UI.Infrastructure.ViewModels;

    public abstract class EditableViewModelBase<TEditObject> : EditableContext<TEditObject>, IEditableViewModel<TEditObject>, IDisposable
        where TEditObject : class
    {
        protected readonly IMessageBus MessageBus;
        protected readonly IValidatorFactory ValidatorFactory;
        private ReactiveCommand _applyCommand;
        private ReactiveCommand _cancelCommand;

        protected EditableViewModelBase(
            IScreen screen, 
            IMessageBus messageBus = null, 
            IValidatorFactory validatorFactory = null)
        {
            this.MessageBus = messageBus;
            this.ValidatorFactory = validatorFactory;
            this.HostScreen = screen;
        }

        public EditState EditState
        {
            get;
            private set;
        }
        public IScreen HostScreen
        {
            get;
            private set;
        }
        public ICommand ApplyCommand
        {
            get
            {
                if (_applyCommand != null)
                {
                    return _applyCommand;
                }

                _applyCommand = new ReactiveCommand(CanExecute());
                _applyCommand.Subscribe(_ => Apply());

                return _applyCommand;
            }
        }
        public ICommand CancelCommand
        {
            get
            {
                if (_cancelCommand == null)
                {
                    _cancelCommand = new ReactiveCommand(Observable.Empty<bool>());
                    _cancelCommand.Subscribe(x => OnCancel());
                }

                return _cancelCommand;
            }
        }

        public virtual void SetEditableObject(TEditObject edit, EditState state)
        {
            SetEditableObject(edit);
            EditState = state;
        }
        public virtual void Dispose()
        {
            if (this._applyCommand != null)
            {
                this._applyCommand.Dispose();
                this._applyCommand = null;
            }
        }

        protected virtual IValidator<TEditObject> GetValidator()
        {
            if (ValidatorFactory == null)
            {
                return null;
            }

            return ValidatorFactory.GetValidator<TEditObject>();
        }
        protected virtual void OnCancel()
        {
            HostScreen.Router.NavigateBack.Execute(null);
        }
        protected override void OnEditableObjectChanging(TEditObject oldObject, TEditObject newObject)
        {
            if (_applyCommand != null)
            {
                _applyCommand.Dispose();
                _applyCommand = null;
                this.RaisePropertyChanged("ApplyCommand");
            }
        }
        protected virtual IObservable<bool> CanExecute(IObservable<bool> validateObservable)
        {
            return validateObservable;
        }
        protected override void CompleteAction(TEditObject instance)
        {
            base.CompleteAction(instance);

            if (MessageBus != null)
            {
                if (EditState == EditState.Insert || EditState == EditState.Clone)
                {
                    MessageBus.SendMessage(new AddedEntityMessage<TEditObject>(instance));
                }
                else if (EditState == EditState.Edit) 
                {
                    MessageBus.SendMessage(new UpdatedEntityMessage<TEditObject>(instance));
                }
            }

            HostScreen.Router.NavigateBack.Execute(null);
        }
        protected override void OnError(Exception exception)
        {
            var message = string.Format("Не получилось {0}", EditState == EditState.Edit ? "обновить" : "добавить");
            UserError.Throw(message, exception);
        }

        private IObservable<bool> CanExecute()
        {
            IValidator<TEditObject> validator = GetValidator();

            if (validator == null)
            {
                return CanExecute(Observable.Empty<bool>());
            }

            var editableObject = EditableObject as INotifyPropertyChanged;

            if (editableObject == null)
            {
                return CanExecute(Observable.Empty<bool>());
            }

            var editableSubject =
                Observable.FromEventPattern<PropertyChangedEventHandler, PropertyChangedEventArgs>(
                    h => editableObject.PropertyChanged += h,
                    h => editableObject.PropertyChanged -= h)
                    .Select(_ => validator.Validate(EditableObject).IsValid)
                    .StartWith(validator.Validate(EditableObject).IsValid);

            return CanExecute(editableSubject);
        }
    }
}