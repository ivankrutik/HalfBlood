<<<<<<< HEAD
﻿using System.Security.Cryptography.X509Certificates;
using Buisness.Entities.CommonDomain;
using NHibernate.Criterion;
=======
﻿using Buisness.Entities.CommonDomain;
>>>>>>> 5049427907a50beed91f60e1c9ba603f725d87c5

namespace Buisness.Components.Strategies.CommonDomain
{
    using Buisness.Filters;

    using Halfblood.Common.Helpers;

    using NHibernate;
    using NHibernate.Helper.Filter;
    using NHibernate.Helper.Filter.Specification;


    [FilterForEntity(typeof(EmployeeDto))]
    public class EmployeeFilterStrategy : FilteringStrategyBase<EmployeeDto, EmployeeFilter>
    {

        public override IQueryOver<EmployeeDto, EmployeeDto> Filtering(IQueryOver<EmployeeDto, EmployeeDto> query, EmployeeFilter filter)
        {
<<<<<<< HEAD
            var tmp = filter.Fullname.Replace("*", "%").ToUpper();
            query.Where(Restrictions.Like(Projections.SqlFunction("upper", NHibernateUtil.String, Projections.Property<EmployeeDto>(x => x.Fullname)), tmp));
=======
            query.FindByRn(filter.Rn);

            query.IsLike(x => x.Fullname, filter.Fullname.ReplaceStar(string.Empty));
>>>>>>> 5049427907a50beed91f60e1c9ba603f725d87c5

            return query;
        }
    }
}