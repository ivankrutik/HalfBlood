// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EditDepartmentOrderView.xaml.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Логика взаимодействия для EditDepartmentOrderView.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Components.DepartmentOrderDomain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Reactive.Linq;
    using System.Text.RegularExpressions;
    using System.Windows.Controls;

    using Buisness.Entities.CommonDomain;
    using Buisness.Filters;

    using Halfblood.Common;

    using ReactiveUI;

    using UI.Components.Helpers;
    using UI.Entities.CommonDomain;
    using UI.Infrastructure;
    using UI.Infrastructure.ViewModels;
    using UI.Infrastructure.ViewModels.DepartmentOrderDomain;

    [PartCreationPolicy(CreationPolicy.NonShared)]
    [Export(typeof(IViewFor<IEditDepartmentOrderViewModel>))]
    public partial class EditDepartmentOrderView : UserControl, IViewFor<IEditDepartmentOrderViewModel>
    {
        private readonly DisposableContext _disposableContext;

        public EditDepartmentOrderView()
        {
            _disposableContext = new DisposableContext(this);
            InitializeComponent();
        }

        public IEditDepartmentOrderViewModel ViewModel
        {
            get { return DataContext as IEditDepartmentOrderViewModel; }
            set
            {
                DataContext = value;
                _disposableContext.Dispose();
                _disposableContext.Add(Binding());
                _disposableContext.Add(Browser);
            }
        }

        object IViewFor.ViewModel
        {
            get { return this.ViewModel; }
            set { this.ViewModel = (IEditDepartmentOrderViewModel)value; }
        }

        private IEnumerable<IDisposable> Binding()
        {
            yield return this.OneWayBind(ViewModel, vm => vm.GetCatalogAccess.Result, v => v.AcatalogView.ItemsSource);

            yield return
                this.ViewModel.WhenAnyValue(x => x.SelectedCertificate)
                    .Where(item => item != null)
                    .Select(
                        item =>
                        string.Format(
                            @"http://kts.vz/MAT_POTR_WEB/wfm_Def_003.aspx?nn={0}&Extended=1",
                            item.NomerCertificate))
                    .Subscribe(navigateUrl => Browser.Navigate(navigateUrl));

            yield return
                this.OneWayBind(ViewModel, vm => vm.EditableObject.Comments, v => v.CommentsListBox.ItemsSource);

            yield return
                this.OneWayBind(
                    ViewModel,
                    vm => vm.EditableObject.Specifications,
                    v => v.CertificatesDataGrid.ItemsSource);

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
            AcbUserContractor.Binding(
                ViewModel.GoodsManagerFilterObject,
                SetGoodsMahagerFilter,
                isBusy => BusyUser.Visibility = isBusy.ToVisibility());
        }
        private void SetGoodsMahagerFilter(IFilterViewModel<GoodsManagerFilter, GoodsManagerDto> filterViewModel, string enteredText)
        {
            filterViewModel.Filter.Contractor.Firstname = string.Empty;
            filterViewModel.Filter.Contractor.Lastname = string.Empty;
       

            if (Regex.IsMatch(enteredText, @"\d"))
            {
                AcbUserContractor.ValueMemberPath = HelperExtensions.GetName<User>(x => x.TableNumber);
                filterViewModel.Filter.Contractor.TableNumber = enteredText;
            }
            else
            {
                AcbUserContractor.ValueMemberPath = HelperExtensions.GetName<User>(x => x.NameShort);
                filterViewModel.Filter.Contractor.NameShort = enteredText;
            }
        }
    }
}
