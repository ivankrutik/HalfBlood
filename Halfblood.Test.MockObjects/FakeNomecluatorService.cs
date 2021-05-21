// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FakeNomecluatorService.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the FakeNomecluatorService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Halfblood.Test.MockObjects
{
    using System.Collections.Generic;
    using Buisness.Entities.Common;
    using Buisness.Entities.Filters;
    using Buisness.Entities.Nomenclator;
    using FizzWare.NBuilder;
    using ServiceContracts.Facade;

    /// <summary>
    /// The fake nomecluator service.
    /// </summary>
    public class FakeNomecluatorService : INomecluatorService
    {
        /// <summary>
        /// The get nomenclature number.
        /// </summary>
        /// <param name="filter">
        /// The filter.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public virtual IEnumerable<NomenclatureNumberDto> GetNomenclatureNumber(NomenclatureNumberFilter filter)
        {
            var dd = Builder<NomenclatureNumberDto>.CreateListOfSize(30).Build();
            dd[0].DicmuntUmeasMain = new UnitOfMeasureDto { MEASMNEMO = "as" };
            return dd;
        }
    }
}