// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IEditableChemicalViewModel.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The EditableChemicalViewModel interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Infrastructure.ViewModels.PlanReceiptOrderDomain
{
    using System.Collections.Generic;

    using Buisness.Entities.CertificateQualityDomain;

    using ReactiveUI;

    using UI.Entities.CertificateQualityDomain.ManufacturersCertificateDomain;

    /// <summary>
    /// The EditableChemicalViewModel interface.
    /// </summary>
    public interface IEditableChemicalViewModel : IEditableViewModel<ReactiveList<ChemicalIndicatorValue>>, IRoutableViewModel
    {
        /// <summary>
        /// Gets a value indicating whether is chemical indicator values load.
        /// </summary>
        bool IsChemicalIndicatorValuesLoad { get; }

        /// <summary>
        /// Gets the chemical indicator values.
        /// </summary>
        IList<DictionaryChemicalIndicatorDto> DictionaryChemicalIndicators { get; }

        /// <summary>
        /// The set certificate quality.
        /// </summary>
        /// <param name="certificateQuality">
        /// The certificate quality.
        /// </param>
        void SetCertificateQuality(CertificateQuality certificateQuality);
    }
}
