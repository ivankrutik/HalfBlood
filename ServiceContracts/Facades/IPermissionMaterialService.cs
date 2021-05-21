namespace ServiceContracts.Facades
{
    using Buisness.Entities.PermissionMaterialDomain;
    using Halfblood.Common;

    public interface IPermissionMaterialService
    {
        PermissionMaterialDto GetPermissionMaterial(long rn);
        PermissionMaterialDto AddPermissionMaterial(PermissionMaterialDto entity);
        void UpdatePermissionMaterial(PermissionMaterialDto entity);
        void RemovePermissionMaterial(long rn);

        PermissionMaterialExtensionDto GetPermissionMaterialExtension(long rn);
        PermissionMaterialExtensionDto AddPermissionMaterialExtension(PermissionMaterialExtensionDto entity);
        void UpdatePermissionMaterialExtension(PermissionMaterialExtensionDto entity);
        void RemovePermissionMaterialExtension(long rn);

        void SetDocumentLinks(long rnCertificateQuality, long rnPermissionMaterial);

        void SetStatusPermissionMaterialUser(long id, PermissionMaterialUserState newState);
    }
}