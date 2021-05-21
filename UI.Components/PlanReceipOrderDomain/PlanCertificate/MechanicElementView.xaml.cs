// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MechanicElementView.xaml.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Interaction logic for MechanicElementView.xaml
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

    using Halfblood.Common.Mappers;

    using ReactiveUI;

    using UI.Components.Helpers;
    using UI.Entities.CertificateQualityDomain;
    using UI.Entities.CertificateQualityDomain.ManufacturersCertificateDomain;
    using UI.Infrastructure.ViewModels.PlanReceiptOrderDomain;

    /// <summary>
    /// Interaction logic for ChemicalElementView.xaml
    /// </summary>
    [Export(typeof(IViewFor<IEditableMechanicViewModel>))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class MechanicElementView : UserControl, IViewFor<IEditableMechanicViewModel>
    {
        private readonly DisposableContext _disposableContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChemicalElementView"/> class.
        /// </summary>
        public MechanicElementView()
        {
            _disposableContext = new DisposableContext(this);
            InitializeComponent();
        }

        /// <summary>
        /// Gets or sets the view model.
        /// </summary>
        public IEditableMechanicViewModel ViewModel
        {
            get { return DataContext as IEditableMechanicViewModel; }
            set
            {
                DataContext = value;
                _disposableContext.Dispose();
                _disposableContext.Add(Binding());
            }
        }

        /// <summary>
        /// Gets or sets the view model.
        /// </summary>
        object IViewFor.ViewModel
        {
            get { return this.ViewModel; }
            set { this.ViewModel = (IEditableMechanicViewModel)value; }
        }

        /// <summary>
        /// The binding.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        private IEnumerable<IDisposable> Binding()
        {
            yield return this.BindCommand(ViewModel, vm => vm.ApplyCommand, v => v.BtnApply);

            yield return
                ViewModel.WhenAny(x => x.DictionaryMechanicalIndicators, x => x.Value)
                    .Where(x => x != null)
                    .Select(
                        res =>
                        res.Select(
                            dictionaryMechanicalIndicator =>
                            new MechanicIndicatorValue
                                {
                                    MechanicalIndicator =
                                        dictionaryMechanicalIndicator
                                        .MapTo<DictionaryMechanicalIndicator>()
                                }))
                    .Subscribe(
                        x =>
                        {
                            LboxMechanic.SelectionChanged -= LboxChemicalOnSelectionChanged;

                            var collection = ViewModel.EditableObject.Union(x, new Comparer()).ToList();
                            LboxMechanic.ItemsSource = collection;

                            foreach (var mechanicIndicatorValue in ViewModel.EditableObject)
                            {
                                LboxMechanic.SelectedItems.Add(mechanicIndicatorValue);
                            }

                            LboxMechanic.SelectionChanged += LboxChemicalOnSelectionChanged;
                        });

            yield return
                ViewModel.WhenAny(x => x.IsMechanicIndicatorValuesLoad, x => x.Value)
                         .Subscribe(isBusy => LoadMechanic.IsActive = isBusy);
        }

        /// <summary>
        /// The list box chemical on selection changed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The args.
        /// </param>
        private void LboxChemicalOnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (MechanicIndicatorValue addedItem in e.AddedItems)
            {
                if (!this.ViewModel.EditableObject.Any(x => x.Equals(addedItem)))
                {
                    this.ViewModel.EditableObject.Add(addedItem);
                }
            }

            foreach (MechanicIndicatorValue addedItem in e.RemovedItems)
            {
                this.ViewModel.EditableObject.Remove(addedItem);
            }
        }

        /// <summary>
        /// The comparer.
        /// </summary>
        private class Comparer : IEqualityComparer<MechanicIndicatorValue>
        {
            public bool Equals(MechanicIndicatorValue x, MechanicIndicatorValue y)
            {
                if (x.MechanicalIndicator == null && y.MechanicalIndicator == null)
                {
                    return true;
                }

                if (x.MechanicalIndicator == null && y.MechanicalIndicator != null)
                {
                    return false;
                }

                return x.MechanicalIndicator.Equals(y.MechanicalIndicator);
            }

            public int GetHashCode(MechanicIndicatorValue obj)
            {
                return obj.MechanicalIndicator.GetHashCode();
            }
        }
    }
}
