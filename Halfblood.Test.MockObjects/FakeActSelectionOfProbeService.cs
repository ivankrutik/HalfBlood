// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FakeActSelectionOfProbeService.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The fake act selection of probe service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Halfblood.Test.MockObjects
{
    using System;
    using System.Collections.Generic;
    using Buisness.Entities.CertificateQualityDomain.ActSelectionProbeDomain;
    using Buisness.Entities.CommonDomain;
    using FizzWare.NBuilder;

    using ParusModelLite.CertificateQualityDomain.ActSelectionOfProbeDomain;

    using QuickGenerate;
    using ServiceContracts.Facades;

    using Buisness.Entities;
    using Buisness.Filters;

    /// <summary>
    /// The fake act selection of probe service.
    /// </summary>
    public class FakeActSelectionOfProbeService : IActSelectionOfProbeService
    {
        /// <summary>
        /// The i.
        /// </summary>
        private static long i;

        /// <summary>
        /// The get act selection of probe destination.
        /// </summary>
        /// <param name="filter">
        /// The filter.
        /// </param>
        /// <returns>
        /// The <see cref="IList"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public IList<ActSelectionOfProbeDto> GetActSelectionOfProbeDestination(ActSelectionOfProbeFilter filter)
        {
            var result = new DomainGenerator()
                .Many<ActSelectionOfProbeDto>(10);
            return new List<ActSelectionOfProbeDto>(result);
        }

        /// <summary>
        /// The get selection of probe.
        /// </summary>
        /// <param name="filter">
        /// The filter.
        /// </param>
        /// <returns>
        /// The <see cref="IList"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public IList<ActSelectionOfProbeDto> GetSelectionOfProbe(ActSelectionOfProbeFilter filter)
        {
            return Builder<ActSelectionOfProbeDto>.CreateListOfSize(10)
                .All()
                .Do(x => i++)
                .With(x => x.Customer, new UserDto { Firstname = string.Format("User{0}",i) })
                .Build();
        }

        /// <summary>
        /// The get making sample dto.
        /// </summary>
        /// <param name="filter">
        /// The filter.
        /// </param>
        /// <returns>
        /// The <see cref="IList"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public IList<ActSelectionOfProbeDepartmentDto> GetMakingSample(MakingSampleFilter filter)
        {
            return Builder<ActSelectionOfProbeDepartmentDto>.CreateListOfSize(10)
                .All()
                .Do(x => i++)
                .With(x =>x.Customer, new UserDto { Firstname = string.Format("User{0}",i)})
                .Build();
        }

        public IList<ActSelectionOfProbeDepartmentRequirementLiteDto> GetRequirements(RequiremensFilter filter)
        {
            return Builder<ActSelectionOfProbeDepartmentRequirementLiteDto>.CreateListOfSize(10)
                .All()
                .Do(x => i++)
                .With(x=>x.Requirement, string.Format("Назначение{0}", i))
                .Build();
        }

        public IList<ActSelectionOfProbeLiteDto> GetActSelectionOfProbe(ActSelectionOfProbeFilter filter)
        {
            var result = new DomainGenerator()
                .With<ActSelectionOfProbeLiteDto>(x => x.For(c => c.Sample, val => val + 1))
                //.With<AttachedDocumentLiteDto>(x => x.For(c => c.Code, new StringGenerator(5, 7, 'N', 'U')))
                //.OneToOne<AttachedDocumentLiteDto, AttachedDocumentTypeDto>((dto, typeDto) => dto.AttachedDocumentType = typeDto)
                .Many<ActSelectionOfProbeLiteDto>(10);
            return new List<ActSelectionOfProbeLiteDto>(result);
        }

        public ActSelectionOfProbeDto GetActSelectionOfProbeDto(long rn)
        {
            throw new NotImplementedException();
        }

        public void UpdateActSelectionOfProbe(ActSelectionOfProbeDto entity)
        {
            throw new NotImplementedException();
        }

        public ActSelectionOfProbeDto AddActSelectionOfProbe(long certificateQualite)
        {
            var entity= new ActSelectionOfProbeDto {Rn = 999, Catalog = new CatalogDto(1007318777)};
            return entity;
        }

        public void RemoveActSelectionOfProbe(long rn)
        {
            throw new NotImplementedException();
        }

        public ActSelectionOfProbeDepartmentDto GetActSelectionOfProbeDepartmentDto(long rn)
        {
            throw new NotImplementedException();
        }

        public void UpdateActSelectionOfProbeDepartment(ActSelectionOfProbeDepartmentDto entity)
        {
            throw new NotImplementedException();
        }

        public ActSelectionOfProbeDepartmentDto AddActSelectionOfProbeDepartment(ActSelectionOfProbeDepartmentDto entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveActSelectionOfProbeDepartment(long rn)
        {
            throw new NotImplementedException();
        }

        public ActSelectionOfProbeDepartmentRequirementDto GetActSelectionOfProbeDepartmentRequirementDto(long rn)
        {
            throw new NotImplementedException();
        }

        public void UpdateActSelectionOfProbeDepartmentRequirement(ActSelectionOfProbeDepartmentRequirementDto entity)
        {
            throw new NotImplementedException();
        }

        public ActSelectionOfProbeDepartmentRequirementDto AddActSelectionOfProbeDepartmentRequirement(
            ActSelectionOfProbeDepartmentRequirementDto entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveActSelectionOfProbeDepartmentRequirement(long rn)
        {
            throw new NotImplementedException();
        }
    }
}
