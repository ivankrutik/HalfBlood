namespace Buisness.Workflows.Managers.PlanReceiptOrderDomain.PlanCertificateDomain
{
    public interface IPlanCertificateState
    {
        void SetStateConfirm();
        void SetStateNotConfirm();
        void SetStateClose();
    }
}
