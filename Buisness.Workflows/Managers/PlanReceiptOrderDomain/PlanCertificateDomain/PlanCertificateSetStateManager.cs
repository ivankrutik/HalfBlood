namespace Buisness.Workflows.Managers.PlanReceiptOrderDomain.PlanCertificateDomain
{
    using System.Linq;
    using System.Reactive.Linq;

    using Buisness.Components.StoredProcedure.PlanReceiptOrderDomain;
    using Buisness.Workflows.Managers;

    using Halfblood.Common;
    using Halfblood.Common.Helpers;

    using NHibernate.Helper.Repository;

    using ParusModel.Entities.PlanReceiptOrderDomain;

    using ServiceContracts.Exceptions;

    public class EntityBase
    {
        public readonly PlanCertificate Entity;
        private readonly INhRepository<PlanCertificate> _repository;

        public EntityBase(PlanCertificate entity, IRepositoryFactory repositoryFactory)
        {
            _repository = repositoryFactory.Create<PlanCertificate>();
            Entity = entity;
        }
        public void SetStateBase(PlanCertificateState newState)
        {
            _repository.ExecuteSPUniqueResult<PlanCertificate>(
                new PlanCertificateSetStateSP(new PlanCertificate { Rn = Entity.Rn }, newState));
            Entity.State = newState;
        }
    }
    public class NotСonfirmState : EntityBase, IPlanCertificateState
    {
        public NotСonfirmState(PlanCertificate entity, IRepositoryFactory repositoryFactory)
            : base(entity, repositoryFactory)
        {
        }

        public void SetStateNotConfirm()
        {
        }

        public void SetStateConfirm()
        {
            SetStateBase(PlanCertificateState.Confirm);
        }

        public void SetStateClose()
        {
            throw new CheckingSetStatePlanReceiptOrderInvalidException(Resource.PCO_0);
        }
    }
    public class СonfirmStateBase : EntityBase
    {
        protected СonfirmStateBase(PlanCertificate entity, IRepositoryFactory repositoryFactory)
            : base(entity, repositoryFactory)
        {
        }

        public void SetStateNotConfirm()
        {
            if (Entity.PlanReceiptOrderPersonalAccounts.Any(x => x.State == PlanReceiptOrderPersonalAccountState.Close))
            {
                throw new CheckingSetStatePlanReceiptOrderInvalidException(Resource.PCO_6);
            }

            if (Entity.PlanReceiptOrderPersonalAccounts.Any(
                    x =>
                    x.State != PlanReceiptOrderPersonalAccountState.NotСonfirm
                    && x.State != PlanReceiptOrderPersonalAccountState.Confirm))
            {
                throw new CheckingSetStatePlanReceiptOrderInvalidException(Resource.PCO_2);
            }

            SetStateBase(PlanCertificateState.NotСonfirm);
        }

        public void SetStateClose()
        {
            if (Entity.PlanReceiptOrderPersonalAccounts.Any(x => x.State != PlanReceiptOrderPersonalAccountState.Close)) return;

            SetStateBase(PlanCertificateState.Close);
        }
    }
    public class СonfirmStateFalling : СonfirmStateBase, IPlanCertificateState
    {
        private readonly IRepositoryFactory _repositoryFactory;
        private IPlanCertificateState _strategy;
        public СonfirmStateFalling(PlanCertificate entity, IRepositoryFactory repositoryFactory, IPlanCertificateState strategy = null)
            : base(entity, repositoryFactory)
        {
            _strategy = strategy;
            _repositoryFactory = repositoryFactory;
        }

        public void SetStateConfirm()
        {
        }

        public new void SetStateNotConfirm()
        {
            base.SetStateNotConfirm();
        }

        public new void SetStateClose()
        {
            Entity.PlanReceiptOrderPersonalAccounts.Where(x => x.State == PlanReceiptOrderPersonalAccountState.Confirm).DoForEach(
                x =>
                {
                    var manager = new SetStateEntityManagerFactory<PlanReceiptOrderPersonalAccount, PlanReceiptOrderPersonalAccountState>(_repositoryFactory).Create();
                    manager.SetState(x, PlanReceiptOrderPersonalAccountState.Close);
                });

            if (Entity.PlanReceiptOrderPersonalAccounts.Any(
                    x =>
                    x.State == PlanReceiptOrderPersonalAccountState.Confirm
                    || x.State == PlanReceiptOrderPersonalAccountState.NotСonfirm))
            {
                return;
            }

            base.SetStateClose();
            if (_strategy != null)
            {
                _strategy.SetStateClose();
            }
        }
    }
    public class СonfirmStateEmerge : СonfirmStateBase, IPlanCertificateState
    {
        private readonly IPlanCertificateState _strategy;
        private readonly IRepositoryFactory _repositoryFactory;
        public СonfirmStateEmerge(PlanCertificate entity, IRepositoryFactory repositoryFactory, IPlanCertificateState strategy = null)
            : base(entity, repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
            _strategy = strategy;
        }

        public void SetStateConfirm()
        {
        }

        public new void SetStateNotConfirm()
        {
            base.SetStateNotConfirm();
        }

        public new void SetStateClose()
        {
            if (Entity.PlanReceiptOrderPersonalAccounts.Any(
                    x =>
                    x.State == PlanReceiptOrderPersonalAccountState.NotСonfirm
                    || x.State == PlanReceiptOrderPersonalAccountState.Confirm))
            {
                return;
            }

            if (Entity.State != PlanCertificateState.Close)
                base.SetStateClose();

            var manager = new SetStateEntityManagerFactory<PlanReceiptOrder, PlanReceiptOrderState>(_repositoryFactory).Create();
            manager.SetState(Entity.PlanReceiptOrder, PlanReceiptOrderState.Close, Sense.Emerge);

            if (_strategy != null)
            {
                _strategy.SetStateClose();
            }
        }
    }
    public class СloseStateBase : EntityBase, IPlanCertificateState
    {
        public СloseStateBase(PlanCertificate entity, IRepositoryFactory repositoryFactory)
            : base(entity, repositoryFactory)
        {
        }

        public void SetStateConfirm()
        {
            if (!Entity.PlanReceiptOrderPersonalAccounts.Any(
                    x =>
                    x.State == PlanReceiptOrderPersonalAccountState.NotСonfirm
                    || x.State == PlanReceiptOrderPersonalAccountState.Confirm))
            {
                return;
            }

            SetStateBase(PlanCertificateState.Confirm);
        }

        public void SetStateNotConfirm()
        {
            throw new CheckingSetStatePlanReceiptOrderInvalidException(Resource.PCO_4);
        }

        public void SetStateClose()
        {
        }
    }
    public class СloseStateFalling : СloseStateBase, IPlanCertificateState
    {
        private readonly IPlanCertificateState _strategy;
        private IRepositoryFactory _repositoryFactory;
        public СloseStateFalling(PlanCertificate entity, IRepositoryFactory repositoryFactory, IPlanCertificateState strategy = null)
            : base(entity, repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
            _strategy = strategy;
        }

        public void SetStateConfirm()
        {
            Entity.PlanReceiptOrderPersonalAccounts.Where(x => x.State == PlanReceiptOrderPersonalAccountState.Close)
                .DoForEach(
                    x =>
                        {
                            var manager =
                                new SetStateEntityManagerFactory<PlanReceiptOrderPersonalAccount, PlanReceiptOrderPersonalAccountState>(_repositoryFactory).Create();
                            manager.SetState(x, PlanReceiptOrderPersonalAccountState.Confirm);
                        });

            base.SetStateConfirm();
            if (_strategy != null)
            {
                _strategy.SetStateConfirm();
            }
        }

        public new void SetStateNotConfirm()
        {
            throw new CheckingSetStatePlanReceiptOrderInvalidException(Resource.PCO_4);
        }

        public new void SetStateClose()
        {
        }
    }
    public class СloseStateEmerge : СloseStateBase, IPlanCertificateState
    {
        private readonly IRepositoryFactory _repositoryFactory;
        public СloseStateEmerge(PlanCertificate entity, IRepositoryFactory repositoryFactory)
            : base(entity, repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
        }

        public new void SetStateConfirm()
        {
            base.SetStateConfirm();
            var manager = new SetStateEntityManagerFactory<PlanReceiptOrder, PlanReceiptOrderState>(_repositoryFactory).Create();
            manager.SetState(Entity.PlanReceiptOrder, PlanReceiptOrderState.Confirm, Sense.Emerge);
        }
        public new void SetStateNotConfirm()
        {
            throw new CheckingSetStatePlanReceiptOrderInvalidException(Resource.PCO_4);
        }
        public new void SetStateClose()
        {
        }
    }
    public class PlanCertificateSetStateEntityManager : ISetStateEntityManager<PlanCertificate, PlanCertificateState>
    {
        private readonly IRepositoryFactory _repositoryFactory;
        private IPlanCertificateState _state;

        public PlanCertificateSetStateEntityManager(IRepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
        }
        public void SetState(PlanCertificate entity, PlanCertificateState newState, Sense behavior = Sense.Falling)
        {
            switch (entity.State)
            {
                case PlanCertificateState.NotСonfirm:
                    _state = new NotСonfirmState(entity, _repositoryFactory);
                    break;
                case PlanCertificateState.Confirm:
                    if (behavior == Sense.Emerge)
                    {
                        _state = new СonfirmStateEmerge(entity, _repositoryFactory);
                    }

                    if (behavior == Sense.Falling)
                    {
                        _state = new СonfirmStateFalling(entity, _repositoryFactory);
                    }

                    if (behavior == Sense.Full)
                    {
                        _state = new СonfirmStateFalling(entity, _repositoryFactory, new СonfirmStateEmerge(entity, _repositoryFactory));
                    }

                    break;
                case PlanCertificateState.Close:
                    if (behavior == Sense.Emerge)
                    {
                        _state = new СloseStateEmerge(entity, _repositoryFactory);
                    }

                    if (behavior == Sense.Falling)
                    {
                        _state = new СloseStateFalling(entity, _repositoryFactory);
                    }

                    if (behavior == Sense.Full)
                    {
                        _state = new СloseStateFalling(entity, _repositoryFactory, new СloseStateEmerge(entity, _repositoryFactory));
                    }

                    break;
                default:
                    throw new CheckingSetStatePlanReceiptOrderInvalidException(
                        Resource.PCOStateNotExist.StringFormat(entity.Rn));
            }

            switch (newState)
            {
                case PlanCertificateState.NotСonfirm:
                    _state.SetStateNotConfirm();
                    break;
                case PlanCertificateState.Confirm:
                    _state.SetStateConfirm();
                    break;
                case PlanCertificateState.Close:
                    _state.SetStateClose();
                    break;
                default:
                    throw new CheckingSetStatePlanReceiptOrderInvalidException(
                        Resource.PCOStateNotExist.StringFormat(entity.Rn));
            }
        }
    }
}
