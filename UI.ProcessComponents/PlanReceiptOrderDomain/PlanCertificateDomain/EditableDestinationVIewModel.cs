// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EditableDestinationVIewModel.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the EditableDestinationVIewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.ProcessComponents.PlanReceiptOrderDomain.PlanCertificateDomain
{
    using System.ComponentModel.Composition;
    using System.Reactive.Linq;

    using Buisness.Filters;

    using FluentValidation;

    using ParusModelLite.CertificateQualityDomain;

    using ReactiveUI;

    using UI.Entities.CertificateQualityDomain.ManufacturersCertificateDomain;
    using UI.Infrastructure.ViewModels;
    using UI.Infrastructure.ViewModels.Filters;
    using UI.Infrastructure.ViewModels.PlanReceiptOrderDomain;
    using UI.ProcessComponents.EditViewModels;

    [Export(typeof(IEditableDestinationViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class EditableDestinationViewModel : EditableViewModelBase<ReactiveList<Destination>>, IEditableDestinationViewModel
    {
        private readonly IFilterViewModelFactory _filterViewModelFactory;
        private IFilterViewModel<DictionaryPassFilter, DictionaryPassLiteDto> _dictionaryPassFilterViewModel;
        private CertificateQuality _certificateQuality;

        [ImportingConstructor]
        public EditableDestinationViewModel(
            IScreen screen,
            IFilterViewModelFactory filterViewModelFactory,
            IMessageBus messageBus,
            IValidatorFactory validatorFactory)
            : base(screen, messageBus, validatorFactory)
        {
            _filterViewModelFactory = filterViewModelFactory;
            _dictionaryPassFilterViewModel =
                _filterViewModelFactory.Create<DictionaryPassFilter, DictionaryPassLiteDto>();
            _dictionaryPassFilterViewModel.InvokeCommand.Execute(null);
        }

        public string UrlPathSegment { get; private set; }
        public IFilterViewModel<DictionaryPassFilter, DictionaryPassLiteDto> DictionaryPassFilterViewModel
        {
            get { return _dictionaryPassFilterViewModel; }
            private set { _dictionaryPassFilterViewModel = value; }
        }

        public void SetCertificateQuality(CertificateQuality certificateQuality)
        {
            _certificateQuality = certificateQuality;
        }

        protected override void ApplyAction(ReactiveList<Destination> editObject)
        {
            editObject.DoForEach(item => item.CertificateQuality = item.CertificateQuality ?? _certificateQuality);
        }
    }
}