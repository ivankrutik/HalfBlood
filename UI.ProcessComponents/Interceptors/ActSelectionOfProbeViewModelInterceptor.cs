namespace UI.ProcessComponents.Interceptors
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Linq;
    using Buisness.Filters;
    using Halfblood.Common;
    using Halfblood.Common.Interceptors;
    using Halfblood.Common.Mappers;
    using ReactiveUI;
    using UI.Infrastructure.Messages;
    using UI.Infrastructure.ViewModels;
    using UI.Infrastructure.ViewModels.Filters;
    using ParusModelLite.CertificateQualityDomain.ActSelectionOfProbeDomain;
    using UI.Entities.CertificateQualityDomain.ActSelectionOfProbeDomain;
    using UI.Infrastructure.ViewModels.ActSelectionOfProbeDomain;

    [Interceptor]
    public class ActSelectionOfProbeViewModelInterceptor : InterceptorBase<IActSelectionOfProbeViewModel>
    {
        private readonly IMessageBus _messageBus;
        private readonly IFilterViewModel<ActSelectionOfProbeFilter, ActSelectionOfProbeLiteDto> _filerObject;
        private readonly IFilterViewModel<ActSelectionOfProbeDepartmentFilter, ActSelectionOfProbeDepartmentLiteDto> _filterActSelectionOfProbeDepartment;
        private readonly IFilterViewModel<ActSelectionOfProbeDepartmentRequirementFilter, ActSelectionOfProbeDepartmentRequirementLiteDto> _filterActSelectionOfProbeDepartmentRequirement;

        private readonly DisposableObject _disposableObject = new DisposableObject();
        private readonly object _locker = new object();
        private WeakReference _weakReference;

        [ImportingConstructor]
        public ActSelectionOfProbeViewModelInterceptor(
            IMessageBus messageBus,
            IFilterViewModelFactory filterViewModelFactory)
        {
            _messageBus = messageBus;
            _filerObject =
                filterViewModelFactory
                    .Create<ActSelectionOfProbeFilter, ActSelectionOfProbeLiteDto>();
            _filterActSelectionOfProbeDepartment = filterViewModelFactory.Create<ActSelectionOfProbeDepartmentFilter, ActSelectionOfProbeDepartmentLiteDto>();
            _filterActSelectionOfProbeDepartmentRequirement = filterViewModelFactory.Create<ActSelectionOfProbeDepartmentRequirementFilter, ActSelectionOfProbeDepartmentRequirementLiteDto>();
        }

        public override void Intercept(IActSelectionOfProbeViewModel interceptableObject)
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
            yield return _messageBus.Listen<AddedEntityMessage<ActSelectionOfProbe>>().Subscribe(LetterIsComeback);
            yield return _messageBus.Listen<AddedEntityMessage<ActSelectionOfProbeDepartment>>().Subscribe(LetterIsComeback);
            yield return _messageBus.Listen<AddedEntityMessage<ActSelectionOfProbeDepartmentRequirement>>().Subscribe(LetterIsComeback);

            yield return _messageBus.Listen<UpdatedEntityMessage<ActSelectionOfProbe>>().Subscribe(LetterIsComeback);
            yield return _messageBus.Listen<UpdatedEntityMessage<ActSelectionOfProbeDepartment>>().Subscribe(LetterIsComeback);
            yield return _messageBus.Listen<UpdatedEntityMessage<ActSelectionOfProbeDepartmentRequirement>>().Subscribe(LetterIsComeback);
            //yield return
            //    _messageBus.Listen<UpdateStateMessage<PlanReceiptOrderPersonalAccount>>()
            //        .Cast<IMessage>()
            //        .Merge(_messageBus.Listen<UpdateStateMessage<PlanCertificate>>().Cast<IMessage>())
            //        .Merge(_messageBus.Listen<UpdateStateMessage<PlanReceiptOrder>>().Cast<IMessage>())
            //        .Subscribe(msg => {
            //            var target = GetTarget();

            //            if (target != null)
            //            {
            //                if (target.PlanCertificateFilterViewModel.InvokeCommand.CanExecute(null))
            //                {
            //                    target.PlanCertificateFilterViewModel.InvokeCommand.Execute(null);
            //                }

            //                if (target.PersonalAccountFilterViewModel.InvokeCommand.CanExecute(null))
            //                {
            //                    target.PersonalAccountFilterViewModel.InvokeCommand.Execute(null);
            //                }
            //            }
            //        });
        }
        private void LetterIsComeback(AddedEntityMessage<ActSelectionOfProbe> addedEntityMessage)
        {
            var target = this.GetTarget();

            if (target != null)
            {
                ActSelectionOfProbeLiteDto newItem = GetActSelectionOfProbe(addedEntityMessage.Entity.Rn);
                ActSelectionOfProbeLiteDto insertingItem =
                    newItem ?? addedEntityMessage.Entity.MapTo<ActSelectionOfProbeLiteDto>();
                target.ActSelectionOfProbeFilter.Result.Insert(0, insertingItem);
                target.SelectedActSelectionOfProbe = insertingItem;
            }
        }
        private void LetterIsComeback(AddedEntityMessage<ActSelectionOfProbeDepartment> addedEntityMessage)
        {
            var target = this.GetTarget();

            if (target != null)
            {

                ActSelectionOfProbeDepartmentLiteDto newItem = GetActSelectionOfProbeDepartmen(addedEntityMessage.Entity.Rn);
                ActSelectionOfProbeDepartmentLiteDto insertingItem =
                    newItem ?? addedEntityMessage.Entity.MapTo<ActSelectionOfProbeDepartmentLiteDto>();
                target.SelectedActSelectionOfProbe.ActSelectionOfProbeDepartments.Add(insertingItem);
                target.SelectedActSelectionOfProbeDepartment = insertingItem;
            }
        }
        private void LetterIsComeback(AddedEntityMessage<ActSelectionOfProbeDepartmentRequirement> addedEntityMessage)
        {
            var target = this.GetTarget();

            if (target != null)
            {

                ActSelectionOfProbeDepartmentRequirementLiteDto newItem = GetActSelectionOfProbeDepartmenRequirement(addedEntityMessage.Entity.Rn);
                ActSelectionOfProbeDepartmentRequirementLiteDto insertingItem =
                    newItem ?? addedEntityMessage.Entity.MapTo<ActSelectionOfProbeDepartmentRequirementLiteDto>();
                target.SelectedActSelectionOfProbeDepartment.ActSelectionOfProbeDepartmentRequirements.Add(insertingItem);
                target.SelectedActSelectionOfProbeDepartmentRequirement = insertingItem;
            }
        }


        private void LetterIsComeback(UpdatedEntityMessage<ActSelectionOfProbe> updatedEntityMessage)
        {
            var target = this.GetTarget();

            if (target == null)
            {
                return;
            }

            int index = 0;
            ActSelectionOfProbeLiteDto oldItem =
                target.ActSelectionOfProbeFilter.Result.FirstOrDefault(
                    x => x.Rn == updatedEntityMessage.Entity.Rn);
            ActSelectionOfProbeLiteDto newItem = this.GetActSelectionOfProbe(updatedEntityMessage.Entity.Rn);
            if (oldItem != null)
            {
                index = target.ActSelectionOfProbeFilter.Result.IndexOf(oldItem);
                target.ActSelectionOfProbeFilter.Result.Remove(oldItem);
            }
            target.ActSelectionOfProbeFilter.Result.Insert(
                index,
                newItem ?? updatedEntityMessage.Entity.MapTo<ActSelectionOfProbeLiteDto>());
        }
        private void LetterIsComeback(UpdatedEntityMessage<ActSelectionOfProbeDepartment> updatedEntityMessage)
        {
            var target = this.GetTarget();

            if (target == null)
            {
                return;
            }

            int index = 0;
            ActSelectionOfProbeDepartmentLiteDto oldItem =
                target.SelectedActSelectionOfProbe.ActSelectionOfProbeDepartments.FirstOrDefault(
                    x => x.Rn == updatedEntityMessage.Entity.Rn);
            ActSelectionOfProbeDepartmentLiteDto newItem = this.GetActSelectionOfProbeDepartmen(updatedEntityMessage.Entity.Rn);
            if (oldItem != null)
            {
                index = target.SelectedActSelectionOfProbe.ActSelectionOfProbeDepartments.IndexOf(oldItem);
                target.SelectedActSelectionOfProbe.ActSelectionOfProbeDepartments.Remove(oldItem);
            }

            target.SelectedActSelectionOfProbe.ActSelectionOfProbeDepartments.Insert(
                index,
                newItem ?? updatedEntityMessage.Entity.MapTo<ActSelectionOfProbeDepartmentLiteDto>());
        }
        private void LetterIsComeback(UpdatedEntityMessage<ActSelectionOfProbeDepartmentRequirement> updatedEntityMessage)
        {
            var target = this.GetTarget();

            if (target == null)
            {
                return;
            }

            int index = 0;
            ActSelectionOfProbeDepartmentRequirementLiteDto oldItem =
                target.SelectedActSelectionOfProbeDepartment.ActSelectionOfProbeDepartmentRequirements.FirstOrDefault(
                    x => x.Rn == updatedEntityMessage.Entity.Rn);
            ActSelectionOfProbeDepartmentRequirementLiteDto newItem = this.GetActSelectionOfProbeDepartmenRequirement(updatedEntityMessage.Entity.Rn);
            if (oldItem != null)
            {
                index = target.SelectedActSelectionOfProbeDepartment.ActSelectionOfProbeDepartmentRequirements.IndexOf(oldItem);
                target.SelectedActSelectionOfProbeDepartment.ActSelectionOfProbeDepartmentRequirements.Remove(oldItem);
            }

            target.SelectedActSelectionOfProbeDepartment.ActSelectionOfProbeDepartmentRequirements.Insert(
                index,
                newItem ?? updatedEntityMessage.Entity.MapTo<ActSelectionOfProbeDepartmentRequirementLiteDto>());
        }

        private ActSelectionOfProbeLiteDto GetActSelectionOfProbe(long rn)
        {
            _filerObject.Filter.Rn = rn;
            _filerObject.Wait();
            return _filerObject.Result.FirstOrDefault();
        }
        private ActSelectionOfProbeDepartmentLiteDto GetActSelectionOfProbeDepartmen(long rn)
        {
            _filterActSelectionOfProbeDepartment.Filter.Rn = rn;
            _filterActSelectionOfProbeDepartment.Wait();
            return _filterActSelectionOfProbeDepartment.Result.FirstOrDefault();
        }
        private ActSelectionOfProbeDepartmentRequirementLiteDto GetActSelectionOfProbeDepartmenRequirement(long rn)
        {
            _filterActSelectionOfProbeDepartmentRequirement.Filter.Rn = rn;
            _filterActSelectionOfProbeDepartmentRequirement.Wait();
            return _filterActSelectionOfProbeDepartmentRequirement.Result.FirstOrDefault();
        }
        private IActSelectionOfProbeViewModel GetTarget()
        {
            lock (_locker)
            {
                if (_weakReference != null && _weakReference.IsAlive)
                {
                    return (IActSelectionOfProbeViewModel)_weakReference.Target;
                }
            }

            return null;
        }
    }
}
