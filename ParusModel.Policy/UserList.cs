// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserList.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the UserList type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ParusModel.Policy
{
    using Halfblood.Common;

    public class UserList : IHasUid<long>
    {
        public virtual string AUTHID { get; set; }
        public virtual string NAME { get; set; }
        public virtual bool PASSWORDCHANGE { get; set; }
        public virtual long? LOGINENABLED { get; set; }
        public virtual long Rn { get; set; }
        public virtual bool REGISTERSIGN { get; set; }
        public virtual bool USESETTINGSSIGN { get; set; }
        public virtual bool SAVEPASSWORDSIGN { get; set; }
        public virtual bool ANONYMOUS { get; set; }
        public virtual bool BACKGROUND { get; set; }
        public virtual bool CLIENTWIN { get; set; }
        public virtual bool CLIENTWEB { get; set; }
        public virtual string PASSWORDWEB { get; set; }
        public virtual Acatalog Acatalog { get; set; }
        object IHasUid.Rn { get { return AUTHID; } }
    }
}
