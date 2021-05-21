namespace Buisness.Workflows.Managers.PlanReceiptOrderDomain
{
    public interface IPlanReceiptOrderState
    {
        void SetStateConfirm();
        void SetStateNotConfirm();
        void SetStateClose();
    }
}
