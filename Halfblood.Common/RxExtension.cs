// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RxExtension.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the RxExtension type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace System.Reactive.Linq
{
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Reactive.Concurrency;

    using ReactiveUI;

    /// <summary>
    /// The rx extension.
    /// </summary>
    public static class RxExtension
    {
        /// <summary>
        /// Gets or sets the UI safe scheduler.
        /// </summary>
        public static IScheduler UiSafeScheduler { get; set; }

        /// <summary>
        /// The catch.
        /// </summary>
        /// <param name="observable">
        /// The observable.
        /// </param>
        /// <param name="onError">
        /// The on error.
        /// </param>
        /// <typeparam name="TResult">
        /// type of result
        /// </typeparam>
        /// <returns>
        /// The <see cref="IObservable"/>.
        /// </returns>
        /// <exception cref="Exception">
        /// Unhandled exception
        /// </exception>
        public static IObservable<TResult> Catch<TResult>(
            this IObservable<TResult> observable, Action<Exception> onError)
        {
            return observable
                .ObserveOnUiSafeScheduler()
                .Catch(
                    new Func<Exception, IObservable<TResult>>(
                        exception =>
                        {
                            if (onError != null)
                            {
                                onError(exception);
                            }
                            else
                            {
                                throw exception;
                            }

                            return Observable.Empty<TResult>();
                        }));
        }

        /// <summary>
        /// The observe on UI safe scheduler.
        /// </summary>
        /// <param name="source">
        /// The source.
        /// </param>
        /// <typeparam name="TSource">
        /// type of source
        /// </typeparam>
        /// <returns>
        /// The <see cref="IObservable"/>.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// The scheduler is null
        /// </exception>
        public static IObservable<TSource> ObserveOnUiSafeScheduler<TSource>(this IObservable<TSource> source)
        {
            if (UiSafeScheduler == null)
            {
                throw new InvalidOperationException("UISafeScheduler has not been initialised");
            }

            return source.ObserveOn(UiSafeScheduler);
        }

        /// <summary>
        /// The for each.
        /// </summary>
        /// <param name="enumerable">
        /// The enumerable.
        /// </param>
        /// <param name="forEach">
        /// The for each.
        /// </param>
        /// <typeparam name="T">
        /// </typeparam>
        public static void DoForEach<T>(this IEnumerable<T> enumerable, Action<T> forEach)
        {
            foreach (T item in enumerable)
            {
                forEach(item);
            }
        }

        public static IObservable<TRet> WhenAny<TSender, TRet>(this TSender This,
                            Expression<Func<TSender, TRet>> property1)
        {
            return This.WhenAny(property1, x => x.Value);
        }
    }
}
