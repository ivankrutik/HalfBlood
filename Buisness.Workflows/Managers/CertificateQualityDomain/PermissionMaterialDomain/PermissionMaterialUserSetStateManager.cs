namespace Buisness.Workflows.Managers.CertificateQualityDomain.PermissionMaterialDomain
{
    using Buisness.Components.StoredProcedure.CertificateQualityDomain.PermissionMaterialDomain;
    using Halfblood.Common;
    using Halfblood.Common.Helpers;
    using NHibernate.Helper.Repository;
    using ParusModel.Entities.PermissionMaterialDomain;
    using ServiceContracts.Exceptions;
    using System.Collections.Generic;

    // Entity Base ===============================================================================================
    public abstract class EntityBase
    {
        public readonly PermissionMaterialUser Entity;
        private readonly INhRepository<PermissionMaterialUser> _repository;
        public IList<long> CreditSlips { get; set; }

        protected EntityBase(PermissionMaterialUser entity, IRepositoryFactory repositoryFactory)
        {
            _repository = repositoryFactory.Create<PermissionMaterialUser>();
            Entity = entity;
        }

        public virtual void SetStateBase(PermissionMaterialUserState newState)
        {
            _repository.ExecuteSPUniqueResult<PermissionMaterialUser>(
                new PermissionMaterialUserSetStateSP(Entity, newState));
            Entity.State = newState;
        }
    }


    // установка состояний =======================================================================================
    public class ExpectingState : EntityBase, IPermissionMaterialUserState
    {
        public ExpectingState(PermissionMaterialUser entity, IRepositoryFactory repositoryFactory)
            : base(entity, repositoryFactory)
        {
        }

        public void SetStateExpecting()
        {
        }

        public void SetStateConfirmed()
        {
            SetStateBase(PermissionMaterialUserState.Confirmed);
        }

        public void SetStateNotConfirmed()
        {
            SetStateBase(PermissionMaterialUserState.NotConfirmed);
        }
    }


    public class ConfirmedState : EntityBase, IPermissionMaterialUserState
    {
        public ConfirmedState(PermissionMaterialUser entity, IRepositoryFactory repositoryFactory)
            : base(entity, repositoryFactory)
        {
        }

        public void SetStateExpecting()
        {
            SetStateBase(PermissionMaterialUserState.Expecting);
        }

        public void SetStateConfirmed()
        {
        }

        public void SetStateNotConfirmed()
        {
            SetStateBase(PermissionMaterialUserState.NotConfirmed);
        }
    }


    public class NotConfirmedState : EntityBase, IPermissionMaterialUserState
    {
        public NotConfirmedState(PermissionMaterialUser entity, IRepositoryFactory repositoryFactory)
            : base(entity, repositoryFactory)
        {
        }

        public void SetStateExpecting()
        {
            SetStateBase(PermissionMaterialUserState.Expecting);
        }

        public void SetStateConfirmed()
        {
            SetStateBase(PermissionMaterialUserState.Confirmed);
        }

        public void SetStateNotConfirmed()
        {
        }
    }


    // Manager ===================================================================================================
    public class PermissionMaterialUserSetStateEntityManager :
        ISetStateEntityManager<PermissionMaterialUser, PermissionMaterialUserState>
    {
        private readonly IRepositoryFactory _repositoryFactory;
        private IPermissionMaterialUserState _state;

        public PermissionMaterialUserSetStateEntityManager(IRepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
        }

        public void SetState(PermissionMaterialUser entity, PermissionMaterialUserState newState, Sense sense = Sense.Falling)
        {
            // устанавливаем набор действий для текущего состояния
            switch (entity.State)
            {
                case PermissionMaterialUserState.Expecting:
                    _state = new ExpectingState(entity, _repositoryFactory);
                    break;

                case PermissionMaterialUserState.Confirmed:
                    _state = new ConfirmedState(entity, _repositoryFactory);
                    break;

                case PermissionMaterialUserState.NotConfirmed:
                    _state = new NotConfirmedState(entity, _repositoryFactory);
                    break;

                default:
                    throw new CheckingSetStatePermissionMaterialUserInvalidException(
                        Resource.PMUStateNotExist.StringFormat(entity.Rn));
            }

            // устанавливаем новое состояние
            switch (newState)
            {
                case PermissionMaterialUserState.Expecting:
                    _state.SetStateExpecting();
                    break;

                case PermissionMaterialUserState.Confirmed:
                    _state.SetStateConfirmed();
                    break;

                case PermissionMaterialUserState.NotConfirmed:
                    _state.SetStateNotConfirmed();
                    break;

                default:
                    throw new CheckingSetStatePermissionMaterialUserInvalidException(
                        Resource.PMUStateNotExist.StringFormat(entity.Rn));
            }
        }
    }
}