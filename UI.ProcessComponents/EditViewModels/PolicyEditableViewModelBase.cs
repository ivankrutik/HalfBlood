// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PolicyEditableViewModelBase.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the PolicyEditableViewModelBase type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.ProcessComponents.EditViewModels
{
    using System.ComponentModel.Composition;

    using FluentValidation;

    using Halfblood.Common;

    using ReactiveUI;

    using UI.Infrastructure;
    using UI.Infrastructure.ViewModels;

    public abstract class PolicyEditableViewModelBase<TEditObject> : EditableViewModelBase<TEditObject>,
                                                                     IHasAccessCatalog, IPartImportsSatisfiedNotification
        where TEditObject : class, IHasUid<long>
    {
        private IGetCatalogAccess _getAccess;

        protected PolicyEditableViewModelBase(
            IScreen screen,
            IMessageBus messageBus,
            IValidatorFactory validatorFactory = null)
            : base(screen, messageBus, validatorFactory)
        {
        }

        [Import]
        public IGetCatalogAccess GetCatalogAccess
        {
            get
            {
                return _getAccess;
            }
            private set
            {
                this.RaiseAndSetIfChanged(ref _getAccess, value);
            }
        }

        void IPartImportsSatisfiedNotification.OnImportsSatisfied()
        {
            OnLoadAcatalog();
        }

        protected virtual void OnLoadAcatalog()
        {
            this.GetCatalogAccess.LoadForEntity(typeof(TEditObject), TypeActionInSystem.TheStandardAddition);
        }
    }
}