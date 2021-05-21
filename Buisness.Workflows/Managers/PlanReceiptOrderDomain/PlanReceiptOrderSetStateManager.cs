namespace Buisness.Workflows.Managers.PlanReceiptOrderDomain
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
        public readonly PlanReceiptOrder Entity;
        private readonly INhRepository<PlanReceiptOrder> _repository;

        public EntityBase(PlanReceiptOrder entity, IRepositoryFactory repositoryFactory)
        {
            Entity = entity;
            _repository = repositoryFactory.Create<PlanReceiptOrder>();
        }
        public void SetStateBase(PlanReceiptOrderState newState)
        {
            _repository.ExecuteSPUniqueResult<PlanReceiptOrder>(new PlanReceiptOrderSetState(Entity, newState));
            Entity.State = newState;
        }
    }
    public class NotСonfirmState : EntityBase, IPlanReceiptOrderState
    {
        public NotСonfirmState(PlanReceiptOrder entity, IRepositoryFactory repositoryFactory)
            : base(entity, repositoryFactory)
        {
        }

        public void SetStateConfirm()
        {
            SetStateBase(PlanReceiptOrderState.Confirm);
        }

        public void SetStateNotConfirm()
        {
        }

        public void SetStateClose()
        {
            throw new CheckingSetStatePlanReceiptOrderInvalidException(Resource.PCO_5);
        }
    }
    public class СonfirmStateBase : EntityBase
    {
        protected СonfirmStateBase(PlanReceiptOrder entity, IRepositoryFactory repositoryFactory)
            : base(entity, repositoryFactory)
        {
        }

        public void SetStateNotConfirm()
        {
            Entity.PlanCertificates.DoForEach(x =>
            {
                if (x.State == PlanCertificateState.Close)
                {
                    throw new CheckingSetStatePlanReceiptOrderInvalidException(Resource.PCO_4);
                }

                if (x.PlanReceiptOrderPersonalAccounts.Any(
                        x1 => x1.State != PlanReceiptOrderPersonalAccountState.NotСonfirm))
                {
                    throw new CheckingSetStatePlanReceiptOrderInvalidException(Resource.PCO_3);
                }
            });

            SetStateBase(PlanReceiptOrderState.NotСonfirm);
        }
        public void SetStateConfirm()
        {
        }
        public void SetStateClose()
        {
            if (Entity.PlanCertificates.Any(x => x.State != PlanCertificateState.Close))
            {
                return;
            }

            SetStateBase(PlanReceiptOrderState.Close);
        }
    }
    public class СonfirmStateFalling : СonfirmStateBase, IPlanReceiptOrderState
    {
        private readonly IRepositoryFactory _repositoryFactory;
        public СonfirmStateFalling(PlanReceiptOrder entity, IRepositoryFactory repositoryFactory)
            : base(entity, repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
        }

        public void SetStateConfirm()
        {
            base.SetStateConfirm();
        }

        public new void SetStateNotConfirm()
        {
            base.SetStateNotConfirm();
        }

        public new void SetStateClose()
        {
            if (Entity.PlanCertificates.Any(x => x.State == PlanCertificateState.NotСonfirm))
            {
                throw new CheckingSetStatePlanReceiptOrderInvalidException(Resource.PCO_0);
            }

            Entity.PlanCertificates.Where(x => x.State == PlanCertificateState.Confirm).DoForEach(x =>
            {
                var manager = new SetStateEntityManagerFactory<PlanCertificate, PlanCertificateState>(_repositoryFactory).Create();
                manager.SetState(x, PlanCertificateState.Close);
            });

            base.SetStateClose();
        }
    }
    public class СonfirmStateEmerge : СonfirmStateBase, IPlanReceiptOrderState
    {
        public СonfirmStateEmerge(PlanReceiptOrder entity, IRepositoryFactory repositoryFactory)
            : base(entity, repositoryFactory)
        {
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
            base.SetStateClose();
        }
    }
    public class CloseStateEmerge : EntityBase, IPlanReceiptOrderState
    {
        public CloseStateEmerge(PlanReceiptOrder entity, IRepositoryFactory repositoryFactory)
            : base(entity, repositoryFactory)
        {
        }

        public void SetStateConfirm()
        {
            if (!Entity.PlanCertificates.Any(
                    x => x.State == PlanCertificateState.NotСonfirm || x.State == PlanCertificateState.Confirm))
            {
                return;
            }

            SetStateBase(PlanReceiptOrderState.Confirm);
        }

        public void SetStateNotConfirm()
        {
            throw new CheckingSetStatePlanReceiptOrderInvalidException(Resource.PCO_4);
        }

        public void SetStateClose()
        {
        }
    }
    public class CloseStateFalling : EntityBase, IPlanReceiptOrderState
    {
        private readonly IRepositoryFactory _repositoryFactory;

        public CloseStateFalling(PlanReceiptOrder entity, IRepositoryFactory repositoryFactory)
            : base(entity, repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
        }

        public void SetStateConfirm()
        {
            Entity.PlanCertificates.Where(x => x.State == PlanCertificateState.Close).DoForEach(
               x =>
               {
                   var manager = new SetStateEntityManagerFactory<PlanCertificate, PlanCertificateState>(_repositoryFactory).Create();
                   manager.SetState(x, PlanCertificateState.Confirm);
               });
            if (Entity.PlanCertificates.Any(x => x.State == PlanCertificateState.Confirm))
                SetStateBase(PlanReceiptOrderState.Confirm);
        }

        public void SetStateNotConfirm()
        {
            throw new CheckingSetStatePlanReceiptOrderInvalidException(Resource.PCO_4);
        }

        public void SetStateClose()
        {
        }
    }
    public class PlanReceiptOrderSetStateEntityManager : ISetStateEntityManager<PlanReceiptOrder, PlanReceiptOrderState>
    {
        private IPlanReceiptOrderState _state;
        private readonly IRepositoryFactory _pepositoryFactory;

        public PlanReceiptOrderSetStateEntityManager(IRepositoryFactory pepositoryFactory)
        {
            _pepositoryFactory = pepositoryFactory;
        }
        public void SetState(PlanReceiptOrder entity, PlanReceiptOrderState newState, Sense behavior = Sense.Falling)
        {
            switch (entity.State)
            {
                case PlanReceiptOrderState.NotСonfirm: { _state = new NotСonfirmState(entity, _pepositoryFactory); break; }
                case PlanReceiptOrderState.Confirm:
                    {
                        if (behavior == Sense.Emerge) { _state = new СonfirmStateEmerge(entity, _pepositoryFactory); }
                        if (behavior == Sense.Falling)
                        {
                            _state = new СonfirmStateFalling(entity, _pepositoryFactory);
                        }
                        if (behavior == Sense.Full)
                        {
                            // _state = new СonfirmStateFalling(entity, _pepositoryFactory, new СonfirmStateEmerge(entity, _pepositoryFactory));
                        }
                        break;
                    }
                case PlanReceiptOrderState.Close:
                    {
                        if (behavior == Sense.Emerge) { _state = new CloseStateEmerge(entity, _pepositoryFactory); }
                        if (behavior == Sense.Falling)
                        {
                            _state = new CloseStateFalling(entity, _pepositoryFactory);
                        }
                        break;
                    }
                default:
                    {
                        throw new CheckingSetStatePlanReceiptOrderInvalidException(Resource.PCOStateNotExist.StringFormat(entity.Rn));
                    }
            }

            switch (newState)
            {
                case PlanReceiptOrderState.NotСonfirm: { _state.SetStateNotConfirm(); break; }
                case PlanReceiptOrderState.Confirm: { _state.SetStateConfirm(); break; }
                case PlanReceiptOrderState.Close: { _state.SetStateClose(); break; }
                default: { throw new CheckingSetStatePlanReceiptOrderInvalidException(Resource.PCOStateNotExist.StringFormat(entity.Rn)); }
            }
        }
    }
}
