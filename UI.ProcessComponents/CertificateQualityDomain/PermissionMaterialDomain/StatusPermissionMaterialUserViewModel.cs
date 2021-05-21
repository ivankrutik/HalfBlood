namespace UI.ProcessComponents.CertificateQualityDomain.PermissionMaterialDomain
{
    using Halfblood.Common;
    using ReactiveUI;
    using ServiceContracts;
    using ServiceContracts.Facades;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Diagnostics.Contracts;
    using System.Reactive;
    using UI.Entities.PermissionMaterialDomain;
    using UI.Infrastructure.Messages;
    using UI.Infrastructure.ViewModels.PermissionMaterialDomain;
    using UI.ProcessComponents.EditViewModels;


    [Export(typeof(IStatusPermissionMaterialUserViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class StatusPermissionMaterialUserViewModel
        : PolicyActionViewModelBase<PermissionMaterialUser, PermissionMaterialUserState>, IStatusPermissionMaterialUserViewModel
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private IList<PermissionMaterialUser> _permissionMaterialUsers;
        private string _note;


        [ImportingConstructor]
        public StatusPermissionMaterialUserViewModel(
            IScreen screen,
            IUnitOfWorkFactory unitOfWorkFactory,
            IMessageBus messageBus)
            : base(screen, messageBus)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }


        public IList<PermissionMaterialUser> PermissionMaterialUsers
        {
            get { return _permissionMaterialUsers; }
            private set { this.RaiseAndSetIfChanged(ref _permissionMaterialUsers, value); }
        }
        public string Note
        {
            get { return _note; }
            set { this.RaiseAndSetIfChanged(ref _note, value); }
        }


        public string UrlPathSegment
        {
            get;
            private set;
        }
        public new IScreen HostScreen
        {
            get { return base.HostScreen; }
        }


        public void SetActionObjectCollection(IList<PermissionMaterialUser> objects)
        {
            Contract.Requires(objects != null, "objects must be not null");

            if (IsBusy)
            {
                throw new InvalidOperationException("Can't set object while operation of changed status is active");
            }

            PermissionMaterialUsers = objects;
        }
        public override void SetActionObject(PermissionMaterialUser @object)
        {
            PermissionMaterialUsers = new List<PermissionMaterialUser> { @object };
        }


        protected override Unit DoLoad()
        {
            using (IUnitOfWork unitOfWork = _unitOfWorkFactory.Create())
            {
                var service = unitOfWork.Create<IPermissionMaterialService>();

                foreach (PermissionMaterialUser permissionMaterialUser in PermissionMaterialUsers)
                {
                    service.SetStatusPermissionMaterialUser(permissionMaterialUser.Rn, State);
                }

                unitOfWork.Commit();
            }

            return Unit.Default;
        }
        protected override void Complete()
        {
            if (MessageBus != null)
            {
                foreach (PermissionMaterialUser permissionMaterialUser in PermissionMaterialUsers)
                {
                    MessageBus.SendMessage(new UpdateStateMessage<PermissionMaterialUser>(permissionMaterialUser));
                }
            }

            if (HostScreen != null)
            {
                HostScreen.Router.NavigateBack.Execute(null);
            }
        }
    }
}
