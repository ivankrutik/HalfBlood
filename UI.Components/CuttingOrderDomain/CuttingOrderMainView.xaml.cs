// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CuttingOrderMainView.xaml.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Логика взаимодействия для CuttingOrderMain.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Components.CuttingOrderDomain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.Composition;
    using System.Windows.Controls;
    using ReactiveUI;

    using UI.Components.Helpers;
    using UI.Infrastructure.ViewModels.CuttingOrderDomain;

    /// <summary>
    /// Логика взаимодействия для CuttingOrderMain.xaml
    /// </summary>
    [Export(typeof(IViewFor<ICuttingOrderMainViewModel>))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class CuttingOrderMainView
        : UserControl, IViewFor<ICuttingOrderMainViewModel>, INotifyPropertyChanged
    {
        private readonly DisposableContext _disposableContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="CuttingOrderMainView"/> class.
        /// </summary>
        public CuttingOrderMainView()
        {
            _disposableContext = new DisposableContext(this);
            InitializeComponent();
        }

        /// <summary>
        /// The property changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets or sets the view model.
        /// </summary>
        public ICuttingOrderMainViewModel ViewModel
        {
            get { return this.DataContext as ICuttingOrderMainViewModel; }
            set
            {
                this.DataContext = value;
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
            set { this.ViewModel = (ICuttingOrderMainViewModel)value; }
        }

        /// <summary>
        /// The on property changed.
        /// </summary>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /// <summary>
        /// The binding.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable{T}"/>.
        /// </returns>
        private IEnumerable<IDisposable> Binding()
        {
            yield return this.OneWayBind(ViewModel, vm => vm.CuttingOrderViewModel, v => v.CuttingOrderView.ViewModel);
            yield return this.OneWayBind(ViewModel, vm => vm.CuttingOrderViewModel, v => v.CuttingOrderFilterView.ViewModel);
        }
    }
}
