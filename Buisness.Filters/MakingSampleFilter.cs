// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MakingSampleFilter.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The making sample filter.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using Buisness.Entities.CommonDomain;
using Filtering.Infrastructure;

namespace Buisness.Filters
{
    using Halfblood.Common;

    /// <summary>
    ///     The making sample filter.
    /// </summary>
    public class MakingSampleFilter : IUserFilter<long>
    {
        /// <summary>
        ///     Gets or sets the requiremens filter.
        /// </summary>
        public long SelectionOfProbe { get; set; }

        public RequiremensFilter RequiremensFilter { get; set; }

        object IHasUid.Rn { get { return Rn; } }

        public long Rn { get; set; }

        public int Skip { get; set; }

        public int Take { get; set; }

        public DateTime? DateCreate { get; set; }

        public UserDto Creator { get; set; }

        public StaffingDivisionDto DepartmentMakingSample { get; set; }

        public UserDto AgentDepartment { get; set; }

        public DateTime? AgentDepartmentDate { get; set; }

        public UserDto ControlerOtk { get; set; }

        public DateTime? ControlerOtkDate { get; set; }

        public UserDto Customer { get; set; }

        public DateTime? CustomerDate { get; set; }

        public UserDto ReceiptLaboratory { get; set; }

        public DateTime? ReceiptLaboratoryDate { get; set; }

        public static MakingSampleFilter Default
        {
            get { return new MakingSampleFilter(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}