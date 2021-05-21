namespace Buisness.Workflows.Managers.CertificateQualityDomain.PermissionMaterialDomain
{
    interface IPermissionMaterialUserState
    {
        void SetStateExpecting();
        void SetStateConfirmed();
        void SetStateNotConfirmed();
    }
}