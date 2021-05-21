// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ChemicalElementView.xaml.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Interaction logic for ChemicalElementView.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Components.PlanReceipOrderDomain.PlanCertificate
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Linq;
    using System.Reactive.Linq;
    using System.Windows.Controls;

    using Halfblood.Common.Log;
    using Halfblood.Common.Mappers;

    using ReactiveUI;

    using UI.Components.Helpers;
    using UI.Entities.CertificateQualityDomain;
    using UI.Entities.CertificateQualityDomain.ManufacturersCertificateDomain;
    using UI.Infrastructure.ViewModels.PlanReceiptOrderDomain;

    /// <summary>
    /// Interaction logic for ChemicalElementView.xaml
    /// </summary>
    [Export(typeof(IViewFor<IEditableChemicalViewModel>))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class ChemicalElementView : UserControl, IViewFor<IEditableChemicalViewModel>
    {
        private readonly DisposableContext _disposableContext;

        ~ChemicalElementView()
        {
            LogManager.Log.Debug("ChemicalElementView is DESTROYED");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ChemicalElementView"/> class.
        /// </summary>
        public ChemicalElementView()
        {
            _disposableContext = new DisposableContext(this);
            InitializeComponent();
        }

        /// <summary>
        /// Gets or sets the view model.
        /// </summary>
        public IEditableChemicalViewModel ViewModel
        {
            get { return DataContext as IEditableChemicalViewModel; }
            set
            {
                DataContext = value;
                _disposableContext.Dispose();
                _disposableContext.Add(Binding());
            }
        }

        object IViewFor.ViewModel
        {
            get { return this.ViewModel; }
            set { this.ViewModel = (IEditableChemicalViewModel)value; }
        }

        private IEnumerable<IDisposable> Binding()
        {
            yield return this.BindCommand(ViewModel, vm => vm.ApplyCommand, v => v.BtnApply);
            yield return ViewModel.WhenAny(x => x.DictionaryChemicalIndicators, x => x.Value)
                .Where(x => x != null)
                .Select(res => res.Select(dictionaryChemicalIndicator => new ChemicalIndicatorValue { DictChemicalIndicator = dictionaryChemicalIndicator.MapTo<DictionaryChemicalIndicator>() }))
                .Subscribe(x =>
                    {
                        LboxChemical.SelectionChanged -= LboxChemicalOnSelectionChanged;

                        var collection = ViewModel.EditableObject.Union(x, new Comparer()).ToList();
                        LboxChemical.ItemsSource = collection;

                        foreach (var chemicalIndicatorValue in ViewModel.EditableObject)
                        {
                            LboxChemical.SelectedItems.Add(chemicalIndicatorValue);
                        }

                        LboxChemical.SelectionChanged += LboxChemicalOnSelectionChanged;
                    });

            yield return
                ViewModel.WhenAny(x => x.IsChemicalIndicatorValuesLoad, x => x.Value)
                         .Subscribe(isBusy => BusyIndicator.IsActive = isBusy);
        }
        private void LboxChemicalOnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (ChemicalIndicatorValue addedItem in e.AddedItems)
            {
                if (!this.ViewModel.EditableObject.Any(x => x.Equals(addedItem)))
                {
                    this.ViewModel.EditableObject.Add(addedItem);
                }
            }

            foreach (ChemicalIndicatorValue removedItem in e.RemovedItems)
            {
                this.ViewModel.EditableObject.Remove(removedItem);
            }
        }

        private class Comparer : IEqualityComparer<ChemicalIndicatorValue>
        {
            public bool Equals(ChemicalIndicatorValue x, ChemicalIndicatorValue y)
            {
                if (x.DictChemicalIndicator == null && y.DictChemicalIndicator == null)
                {
                    return true;
                }

                if (x.DictChemicalIndicator == null && y.DictChemicalIndicator != null)
                {
                    return false;
                }

                return x.DictChemicalIndicator.Equals(y.DictChemicalIndicator);
            }

            public int GetHashCode(ChemicalIndicatorValue obj)
            {
                return obj.DictChemicalIndicator.GetHashCode();
            }
        }
    }
}
