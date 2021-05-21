// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EditablePlanReceiptOrderView.xaml.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the EditablePlanReceiptOrderView type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Components.PlanReceipOrderDomain.PlanReceiptOrder
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Reactive.Disposables;
    using System.Reactive.Linq;
    using System.Text.RegularExpressions;
    using System.Windows.Controls;

    using Buisness.Entities.CommonDomain;
    using Buisness.Filters;

    using Halfblood.Common;
    using Halfblood.Common.Log;

    using ReactiveUI;

    using UI.Components.Helpers;
    using UI.Entities.CommonDomain;
    using UI.Infrastructure;
    using UI.Infrastructure.ViewModels;
    using UI.Infrastructure.ViewModels.PlanReceiptOrderDomain;
    using UI.Resources;

    [PartCreationPolicy(CreationPolicy.NonShared)]
    [Export(typeof(IViewFor<IEditablePlanReceiptOrderViewModel>))]
    public partial class EditablePlanReceiptOrderView : UserControl, IViewFor<IEditablePlanReceiptOrderViewModel>
    {
        private readonly DisposableContext _disposableContext;

        ~EditablePlanReceiptOrderView()
        {
            LogManager.Log.Debug("EditablePlanReceiptOrderView IS DESTROYED");
        }

        public EditablePlanReceiptOrderView()
        {
            _disposableContext = new DisposableContext(this);
            InitializeComponent();
        }

        public IEditablePlanReceiptOrderViewModel ViewModel
        {
            get { return DataContext as IEditablePlanReceiptOrderViewModel; }
            set
            {
                DataContext = value;
                _disposableContext.Dispose();
                _disposableContext.Add(Binding());
                _disposableContext.Add(Disposable.Create(() => DataContext = null));
            }
        }

        object IViewFor.ViewModel
        {
            get { return this.ViewModel; }
            set { this.ViewModel = (IEditablePlanReceiptOrderViewModel)value; }
        }

        private IEnumerable<IDisposable> Binding()
        {
            yield return this.OneWayBind(ViewModel, vm => vm.IsBusy, v => v.ProgressRing.IsActive);

            yield return this.BindCommand(ViewModel, vm => vm.ApplyCommand, v => v.BtnApply);

            yield return
                ViewModel.WhenAny(x => x.EditState)
                    .Subscribe(state => AcatalogView.IsEnabled = !(state == EditState.Clone || state == EditState.Edit));

            yield return
                AcbUserContractor.Binding(
                    ViewModel.UserContractorFilterViewModel,
                    SetUserFilter,
                    isBusy => BusyUser.Visibility = isBusy.ToVisibility());

            yield return
                this.OneWayBind(
                    ViewModel,
                    vm => vm.GroundDocTypeOfDocumentFilterViewModel.Result,
                    v => v.CmbGroundDocType.ItemsSource);

            yield return
                this.OneWayBind(
                    ViewModel,
                    vm => vm.GroundReceiptTypeOfDocumentFilterViewModel.Result,
                    v => v.CmbGroundReceiptTypeOfDocument.ItemsSource);

            yield return
                this.OneWayBind(
                    ViewModel,
                    vm => vm.GasStationOilDepotFilterViewModel.Result,
                    v => v.CmbStore.ItemsSource);


            yield return this.OneWayBind(ViewModel, vm => vm.GetCatalogAccess.Result, v => v.AcatalogView.ItemsSource);
            yield return ViewModel.WhenAny(x => x.IsBusy, x => x.Value).Subscribe(isBusy => Root.IsEnabled = !isBusy);

            Title.Text = ViewModel.EditState == EditState.Insert ? CustomMessages.Creation : CustomMessages.Editing;
        }
        private void SetUserFilter(IFilterViewModel<UserFilter, UserDto> filterViewModel, string enteredText)
        {
            filterViewModel.Filter.TableNumber = string.Empty;
            filterViewModel.Filter.Lastname = string.Empty;
            ///NOTE: Устанавливаем каталог "Поставщики покупатели"
            filterViewModel.Filter.TypeCatalog = AgnlistCatalog.Contactor;

            if (Regex.IsMatch(enteredText, @"\d"))
            {
                AcbUserContractor.ValueMemberPath = HelperExtensions.GetName<User>(x => x.TableNumber);
                filterViewModel.Filter.TableNumber = enteredText;
            }
            else
            {
                AcbUserContractor.ValueMemberPath = HelperExtensions.GetName<User>(x => x.NameShort);
                filterViewModel.Filter.NameShort = enteredText;
            }
        }
    }
}