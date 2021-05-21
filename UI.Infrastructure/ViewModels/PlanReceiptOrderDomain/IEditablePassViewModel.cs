// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IEditablePassViewModel.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the IEditablePassViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------


using System.Collections.Generic;

namespace UI.Infrastructure.ViewModels.PlanReceiptOrderDomain
{
    using Buisness.Filters;

    using ParusModelLite.CertificateQualityDomain;

    using ReactiveUI;

    using UI.Entities.CertificateQualityDomain.ManufacturersCertificateDomain;

    using System.Windows.Input;
    /// <summary>
    /// The EditablePassViewModel interface.
    /// </summary>
    public interface IEditablePassViewModel : IEditableViewModel<ReactiveList<Pass>>, IRoutableViewModel
    {
        /// <summary>
        /// Gets the dictionary pass filter view model.
        /// </summary>
        IFilterViewModel<DictionaryPassFilter, DictionaryPassLiteDto> DictionaryPassFilterViewModel { get; }

        /// <summary>
        /// The set editable object.
        /// </summary>
        /// <param name="passes">
        /// The passes.
        /// </param>
        void SetEditableObject(ReactiveList<Pass> passes);

        /// <summary>
        /// The set certificate quality.
        /// </summary>
        /// <param name="certificateQuality">
        /// The certificate quality.
        /// </param>
        void SetCertificateQuality(CertificateQuality certificateQuality);

        ICommand PrimeJustAsDestinationCommand { get; }

        IList<Destination> Destinations { get; set; }

    
    }
}