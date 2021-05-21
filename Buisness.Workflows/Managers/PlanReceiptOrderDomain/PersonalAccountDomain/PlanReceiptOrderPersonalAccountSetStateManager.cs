using Buisness.Workflows.Managers.CreditSlipDomain;

namespace Buisness.Workflows.Managers.PlanReceiptOrderDomain.PersonalAccountDomain
{
    using System.Collections.Generic;
    using System.Linq;

    using Buisness.Components.StoredProcedure.PlanReceiptOrderDomain;
    using Buisness.Workflows.Managers;

    using Halfblood.Common;
    using Halfblood.Common.Helpers;

    using NHibernate.Helper.Repository;

    using ParusModel.Entities.PlanReceiptOrderDomain;

    using ServiceContracts.Exceptions;

    public abstract class EntityBase
    {
        public readonly PlanReceiptOrderPersonalAccount Entity;
        private readonly INhRepository<PlanReceiptOrderPersonalAccount> _repository;
        public IList<long> CreditSlips { get; set; }

        protected EntityBase(PlanReceiptOrderPersonalAccount entity, IRepositoryFactory repositoryFactory)
        {
            _repository = repositoryFactory.Create<PlanReceiptOrderPersonalAccount>();
            Entity = entity;
        }

        public virtual void SetStateBase(PlanReceiptOrderPersonalAccountState newState)
        {
            _repository.ExecuteSPUniqueResult<PlanReceiptOrderPersonalAccount>(
                new PersonalAccountSetStateSP(Entity, newState));
            Entity.State = newState;
        }
    }

    public class NotСonfirmState : EntityBase, IPlanReceiptOrderPersonalAccountState
    {
        public NotСonfirmState(PlanReceiptOrderPersonalAccount entity, IRepositoryFactory repositoryFactory)
            : base(entity, repositoryFactory)
        {
        }

        public void SetStateConfirm()
        {
            if (Entity.PlaneCertificate.State != PlanCertificateState.Confirm)
            {
                throw new CheckingSetStatePlanReceiptOrderInvalidException(Resource.PCO_0);
            }

            if (Entity.PlaneCertificate.PlanReceiptOrder.State != PlanReceiptOrderState.Confirm)
            {
                throw new CheckingSetStatePlanReceiptOrderInvalidException(Resource.PCO_5);
            }

            SetStateBase(PlanReceiptOrderPersonalAccountState.Confirm);
        }

        public void SetStateNotConfirm()
        {
        }

        public void SetStateClose()
        {
            throw new CheckingSetStatePlanReceiptOrderInvalidException(Resource.PCO_1);
        }
    }

    public abstract class СonfirmStateBase : EntityBase
    {
        protected СonfirmStateBase(PlanReceiptOrderPersonalAccount entity, IRepositoryFactory repositoryFactory)
            : base(entity, repositoryFactory)
        {
        }

        public virtual void SetStateNotConfirm()
        {
            SetStateBase(PlanReceiptOrderPersonalAccountState.NotСonfirm);
        }
        public virtual void SetStateClose()
        {
            if (Entity.State != PlanReceiptOrderPersonalAccountState.Confirm)
            {
                throw new CheckingSetStatePlanReceiptOrderInvalidException(Resource.PCO_1);
            }

           CreditSlipManager.AddCreate(Entity);

            SetStateBase(PlanReceiptOrderPersonalAccountState.Close);
        }
    }

    public class СonfirmStateFalling : СonfirmStateBase, IPlanReceiptOrderPersonalAccountState
    {
        private IPlanReceiptOrderPersonalAccountState _strategy;

        public СonfirmStateFalling(
            PlanReceiptOrderPersonalAccount entity,
            IRepositoryFactory repositoryFactory,
            IPlanReceiptOrderPersonalAccountState strategy = null)
            : base(entity, repositoryFactory)
        {
            _strategy = strategy;
        }


        public void SetStateConfirm()
        {
        }

        public override void SetStateClose()
        {
            base.SetStateClose();
            if (_strategy != null)
            {
                _strategy.SetStateClose();
            }
        }
    }

    public class СonfirmStateEmerge : СonfirmStateBase, IPlanReceiptOrderPersonalAccountState
    {
        private readonly IRepositoryFactory _pepositoryFactory;

        public СonfirmStateEmerge(PlanReceiptOrderPersonalAccount entity, IRepositoryFactory pepositoryFactory)
            : base(entity, pepositoryFactory)
        {
            _pepositoryFactory = pepositoryFactory;
        }

        public void SetStateConfirm()
        {
        }

        public override void SetStateClose()
        {
            if (
                Entity.PlaneCertificate.PlanReceiptOrderPersonalAccounts.Any(
                    x =>
                    x.State == PlanReceiptOrderPersonalAccountState.NotСonfirm
                    || x.State == PlanReceiptOrderPersonalAccountState.Confirm))
            {
                return;
            }

            var manager = new SetStateEntityManagerFactory<PlanCertificate, PlanCertificateState>(_pepositoryFactory).Create();
            manager.SetState(Entity.PlaneCertificate, PlanCertificateState.Close, Sense.Emerge);
        }
    }

