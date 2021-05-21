// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CatalogHierarchical.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the CatalogHierarchical type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Entities.CommonDomain
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    using Halfblood.Common;

    public class CatalogHierarchical : IDto<long>
    {
        public CatalogHierarchical()
        {
            Childs = new ObservableCollection<CatalogHierarchical>();
        }

        object IHasUid.Rn { get { return Rn; } }
        public string Name { get; set; }
        public bool IsAccess { get; set; }
        public IList<CatalogHierarchical> Childs { get; set; }
        public long Rn { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}