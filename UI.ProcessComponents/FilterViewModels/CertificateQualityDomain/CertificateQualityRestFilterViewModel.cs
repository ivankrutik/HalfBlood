// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CertificateQualityFilterViewModel.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The certificate quality filter view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.ProcessComponents.FilterViewModels.CertificateQualityDomain
{
    using System.ComponentModel.Composition;

    using Buisness.Entities.CertificateQualityDomain.ManufacturersCertificateDomain;
    using Buisness.Entities.NomenclatorDomain;
    using Buisness.Filters;

    using ParusModelLite.CertificateQualityDomain.ManufacturersCertificateDomain;

    using ReactiveUI;

    using ServiceContracts;

    using UI.Infrastructure.ViewModels;
    using UI.Infrastructure.ViewModels.Filters;

    [Export(typeof(ICertificateQualityRestFilterViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class CertificateQualityRestFilterViewModel
        : GenericFilterViewModel<CertificateQualityFilter, CertificateQualityRestLiteDto>, ICertificateQualityRestFilterViewModel
    {
        [ImportingConstructor]
        public CertificateQualityRestFilterViewModel(
            IScreen screen,
            IUnitOfWorkFactory unitOfWorkFactory,
            IFilterViewModelFactory filterViewModelFactory)
            : base(unitOfWorkFactory)
        {
            GostCast = filterViewModelFactory.Create<CertificateQualityFilter, CertificateQualityDto>();
            GostMix = filterViewModelFactory.Create<CertificateQualityFilter, CertificateQualityDto>();
            Marka = filterViewModelFactory.Create<CertificateQualityFilter, CertificateQualityDto>();
            Mix = filterViewModelFactory.Create<CertificateQualityFilter, CertificateQualityDto>();
            NomenclatureNumberFilterViewModel =
                filterViewModelFactory.Create<NomenclatureNumberFilter, NomenclatureNumberDto>();
            HostScreen = screen;
            Filter = CertificateQualityFilter.Default;
        }

        public string UrlPathSegment
        {
            get { return "CertificateQualityRestFilterViewModel"; }
        }
        public IScreen HostScreen { get; private set; }
        public IFilterViewModel<CertificateQualityFilter, CertificateQualityDto> GostCast { get; private set; }
        public IFilterViewModel<CertificateQualityFilter, CertificateQualityDto> GostMix { get; private set; }
        public IFilterViewModel<CertificateQualityFilter, CertificateQualityDto> Marka { get; private set; }
        public IFilterViewModel<CertificateQualityFilter, CertificateQualityDto> Mix { get; private set; }
        public IFilterViewModel<NomenclatureNumberFilter, NomenclatureNumberDto> NomenclatureNumberFilterViewModel { get; private set; }
    }
}
