// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ActSelectionOfProbeViewModel.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The act selection of probe view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.ProcessComponents.CertificateQualityDomain.ActSelectionOfProbeDomain
{
    using System.ComponentModel.Composition;

    using ParusModelLite.CertificateQualityDomain.ActSelectionOfProbeDomain;
    using Halfblood.Common.Log;
    using ReactiveUI;

    using ServiceContracts;

    using UI.Infrastructure;
    using UI.Infrastructure.ViewModels.ActSelectionOfProbeDomain;
    using UI.Infrastructure.ViewModels.Filters;
    using Buisness.Entities.CertificateQualityDomain.ActSelectionProbeDomain;

    using FluentValidation;
    using Halfblood.Common.Mappers;
    using ServiceContracts.Facades;
    using UI.Entities.CertificateQualityDomain.ActSelectionOfProbeDomain;
    using UI.ProcessComponents.EditViewModels;
    using ParusModelLite.CertificateQualityDomain.ManufacturersCertificateDomain;

    [Export(typeof(IEditableActSelectionOfProbeViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class EditableActSelectionOfProbeViewViewModel :
        PolicyEditableViewModelBase<ActSelectionOfProbe>, IEditableActSelectionOfProbeViewModel
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private ActSelectionOfProbeDepartmentLiteDto _selectedActSelectionOfProbeDepartment;

        ~EditableActSelectionOfProbeViewViewModel()
        {
            LogManager.Log.Debug("EditableActSelectionOfProbeViewViewModel IS DESTROYED");
        }

        [ImportingConstructor]
        public EditableActSelectionOfProbeViewViewModel(
            IScreen screen,
            IUnitOfWorkFactory unitOfWorkFactory,
            IValidatorFactory validatorFactory,
            IMessageBus messageBus,
            IFilterViewModelFactory filterViewModelFactory)
            : base(screen, messageBus, validatorFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;

        }

        public string UrlPathSegment
        {
            get { return "/EditableActSelectionOfProbeViewModel"; }
        }
        public CertificateQualityLiteDto CertificateQuality { get; set; }
        public ActSelectionOfProbeDepartmentLiteDto SelectedActSelectionOfProbeDepartment
        {
            get { return _selectedActSelectionOfProbeDepartment; }
            set
            {
                this.RaiseAndSetIfChanged(ref _selectedActSelectionOfProbeDepartment, value);
            }
        }

        protected override void ApplyAction(ActSelectionOfProbe actSelectionOfProbe)
        {
            using (IUnitOfWork unitOfWork = _unitOfWorkFactory.Create())
            {
                var service = unitOfWork.Create<IActSelectionOfProbeService>();
                if (this.EditState == EditState.Edit)
                {
                    service.UpdateActSelectionOfProbe(actSelectionOfProbe.MapTo<ActSelectionOfProbeDto>());
                }

                unitOfWork.Commit();
            }
        }
    }
}