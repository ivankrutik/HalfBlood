// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CuttingOrderDto.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the CuttingOrderDto type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Entities.CuttingOrderDomain
{
    using System;
    using System.Collections.Generic;

    using Buisness.Entities.CommonDomain;

    using Halfblood.Common;

    /// <summary>
    ///     The cutting order dto.
    /// </summary>
    public class CuttingOrderDto : IDto<long>
    {
        object IHasUid.Rn { get { return Rn; } }

        /// <summary>
        ///     Gets or sets the numb.
        /// </summary>
        public decimal? Numb { get; set; }

        /// <summary>
        ///     Gets or sets the pref.
        /// </summary>
        public string Pref { get; set; }

        /// <summary>
        ///     Gets or sets the state.
        /// </summary>
        public CuttingOrderState State { get; set; }

        /// <summary>
        ///     Gets or sets the note.
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        ///     Gets or sets the date document integration.
        /// </summary>
        public DateTime? DateDocumentIntegration { get; set; }

        /// <summary>
        ///     Gets or sets the priority.
        /// </summary>
        public CuttingOrderPriority Priority { get; set; }

        /// <summary>
        ///     Gets or sets the creation date.
        /// </summary>
        public DateTime? CreationDate { get; set; }

        /// <summary>
        ///     Gets or sets the assume date.
        /// </summary>
        public DateTime? AssumeDate { get; set; }

        /// <summary>
        ///     Gets or sets the department.
        /// </summary>
        public StaffingDivisionDto Department { get; set; }

        /// <summary>
        ///     Gets or sets the district.
        /// </summary>
        public StaffingDivisionDto District { get; set; }

        /// <summary>
        ///     Gets or sets the storekeeper.
        /// </summary>
        public UserDto Storekeeper { get; set; }

        /// <summary>
        ///     Gets or sets the inspector.
        /// </summary>
        public UserDto Inspector { get; set; }

        /// <summary>
        ///     Gets or sets the creator.
        /// </summary>
        public UserDto Creator { get; set; }

        /// <summary>
        ///     Gets or sets the specifications.
        /// </summary>
        public IList<CuttingOrderSpecificationDto> Specifications { get; set; }

        /// <summary>
        ///     Gets or sets the last move date.
        /// </summary>
        public string LastMoveDate { get; set; }

        /// <summary>
        ///     Gets or sets the last move recipient document.
        /// </summary>
        public string LastMoveRecipientDocument { get; set; }

        /// <summary>
        ///     Gets or sets the packer.
        /// </summary>
        public UserDto Packer { get; set; }

        /// <summary>
        ///     Gets or sets the acatalog.
        /// </summary>
        public CatalogDto Catalog { get; set; }

        /// <summary>
        ///     Gets or sets the moves.
        /// </summary>
        public IList<CuttingOrderMoveDto> Moves { get; set; }

        /// <summary>
        ///     Gets or sets the rn.
        /// </summary>
        public long Rn { get; set; }
    }
}