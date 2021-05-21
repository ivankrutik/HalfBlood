namespace Buisness.Components.StoredProcedure.CertificateQualityDomain.PermissionMaterialDomain
{
    using Halfblood.Common;
    using NHibernate.Helper;
    using ParusModel.Entities.PermissionMaterialDomain;

    public class PermissionMaterialExtensionUserSetStateSP : IStoredProcedure
    {
        public PermissionMaterialExtensionUserSetStateSP
            (PermissionMaterialExtensionUser permissionMaterialExtensionUser,
            PermissionMaterialUserState state)
        {
            Rn = permissionMaterialExtensionUser.Rn;
            State = state;
        }

        [StoredParameter("RN")]
        public long Rn
        {
            get;
            private set;
        }

        [StoredParameter("NewStatus")]
        public PermissionMaterialUserState State
        {
            get;
            private set;
        }

        public string Name
        {
            get { return "PMEU_SET_STATE"; }
        }
    }
}