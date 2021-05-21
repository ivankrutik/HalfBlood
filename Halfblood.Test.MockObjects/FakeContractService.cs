namespace Halfblood.Test.MockObjects
{
    using System.Collections.Generic;

    using Buisness.Entities.CommonDomain;
    using Buisness.Entities.ContractDomain;
    using Buisness.Filters;

    using FizzWare.NBuilder;

    using ServiceContracts.Facades;

    public class FakeContractService : IContractService
    {
        public IList<ContractDto> GetContractsFilter(ContractFilter filter)
        {
            var d = Builder<ContractDto>.CreateListOfSize(10).Build();
            d[0].StagesOfTheContracts = new List<StagesOfTheContractDto>
                {
                    new StagesOfTheContractDto {PersonalAccount = new PersonalAccountDto {Numb = "0"}}
                };
            d[1].StagesOfTheContracts = new List<StagesOfTheContractDto>
                {
                    new StagesOfTheContractDto {PersonalAccount = new PersonalAccountDto {Numb = "1"}}
                };
            d[2].StagesOfTheContracts = new List<StagesOfTheContractDto>
                {
                    new StagesOfTheContractDto {PersonalAccount = new PersonalAccountDto {Numb = "2"}}
                };
            d[3].StagesOfTheContracts = new List<StagesOfTheContractDto>
                {
                    new StagesOfTheContractDto {PersonalAccount = new PersonalAccountDto {Numb = "3"}}
                };
            return d;
        }
    }
}
