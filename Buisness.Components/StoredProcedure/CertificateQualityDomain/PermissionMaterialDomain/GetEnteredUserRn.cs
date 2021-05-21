namespace Buisness.Components.StoredProcedure.CertificateQualityDomain.PermissionMaterialDomain
{
    using NHibernate.Helper;

    public class GetEnteredUserRnSP : IStoredProcedure
    {
        public string Name
        {
            get { return "GET_ENTERED_USER_RN"; }
        }
    }
}