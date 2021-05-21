// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PersonalAccountFilter.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the PersonalAccountFilter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using Filtering.Infrastructure;

namespace Buisness.Filters
{
    using Halfblood.Common;

    public class PersonalAccountFilter : IUserFilter<long>
    {
        object IHasUid.Rn { get { return Rn; } }
        public virtual long Rn { get; set; }
        public virtual string Numb { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }

        [Obsolete("Перекретная ссылка на StagesOfTheContractFilter")]
        public static PersonalAccountFilter Default
        {
            get { return new PersonalAccountFilter(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}