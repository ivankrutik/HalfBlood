namespace Buisness.Components.StoredProcedure.CertificateQualityDomain.PermissionMaterialDomain
{
    using Halfblood.Common;
    using NHibernate.Helper;
    using ParusModel.Entities.PermissionMaterialDomain;

    public class PermissionMaterialUserSetStateSP : IStoredProcedure
    {
        public PermissionMaterialUserSetStateSP(
            PermissionMaterialUser permissionMaterialUser,
            PermissionMaterialUserState state)
        {
            Rn = permissionMaterialUser.Rn;
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
            get { return "PMU_SET_STATE"; }
        }
    }
}