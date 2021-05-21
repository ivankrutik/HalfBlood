namespace UI.Components.CuttingOrderDomain.CuttingOrderMove
{
    using System.ComponentModel.Composition;
    using System.Windows.Controls;
    using ReactiveUI;
    using Infrastructure.ViewModels.CuttingOrderDomain;
    using UI.Components.Helpers;
    using System;
    using System.Collections.Generic;
    using System.Reactive.Linq;
    
    /// <summary>
    /// Логика взаимодействия для CuttingOrderMoveView.xaml
    /// </summary>
    [Export(typeof(IViewFor<ICuttingOrderMoveViewModel>))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class CuttingOrderMoveView 
        : UserControl, IViewFor<ICuttingOrderMoveViewModel>
    {
        #region private fields

        private readonly DisposableContext _disposableContext;
        
        #endregion

        public CuttingOrderMoveView()
        {
            InitializeComponent();
            _disposableContext = new DisposableContext(this);
        }

        /// <summary>
        /// Gets or sets the view model.
        /// </summary>
        public ICuttingOrderMoveViewModel ViewModel
        {
            get { return DataContext as ICuttingOrderMoveViewModel; }
            set
            {
                DataContext = value;
                _disposableContext.Dispose();
                _disposableContext.Add(Binding());
            }
        }

        
        // <summary>
        /// Gets or sets the view model.
        /// </summary>
        object IViewFor.ViewModel
        {
            get { return this.ViewModel; }
            set { this.ViewModel = (ICuttingOrderMoveViewModel)value; }
        }

        private IEnumerable<IDisposable> Binding()
        {
            this.Bind(
                   this.ViewModel, vm => vm.SelectedCuttingOrderMove, v => v.DtGridCuttingOrderMoves.SelectedItem);

            yield return
               this.OneWayBind(
                   this.ViewModel, vm => vm.CuttingOrderMoveFilterViewModel.Result, v => v.DtGridCuttingOrderMoves.ItemsSource);

            yield return
               this.OneWayBind(
                   this.ViewModel, vm => vm.CuttingOrderMoveFilterViewModel.IsBusy, v => v.BusyIndicator.IsActive);

            yield return
                ViewModel.WhenAny(x => x.CuttingOrderMoveFilterViewModel.Result, x => x.Value)
                          .Where(res => res != null && res.Count > 0)
                          .Subscribe(_ => DtGridCuttingOrderMoves.SelectedIndex = 0);
        }


    }
}
