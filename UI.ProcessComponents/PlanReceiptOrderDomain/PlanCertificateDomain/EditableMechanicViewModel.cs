// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EditableMechanicViewModel.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The editable chemical view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.ProcessComponents.PlanReceiptOrderDomain.PlanCertificateDomain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Linq;
    using System.Reactive;
    using System.Reactive.Linq;

    using Buisness.Entities.CertificateQualityDomain;
    using Buisness.Filters;

    using FluentValidation;

    using ReactiveUI;

    using UI.Entities.CertificateQualityDomain.ManufacturersCertificateDomain;
    using UI.Infrastructure.ViewModels.Filters;
    using UI.Infrastructure.ViewModels.PlanReceiptOrderDomain;
    using UI.ProcessComponents.EditViewModels;

    /// <summary>
    /// The editable chemical view model.
    /// </summary>
    [Export(typeof(IEditableMechanicViewModel))]
    public class EditableMechanicViewModel : EditableViewModelBase<ReactiveList<MechanicIndicatorValue>>, IEditableMechanicViewModel
    {
        private readonly IFilterViewModelFactory _filterViewModelFactory;
        private readonly IValidatorFactory _validatorFactory;
        private bool _isMechanicIndicatorValuesLoad;
        private CertificateQuality _certificateQuality;
        private IList<DictionaryMechanicalIndicatorDto> _dictionaryMechanicalIndicators;

        /// <summary>
        /// Initializes a new instance of the <see cref="EditableMechanicViewModel"/> class.
        /// </summary>
        /// <param name="screen">
        /// The screen.
        /// </param>
        /// <param name="filterViewModelFactory">
        /// The filter view model factory.
        /// </param>
        /// <param name="validatorFactory">
        /// The validator factory.
        /// </param>
        [ImportingConstructor]
        public EditableMechanicViewModel(
            IScreen screen,
            IFilterViewModelFactory filterViewModelFactory,
            IValidatorFactory validatorFactory)
            : base(screen)
        {
            _filterViewModelFactory = filterViewModelFactory;
            _validatorFactory = validatorFactory;
            var loader = _filterViewModelFactory.Create<DictionaryMechanicalIndicatorFilter, DictionaryMechanicalIndicatorDto>();

            loader.WhenAny(x => x.IsBusy, x => x.Value).Subscribe(isBusy => IsMechanicIndicatorValuesLoad = isBusy);
            loader.WhenAny(x => x.Result, x => x.Value)
                  .Where(res => res != null)
                  .Subscribe(res => DictionaryMechanicalIndicators = res);

            loader.InvokeCommand.Execute(null);
        }

        /// <summary>
        /// Gets the url path segment.
        /// </summary>
        public string UrlPathSegment
        {
            get { return "EditableMechanicViewModel"; }
        }

        /// <summary>
        /// Gets a value indicating whether is chemical indicator values load.
        /// </summary>
        public bool IsMechanicIndicatorValuesLoad
        {
            get { return _isMechanicIndicatorValuesLoad; }
            private set
            {
                this.RaiseAndSetIfChanged(ref _isMechanicIndicatorValuesLoad, value);
            }
        }

        /// <summary>
        /// Gets the chemical indicator values.
        /// </summary>
        public IList<DictionaryMechanicalIndicatorDto> DictionaryMechanicalIndicators
        {
            get { return _dictionaryMechanicalIndicators; }
            private set
            {
                this.RaiseAndSetIfChanged( ref _dictionaryMechanicalIndicators, value);
            }
        }

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

        /// <summary>
        /// The apply action.
        /// </summary>
        /// <param name="editObject">
        /// The edit object.
        /// </param>
        protected override void ApplyAction(ReactiveList<MechanicIndicatorValue> editObject)
        {
            editObject.DoForEach(item => item.CertificateQuality = item.CertificateQuality ?? _certificateQuality);
        }

        /// <summary>
        /// The can execute.
        /// </summary>
        /// <param name="validateObservable">
        /// The validate observable.
        /// </param>
        /// <returns>
        /// The <see cref="IObservable"/>.
        /// </returns>
        protected override IObservable<bool> CanExecute(IObservable<bool> validateObservable)
        {
            IValidator<MechanicIndicatorValue> validator = _validatorFactory.GetValidator<MechanicIndicatorValue>();

            EditableObject.ChangeTrackingEnabled = true;

            return
                EditableObject.ItemChanged.Select(_ => Unit.Default)
                              .Merge(EditableObject.Changed.Select(_ => Unit.Default))
                              .Select(_ => !EditableObject.Any(mechanicItem => !validator.Validate(mechanicItem).IsValid))
                              .StartWith(!EditableObject.Any(mechanicItem => !validator.Validate(mechanicItem).IsValid));
        }
    }
}
