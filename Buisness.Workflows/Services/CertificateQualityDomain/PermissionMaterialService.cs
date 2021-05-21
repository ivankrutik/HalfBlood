namespace Buisness.Workflows.Services.CertificateQualityDomain
{
    using Buisness.Entities.PermissionMaterialDomain;
    using Managers;
    using Buisness.Workflows.Managers.CreditSlipDomain;
    using Halfblood.Common;
    using NHibernate.Helper.Filter;
    using NHibernate.Helper.Repository;
    using NHibernate.Helper.Service;
    using ParusModel.Entities;
    using ParusModel.Entities.PermissionMaterialDomain;
    using ServiceContracts.Facades;

    [Register(typeof(IPermissionMaterialService))]
    public class PermissionMaterialService : ServiceBase, IPermissionMaterialService
    {
        private readonly IRepositoryFactory _repositoryFactory;

        public PermissionMaterialService(
            IRepositoryFactory repositoryFactory,
            IFilterStrategyFactory filterStrategyFactory)
            : base(repositoryFactory, filterStrategyFactory)
        {
            _repositoryFactory = repositoryFactory;
        }

        // Разрешение на условный допуск
        public PermissionMaterialDto GetPermissionMaterial(long rn)
        {
            PermissionMaterialDto result = GetEntity<PermissionMaterial, PermissionMaterialDto>(rn);
            return result;
        }
        public PermissionMaterialDto AddPermissionMaterial(PermissionMaterialDto entity)
        {
            return AddEntity<PermissionMaterial, PermissionMaterialDto>(entity);
        }
        public void UpdatePermissionMaterial(PermissionMaterialDto entity)
        {
            UpdateEntity<PermissionMaterial, PermissionMaterialDto>(entity);
        }
        public void RemovePermissionMaterial(long rn)
        {
            RemoveEntity<PermissionMaterial, PermissionMaterialDto>(new PermissionMaterialDto { Rn = rn });
        }

        // Продление разрешения на условный допуск
        public PermissionMaterialExtensionDto GetPermissionMaterialExtension(long rn)
        {
            PermissionMaterialExtensionDto result = GetEntity<PermissionMaterialExtension, PermissionMaterialExtensionDto>(rn);
            return result;
        }
        public PermissionMaterialExtensionDto AddPermissionMaterialExtension(PermissionMaterialExtensionDto entity)
        {
            return AddEntity<PermissionMaterialExtension, PermissionMaterialExtensionDto>(entity);
        }
        public void UpdatePermissionMaterialExtension(PermissionMaterialExtensionDto entity)
        {
            UpdateEntity<PermissionMaterialExtension, PermissionMaterialExtensionDto>(entity);
        }
        public void RemovePermissionMaterialExtension(long rn)
        {
            RemoveEntity<PermissionMaterialExtension, PermissionMaterialExtensionDto>(new PermissionMaterialExtensionDto { Rn = rn });
        }


        // Установка связи между Сертификатом качества и Разрешением на условный допуск
        public void SetDocumentLinks(long rnCertificateQuality, long rnPermissionMaterial)
        {
            var repositoryDocumentLinks = _repositoryFactory.Create<RelationshipBetweenDocuments>();

            var documentLink = new RelationshipBetweenDocuments
            {
                InDocument = rnCertificateQuality,
                OutDocument = rnPermissionMaterial,
                InUnitCode = NamesOfSectionSystem.CertificateQuality,
                OutUnitCode = NamesOfSectionSystem.PermissionMaterial
            };

            repositoryDocumentLinks.Insert(documentLink);
        }

        // Установка статуса у лица из списка для согласования 
        public void SetStatusPermissionMaterialUser(long id, PermissionMaterialUserState newState)
        {
            var entity = GetEntity<ParusModel.Entities.PermissionMaterialDomain.PermissionMaterialUser>(id);
            var manager = new SetStateEntityManagerFactory<ParusModel.Entities.PermissionMaterialDomain.PermissionMaterialUser, PermissionMaterialUserState>(RepositoryFactory).Create();
            manager.SetState(entity, newState, Sense.Full);

            try
            {
                var createCreditSlip = new CreditSlipManager(RepositoryFactory);
                createCreditSlip.Flush();
            }
            finally
            {
                CreditSlipManager.Clean();
            }
        }
    }
}