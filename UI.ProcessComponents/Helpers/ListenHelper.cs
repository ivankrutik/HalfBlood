// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ListenHelper.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the ListenHelper type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.ProcessComponents.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reactive.Linq;

    using Halfblood.Common;
    using Halfblood.Common.Mappers;

    using ReactiveUI;

    using UI.Infrastructure.Messages;

    /// <summary>
    /// The listen helper.
    /// </summary>
    public static class ListenHelper
    {
        public static IDisposable ListenUpdatedMessage<TEntity, TConvertType>(
            this IMessageBus messageBus,
            IList<TConvertType> collection,
            Action<TConvertType> action = null)
            where TConvertType : IHasUid<long>
        {
            return ListenUpdatedMessage<TEntity>(
                messageBus,
                entity =>
                    {
                        var newLiteDto = entity.MapTo<TConvertType>();
                        var oldLiteDto = collection.FirstOrDefault(x => x.Rn == newLiteDto.Rn);

                        int index = collection.IndexOf(oldLiteDto);
                        collection.Remove(oldLiteDto);
                        collection.Insert(index, newLiteDto);

                        if (action != null)
                        {
                            action(newLiteDto);
                        }

                    });
        }

        public static IDisposable ListenUpdatedMessage<TEntity, TConvertType>(
            this IMessageBus messageBus,
            IObservable<IList<TConvertType>> observable,
            Action<TConvertType> action = null)
            where TConvertType : IHasUid<long>
        {
            var disposable = new DisposableObject();

            IList<TConvertType> collection = null;
            disposable.Add(observable.Subscribe(result => collection = result));

            disposable.Add(
                ListenUpdatedMessage<TEntity>(
                    messageBus,
                    entity =>
                        {
                            if (collection == null)
                            {
                                return;
                            }

                            var newLiteDto = entity.MapTo<TConvertType>();
                            var oldLiteDto = collection.FirstOrDefault(x => x.Rn == newLiteDto.Rn);

                            int index = collection.IndexOf(oldLiteDto);
                            collection.Remove(oldLiteDto);
                            collection.Insert(index, newLiteDto);

                            if (action != null)
                            {
                                action(newLiteDto);
                            }

                        }));

            return disposable;
        }

        public static IDisposable ListenUpdatedMessage<TEntity>(
            this IMessageBus messageBus,
            Action<TEntity> action = null)
        {
            return
                messageBus.Listen<UpdatedEntityMessage<TEntity>>()
                    .ObserveOnUiSafeScheduler()
                    .Where(msg => msg != null && msg.Entity != null)
                    .Subscribe(
                        msg =>
                        {
                            if (action != null)
                            {
                                action(msg.Entity);
                            }
                        });
        }

        public static IDisposable ListenAddedMessage<TEntity, TConvertEntity>(
            this IMessageBus messageBus, 
            IList<TConvertEntity> collection,
            Action<TConvertEntity> action = null)
        {
            return ListenAddedMessage<TEntity>(messageBus,
                entity =>
                    {
                        var newValue = entity.MapTo<TConvertEntity>();
                        collection.Insert(0, newValue);
                        if (action != null)
                        {
                            action(newValue);
                        }
                    });
        }

        public static IDisposable ListenAddedMessage<TEntity, TConvertEntity>(
            this IMessageBus messageBus,
            IObservable<IList<TConvertEntity>> observable,
            Action<TConvertEntity> action = null)
        {
            var disposable = new DisposableObject();

            IList<TConvertEntity> collection = null;
            disposable.Add(observable.Subscribe(result => collection = result));

            disposable.Add(
                ListenAddedMessage<TEntity>(
                    messageBus,
                    entity =>
                        {
                            var newValue = entity.MapTo<TConvertEntity>();
                            if (collection != null)
                            {
                                collection.Insert(0, newValue);
                            }

                            if (action != null)
                            {
                                action(newValue);
                            }
                        }));

            return disposable;
        }

        public static IDisposable ListenAddedMessage<TEntity>(
            this IMessageBus messageBus,
            Action<TEntity> action)
        {
            return
                messageBus.Listen<AddedEntityMessage<TEntity>>()
                    .ObserveOnUiSafeScheduler()
                    .Where(msg => msg != null && msg.Entity != null)
                    .Subscribe(
                        msg =>
                            {
                                if (action != null)
                                {
                                    action(msg.Entity);
                                }
                            });
        }
    }
}
