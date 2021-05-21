// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ActSelectionOfProbeService.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the ActSelectionOfProbeService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Workflows.Services.CertificateQualityDomain
{
    using Buisness.Entities.CertificateQualityDomain.ActSelectionProbeDomain;
    using Halfblood.Common;

    using NHibernate.Helper.Filter;
    using NHibernate.Helper.Repository;
    using NHibernate.Helper.Service;
    using ServiceContracts.Facades;
    using DataAccessLogic.Infrastructure;
    using ParusModel.Entities;
    using ParusModel.Entities.CertificateQualityDomain.ActSelectionOfProbeDomain;
    /// <summary>
    /// The act selection of probe service.
    /// </summary>
    [Register(typeof(IActSelectionOfProbeService))]
    public class ActSelectionOfProbeService : ServiceBase, IActSelectionOfProbeService
    {

        public ActSelectionOfProbeService(
            IRepositoryFactory repositoryFactory,
            IFilterStrategyFactory filterStrategyFactory)
            : base(repositoryFactory, filterStrategyFactory)
        {
        }



        public ActSelectionOfProbeDto GetActSelectionOfProbeDto(long rn)
        {
            var result = GetEntity<ActSelectionOfProbe, ActSelectionOfProbeDto>(rn);
            return result;
        }

        public void UpdateActSelectionOfProbe(ActSelectionOfProbeDto entity)
        {
            UpdateEntity<ActSelectionOfProbe, ActSelectionOfProbeDto>(entity);
        }

        public ActSelectionOfProbeDto AddActSelectionOfProbe(long certificateQualite)
        {
            var repositoryLink = RepositoryFactory.Create<RelationshipBetweenDocuments>();
            var entity = new ActSelectionOfProbe { Catalog = new Catalog(1210980309) };
            var actSelectionOfProbe = AddEntity<ActSelectionOfProbe, ActSelectionOfProbeDto>(entity);

            var documentLink = new RelationshipBetweenDocuments
            {
                InDocument = certificateQualite,
                OutDocument = actSelectionOfProbe.Rn,
                InUnitCode = NamesOfSectionSystem.CertificateQuality,
                OutUnitCode = NamesOfSectionSystem.ActSelectionOfProbe
            };

            repositoryLink.Insert(documentLink);
            return actSelectionOfProbe;
        }

        public void RemoveActSelectionOfProbe(long rn)
        {
            var actSelectionOfProbe = RepositoryFactory.Create<ActSelectionOfProbe>().Get(rn);
            RemoveEntity<ActSelectionOfProbe>(actSelectionOfProbe);
        }

        public ActSelectionOfProbeDepartmentDto GetActSelectionOfProbeDepartmentDto(long rn)
        {
            var result = GetEntity<ActSelectionOfProbeDepartment, ActSelectionOfProbeDepartmentDto>(rn);
            return result;
        }


        public void UpdateActSelectionOfProbeDepartment(ActSelectionOfProbeDepartmentDto entity)
        {
            UpdateEntity<ActSelectionOfProbeDepartment, ActSelectionOfProbeDepartmentDto>(entity);
        }

        public ActSelectionOfProbeDepartmentDto AddActSelectionOfProbeDepartment(ActSelectionOfProbeDepartmentDto entity)
        {
            return AddEntity<ActSelectionOfProbeDepartment, ActSelectionOfProbeDepartmentDto>(entity);
        }

        public void RemoveActSelectionOfProbeDepartment(long rn)
        {
            var actSelectionOfProbeDepartment = RepositoryFactory.Create<ActSelectionOfProbeDepartment>().Get(rn);
            RemoveEntity<ActSelectionOfProbeDepartment>(actSelectionOfProbeDepartment);
        }

        public ActSelectionOfProbeDepartmentRequirementDto GetActSelectionOfProbeDepartmentRequirementDto(long rn)
        {
            var result = GetEntity<ActSelectionOfProbeDepartmentRequirement, ActSelectionOfProbeDepartmentRequirementDto>(rn);
            return result;
        }

        public void UpdateActSelectionOfProbeDepartmentRequirement(ActSelectionOfProbeDepartmentRequirementDto entity)
        {
            UpdateEntity<ActSelectionOfProbeDepartmentRequirement, ActSelectionOfProbeDepartmentRequirementDto>(entity);
        }

        public ActSelectionOfProbeDepartmentRequirementDto AddActSelectionOfProbeDepartmentRequirement(
            ActSelectionOfProbeDepartmentRequirementDto entity)
        {
           return AddEntity<ActSelectionOfProbeDepartmentRequirement, ActSelectionOfProbeDepartmentRequirementDto>(entity);
        }

        public void RemoveActSelectionOfProbeDepartmentRequirement(long rn)
        {
            var actSelectionOfProbeDepartmentRequirement = RepositoryFactory.Create<ActSelectionOfProbeDepartmentRequirement>().Get(rn);
            RemoveEntity<ActSelectionOfProbeDepartmentRequirement>(actSelectionOfProbeDepartmentRequirement);
        }
    }
}