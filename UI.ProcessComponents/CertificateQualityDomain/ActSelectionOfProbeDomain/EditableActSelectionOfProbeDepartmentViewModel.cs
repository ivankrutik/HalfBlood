// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EditablePersonalAccountViewModel.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the EditablePersonalAccountViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------


using Halfblood.Common.Reporting;
using Halfblood.Reports;

namespace UI.ProcessComponents.CertificateQualityDomain.ActSelectionOfProbeDomain
{
    using System;
    using System.Reactive.Linq;
    using Buisness.Entities.CommonDomain;
    using Buisness.Filters;
    using FluentValidation;
    using Halfblood.Common.Mappers;
    using ReactiveUI;
    using ServiceContracts;
    using ServiceContracts.Facades;
    using UI.Entities.CertificateQualityDomain.ActSelectionOfProbeDomain;
    using UI.Infrastructure;
    using UI.Infrastructure.ViewModels;
    using UI.Infrastructure.ViewModels.ActSelectionOfProbeDomain;
    using UI.Infrastructure.ViewModels.Filters;
    using UI.ProcessComponents.EditViewModels;
    using Buisness.Entities.CertificateQualityDomain.ActSelectionProbeDomain;
    using System.ComponentModel.Composition;

    /// <summary>
    /// The editable personal account view model.
    /// </summary>
    [Export(typeof(IEditableActSelectionOfProbeDepartmentViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class EditableActSelectionOfProbeDepartmentViewModel
        : PolicyEditableViewModelBase<ActSelectionOfProbeDepartment>, IEditableActSelectionOfProbeDepartmentViewModel
    {
        #region Private Fields
        protected readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly IFilterViewModelFactory _filterViewModelFactory;
        private readonly IPrintManager _printManager;
        private IFilterViewModel<StaffingDivisionFilter, StaffingDivisionDto> _staffingDivisionReceiver;
        private IFilterViewModel<StaffingDivisionFilter, StaffingDivisionDto> _staffingDivisionMakingSample;
        #endregion

        [ImportingConstructor]
        public EditableActSelectionOfProbeDepartmentViewModel(
            IScreen screen,
            IMessageBus messageBus,
            IPrintManager printManager,
            IUnitOfWorkFactory unitOfWork,
            IFilterViewModelFactory filterViewModelFactory,
            IValidatorFactory validatorFactory)
            : base(screen, messageBus, validatorFactory)
        {
            _filterViewModelFactory = filterViewModelFactory;
            _unitOfWorkFactory = unitOfWork;
            _printManager = printManager;
            StaffingDivisionMakingSample.InvokeCommand.Execute(null);
            StaffingDivisionReceiver.InvokeCommand.Execute(null);
        }

        public string UrlPathSegment
        {
            get { return "/EditableActSelectionOfProbeDepartmentViewModel"; }
        }

        public IFilterViewModel<StaffingDivisionFilter, StaffingDivisionDto> StaffingDivisionReceiver
        {
            get
            {
                return _staffingDivisionReceiver
                    ?? (_staffingDivisionReceiver = _filterViewModelFactory.Create<StaffingDivisionFilter, StaffingDivisionDto>());
            }
        }

        public IFilterViewModel<StaffingDivisionFilter, StaffingDivisionDto> StaffingDivisionMakingSample
        {
            get
            {
                return _staffingDivisionMakingSample
                    ?? (_staffingDivisionMakingSample = _filterViewModelFactory.Create<StaffingDivisionFilter, StaffingDivisionDto>());
            }
        }

        protected override void ApplyAction(ActSelectionOfProbeDepartment editObject)
        {
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                var service = unitOfWork.Create<IActSelectionOfProbeService>();
                if (EditState == EditState.Edit)
                {
                    service.UpdateActSelectionOfProbeDepartment(editObject.MapTo<ActSelectionOfProbeDepartmentDto>());
                }
                else
                {
                    EditableObject.Rn =
                        service.AddActSelectionOfProbeDepartment(
                            editObject.MapTo<ActSelectionOfProbeDepartmentDto>()).Rn;
                }

                unitOfWork.Commit();
            }
            
            PrintLabel();
        }
      
        private void PrintLabel()
        {
            var report = new LabelActSelectionOfProbe(EditableObject.Rn);
            _printManager.OpenReportInBrowser(report);
        }

    }
}