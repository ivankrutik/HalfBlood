// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EditableChemicalViewModel.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the EditableChemicalViewModel type.
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

    using Halfblood.Common.Log;

    using ReactiveUI;

    using UI.Entities.CertificateQualityDomain.ManufacturersCertificateDomain;
    using UI.Infrastructure.ViewModels.Filters;
    using UI.Infrastructure.ViewModels.PlanReceiptOrderDomain;
    using UI.ProcessComponents.EditViewModels;

    [Export(typeof(IEditableChemicalViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class EditableChemicalViewModel : EditableViewModelBase<ReactiveList<ChemicalIndicatorValue>>, IEditableChemicalViewModel
    {
        private readonly IValidatorFactory _validatorFactory;
        private bool _isDictionaryChemicalIndicatorValuesLoad;
        private IList<DictionaryChemicalIndicatorDto> _dictionaryChemicalIndicators;
        private CertificateQuality _certificateQuality;

        ~EditableChemicalViewModel()
        {
            LogManager.Log.Debug("EditableChemicalViewModel is DESTROYED");
        }

        [ImportingConstructor]
        public EditableChemicalViewModel(
            IScreen screen, 
            IFilterViewModelFactory filterViewModelFactory,
            IValidatorFactory validatorFactory)
            : base(screen)
        {
            _validatorFactory = validatorFactory;
            var loader =
                filterViewModelFactory.Create<DictionaryChemicalIndicatorFilter, DictionaryChemicalIndicatorDto>();

            loader.WhenAny(x => x.Result, x => x.Value)
                .Where(res => res != null)
                .Subscribe(res => DictionaryChemicalIndicators = res);

            loader.WhenAny(x => x.IsBusy, x => x.Value).Subscribe(isBusy => IsChemicalIndicatorValuesLoad = isBusy);
            loader.InvokeCommand.Execute(null);
        }

        public string UrlPathSegment
        {
            get { return "EditableChemicalViewModel"; }
        }
        public bool IsChemicalIndicatorValuesLoad
        {
            get { return _isDictionaryChemicalIndicatorValuesLoad; }
            private set
            {
                this.RaiseAndSetIfChanged(ref _isDictionaryChemicalIndicatorValuesLoad, value);
            }
        }
        public IList<DictionaryChemicalIndicatorDto> DictionaryChemicalIndicators
        {
            get { return _dictionaryChemicalIndicators; }
            private set
            {
                this.RaiseAndSetIfChanged(ref _dictionaryChemicalIndicators, value);
            }
        }

        public void SetCertificateQuality(CertificateQuality certificateQuality)
        {
            _certificateQuality = certificateQuality;
        }

        protected override void ApplyAction(ReactiveList<ChemicalIndicatorValue> editObject)
        {
            editObject.DoForEach(item => item.CertificateQuality = item.CertificateQuality ?? _certificateQuality);
        }
        protected override IObservable<bool> CanExecute(IObservable<bool> validateObservable)
        {
            IValidator<ChemicalIndicatorValue> validator = _validatorFactory.GetValidator<ChemicalIndicatorValue>();

            EditableObject.ChangeTrackingEnabled = true;

            return
                EditableObject.ItemChanged.Select(_ => Unit.Default)
                              .Merge(EditableObject.Changed.Select(_ => Unit.Default))
                              .Select(_ => !EditableObject.Any(chemicItem => !validator.Validate(chemicItem).IsValid))
                              .StartWith(!EditableObject.Any(chemicItem => !validator.Validate(chemicItem).IsValid));
        }
    }
}