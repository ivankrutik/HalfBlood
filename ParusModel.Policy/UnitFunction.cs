// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnitFunction.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the UnitFunction type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ParusModel.Policy
{
    using System.Collections.Generic;

    using DataAccessLogic.Infrastructure;

    using Halfblood.Common;

    public class UnitFunction : IEntity<long>
    {
        public virtual string Code { get; set; }
        public virtual string Name { get; set; }
        public virtual long Numb { get; set; }
        public virtual int? SPECACTIONTYPE { get; set; }
        public virtual long Rn { get; set; }
        public virtual long? RESID { get; set; }
        public virtual TypeActionInSystem Standard { get; set; }
        public virtual bool? PROCESSMODE { get; set; }
        public virtual bool? TRANSACTMODE { get; set; }
        public virtual bool? REFRESHMODE { get; set; }
        public virtual bool TECHNOLOGY { get; set; }
        public virtual bool AFTERSHOWKIND { get; set; }
        public virtual string AFTERPARAMS { get; set; }
        public virtual bool SHOWDIALOG { get; set; }
        public virtual SectionOfSystem SectionOfSystemUnitcode { get; set; }
        public virtual SectionOfSystem SectionOfSystemMastercode { get; set; }
        public virtual SectionOfSystem SectionOfSystemDetailcode { get; set; }
        public virtual Catalog Catalog { get; protected set; }
        public virtual IList<UserPrivilege> UserPrivileges { get; set; }
        public virtual string NameSectionOfSystem { get; protected set; }
        object IHasUid.Rn { get { return Rn; } }
    }
}