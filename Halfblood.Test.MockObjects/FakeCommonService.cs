// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FakeCommonService.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the FakeCommonService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------


namespace Halfblood.Test.MockObjects
{
    using System;
    using System.Collections.Generic;

    using Buisness.Entities;
    using Buisness.Entities.CommonDomain;
    using Buisness.Entities.ContractDomain;
    using Buisness.Filters;

    using Filtering.Infrastructure;

    using FizzWare.NBuilder;

    using Halfblood.Common;

    using ParusModelLite.CommonDomain;

    using QuickGenerate;
    using QuickGenerate.Primitives;

    using ServiceContracts.Facades;

    public class FakeCommonService : ICommonService
    {
        public virtual IList<UserDto> GetUsers(UserFilter filter)
        {
            return Builder<UserDto>.CreateListOfSize(10).Build();
        }

        public virtual IList<PersonalAccountDto> GetPersonalAccountFilter(PersonalAccountFilter filter)
        {
            var result = new DomainGenerator()
                .With<PersonalAccountDto>(x => x.For(c => c.Rn, (long)0, val => val + 1))
                .With<PersonalAccountDto>(x => x.For(c => c.Numb, new StringGenerator(5, 7, 'N', 'U')))
                .OneToOne<PersonalAccountDto, StagesOfTheContractDto>((personalAccount, stagesOfTheContract) => personalAccount.StagesOfTheContract = stagesOfTheContract)
                .OneToOne<StagesOfTheContractDto, ContractDto>((dto, contractDto) => dto.Contract = contractDto)
                .Many<PersonalAccountDto>(10);
            return new List<PersonalAccountDto>(result);
        }

        public IList<TypeOfDocumentDto> GetTypeOfDocumentFilter(TypeOfDocumentFilter filter)
        {
            var result = new DomainGenerator()
                .With<TypeOfDocumentDto>(x => x.For(c => c.Code, new StringGenerator(1, 3, 'D', 'O')))
                .With<TypeOfDocumentDto>(x => x.For(c => c.Name, new StringGenerator(1, 4, 'D', 'N')))
                .Many<TypeOfDocumentDto>(10);
            return new List<TypeOfDocumentDto>(result);
        }

        public IList<CatalogDto> GetAcatalogFilter(IDto editableObject, TypeActionInSystem typeActionInSystem)
        {
            //            var result = new DomainGenerator()
            //                .With<AcatalogDto>(x => x.For(c => c.Name, new StringGenerator(1, 4, 'N', 'A'))).Many<AcatalogDto>(10);
            var result = Builder<CatalogDto>.CreateListOfSize(10).Build();
            return result;
        }

        public IList<StoreLiteDto> GetStoreGasStationOilDepotFilter(StoreGasStationOilDepotFilter filter)
        {
            var result = Builder<StoreLiteDto>.CreateListOfSize(10).Build();
            return result;
        }

        public IList<NameOfCurrencyDto> GetCurrencies()
        {
            return Builder<NameOfCurrencyDto>.CreateListOfSize(10).Build();
        }

        public IList<LinkDto> GetLinkForWorkflow(LinkFilter filter)
        {
            var result = new DomainGenerator()
              .With<LinkDto>(x => x.For(c => c.InDocument,(long)1, val => val + 1 ))
              .With<LinkDto>(x => x.For(c => c.OutDocument, (long)3, val => val + 1))
              .Many<LinkDto>(10);
            return new List<LinkDto>(result);
        }

        public IList<IDto> Filtering(Type type, IUserFilter filter)
        {
            return new List<IDto>();
        }
    }
}
