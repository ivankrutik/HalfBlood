// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BindingHelper.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the BindingHelper type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Components.Helpers
{
    using System;
    using System.Reactive.Linq;
    using System.Windows.Controls;

    using Halfblood.Common;

    using ReactiveUI;

    using UI.Infrastructure.ViewModels;

    /// <summary>
    /// The binding helper.
    /// </summary>
    public static class BindingHelper
    {
        public static IDisposable Binding<TFilter, TObject>(
            this AutoCompleteBox acb,
            IFilterViewModel<TFilter, TObject> filterViewModel,
            Action<IFilterViewModel<TFilter, TObject>, AutoCompleteBox, string> action = null,
            Action<bool> busy = null,
            int startWith = 1)
        {
            var diposableObject = new DisposableObject();

            diposableObject.Add(
                acb.WhenAny(x => x.SearchText, x => x.Value)
                    .Do(_ => filterViewModel.Abort())
                    .Throttle(TimeSpan.FromSeconds(1))
                    .Where(text => !string.IsNullOrWhiteSpace(text))
                    .Where(text => text.Length >= startWith)
                    .ObserveOnUiSafeScheduler()
                    .Do(
                        text =>
                        {
                            if (action != null)
                            {
                                action(filterViewModel, acb, string.Concat(text, "*"));
                            }
                        }).Subscribe(_ =>
                                    {
                                        if (filterViewModel.Result != null)
                                        {
                                            filterViewModel.Result.Clear();
                                        }

                                        filterViewModel.InvokeCommand.Execute(null);
                                    }));

            if (busy != null)
            {
                diposableObject.Add(filterViewModel.WhenAnyValue(x => x.IsBusy).Subscribe(busy));
            }

            diposableObject.Add(
                filterViewModel.WhenAny(x => x.Result, x => x.Value)
                               .Where(x => x != null && x.Count > 0)
                               .ObserveOnUiSafeScheduler()
                               .Subscribe(
                                   result =>
                                   {
                                       acb.ItemsSource = result;
                                       if (acb.IsKeyboardFocusWithin)
                                       {
                                           acb.IsDropDownOpen = true;
                                       }
                                   }));

            return diposableObject;
        }

        public static IDisposable Binding<TFilter, TObject>(
            this AutoCompleteBox acb,
            IFilterViewModel<TFilter, TObject> filterViewModel,
            Action<IFilterViewModel<TFilter, TObject>, string> action = null,
            Action<bool> busy = null,
            int startWith = 1)
        {
            var disposableObject = new DisposableObject();

            var searchTextEntered = acb.WhenAny(x => x.SearchText, x => x.Value)
                    .Do(_ => filterViewModel.Abort())
                    .Throttle(TimeSpan.FromSeconds(1))
                    .Where(text => !string.IsNullOrWhiteSpace(text))
                    .Where(text => text.Length >= startWith)
                    .ObserveOnUiSafeScheduler()
                    .Do(text =>
                        {
                            if (action != null)
                            {
                                action(filterViewModel, string.Concat(text, "*"));
                            }
                        });

            disposableObject.Add(
                searchTextEntered.Subscribe(
                    _ =>
                        {
                            if (filterViewModel.Result != null)
                            {
                                filterViewModel.Result.Clear();
                            }

                            filterViewModel.InvokeCommand.Execute(null);
                        }));

            var loadCompleted = filterViewModel.WhenAny(x => x.Result, x => x.Value)
                .Where(x => x != null && x.Count > 0);

            disposableObject.Add(loadCompleted.ObserveOnUiSafeScheduler().Subscribe(
                result =>
                    {
                        acb.ItemsSource = result;
                        if (acb.IsKeyboardFocusWithin)
                        {
                            acb.IsDropDownOpen = true;
                        }
                    }));

            if (busy != null)
            {
                disposableObject.Add(filterViewModel.WhenAnyValue(x => x.IsBusy).Subscribe(busy));
            }

            return disposableObject;
        }
    }
}
