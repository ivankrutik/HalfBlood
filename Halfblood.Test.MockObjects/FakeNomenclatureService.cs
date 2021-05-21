// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FakeNomenclatureService.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the FakeNomenclatureService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Buisness.Filters;

namespace Halfblood.Test.MockObjects
{
    using System.Collections.Generic;
    using Buisness.Entities.CommonDomain;
    using Buisness.Entities.NomenclatorDomain;
    using FizzWare.NBuilder;
    using ServiceContracts.Facades;

    /// <summary>
    /// The fake nomenclature service.
    /// </summary>
    public class FakeNomenclatureService : INomenclatureService
    {
        public virtual IList<NomenclatureNumberDto> GetNomenclatureNumber(NomenclatureNumberFilter filter)
        {
            var dd = Builder<NomenclatureNumberDto>.CreateListOfSize(30).Build();
            dd[0].DicmuntUmeasMain = new UnitOfMeasureDto { Code = "as" };
            return dd;
        }

        public IList<NomenclatureNumberModificationDto> GetNomenclatureNumberModification(NomenclatureNumberModificationFilter filter)
        {
            var dd = Builder<NomenclatureNumberModificationDto>.CreateListOfSize(30).Build();
            return dd;
        }
    }
}
