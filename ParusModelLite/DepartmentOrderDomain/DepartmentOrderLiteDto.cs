namespace ParusModelLite.DepartmentOrderDomain
{
    using System;

    using Halfblood.Common;

    public class DepartmentOrderLiteDto : IDto<long>
    {
        public long Rn { get; set; }
        public string Ordpref { get; set; }
        public string Ordnumb { get; set; }
        public string StoreGasStationOilDepot { get; set; }
        public DateTime Orddate { get; set; }
        public string State { get; set; }
        public string StateDate { get; set; }
        public string StaffingDivision_SUBDIV { get; set; }
        public string NomenclatureNumber { get; set; }
        public string Dopusk { get; set; }
        public int MainQuant { get; set; }
        public int AllowQuant { get; set; }
        public int NumberOfIssued { get; set; }
        public string CommentShop { get; set; }
        public string CommentGoodsManager { get; set; }
        public string CommentTovForCex { get; set; }
        public string CommnetStore { get; set; }
        public string Urgently { get; set; }
        public string AgnlistGoodsManager { get; set; }
        public string AgnlistCreator { get; set; }
        public string Agnlist_AGENT { get; set; }
        public string StaffingDivision_ACC_SUBDIV { get; set; }
        object IHasUid.Rn { get { return Rn; } }
    }
}
