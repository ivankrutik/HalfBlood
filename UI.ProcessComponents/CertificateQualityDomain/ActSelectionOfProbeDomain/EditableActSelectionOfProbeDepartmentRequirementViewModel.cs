// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EditablePersonalAccountViewModel.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the EditablePersonalAccountViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------


namespace UI.ProcessComponents.CertificateQualityDomain.ActSelectionOfProbeDomain
{
    using System;
    using System.Reactive.Linq;
    using FluentValidation;
    using Halfblood.Common.Mappers;
    using ReactiveUI;
    using ServiceContracts;
    using ServiceContracts.Facades;
    using UI.Entities.CertificateQualityDomain.ActSelectionOfProbeDomain;
    using UI.Infrastructure;
    using UI.Infrastructure.ViewModels.ActSelectionOfProbeDomain;
    using UI.ProcessComponents.EditViewModels;
    using Buisness.Entities.CertificateQualityDomain.ActSelectionProbeDomain;
    using System.ComponentModel.Composition;

    /// <summary>
    /// The editable personal account view model.
    /// </summary>
    [Export(typeof(IEditableActSelectionOfProbeDepartmentRequirementViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class EditableActSelectionOfProbeDepartmentRequirementViewModel
        : EditableViewModelBase <ActSelectionOfProbeDepartmentRequirement>, IEditableActSelectionOfProbeDepartmentRequirementViewModel
    {
        #region Private Fields
        protected readonly IUnitOfWorkFactory _unitOfWorkFactory;
        #endregion
        [ImportingConstructor]
        public EditableActSelectionOfProbeDepartmentRequirementViewModel(
            IScreen screen,
            IMessageBus messageBus,
            IUnitOfWorkFactory unitOfWork,
            IValidatorFactory validatorFactory)
            : base(screen, messageBus, validatorFactory)
        {
            _unitOfWorkFactory = unitOfWork;
        }

        public string UrlPathSegment
        {
            get { return "/EditableActSelectionOfProbeDepartmentRequirementViewModel"; }
        }




        protected override void ApplyAction(ActSelectionOfProbeDepartmentRequirement editObject)
        {
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                var service = unitOfWork.Create<IActSelectionOfProbeService>();
                if (EditState == EditState.Edit)
                {
                    service.UpdateActSelectionOfProbeDepartmentRequirement(editObject.MapTo<ActSelectionOfProbeDepartmentRequirementDto>());
                }
                else
                {
                    EditableObject.Rn =
                        service.AddActSelectionOfProbeDepartmentRequirement(
                            editObject.MapTo<ActSelectionOfProbeDepartmentRequirementDto>()).Rn;
                }

                unitOfWork.Commit();
            }
        }
        protected override IObservable<bool> CanExecute(IObservable<bool> validateObservable)
        {
            var secondObservable =
                EditableObject.WhenAny(x => x, x => x.Value).Select(x => x != null && x.Rn > 0);

            return validateObservable.CombineLatest(secondObservable, (left, right) => left && right);
        }

    }
}