// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EditablePassViewModel.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the EditablePassViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------


namespace UI.ProcessComponents.PlanReceiptOrderDomain.PlanCertificateDomain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Linq;
    using System.Reactive.Linq;
    using System.Windows.Input;
    using Buisness.Filters;
    using FluentValidation;
    using ParusModelLite.CertificateQualityDomain;
    using ReactiveUI;
    using UI.Entities.CertificateQualityDomain.ManufacturersCertificateDomain;
    using UI.Infrastructure.ViewModels;
    using UI.Infrastructure.ViewModels.Filters;
    using UI.Infrastructure.ViewModels.PlanReceiptOrderDomain;
    using UI.ProcessComponents.EditViewModels;

    /// <summary>
    /// The editable pass view model.
    /// </summary>
    [Export(typeof(IEditablePassViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class EditablePassViewModel : EditableViewModelBase<ReactiveList<Pass>>, IEditablePassViewModel
    {
        #region private fields
        private CertificateQuality _certificateQuality;
        private ReactiveCommand _primeJustAsDestinationCommand;
        private IList<Destination> _destinations;
        #endregion
        [ImportingConstructor]
        public EditablePassViewModel(
            IScreen screen,
            IFilterViewModelFactory filterViewModelFactory,
            IMessageBus messageBus,
            IValidatorFactory validatorFactory)
            : base(screen, messageBus, validatorFactory)
        {
            DictionaryPassFilterViewModel = filterViewModelFactory.Create<DictionaryPassFilter, DictionaryPassLiteDto>();
            DictionaryPassFilterViewModel.InvokeCommand.Execute(null);
        }

        /// <summary>
        /// Gets the url path segment.
        /// </summary>
        public string UrlPathSegment { get; private set; }

        /// <summary>
        /// Gets the dictionary pass filter view model.
        /// </summary>
        public IFilterViewModel<DictionaryPassFilter, DictionaryPassLiteDto> DictionaryPassFilterViewModel { get; private set; }

        /// <summary>
        /// The set certificate quality.
        /// </summary>
        /// <param name="certificateQuality">
        /// The certificate quality.
        /// </param>
        public void SetCertificateQuality(CertificateQuality certificateQuality)
        {
            _certificateQuality = certificateQuality;
        }

        public ICommand PrimeJustAsDestinationCommand
        {
            get
            {
                if (_primeJustAsDestinationCommand == null)
                {
                    var canExecute = this.WhenAny(x => x.Destinations).Select(_ => Destinations != null).StartWith(Destinations != null);

                    _primeJustAsDestinationCommand = new ReactiveCommand(canExecute);
                    _primeJustAsDestinationCommand.Subscribe(
                        _ =>
                        {

                            var pas = new ReactiveList<Pass>();

                            foreach (var x in Destinations.Select(elem => new Pass { DictionaryPass = elem.DictionaryPass }))
                            {
                                pas.Add(x);
                            }
                            this.SetEditableObject(pas);
                            DictionaryPassFilterViewModel.InvokeCommand.Execute(null);
                        }
                        );
                }

                return _primeJustAsDestinationCommand;
            }
        }

        public IList<Destination> Destinations
        {
            get { return _destinations; }
            set { this.RaiseAndSetIfChanged(ref _destinations, value); }
        }

        /// <summary>
        /// The apply action.
        /// </summary>
        /// <param name="editObject">
        /// The edit object.
        /// </param>
        protected override void ApplyAction(ReactiveList<Pass> editObject)
        {
            editObject.DoForEach(item => item.CertificateQuality = item.CertificateQuality ?? _certificateQuality);
        }
    }
}
