// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DictionaryPass.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the DictionaryPass type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ParusModelLite.CertificateQualityDomain
{
    using System;

    using Halfblood.Common;

    public class DictionaryPassLiteDto : IDto<long>
    {
        public virtual long Rn { get; set; }
        public virtual DateTime? CreationDate { get; set; }
        public virtual string Pass { get; set; }
        public virtual string MemoPass { get; set; }
        object IHasUid.Rn { get { return Rn; } }
    }
}
