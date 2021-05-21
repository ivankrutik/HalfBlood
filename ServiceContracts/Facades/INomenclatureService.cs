namespace ServiceContracts.Facade
{
    using System.Collections.Generic;
    using Buisness.Entities.Filters;
    using Buisness.Entities.Nomenclator;

    public interface INomenclatureService
    {
        IEnumerable<NomenclatureNumberDto> GetNomenclatureNumber(NomenclatureNumberFilter filter);
    }
}
