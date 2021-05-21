// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EditablePersonalAccountView.xaml.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the EditPersonalAccountView type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Components.CertificateQualityDomain.ActSelectionProbeDomain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Windows.Controls;

    using ReactiveUI;
    using UI.Components.Helpers;
    using UI.Infrastructure;
    using UI.Resources;
    using System.Reactive.Disposables;
    using UI.Infrastructure.ViewModels.ActSelectionOfProbeDomain;
    using System.Reactive.Linq;
    using Halfblood.Common.Log;


    /// <summary>
    /// The editable personal account view.
    /// </summary>
    [Export(typeof(IViewFor<IEditableActSelectionOfProbeViewModel>))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class EditableActSelectionOfProbeView : UserControl, IViewFor<IEditableActSelectionOfProbeViewModel>
    {
        private readonly DisposableContext _disposableContext;

        ~EditableActSelectionOfProbeView()
        {
             LogManager.Log.Debug("EditableActSelectionOfProbeView IS DESTROYED");
        }

        public EditableActSelectionOfProbeView()
        {
            InitializeComponent();
            _disposableContext = new DisposableContext(this);
        }

        /// <summary>
        /// Gets or sets the view model.
        /// </summary>
        object IViewFor.ViewModel
        {
            get { return this.ViewModel; }
            set { this.ViewModel = (IEditableActSelectionOfProbeViewModel)value; }
        }

        /// <summary>
        /// Gets or sets the view model.
        /// </summary>
        public IEditableActSelectionOfProbeViewModel ViewModel
        {
            get { return this.DataContext as IEditableActSelectionOfProbeViewModel; }
            set
            {
                DataContext = value;
                _disposableContext.Dispose();
                _disposableContext.Add(this.Binding());
                _disposableContext.Add(Disposable.Create(() => DataContext = null));
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
            Title.Text = ViewModel.EditState == EditState.Insert ? CustomMessages.Creation : CustomMessages.Editing;

            yield return
                          ViewModel.WhenAny(x => x.EditState)
                              .Subscribe(state => AvCatalog.IsEnabled = state != EditState.Edit);

            yield return this.BindCommand(ViewModel, vm => vm.ApplyCommand, v => v.BtnApply);

            yield return this.OneWayBind(ViewModel, vm => vm.GetCatalogAccess.Result, v => v.AvCatalog.ItemsSource);


        }
    }
}