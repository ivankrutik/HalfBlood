using Buisness.Filters;
using Halfblood.Common;
using ParusModelLite.CertificateQualityDomain.PermissionMaterialDomain;

namespace Halfblood.Test.MockObjects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Buisness.Entities.PermissionMaterialDomain;
    using QuickGenerate;
    using ServiceContracts.Facades;

    public class FakePermissionMaterialService : IPermissionMaterialService
    {
        public IList<PermissionMaterialLiteDto> GetPermissionMaterialFilter(PermissionMaterialFilter filter)
        {
            var result = new DomainGenerator()
                 .With<PermissionMaterialLiteDto>(x => x.For(c => c.Rn, (long)0, val => val + 1))
                 .With<PermissionMaterialLiteDto>(x => x.For(c => (decimal)c.Count, (decimal)0, val => val + 1))
                 .With<PermissionMaterialLiteDto>(x => x.For(c => c.AcceptToDate, new DateTime()))
                 .With<PermissionMaterialLiteDto>(x => x.For(c => c.Note, "SD"))
                 .Many<PermissionMaterialLiteDto>(10);

            return result.ToList();
        }

        public PermissionMaterialDto GetPermissionMaterial(long rn)
        {
            var result = new DomainGenerator()
                .With<PermissionMaterialDto>(x => x.For(c => c.Rn, rn))
                .OneToMany<PermissionMaterialDto, PermissionMaterialExtensionDto>(1, 10, (x, y) => x.PermissionMaterialExtensions = GetPermissionMaterialExtensionFilter(null))
                .One<PermissionMaterialDto>();
            return result;
        }

        public void UpdatePermissionMaterial(PermissionMaterialDto entity)
        {

        }

        public PermissionMaterialDto AddPermissionMaterial(PermissionMaterialDto entity)
        {
            entity.Rn = 10;
            return entity;
        }

        public void RemovePermissionMaterial(long rn)
        {
            
        }

        public IList<PermissionMaterialExtensionDto> GetPermissionMaterialExtensionFilter(PermissionMaterialExtensionFilter filter)
        {
            var result = new DomainGenerator()
                 .With<PermissionMaterialExtensionDto>(x => x.For(c => c.Rn, (long)0, val => val + 1))
                 .Many<PermissionMaterialExtensionDto>(10);
            return result.ToList();
        }

        public PermissionMaterialExtensionDto GetPermissionMaterialExtension(long rn)
        {
            var result = new DomainGenerator()
                 .With<PermissionMaterialExtensionDto>(x => x.For(c => c.Rn, rn))
                  .One<PermissionMaterialExtensionDto>();
            return result;
        }

        public void UpdatePermissionMaterialExtension(PermissionMaterialExtensionDto entity)
        {

        }

        public PermissionMaterialExtensionDto AddPermissionMaterialExtension(PermissionMaterialExtensionDto entity)
        {
            entity.Rn = 10;
            return entity;
        }

        public void RemovePermissionMaterialExtension(long  rn)
        {
            
        }

        public PermissionMaterialUserDto InsertPermissionMaterialUser(PermissionMaterialUserDto entity)
        {
            throw new NotImplementedException();
        }

        public void RemovePermissionMaterialUser(long rn)
        {
            throw new NotImplementedException();
        }

        public PermissionMaterialExtensionUserDto InsertPermissionMateriaExtensionlUser(PermissionMaterialExtensionUserDto entity)
        {
            throw new NotImplementedException();
        }

        public void RemovePermissionMaterialExtensionUser(long rn)
        {
            throw new NotImplementedException();
        }

        public void SetDocumentLinks(long rnCertificateQuality, long rnPermissionMaterial)
        {
            throw new NotImplementedException();
        }

        public void SetStatusPermissionMaterialUser(long id, PermissionMaterialUserState newState)
        {
            throw new NotImplementedException();
        }
    }
}
