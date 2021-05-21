// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPlanReceiptOrderService.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the IPlanReceiptOrderService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ServiceContracts.Facades
{
    using Buisness.Entities.CommonDomain;
    using Buisness.Entities.PlanReceiptOrderDomain;

    using Halfblood.Common;

    /// <summary>
    /// The PlanReceiptOrderService interface.
    /// </summary>
    public interface IPlanReceiptOrderService
    {
        PlanReceiptOrderPersonalAccountWithoutPlanCertificateDto
            GetPlanReceiptOrderPersonalAccountWithoutPlanCertificate(long id);
        PlanReceiptOrderWithoutPlanCertificateDto GetPlanReceiptOrderWithoutPlanCertificateDto(long id);
        PlanCertificateDto GetPlanCertificate(long id);
        PlanReceiptOrderDto GetPlanReceiptOrder(long id);
        PlanReceiptOrderPersonalAccountDto GetPlanReceiptOrderPersonalAccount(long id);
        PlanReceiptOrderDto AddPlanReceiptOrder(PlanReceiptOrderDto entity);
        void UpdatePlanReceiptOrder(PlanReceiptOrderDto entity);
        void UpdatePlanCertificate(PlanCertificateDto entity);
        void UpdatePersonalAccount(PlanReceiptOrderPersonalAccountDto entity);
        PlanCertificateDto AddPlanCertificate(PlanCertificateDto entity);
        PlanReceiptOrderPersonalAccountDto AddPlanReceiptOrderPersonalAccount(PlanReceiptOrderPersonalAccountDto entity);
        
        void SetStatePlanReceiptOrder(long id, PlanReceiptOrderState newState);
        void SetStatusPersonalAccount(long id, PlanReceiptOrderPersonalAccountState newState);
        void SetStatusPlanCertificate(long id, PlanCertificateState newState);
       
        void SetGroupPersonalAccountPlanReceiptOrder(PlanReceiptOrderDto entity, PersonalAccountDto personalAccount);

        void RemovePlanReceiptOrder(long rn);
        void RemovePlanCertificate(long rn);
        void RemovePlanReceiptOrderPersonalAccount(long rn);
    }
}