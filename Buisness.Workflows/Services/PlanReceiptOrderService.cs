// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PlanReceiptOrderService.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the PlanReceiptOrderService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Workflows.Services
{
    using Buisness.Components.StoredProcedure.PlanReceiptOrderDomain;
    using Buisness.Entities.CommonDomain;
    using Buisness.Entities.PlanReceiptOrderDomain;
    using Buisness.Filters;
    using Buisness.Workflows.Managers;
    using Halfblood.Common;
    using Halfblood.Common.Mappers;

    using NHibernate.Helper.Filter;
    using NHibernate.Helper.Filter.Specification;
    using NHibernate.Helper.Repository;
    using NHibernate.Helper.Service;

    using ParusModel.Entities;
    using ParusModel.Entities.PlanReceiptOrderDomain;

    using ServiceContracts.Facades;

    using System.Linq;
    using Buisness.Workflows.Managers.CreditSlipDomain;
    using ServiceContracts.Exceptions;

    [Register(typeof(IPlanReceiptOrderService))]
    public class PlanReceiptOrderService : ServiceBase, IPlanReceiptOrderService
    {
        public PlanReceiptOrderService(
            IRepositoryFactory repositoryFactory,
            IFilterStrategyFactory filterStrategyFactory)
            : base(repositoryFactory, filterStrategyFactory)
        {
        }

        public PlanReceiptOrderWithoutPlanCertificateDto GetPlanReceiptOrderWithoutPlanCertificateDto(long id)
        {
            PlanReceiptOrderWithoutPlanCertificateDto result = GetEntity<PlanReceiptOrder, PlanReceiptOrderWithoutPlanCertificateDto>(id);
            return result;
        }
        public PlanReceiptOrderDto GetPlanReceiptOrder(long id)
        {
            PlanReceiptOrderDto result = GetEntity<PlanReceiptOrder, PlanReceiptOrderDto>(id);
            return result;
        }
        public PlanCertificateDto GetPlanCertificate(long id)
        {
            return GetEntity<PlanCertificate, PlanCertificateDto>(id);
        }
        public PlanReceiptOrderPersonalAccountWithoutPlanCertificateDto GetPlanReceiptOrderPersonalAccountWithoutPlanCertificate(long id)
        {
            PlanReceiptOrderPersonalAccountWithoutPlanCertificateDto result =
                GetEntity<PlanReceiptOrderPersonalAccount, PlanReceiptOrderPersonalAccountWithoutPlanCertificateDto>(id);

            return result;
        }
        public PlanReceiptOrderPersonalAccountDto GetPlanReceiptOrderPersonalAccount(long id)
        {
            PlanReceiptOrderPersonalAccountDto result =
                GetEntity<PlanReceiptOrderPersonalAccount, PlanReceiptOrderPersonalAccountDto>(id);

            return result;
        }
        public PlanReceiptOrderDto AddPlanReceiptOrder(PlanReceiptOrderDto entity)
        {
            var addedEntity = AddEntity<PlanReceiptOrder, PlanReceiptOrderDto>(entity);
            var numbPref =
                RepositoryFactory.Create<PlanReceiptOrder>()
                    .Specify()
                    .Filtering(new PlanReceiptOrderFilter(addedEntity.Rn))
                    .Select(x => x.Numb, x => x.Pref)
                    .UnderlyingCriteria.UniqueResult<object[]>();

            addedEntity.Numb = (long)numbPref[0];
            addedEntity.Pref = (string)numbPref[1];

            return addedEntity;
        }
        public void SetStatePlanReceiptOrder(long id, PlanReceiptOrderState newState)
        {
            var entity = GetEntity<PlanReceiptOrder>(id);
            var manager = new SetStateEntityManagerFactory<PlanReceiptOrder, PlanReceiptOrderState>(RepositoryFactory).Create();
            manager.SetState(entity, newState);

            try
            {
                var createCreditSlip = new CreditSlipManager(RepositoryFactory);
                createCreditSlip.Flush();
            }
            finally
            {
                CreditSlipManager.Clean();
            }
        }
        public void SetStatusPersonalAccount(long id, PlanReceiptOrderPersonalAccountState newState)
        {
            var entity = GetEntity<PlanReceiptOrderPersonalAccount>(id);
            var manager = new SetStateEntityManagerFactory<PlanReceiptOrderPersonalAccount, PlanReceiptOrderPersonalAccountState>(RepositoryFactory).Create();
            manager.SetState(entity, newState, Sense.Full);

            try
            {
                var createCreditSlip = new CreditSlipManager(RepositoryFactory);
                createCreditSlip.Flush();
            }
            finally
            {
                CreditSlipManager.Clean();
            }
        }
        public void SetStatusPlanCertificate(long id, PlanCertificateState newState)
        {

            var entity = GetEntity<PlanCertificate>(id);
            var manager = new SetStateEntityManagerFactory<PlanCertificate, PlanCertificateState>(RepositoryFactory).Create();
            manager.SetState(entity, newState, Sense.Full);

            try
            {
                var createCreditSlip = new CreditSlipManager(RepositoryFactory);
                createCreditSlip.Flush();
            }
            finally
            {
                CreditSlipManager.Clean();
            }
        }

        public void SetGroupPersonalAccountPlanReceiptOrder(PlanReceiptOrderDto entity, PersonalAccountDto personalAccount)
        {
            var planReceiptOrder = RepositoryFactory.Create<PlanReceiptOrder>().Get(entity.Rn);

            if (planReceiptOrder.PlanCertificates.Any(x => x.PlanReceiptOrderPersonalAccounts.Any(v => v.State == PlanReceiptOrderPersonalAccountState.Confirm)))
                throw new CheckingSetStatePlanReceiptOrderInvalidException(Resource.PCO_17);
            if (planReceiptOrder.PlanCertificates.Any(x => x.PlanReceiptOrderPersonalAccounts.Any(v => v.State == PlanReceiptOrderPersonalAccountState.Close)))
                throw new CheckingSetStatePlanReceiptOrderInvalidException(Resource.PCO_18);

            ExecuteStoreProcedure<PlanCertificate>(
                new PlanReceiptOrderSetGroupState(
                    entity.MapTo<PlanReceiptOrder>(),
                    personalAccount.MapTo<PersonalAccount>()));
        }
        public void UpdatePlanReceiptOrder(PlanReceiptOrderDto entity)
        {
            var repository = RepositoryFactory.Create<PlanReceiptOrder>();
            var planReceiptOrder = repository.Get(entity.Rn);
            if (planReceiptOrder.PlanCertificates.Any(x => x.PlanReceiptOrderPersonalAccounts.Any(
                    z => z.State != PlanReceiptOrderPersonalAccountState.NotСonfirm)))
            {
                throw new CheckingSetStatePlanReceiptOrderInvalidException(Resource.PCO_2);
            }
            repository.Evict(planReceiptOrder);
            UpdateEntity<PlanReceiptOrder, PlanReceiptOrderDto>(entity);
        }
        public void UpdatePersonalAccount(PlanReceiptOrderPersonalAccountDto entity)
        {
            var repository = RepositoryFactory.Create<PlanReceiptOrderPersonalAccount>();
            var receiptOrderPersonalAccount = repository.Get(entity.Rn);
            if (receiptOrderPersonalAccount.State == PlanReceiptOrderPersonalAccountState.Confirm)
                throw new CheckingSetStatePlanReceiptOrderInvalidException(Resource.PCO_16);
            if (receiptOrderPersonalAccount.State == PlanReceiptOrderPersonalAccountState.Close)
                throw new CheckingSetStatePlanReceiptOrderInvalidException(Resource.PCO_15);

            repository.Evict(receiptOrderPersonalAccount);
            UpdateEntity<PlanReceiptOrderPersonalAccount, PlanReceiptOrderPersonalAccountDto>(entity);
        }
        public void UpdatePlanCertificate(PlanCertificateDto entity)
        {
            //var repository = RepositoryFactory.Create<PlanCertificate>();
            //var planCertificate = repository.Get(entity.Rn);
            //if (planCertificate.PlanReceiptOrderPersonalAccounts.Any(
            //        x => x.State != PlanReceiptOrderPersonalAccountState.NotСonfirm))
            //{
            //    throw new CheckingSetStatePlanReceiptOrderInvalidException(Resource.PCO_2);
            //}
//            repository.Evict(planCertificate);
//            entity.CertificateQuality.AttachedDocuments[0].Document = (IDto<long>)new AttachedDocumentDto{Rn= entity.CertificateQuality.Rn};
            UpdateEntity<PlanCertificate, PlanCertificateDto>(entity);
        }
        public PlanCertificateDto AddPlanCertificate(PlanCertificateDto entity)
        {
            var planReceiptOrder = RepositoryFactory.Create<PlanReceiptOrder>().Get(entity.PlanReceiptOrder.Rn);
            if (planReceiptOrder.State == PlanReceiptOrderState.Close)
                throw new CheckingSetStatePlanReceiptOrderInvalidException(Resource.PCO_14);

            return AddEntity<PlanCertificate, PlanCertificateDto>(entity);
        }
        public PlanReceiptOrderPersonalAccountDto AddPlanReceiptOrderPersonalAccount(PlanReceiptOrderPersonalAccountDto entity)
        {
            var repository = RepositoryFactory.Create<PlanCertificate>();
            var planCertificate = repository.Get(entity.PlanCertificate.Rn);
            if ((planCertificate.State != PlanCertificateState.NotСonfirm) &&
                (planCertificate.State != PlanCertificateState.Confirm))
                throw new CheckingSetStatePlanReceiptOrderInvalidException(Resource.PCO_13);

            return
                AddEntity<PlanReceiptOrderPersonalAccount, PlanReceiptOrderPersonalAccountDto>(
                    entity);
        }
        public void RemovePlanReceiptOrder(long rn)
        {
            var planReceiptOrder = RepositoryFactory.Create<PlanReceiptOrder>().Get(rn);
            if (planReceiptOrder.PlanCertificates.Any(x => x.PlanReceiptOrderPersonalAccounts.Any(
                    z => z.State != PlanReceiptOrderPersonalAccountState.NotСonfirm)))
            {
                throw new CheckingSetStatePlanReceiptOrderInvalidException(Resource.PCO_8);
            }
            RemoveEntity<PlanReceiptOrder>(planReceiptOrder);
        }
        public void RemovePlanCertificate(long rn)
        {
            var planCertificate = RepositoryFactory.Create<PlanCertificate>().Get(rn);
            if (planCertificate.PlanReceiptOrderPersonalAccounts.Any(
                    x => x.State == PlanReceiptOrderPersonalAccountState.Close))
            {
                throw new CheckingSetStatePlanReceiptOrderInvalidException(Resource.PCO_9);
            }
            if (planCertificate.PlanReceiptOrderPersonalAccounts.Any(
                    x => x.State == PlanReceiptOrderPersonalAccountState.Confirm))
            {
                throw new CheckingSetStatePlanReceiptOrderInvalidException(Resource.PCO_12);
            }

            RemoveEntity<PlanCertificate>(planCertificate);
        }
        public void RemovePlanReceiptOrderPersonalAccount(long rn)
        {
            var repository = RepositoryFactory.Create<PlanReceiptOrderPersonalAccount>();
            var planReceiptOrderPersonalAccount = repository.Get(rn);
            if (planReceiptOrderPersonalAccount.State == PlanReceiptOrderPersonalAccountState.Close)
            {
                throw new CheckingSetStatePlanReceiptOrderInvalidException(Resource.PCO_10);
            }
            if (planReceiptOrderPersonalAccount.State == PlanReceiptOrderPersonalAccountState.Confirm)
            {
                throw new CheckingSetStatePlanReceiptOrderInvalidException(Resource.PCO_11);
            }
            RemoveEntity<PlanReceiptOrderPersonalAccount>(planReceiptOrderPersonalAccount);
        }
    }
}