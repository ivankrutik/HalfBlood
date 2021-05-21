// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EditablePassView.xaml.cs" company="VZ">
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
    using System.Reactive.Linq;
    using System.Windows.Controls;
    using System.Windows.Input;

    using Halfblood.Common.Mappers;

    using ReactiveUI;

    using UI.Components.Helpers;
    using UI.Entities.CertificateQualityDomain;
    using UI.Entities.CertificateQualityDomain.ManufacturersCertificateDomain;
    using UI.Infrastructure.ViewModels.PlanReceiptOrderDomain;

    using KeyEventArgs = System.Windows.Input.KeyEventArgs;

    /// <summary>
    /// The editable pass view.
    /// </summary>
    [Export(typeof(IViewFor<IEditablePassViewModel>))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class EditablePassView : UserControl, IViewFor<IEditablePassViewModel>, INotifyPropertyChanged
    {
        #region private fields
        private readonly DisposableContext _disposableContext;
        private DragAndDropHelper<DictionaryPass> _drag;
        private DragAndDropHelper<Pass> _dragDic;
        private IList<DictionaryPass> _dictionaryPasses;
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="EditablePassView"/> class.
        /// </summary>
        public EditablePassView()
        {
            _disposableContext = new DisposableContext(this);
            InitializeComponent();
        }

        /// <summary>
        /// The property changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

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

                                   var x = new Pass { DictionaryPass = pass };
                                   this.ViewModel.EditableObject.Add(x);
                                   LbxPass.SelectedItem = x;
                               }));
            }
        }

        /// <summary>
        /// Gets the drag dictionary.
        /// </summary>
        public DragAndDropHelper<Pass> DragDictionary
        {
            get
            {
                return this._dragDic
                       ?? (this._dragDic =
                           new DragAndDropHelper<Pass>(
                               pass =>
                               {
                                   ViewModel.EditableObject.Remove(pass);
                                   DictionaryPasses.Add(pass.DictionaryPass);
                               }));
            }
        }

        /// <summary>
        /// Gets the dictionary passes.
        /// </summary>
        public IList<DictionaryPass> DictionaryPasses
        {
            get { return this._dictionaryPasses; }
            private set
            {
                this._dictionaryPasses = value;
                this.OnPropertyChanged("DictionaryPasses");
            }
        }

        /// <summary>
        /// Gets or sets the view model.
        /// </summary>
        public IEditablePassViewModel ViewModel
        {
            get { return this.DataContext as IEditablePassViewModel; }
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
            set { this.ViewModel = (IEditablePassViewModel)value; }
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
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        private IEnumerable<IDisposable> Binding()
        {
            yield return
                ViewModel.WhenAny(x => x.DictionaryPassFilterViewModel.Result, x => x.Value)
                    .ObserveOnUiSafeScheduler()
                    .Subscribe(
                        list =>
                            {
                                if (list == null)
                                {
                                    return;
                                }

                                foreach (var elem1 in
                                    (from elem in ViewModel.EditableObject
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
            yield return this.BindCommand(ViewModel, vm => vm.PrimeJustAsDestinationCommand, v => v.BtnCopyDestination);
        }

        /// <summary>
        /// The ListBox pass on key down.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The key event args.
        /// </param>
        private void LbxPassOnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                foreach (var elem in LbxPass.SelectedItems.Cast<Pass>().ToList())
                {
                    ViewModel.EditableObject.Remove(elem);
                    DictionaryPasses.Add(elem.DictionaryPass);
                }
            }
        }
    }
}
