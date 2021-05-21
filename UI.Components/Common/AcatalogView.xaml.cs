// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AcatalogView.xaml.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Логика взаимодействия для Catalog.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Components.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reactive.Linq;
    using System.Windows;
    using System.Windows.Controls;

    using Buisness.Entities.CommonDomain;

    using ReactiveUI;

    using UI.Components.Helpers;
    using UI.Entities.CommonDomain;

    /// <summary>
    /// Логика взаимодействия для Catalog.xaml
    /// </summary>
    public partial class AcatalogView : UserControl
    {
        private readonly DisposableContext _disposableContext;

        /// <summary>
        /// The items source property.
        /// </summary>
        public static readonly DependencyProperty ItemsSourceProperty = DependencyProperty.Register("ItemsSource", typeof(IList<CatalogHierarchical>), typeof(AcatalogView), new PropertyMetadata(default(IList<CatalogHierarchical>)));

        /// <summary>
        /// The selected item property.
        /// </summary>
        public static readonly DependencyProperty SelectedItemProperty = DependencyProperty.Register("SelectedItem", typeof(Catalog), typeof(AcatalogView), new PropertyMetadata(default(Catalog)));

        /// <summary>
        /// Initializes a new instance of the <see cref="AcatalogView"/> class.
        /// </summary>
        public AcatalogView()
        {
            InitializeComponent();
            _disposableContext = new DisposableContext(this);
            Loaded += this.AcatalogViewLoaded;
        }

        /// <summary>
        /// Gets or sets the items source.
        /// </summary>
        public IList<CatalogHierarchical> ItemsSource
        {
            get { return (IList<CatalogHierarchical>)this.GetValue(ItemsSourceProperty); }
            set { this.SetValue(ItemsSourceProperty, value); }
        }

        /// <summary>
        /// Gets or sets the selected item.
        /// </summary>
        public Catalog SelectedItem
        {
            get { return (Catalog)this.GetValue(SelectedItemProperty); }
            set { this.SetValue(SelectedItemProperty, value); }
        }

        private IEnumerable<IDisposable> Binding()
        {
            yield return
                this.WhenAnyValue(x => x.ItemsSource).Where(x => x != null).Subscribe(
                    itemsSource =>
                        {
                            var collection = itemsSource.Union(itemsSource.SelectMany(x => x.Childs));

                            if (SelectedItem == null && collection.Any(x => x.IsAccess))
                            {
                                CatalogHierarchical selectCatalog = collection.First(x => x.IsAccess);
                                SelectedItem = new Catalog(selectCatalog.Rn) { Name = selectCatalog.Name };
                            }

                            TrvAcatalog.ItemsSource = itemsSource;
                        });

            yield return
                this.WhenAnyValue(x => x.TrvAcatalog.SelectedItem)
                    .Where(x => x != null && ((CatalogHierarchical)x).IsAccess)
                    .Subscribe(
                        selectedItem =>
                            {
                                var selecCatalog = (CatalogHierarchical)selectedItem;
                                SelectedItem = new Catalog(selecCatalog.Rn) { Name = selecCatalog.Name };
                            });
        }
        private void AcatalogViewLoaded(object sender, RoutedEventArgs e)
        {
            Loaded -= this.AcatalogViewLoaded;
            this._disposableContext.Add(this.Binding());
        }
    }
}
