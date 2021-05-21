// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IEditablePlanCertificateViewModel.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the IEditablePlanCertificateViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Infrastructure.ViewModels.PlanReceiptOrderDomain
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Input;

    using Buisness.Entities.CertificateQualityDomain.ManufacturersCertificateDomain;
    using Buisness.Entities.CommonDomain;
    using Buisness.Entities.NomenclatorDomain;
    using Buisness.Filters;

    using ParusModelLite.CertificateQualityDomain.ManufacturersCertificateDomain;

    using ReactiveUI;

    using UI.Entities.CommonDomain;
    using UI.Entities.NomeclatorDomain;
    using UI.Entities.PlanReceiptOrderDomain;

    /// <summary>
    /// The EditPlanCertificateViewModel interface.
    /// </summary>
    public interface IEditablePlanCertificateViewModel : IEditableViewModel<PlanCertificate>, IRoutableViewModel, IDisposable
    {
        /// <summary>
        /// Gets the get a catalog access.
        /// </summary>
        IGetCatalogAccess GetCatalogAccess { get; }

        /// <summary>
        /// Gets the document viewer.
        /// </summary>
        IAttachedDocumentViewModel Document { get; }

        /// <summary>
        /// Gets or sets the selected nomenclature number.
        /// </summary>
        NomenclatureNumber SelectedNomenclatureNumber { get; set; }

        /// <summary>
        /// Gets the preparing for edit pass command.
        /// </summary>
        ICommand PreparingForEditPassCommand { get; }

        /// <summary>
        /// Gets the preparing for edit destination command.
        /// </summary>
        ICommand PreparingForEditDestinationCommand { get; }

        /// <summary>
        /// Gets the preparing for edit mechanic indicator values command.
        /// </summary>
        ICommand PreparingForEditMechanicIndicatorValuesCommand { get; }

        /// <summary>
        /// Gets the preparing for edit chemical indicator values command.
        /// </summary>
        ICommand PreparingForEditChemicalIndicatorValuesCommand { get; }

        /// <summary>
        /// Gets the get certificate quality.
        /// </summary>
        IFilterViewModel<CertificateQualityFilter, CertificateQualityDto> CertificateQualityViewModel { get; }

        /// <summary>
        /// Gets the GOST cast filter view model.
        /// </summary>
        IFilterViewModel<CertificateQualityFilter, CertificateQualityLiteDto> GostCastFilterViewModel { get; }

        /// <summary>
        /// Gets the GOST mix filter view model.
        /// </summary>
        IFilterViewModel<CertificateQualityFilter, CertificateQualityLiteDto> GostMixFilterViewModel { get; }

        /// <summary>
        /// Gets the marka filter view model.
        /// </summary>
        IFilterViewModel<CertificateQualityFilter, CertificateQualityLiteDto> MarkaFilterViewModel { get; }

        /// <summary>
        /// Gets the mix filter view model.
        /// </summary>
        IFilterViewModel<CertificateQualityFilter, CertificateQualityLiteDto> MixFilterViewModel { get; }

        /// <summary>
        /// Gets the user filter view model.
        /// </summary>
        IFilterViewModel<UserFilter, UserDto> UserFilterViewModel { get; }

        /// <summary>
        /// Gets the goods manager modification filter view model.
        /// </summary>
        IFilterViewModel<NomenclatureNumberModificationFilter, NomenclatureNumberModificationDto> GoodsmanagerModificationFilterViewModel { get; }

        /// <summary>
        /// Gets the storekeeper modification filter view model.
        /// </summary>
        IFilterViewModel<NomenclatureNumberModificationFilter, NomenclatureNumberModificationDto> StorekeeperModificationFilterViewModel { get; }

        /// <summary>
        /// Gets the user filter view model.
        /// </summary>
        IList<NameOfCurrency> NameOfCurrencies { get; set; }

        /// <summary>
        /// Gets or sets the tax bands.
        /// </summary>
        IList<TaxBand> TaxBands { get; set; }

        /// <summary>
        /// Gets the unit of measures.
        /// </summary>
        IList<UnitOfMeasure> UnitOfMeasures { get; set; }
    }
}