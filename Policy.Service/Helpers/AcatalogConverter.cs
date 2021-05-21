// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AcatalogConverter.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the AcatalogConverter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.InternalService.Helpers
{
    using System.Collections.Generic;
    using System.Linq;

    using Buisness.Entities.CommonDomain;

    using ParusModel.Policy;

    public static class AcatalogConverter
    {
        public static IList<CatalogHierarchical> ConvertToHierarchical(this IList<Acatalog> acatalosRoot)
        {
            if (acatalosRoot == null)
            {
                return null;
            }

            return
                acatalosRoot.Where(x => x.Parent == null)
                    .ToList()
                    .Select(
                        elem =>
                            new CatalogHierarchical
                            {
                                Rn = elem.Rn,
                                Name = elem.Name,
                                Childs = FindChildren(elem.Rn, acatalosRoot)
                            })
                    .ToList();
        }

        public static IList<CatalogHierarchical> SetIsAccess(this IList<Acatalog> accessCatalog, IList<CatalogHierarchical> catalog)
        {
            foreach (var elem in catalog)
            {
                elem.IsAccess = FindChildrenHierarchical(elem, accessCatalog);
            }

            return catalog;
        }

        private static IList<CatalogHierarchical> FindChildren(long rn, IList<Acatalog> acatalosRoot)
        {
            var e = acatalosRoot.Where(x => x.Parent != null && x.Parent.Rn == rn).ToList();
            return
                e.TakeWhile(elem => elem.Parent != null)
                    .Select(
                        elem =>
                        new CatalogHierarchical
                            {
                                Rn = elem.Rn,
                                Name = elem.Name,
                                Childs = FindChildren(elem.Rn, acatalosRoot),
                                IsAccess = false
                            })
                    .ToList();
        }

        private static bool FindChildrenHierarchical(CatalogHierarchical catalog, IList<Acatalog> accessCatalog)
        {
            foreach (var elem in catalog.Childs)
            {
                elem.IsAccess = FindChildrenHierarchical(elem, accessCatalog);
            }

            return accessCatalog.Where(x => x.Rn == catalog.Rn).Any();
        }
    }
}
