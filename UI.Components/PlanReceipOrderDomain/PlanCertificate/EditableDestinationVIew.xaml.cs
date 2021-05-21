// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EditableDestinationView.xaml.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Логика взаимодействия для EditablePassView.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Components.PlanReceipOrderDomain.PlanCertificate
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.ComponentModel.Composition;
    using System.Linq;
    using System.Windows.Controls;
    using System.Windows.Input;

    using Halfblood.Common.Mappers;

    using ReactiveUI;

    using Helpers;
    using UI.Entities.CertificateQualityDomain;
    using UI.Entities.CertificateQualityDomain.ManufacturersCertificateDomain;
    using UI.Infrastructure.ViewModels.PlanReceiptOrderDomain;
    using KeyEventArgs = System.Windows.Input.KeyEventArgs;

    /// <summary>
    /// Логика взаимодействия для EditablePassView.xaml
    /// </summary>
    [Export(typeof(IViewFor<IEditableDestinationViewModel>))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class EditableDestinationView : UserControl, IViewFor<IEditableDestinationViewModel>, INotifyPropertyChanged
    {
        #region private fields
        private readonly DisposableContext _disposableContext;
        private DragAndDropHelper<DictionaryPass> _drag;
        private DragAndDropHelper<Destination> _dragDic;
        private IList<DictionaryPass> _dictionaryPasses;
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="EditableDestinationView"/> class.
        /// </summary>
        public EditableDestinationView()
        {
            _disposableContext = new DisposableContext(this);
            InitializeComponent();
        }

        /// <summary>
        /// The property changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets the drag dictionary.
        /// </summary>
        public DragAndDropHelper<Destination> DragDictionary
        {
            get
            {
                return this._dragDic
                       ?? (this._dragDic =
                           new DragAndDropHelper<Destination>(
                               destination =>
                               {
                                   ViewModel.EditableObject.Remove(destination);
                                   DictionaryPasses.Add(destination.DictionaryPass);
                               }));
            }
        }

        /// <summary>
        /// Gets the drag.
        /// </summary>
        public DragAndDropHelper<DictionaryPass> Drag
        {
            get
            {
                return this._drag
                       ?? (this._drag =
                           new DragAndDropHelper<DictionaryPass>(
                               pass =>
                               {
                                   DictionaryPasses.Remove(pass);

                                   var x = new Destination { DictionaryPass = pass };
                                   this.ViewModel.EditableObject.Add(x);
                                   LbxDestinations.SelectedItem = x;
                               }));
            }
        }

        /// <summary>
        /// Gets or sets the dictionary passes.
        /// </summary>
        public IList<DictionaryPass> DictionaryPasses
        {
            get { return this._dictionaryPasses; }
            set
            {
                this._dictionaryPasses = value;
                OnPropertyChanged("DictionaryPasses");
            }
        }

        /// <summary>
        /// Gets or sets the view model.
        /// </summary>
        public IEditableDestinationViewModel ViewModel
        {
            get { return this.DataContext as IEditableDestinationViewModel; }
            set
            {
                this.DataContext = value;
                this._disposableContext.Dispose();
                this._disposableContext.Add(this.Binding());
            }
        }



        /// <summary>
        /// Gets or sets the view model.
        /// </summary>
        object IViewFor.ViewModel
        {
            get { return this.ViewModel; }
            set { this.ViewModel = (IEditableDestinationViewModel)value; }
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
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// The binding.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        private IEnumerable<IDisposable> Binding()
        {
            yield return ViewModel.WhenAny(x => x.DictionaryPassFilterViewModel.Result, x => x.Value).Subscribe(list =>
                {
                    if (list == null)
                    {
                        return;
                    }

                    foreach (var elem1 in (from elem in ViewModel.EditableObject
                                           from elem1 in list
                                           where elem.DictionaryPass.Rn == elem1.Rn
                                           select elem1).ToArray())
                    {
                        list.Remove(elem1);
                    }

                    DictionaryPasses = new ObservableCollection<DictionaryPass>(list.MapTo<DictionaryPass>());
                });


            yield return ViewModel.WhenAny(vm => vm.DictionaryPassFilterViewModel.IsBusy, x => x.Value).Subscribe(x =>
                {
                    BusyIndicator.IsActive = x;
                });
            yield return this.BindCommand(ViewModel, vm => vm.ApplyCommand, v => v.BtnApply);
        }

        /// <summary>
        /// The list box pass on key down.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The args.
        /// </param>
        private void LbxPassOnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                foreach (var elem in LbxDestinations.SelectedItems.Cast<Destination>().ToList())
                {
                    ViewModel.EditableObject.Remove(elem);
                    DictionaryPasses.Add(elem.DictionaryPass);
                }
            }
        }

        private void BtnApply_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }
    }
}
