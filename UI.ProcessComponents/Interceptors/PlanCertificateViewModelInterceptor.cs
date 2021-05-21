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
    public class PlanCertificateViewModelInterceptor : InterceptorBase<IPlanCertificateViewModel>
    {
        private readonly IMessageBus _messageBus;
        private readonly
            IFilterViewModel<PlanReceiptOrderPersonalAccountFilter, PersonalAccountOfPlanReceiptOrderLiteDto>
            _filerObject;
        private readonly IFilterViewModel<PlanCertificateFilter, PlanCertificateLiteDto> _filterCertificate;
        private readonly DisposableObject _disposableObject = new DisposableObject();
        private readonly object _locker = new object();
        private WeakReference _weakReference;

        [ImportingConstructor]
        public PlanCertificateViewModelInterceptor(
            IMessageBus messageBus,
            IFilterViewModelFactory filterViewModelFactory)
        {
            _messageBus = messageBus;
            _filerObject =
                filterViewModelFactory
                    .Create<PlanReceiptOrderPersonalAccountFilter, PersonalAccountOfPlanReceiptOrderLiteDto>();
            _filterCertificate = filterViewModelFactory.Create<PlanCertificateFilter, PlanCertificateLiteDto>();
        }

        public override void Intercept(IPlanCertificateViewModel interceptableObject)
        {
            lock (_locker)
            {
                _weakReference = new WeakReference(interceptableObject);

                _disposableObject.Dispose();
                _disposableObject.Add(this.Listen());
            }
        }

        private IEnumerable<IDisposable> Listen()
        {
            yield return _messageBus.Listen<AddedEntityMessage<PlanReceiptOrderPersonalAccount>>().Subscribe(LetterIsComeback);
            yield return _messageBus.Listen<AddedEntityMessage<PlanCertificate>>().Subscribe(LetterIsComeback);
            yield return _messageBus.Listen<UpdatedEntityMessage<PlanCertificate>>().Subscribe(LetterIsComeback);
            yield return _messageBus.Listen<UpdatedEntityMessage<PlanReceiptOrderPersonalAccount>>().Subscribe(LetterIsComeback);
            yield return
                _messageBus.Listen<UpdateStateMessage<PlanReceiptOrderPersonalAccount>>()
                    .Cast<IMessage>()
                    .Merge(_messageBus.Listen<UpdateStateMessage<PlanCertificate>>().Cast<IMessage>())
                    .Merge(_messageBus.Listen<UpdateStateMessage<PlanReceiptOrder>>().Cast<IMessage>())
                    .Subscribe(msg => {
                        var target = GetTarget();

                        if (target != null)
                        {
                            if (target.PlanCertificateFilterViewModel.InvokeCommand.CanExecute(null))
                            {
                                target.PlanCertificateFilterViewModel.InvokeCommand.Execute(null);
                            }

                            if (target.PersonalAccountFilterViewModel.InvokeCommand.CanExecute(null))
                            {
                                target.PersonalAccountFilterViewModel.InvokeCommand.Execute(null);
                            }
                        }
                    });
        }
        private void LetterIsComeback(AddedEntityMessage<PlanReceiptOrderPersonalAccount> addedEntityMessage)
        {
            var target = this.GetTarget();

            if (target != null) {
                PersonalAccountOfPlanReceiptOrderLiteDto newItem = GetPersonalAccount(addedEntityMessage.Entity.Rn);
                PersonalAccountOfPlanReceiptOrderLiteDto insertingItem = 
                    newItem ?? addedEntityMessage.Entity.MapTo<PersonalAccountOfPlanReceiptOrderLiteDto>();
                target.PersonalAccountFilterViewModel.Result.Insert(0, insertingItem);
                target.SelectedPlanReceiptOrderPersonalAccount = insertingItem;
            }
        }
        private void LetterIsComeback(AddedEntityMessage<PlanCertificate> addedEntityMessage)
        {
            var target = this.GetTarget();

            if (target != null) {
                PlanCertificateLiteDto newItem = GetCertificate(addedEntityMessage.Entity.Rn);
                PlanCertificateLiteDto insertingItem =
                    newItem ?? addedEntityMessage.Entity.MapTo<PlanCertificateLiteDto>();
                target.PlanCertificateFilterViewModel.Result.Insert(0, insertingItem);
                target.SelectedPlanCertificate = insertingItem;
            }
        }
        private void LetterIsComeback(UpdatedEntityMessage<PlanReceiptOrderPersonalAccount> updatedEntityMessage)
        {
            var target = this.GetTarget();

            if (target == null) {
                return;
            }

            int index = 0;
            PersonalAccountOfPlanReceiptOrderLiteDto oldItem =
                target.PersonalAccountFilterViewModel.Result.FirstOrDefault(
                    x => x.Rn == updatedEntityMessage.Entity.Rn);
            PersonalAccountOfPlanReceiptOrderLiteDto newItem = this.GetPersonalAccount(updatedEntityMessage.Entity.Rn);
            if (oldItem != null)
            {
                index = target.PersonalAccountFilterViewModel.Result.IndexOf(oldItem);
                target.PersonalAccountFilterViewModel.Result.Remove(oldItem);
            }
            target.PersonalAccountFilterViewModel.Result.Insert(
                index,
                newItem ?? updatedEntityMessage.Entity.MapTo<PersonalAccountOfPlanReceiptOrderLiteDto>());
        }
        private void LetterIsComeback(UpdatedEntityMessage<PlanCertificate> updatedEntityMessage)
        {
            var target = this.GetTarget();

            if (target == null) {
                return;
            }

            int index = 0;
            PlanCertificateLiteDto oldItem =
                target.PlanCertificateFilterViewModel.Result.FirstOrDefault(
                    x => x.Rn == updatedEntityMessage.Entity.Rn);
            PlanCertificateLiteDto newItem = this.GetCertificate(updatedEntityMessage.Entity.Rn);
            if (oldItem != null) {
                index = target.PlanCertificateFilterViewModel.Result.IndexOf(oldItem);
                target.PlanCertificateFilterViewModel.Result.Remove(oldItem);
            }

            target.PlanCertificateFilterViewModel.Result.Insert(
                index,
                newItem ?? updatedEntityMessage.Entity.MapTo<PlanCertificateLiteDto>());
        }
        private PersonalAccountOfPlanReceiptOrderLiteDto GetPersonalAccount(long rn)
        {
            _filerObject.Filter.Rn = rn;
            _filerObject.Wait();
            return _filerObject.Result.FirstOrDefault();
        }
        private PlanCertificateLiteDto GetCertificate(long rn)
        {
            _filterCertificate.Filter.Rn = rn;
            _filterCertificate.Wait();
            return _filterCertificate.Result.FirstOrDefault();
        }
        private IPlanCertificateViewModel GetTarget()
        {
            lock (_locker) {
                if (_weakReference != null && _weakReference.IsAlive) {
                    return (IPlanCertificateViewModel)_weakReference.Target;
                }
            }

            return null;
        }
    }
}
