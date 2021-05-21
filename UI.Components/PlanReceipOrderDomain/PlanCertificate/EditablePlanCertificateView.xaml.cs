// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EditablePlanCertificateView.xaml.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the EditablePlanCertificateView type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Components.PlanReceipOrderDomain.PlanCertificate
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Reactive.Disposables;
    using System.Reactive.Linq;
    using System.Text.RegularExpressions;
    using System.Windows;
    using System.Windows.Controls;

    using Buisness.Entities.CommonDomain;
    using Buisness.Entities.NomenclatorDomain;
    using Buisness.Filters;

    using Halfblood.Common;
    using Halfblood.Common.Log;

    using MaterialsSearch.Search.SearchObject;
    using MaterialsSearch.Utils;

    using ReactiveUI;

    using UI.Components.Helpers;
    using UI.Entities.CommonDomain;
    using UI.Infrastructure;
    using UI.Infrastructure.ViewModels;
    using UI.Infrastructure.ViewModels.PlanReceiptOrderDomain;
    using UI.Resources;

    [Export(typeof(IViewFor<IEditablePlanCertificateViewModel>))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class EditablePlanCertificateView : UserControl, IViewFor<IEditablePlanCertificateViewModel>
    {
        private readonly DisposableContext _disposableContext;

        ~EditablePlanCertificateView()
        {
            LogManager.Log.Debug("EditablePlanCertificateView IS DESTROYED");
        }

        public EditablePlanCertificateView()
        {
            _disposableContext = new DisposableContext(this);
            InitializeComponent();
        }

        public IEditablePlanCertificateViewModel ViewModel
        {
            get { return DataContext as IEditablePlanCertificateViewModel; }
            set
            {
                DataContext = value;
                _disposableContext.Dispose();
                _disposableContext.Add(Binding());
                _disposableContext.Add(Disposable.Create(() => DataContext = null));
                _disposableContext.Add(Disposable.Create(() => AttachDocumentEntityView.ViewModel = null));
            }
        }

        object IViewFor.ViewModel
        {
            get { return this.ViewModel; }
            set { this.ViewModel = (IEditablePlanCertificateViewModel)value; }
        }

        private IEnumerable<IDisposable> Binding()
        {
            switch (ViewModel.EditState)
            {
                case EditState.Insert: { Title.Text = CustomMessages.Creation; break; }
                case EditState.Edit: { Title.Text = CustomMessages.Editing; break; }
                case EditState.Clone: { Title.Text = CustomMessages.Copy; break; }
            }

            yield return ViewModel.WhenAny(x => x.EditState).Subscribe(
                state =>
                {
                    if (state == EditState.Clone || state == EditState.Edit)
                    {
                        AcatalogView.IsEnabled = false;
                    }
                    else
                    {
                        AcatalogView.IsEnabled = true;
                    }
                });

            yield return
                AcbGostMarka.Binding(
                    ViewModel.GostCastFilterViewModel,
                    (model, s) => model.Filter.GostMarka = s,
                    isBusy => BusyGostCast.Visibility = isBusy.ToVisibility());

            yield return
                AcbGostMix.Binding(
                    ViewModel.GostMixFilterViewModel,
                    (model, s) => model.Filter.GostMix = s,
                    isBusy => BusyGostMix.Visibility = isBusy.ToVisibility());

            yield return
                AcbMarka.Binding(
                    ViewModel.MarkaFilterViewModel,
                    (model, s) => model.Filter.Marka = s,
                    isBusy => BusyMarka.Visibility = isBusy.ToVisibility());

            yield return
                AcbMix.Binding(
                    ViewModel.MixFilterViewModel,
                    (model, s) => model.Filter.Mix = s,
                    isBusy => BusyMix.Visibility = isBusy.ToVisibility());

            yield return
                ReatorFactory.Binding(
                    ViewModel.UserFilterViewModel,
                    SetUserFilter,
                    isBusy => BusyReatorFactory.Visibility = isBusy.ToVisibility(),
                    3);

            yield return
                AcbNomenclatureNumberStore.Binding(
                    this.ViewModel.StorekeeperModificationFilterViewModel,
                    SetNnStoreFilter,
                    isBusy => IndicatorStorekeeper.Visibility = isBusy.ToVisibility(),
                    3);

            yield return
                this.OneWayBind(
                    this.ViewModel,
                    vm => vm.TaxBands,
                    v => v.ComboBoxTaxBand.ItemsSource);

            yield return
                this.OneWayBind(this.ViewModel, vm => vm.EditableObject.TaxBand, v => v.ComboBoxTaxBand.SelectedItem);

            yield return
                this.OneWayBind(
                    this.ViewModel,
                    vm => vm.UnitOfMeasures,
                    v => v.ComboBoxUnitOfMeasure.ItemsSource);

            yield return
                this.OneWayBind(
                    this.ViewModel,
                    vm => vm.NameOfCurrencies,
                    v => v.ComboBoxNameOfCurrency.ItemsSource);

            yield return this.Bind(this.ViewModel, vm => vm.EditableObject.CountByDocument, v => v.Count.Text);

            yield return this.ViewModel.WhenAny(x => x.SelectedNomenclatureNumber, x => x.Value).Subscribe(
                x =>
                {
                    this.Meas.Text = x == null || x.DicmuntUmeasMain == null
                                         ? string.Empty
                                         : x.DicmuntUmeasMain.MEASMNEMO;
                });

            yield return this.ViewModel.WhenAny(x => x.SelectedNomenclatureNumber, x => x.Value).Subscribe(
                x =>
                {
                    this.MeasAlt.Text = x == null || x.DicmuntUmeasAlt == null
                                            ? string.Empty
                                            : x.DicmuntUmeasAlt.MEASMNEMO;
                });

            yield return
                this.OneWayBind(
                    this.ViewModel,
                    vm => vm.GetCatalogAccess.Result,
                    v => v.AcatalogView.ItemsSource);

            yield return
                this.ViewModel.CertificateQualityViewModel.WhenAny(x => x.IsBusy, y => y.Value)
                    .Subscribe(
                        isBusy =>
                        {
                            Root.IsEnabled = !isBusy;
                            BusyIndicator.IsActive = isBusy;
                        });

            yield return this.ViewModel.WhenAnyValue(x => x.IsBusy).Subscribe(
                isBusy =>
                {
                    Root.IsEnabled = !isBusy;
                    BusyIndicator.IsActive = isBusy;
                });

            yield return this.BindCommand(ViewModel, vm => vm.ApplyCommand, v => v.BtnApply);

            yield return
                this.BindCommand(ViewModel, vm => vm.PreparingForEditDestinationCommand, v => v.EditDestinationCommand);

            yield return
                this.BindCommand(
                    ViewModel,
                    vm => vm.PreparingForEditChemicalIndicatorValuesCommand,
                    v => v.EditChemicalIndicatorValuesCommand);

            yield return
                this.BindCommand(
                    ViewModel,
                    vm => vm.PreparingForEditMechanicIndicatorValuesCommand,
                    v => v.EditMechanicIndicatorValuesCommand);

            yield return this.BindCommand(ViewModel, vm => vm.PreparingForEditPassCommand, v => v.EditPassCommand);
            yield return this.OneWayBind(ViewModel, vm => vm.Document, v => v.AttachDocumentEntityView.ViewModel);
            yield return
                ViewModel.EditableObject.WhenAnyValue(x => x.CountByDocument)
                    .Subscribe(x => ViewModel.EditableObject.CountFact = x);
            
        }
        private void SetUserFilter(IFilterViewModel<UserFilter, UserDto> filterViewModel, string enteredText)
        {
            filterViewModel.Filter.TableNumber = string.Empty;
            filterViewModel.Filter.Lastname = string.Empty;

            if (Regex.IsMatch(enteredText, @"\d"))
            {
                ReatorFactory.ValueMemberPath = HelperExtensions.GetName<User>(x => x.TableNumber);
                filterViewModel.Filter.TableNumber = enteredText;
            }
            else
            {
                ReatorFactory.ValueMemberPath = HelperExtensions.GetName<User>(x => x.OrganizationName);
                filterViewModel.Filter.OrganizationName = enteredText;
            }
        }
        private void SetNnStoreFilter(
            IFilterViewModel<NomenclatureNumberModificationFilter, NomenclatureNumberModificationDto> filterViewModel,
            AutoCompleteBox autoCompleteBox,
            string enteredText)
        {
            filterViewModel.Filter.Code = string.Empty;
            filterViewModel.Filter.Name = string.Empty;

            if (Regex.IsMatch(enteredText, @"\d"))
            {
                autoCompleteBox.ValueMemberPath = HelperExtensions.GetName<NomenclatureNumberModificationDto>(x => x.Code);
                filterViewModel.Filter.Code = enteredText;
            }
            else
            {
                autoCompleteBox.ValueMemberPath = HelperExtensions.GetName<NomenclatureNumberModificationDto>(x => x.Name);
                filterViewModel.Filter.Name = enteredText;
            }
        }
        private void btnGet_OnClick(object sender, RoutedEventArgs e)
        {
            ViewModel.CertificateQualityViewModel.SetFilter(new CertificateQualityFilter { Take = 1, NomenclatureNumber = new NomenclatureNumberFilter { Code = ViewModel.EditableObject.ModificationNomenclature.Code } });
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var mat =
                MaterialsUtils.GetMaterial(
                    new InputParameters
                    {
                        Search_Data =
                            new SearchData
                            {
                                Type = SearchType.stSortament,
                                Marka = AcbMarka.Text,
                                GostMarka = AcbGostMarka.Text,
                                GostSort = AcbGostMix.Text,
                                Tiporazmer = StandardSize.Text,
                                Forma = AcbMix.Text,
                            }
                    },
                    MaterialsConsts.connectDb.Main);

            if (mat == null)
            {
                return;
            }

            var m = MaterialsUtils.GetSortamentExInfo(Convert.ToInt32(mat.Bold_id));
            var material = MaterialsUtils.MaskMaterial(m.Material);
            AcbMarka.Text = material;
            AcbGostMarka.Text = m.GOST_MAT;
            AcbGostMix.Text = m.GOST_SORT;
            StandardSize.Text = m.Typosize;
            AcbMix.Text = m.Shape;
            TxbFullRepresentation.Text = m.Name;
        }
    }
}