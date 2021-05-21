namespace UI.ProcessComponents.Interceptors
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Linq;
    using System.Reactive.Linq;
    using Buisness.Filters;
    using Halfblood.Common;
    using Halfblood.Common.Interceptors;
    using Halfblood.Common.Mappers;
    using ParusModelLite.PlanReceiptOrderDomain;
    using ReactiveUI;
    using UI.Entities.PlanReceiptOrderDomain;
    using UI.Infrastructure.Messages;
    using UI.Infrastructure.ViewModels;
    using UI.Infrastructure.ViewModels.Filters;
    using UI.Infrastructure.ViewModels.PlanReceiptOrderDomain;

    [Interceptor]
    public class PlanReceiptOrderViewModelInterceptor : InterceptorBase<IPlanReceiptOrderViewModel>
    {
        private readonly IMessageBus _messageBus;
        private readonly IFilterViewModel<PlanReceiptOrderFilter, PlanReceiptOrderLiteDto> _filerObject;
        private readonly DisposableObject _disposableObject = new DisposableObject();
        private readonly object _locker = new object();
        private WeakReference _weakReference;

        [ImportingConstructor]
        public PlanReceiptOrderViewModelInterceptor(
            IMessageBus messageBus,
            IFilterViewModelFactory filterViewModelFactory)
        {
            _messageBus = messageBus;
            _filerObject = filterViewModelFactory.Create<PlanReceiptOrderFilter, PlanReceiptOrderLiteDto>();
        }

        public override void Intercept(IPlanReceiptOrderViewModel interceptableObject)
        {
            lock (_locker) {
                _weakReference = new WeakReference(interceptableObject);
                
                _disposableObject.Dispose();
                _disposableObject.Add(Listen());
            }
        }

        private IEnumerable<IDisposable> Listen()
        {
            yield return _messageBus.Listen<AddedEntityMessage<PlanReceiptOrder>>().Subscribe(this.LetterIsComeback);

            yield return
                _messageBus.Listen<UpdateStateMessage<PlanReceiptOrder>>()
                    .Cast<IMessage>()
                    .Merge(_messageBus.Listen<UpdateStateMessage<PlanReceiptOrderPersonalAccount>>().Cast<IMessage>())
                    .Merge(_messageBus.Listen<UpdateStateMessage<PlanCertificate>>().Cast<IMessage>())
                    .Where(_ => _weakReference.IsAlive)
                    .Subscribe(_ => {
                        var target = (IPlanReceiptOrderViewModel)_weakReference.Target;
                        if (target != null && target.PlanReceiptOrderFilterViewModel.InvokeCommand.CanExecute(null))
                        {
                            target.PlanReceiptOrderFilterViewModel.InvokeCommand.Execute(null);
                        }
                    });

            yield return _messageBus.Listen<UpdatedEntityMessage<PlanReceiptOrder>>().Subscribe(LetterIsComeback);
        }
        private void LetterIsComeback(UpdatedEntityMessage<PlanReceiptOrder> updatedEntityMessage)
        {
            var target = this.GetTarget();

            if (target == null) {
                return;
            }

            int index = 0;
            PlanReceiptOrderLiteDto oldItem =
                target.PlanReceiptOrderFilterViewModel.Result.FirstOrDefault(
                    x => x.Rn == updatedEntityMessage.Entity.Rn);
            PlanReceiptOrderLiteDto insetingItem = GetDto(updatedEntityMessage.Entity.Rn)
                                                   ?? updatedEntityMessage.Entity.MapTo<PlanReceiptOrderLiteDto>();
            if (oldItem != null) {
                index = target.PlanReceiptOrderFilterViewModel.Result.IndexOf(oldItem);
                target.PlanReceiptOrderFilterViewModel.Result.Remove(oldItem);
            }

            target.PlanReceiptOrderFilterViewModel.Result.Insert(index, insetingItem);
            target.SelectedPlanReceiptOrder = insetingItem;
        }
        private void LetterIsComeback(AddedEntityMessage<PlanReceiptOrder> addedEntityMessage)
        {
            var target = GetTarget();

            if (target == null) {
                return;
            }

            PlanReceiptOrderLiteDto insetingItem = GetDto(addedEntityMessage.Entity.Rn)
                                                   ?? addedEntityMessage.Entity.MapTo<PlanReceiptOrderLiteDto>();
            target.PlanReceiptOrderFilterViewModel.Result.Insert(0, insetingItem);
            target.SelectedPlanReceiptOrder = insetingItem;
        }
        private PlanReceiptOrderLiteDto GetDto(long rn)
        {
            _filerObject.Filter.Rn = rn;
            _filerObject.Wait();
            return _filerObject.Result.FirstOrDefault();
        }
        private IPlanReceiptOrderViewModel GetTarget()
        {
            lock (_locker) {
                if (_weakReference != null && _weakReference.IsAlive) {
                    return (IPlanReceiptOrderViewModel)_weakReference.Target;
                }
            }

            return null;
        }
    }
}
