// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PlanReceiptOrderPersonalAccountDto.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the PlanReceiptOrderPersonalAccountDto type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Entities.PlanReceiptOrderDomain
{
    using System;

    using Buisness.Entities.CommonDomain;

    using Halfblood.Common;

    [RelationEntityToDto(NamesOfSectionSystem.PlanReceiptOrderPersonalAccount)]
    public class PlanReceiptOrderPersonalAccountWithoutPlanCertificateDto : IDto<long>
    {
        object IHasUid.Rn { get { return Rn; } }
        public decimal? CountByDocument { get; set; }
        public decimal? CountFact { get; set; }
        public DateTime? CreationDate { get; set; }
        public UserDto UserCreator { get; set; }
        public string Note { get; set; }
        public PlanReceiptOrderPersonalAccountState State { get; set; }
        public DateTime? StateDate { get; set; }
        public UserDto UserSetState { get; set; }
        public CatalogDto Catalog { get; set; }
        public PersonalAccountDto PersonalAccount { get; set; }
        public long Rn { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is PlanReceiptOrderPersonalAccountDto == false) return false;
            if (ReferenceEquals(this, obj)) return true;

            if (ReferenceEquals(this, null) || ReferenceEquals(obj, null))
                return false;

            var order = obj as PlanReceiptOrderPersonalAccountDto;

            return order.Rn == Rn;
        }

        public override int GetHashCode()
        {
            return Rn.GetHashCode();
        }
    }

    [RelationEntityToDto(NamesOfSectionSystem.PlanReceiptOrderPersonalAccount)]
    public class PlanReceiptOrderPersonalAccountDto : PlanReceiptOrderPersonalAccountWithoutPlanCertificateDto
    {
        public PlanCertificateDto PlanCertificate { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is PlanReceiptOrderPersonalAccountDto == false) return false;
            if (ReferenceEquals(this, obj)) return true;

            if (ReferenceEquals(this, null) || ReferenceEquals(obj, null))
                return false;

            var order = obj as PlanReceiptOrderPersonalAccountDto;

            return order.Rn == Rn;
        }

        public override int GetHashCode()
        {
            return Rn.GetHashCode();
        }
    }
}