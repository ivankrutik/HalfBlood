namespace Buisness.Components.Strategies.CommonDomain
{
    using Buisness.Filters;
    using NHibernate;
    using NHibernate.Helper.Filter;
    using NHibernate.Helper.Filter.Specification;

    using ParusModel.Entities;

     [FilterForEntity(typeof(UnitOfMeasure))]
    public class UnitOfMeasureFilteringStrategy:FilteringStrategyBase<UnitOfMeasure, UnitOfMeasureFilter>
    {
         public override IQueryOver<UnitOfMeasure, UnitOfMeasure> Filtering(IQueryOver<UnitOfMeasure, UnitOfMeasure> query, UnitOfMeasureFilter filter)
         {
             query.FindByRn(filter.Rn);

             if (!string.IsNullOrWhiteSpace(filter.Code))
             {
                 query.Where(x => x.Code == filter.Code);
             }

             query = query.OrderBy(x => x.Code).Asc;

             return query;
         }
    }
}
