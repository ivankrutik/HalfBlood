// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NamesOfSectionSystem.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The names of section system.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Halfblood.Common
{
    using System.Collections.Generic;

    /// <summary>
    /// The names of section system.
    /// </summary>
    public static class NamesOfSectionSystem
    {
        public static IDictionary<string, string> Names = new Dictionary<string, string>();

        /// <summary>
        /// The plan receipt order.
        /// </summary>
        public const string PlanReceiptOrder = "UDO_PCO";

        public const string ActSelectionOfProbe = "ACT_SELECTION_PROBE";
        public const string PlanReceiptOrderDepartment = "ACT_SELECTION_PROBE_DEPARTMENT";

        /// <summary>
        /// The attached document.
        /// </summary>
        public const string ATTACHED_DOCUMENT = "FileLinks";

        /// <summary>
        /// The certificate quality.
        /// </summary>
        public const string CertificateQuality = "QUALITY_CERTIFICATE";

        public const string WarehouseQualityCertificate = "QUALITY_CERTIFICATE_OUT";
        /// <summary>
        /// The Permission for Material
        /// </summary>
        public const string PermissionMaterial = "Permission_For_Use_Material";
        public const string PlanReceiptOrderPersonalAccount = "UDO_PCOPERSACC";
        public const string SightInventoryHoldings = "UDO_SIGHT";
        public const string DepartmentsOrder = "DepartmentsOrders";
        public const string TradeReports = "TradeReports";
        public const string TradeReportsSp = "TradeReportsSp";
        public const string StoreOpersJournal = "StoreOpersJournal";
        public const string ExpenditureInvoice = "GoodsTransInvoicesToDepts";

        public const string CreditSlipSpecification = "IncomingOrdersSpecs";
        public const string CreditSlip = "IncomingOrders";
        

        static NamesOfSectionSystem()
        {
            Names.Add(PlanReceiptOrder, "Плановый ПО");
            Names.Add(ATTACHED_DOCUMENT, "Прикрепленные документы");
            Names.Add(TradeReportsSp, "Товарный отчет спецификация");
            Names.Add(StoreOpersJournal, "Журнал складских операций");
            Names.Add(TradeReports, "Товарный отчет");
            Names.Add(ActSelectionOfProbe, "Акт отбора проб");
        }

     
    }
}
