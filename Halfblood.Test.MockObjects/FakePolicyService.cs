// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FakePolicyService.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the FakePolicyService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Halfblood.Test.MockObjects
{
    using System;
    using System.Collections.Generic;

    using Buisness.Entities;
    using Buisness.Entities.CommonDomain;

    using FizzWare.NBuilder;

    using Halfblood.Common;

    using ServiceContracts.Facades;

    public class FakePolicyService : IPolicyService
    {
        public CatalogHierarchical GetCatalogHierarchical(Type type, TypeActionInSystem typeActionInSystem)
        {
            var result = Builder<CatalogHierarchical>.CreateNew().Build();
            return result;

        }

        public IList<UnitFunctionDto> GetFunction(Type type, TypeActionInSystem typeActionInSystem, CatalogDto catalog = null)
        {
            throw new NotImplementedException();
        }

        public IList<UnitFunctionDto> GetFunction(Type type, TypeActionInSystem typeActionInSystem, long acatalog)
        {
            throw new NotImplementedException();
        }
    }
}
