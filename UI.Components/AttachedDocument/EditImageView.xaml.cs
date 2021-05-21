// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EditImageView.xaml.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Interaction logic for EditImageView.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Components.AttachedDocument
{
    using System.ComponentModel.Composition;
    using System.Reactive.Disposables;
    using System.Windows.Controls;

    using Halfblood.Common.Log;

    using ReactiveUI;

    using UI.Components.Helpers;
    using UI.Infrastructure.ViewModels.AttachedDocumentDomain;

    /// <summary>
    /// Interaction logic for EditImageView.xaml
    /// </summary>
    [Export(typeof(IViewFor<IEditImageViewModel>))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class EditImageView : UserControl, IViewFor<IEditImageViewModel>
    {
        private readonly DisposableContext _disposableContext;

        ~EditImageView()
        {
            LogManager.Log.Debug("EditImageView IS DESTROYED");
        }

        public EditImageView()
        {
            _disposableContext = new DisposableContext(this);
            InitializeComponent();
        }

        public IEditImageViewModel ViewModel
        {
            get { return DataContext as IEditImageViewModel; }
            set
            {
                DataContext = value;
                _disposableContext.Dispose();
               _disposableContext.Add(Disposable.Create(() => DataContext = null));
            }
        }

        object IViewFor.ViewModel
        {
            get { return this.ViewModel; }
            set { this.ViewModel = (IEditImageViewModel)value; }
        }
    }
}