    public class СloseStateFalling : EntityBase, IPlanReceiptOrderPersonalAccountState
    {
        private readonly IPlanReceiptOrderPersonalAccountState _strategy;

        public СloseStateFalling(
            PlanReceiptOrderPersonalAccount entity,
            IRepositoryFactory repositoryFactory,
            IPlanReceiptOrderPersonalAccountState strategy = null)
            : base(entity, repositoryFactory)
        {
            _strategy = strategy;
        }

        public void SetStateConfirm()
        {
            CreditSlipManager.AddRemove(Entity);
            SetStateBase(PlanReceiptOrderPersonalAccountState.Confirm);
            if (_strategy != null)
            {
                _strategy.SetStateConfirm();
            }
        }
        public void SetStateNotConfirm()
        {
            throw new CheckingSetStatePlanReceiptOrderInvalidException(Resource.PCO_7);
        }
        public void SetStateClose()
        {
        }
    }

    public class СloseStateEmergy : EntityBase, IPlanReceiptOrderPersonalAccountState
    {
        private readonly IRepositoryFactory _repositoryFactory;
        public СloseStateEmergy(PlanReceiptOrderPersonalAccount entity, IRepositoryFactory repositoryFactory)
            : base(entity, repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
        }

        public void SetStateConfirm()
        {
            if (Entity.PlaneCertificate.PlanReceiptOrderPersonalAccounts.Any(x => x.State != PlanReceiptOrderPersonalAccountState.Close))
            {
                var manager = new SetStateEntityManagerFactory<PlanCertificate, PlanCertificateState>(_repositoryFactory).Create();
                manager.SetState(Entity.PlaneCertificate, PlanCertificateState.Confirm, Sense.Emerge);
            }
        }
        public void SetStateNotConfirm()
        {
            throw new CheckingSetStatePlanReceiptOrderInvalidException(Resource.PCO_1);
        }
        public void SetStateClose()
        {
        }
    }

    public class PlanReceiptOrderPersonalAccountSetStateEntityManager :
        ISetStateEntityManager<PlanReceiptOrderPersonalAccount, PlanReceiptOrderPersonalAccountState>
    {
        private readonly IRepositoryFactory _repositoryFactory;
        private IPlanReceiptOrderPersonalAccountState _state;

        public PlanReceiptOrderPersonalAccountSetStateEntityManager(IRepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
        }

        public void SetState(
            PlanReceiptOrderPersonalAccount entity,
            PlanReceiptOrderPersonalAccountState newState,
            Sense behavios = Sense.Falling)
        {
            switch (entity.State)
            {
                case PlanReceiptOrderPersonalAccountState.NotСonfirm:
                    _state = new NotСonfirmState(entity, _repositoryFactory);
                    break;

                case PlanReceiptOrderPersonalAccountState.Confirm:
                    if (behavios == Sense.Emerge)
                    {
                        _state = new СonfirmStateEmerge(entity, _repositoryFactory);
                    }

                    if (behavios == Sense.Falling)
                    {
                        _state = new СonfirmStateFalling(entity, _repositoryFactory);
                    }

                    if (behavios == Sense.Full)
                    {
                        _state = new СonfirmStateFalling(
                            entity,
                            _repositoryFactory,
                            new СonfirmStateEmerge(entity, _repositoryFactory));
                    }
                    break;

                case PlanReceiptOrderPersonalAccountState.Close:
                    if (behavios == Sense.Emerge)
                    {
                        _state = new СloseStateEmergy(entity, _repositoryFactory);
                    }

                    if (behavios == Sense.Falling)
                    {
                        _state = new СloseStateFalling(entity, _repositoryFactory);
                    }

                    if (behavios == Sense.Full)
                    {
                        _state = new СloseStateFalling(
                            entity,
                            _repositoryFactory,
                            new СloseStateEmergy(entity, _repositoryFactory));
                    }
                    break;

                default:
                    throw new CheckingSetStatePlanReceiptOrderInvalidException(
                        Resource.PCOStateNotExist.StringFormat(entity.Rn));
            }

            switch (newState)
            {
                case PlanReceiptOrderPersonalAccountState.NotСonfirm:
                    _state.SetStateNotConfirm();
                    break;
                case PlanReceiptOrderPersonalAccountState.Confirm:
                    _state.SetStateConfirm();
                    break;
                case PlanReceiptOrderPersonalAccountState.Close:
                    _state.SetStateClose();
                    break;
                default:
                    throw new CheckingSetStatePlanReceiptOrderInvalidException(
                        Resource.PCOStateNotExist.StringFormat(entity.Rn));
            }
        }
    }
}