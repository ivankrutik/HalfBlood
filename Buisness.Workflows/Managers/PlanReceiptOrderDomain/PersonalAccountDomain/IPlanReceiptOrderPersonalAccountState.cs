namespace Buisness.Workflows.Managers.PlanReceiptOrderDomain.PersonalAccountDomain
{
    public interface IPlanReceiptOrderPersonalAccountState
    {
        void SetStateConfirm();
        void SetStateNotConfirm();
        void SetStateClose();
    }
}
