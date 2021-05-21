// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IEditableDestinationVIewModel.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the IEditableDestinationViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Infrastructure.ViewModels.PlanReceiptOrderDomain
{
    using Buisness.Filters;

    using ParusModelLite.CertificateQualityDomain;

    using ReactiveUI;

    using UI.Entities.CertificateQualityDomain.ManufacturersCertificateDomain;

    /// <summary>
    /// The EditableDestinationViewModel interface.
    /// </summary>
    public interface IEditableDestinationViewModel : IEditableViewModel<ReactiveList<Destination>>, IRoutableViewModel
    {
        /// <summary>
        /// Gets the dictionary pass filter view model.
        /// </summary>
        IFilterViewModel<DictionaryPassFilter, DictionaryPassLiteDto> DictionaryPassFilterViewModel { get; }

        /// <summary>
        /// The set editable object.
        /// </summary>
        /// <param name="destinations">
        /// The destinations.
        /// </param>
        void SetEditableObject(ReactiveList<Destination> destinations);

        /// <summary>
        /// The set certificate quality.
        /// </summary>
        /// <param name="certificateQuality">
        /// The certificate quality.
        /// </param>
        void SetCertificateQuality(CertificateQuality certificateQuality);
    }
}