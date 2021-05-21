// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Enums.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the Enums type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Halfblood.Common
{
    public enum SightState : byte
    {
        /// <summary>
        /// "Неутвержден"
        /// </summary>
        NotConfirmed = 0,

        /// <summary>
        /// "Утвержден"
        /// </summary>
        Confirmed = 1,

        /// <summary>
        ///  "Отклонен"
        /// </summary>
        Rejected = 2,

        /// <summary>
        /// "Закрыт"
        /// </summary>
        Closed = 3,

        /// <summary>
        /// "Проблемная"
        /// </summary>
        Problem = 4,

        /// <summary>
        /// Аннулированная
        /// </summary>
        Annulated = 5,

        /// <summary>
        /// Добавил статус из (Закрытых) в Утвержденные
        /// </summary>
        ClosedToConfirmed = 31
    }
    public enum DepartmentOrderState
    {
        /// <summary>
        /// "Неутвержден"
        /// </summary>
        NotConfirmed = 0,

        /// <summary>
        /// "Утвержден"
        /// </summary>
        Confirmed = 1,

        /// <summary>
        ///  "Согласование"
        /// </summary>
        Сonsent = 2,

        /// <summary>
        /// "Закрыт"
        /// </summary>
        Closed = 3,

        /// <summary>
        /// Аннулированная
        /// </summary>
        Annulated = 4,

        /// <summary>
        /// Все
        /// </summary>
        All = 5
    }
    public enum DepartmentOrderSignBlockingOrder
    {
        /// <summary>
        /// "Нет"
        /// </summary>
        Not = 0,

        /// <summary>
        /// "Да"
        /// </summary>
        Yes = 1
    }
    public enum DepartmentOrderPeriodicOrder
    {
        /// <summary>
        /// "Неутвержден"
        /// </summary>
        Single = 0,

        /// <summary>
        /// "Утвержден"
        /// </summary>
        Periodic = 1
    }
    public enum DepartmentOrderConsiderCalendar
    {
        /// <summary>
        /// "Нет"
        /// </summary>
        Not = 0,

        /// <summary>
        /// "Да"
        /// </summary>
        Yes = 1
    }
    public enum DepartmentOrderCorrectionPeriods
    {
        /// <summary>
        /// "Нет"
        /// </summary>
        Not = 0,

        /// <summary>
        /// "Да"
        /// </summary>
        Yes = 1
    }
    public enum DepartmentOrderPeriodType
    {
        /// <summary>
        /// "Дни"
        /// </summary>
        Days = 0,

        /// <summary>
        /// "Неделя"
        /// </summary>
        Week = 1,

        /// <summary>
        ///  "Декада"
        /// </summary>
        Decade = 2,

        /// <summary>
        /// "Месяц"
        /// </summary>
        Month = 3,

        /// <summary>
        /// "Квартал"
        /// </summary>
        Quarter = 4,

        /// <summary>
        /// "Год"
        /// </summary>
        Year = 5
    }
    public enum DepartmentOrderEmergencyOrder
    {
        /// <summary>
        /// "Нет"
        /// </summary>
        Not = 0,

        /// <summary>
        /// "Да"
        /// </summary>
        Yes = 1
    }
    public enum DepartmentOrderContemporaneousPerformance
    {
        /// <summary>
        /// "Нет"
        /// </summary>
        Not = 0,

        /// <summary>
        /// "Да"
        /// </summary>
        Yes = 1
    }
    public enum DepartmentOrderSignsOfConsolidation
    {
        /// <summary>
        /// "Не включен в консолидацию"
        /// </summary>
        ItIsNotIncludedInConsolidation = 0,

        /// <summary>
        /// "Включен в консолидацию"
        /// </summary>
        ItIsIncludedInTheConsolidation = 1,

        /// <summary>
        ///  "Консолидированный"
        /// </summary>
        Consolidated = 2,

        /// <summary>
        /// "Консолидированный и включен в консолидацию"
        /// </summary>
        ItIsConsolidatedAndIncludedInConsolidation = 3
    }

    /// <summary>
    /// признак отработки с приходом
    /// </summary>
    public enum InvoiceForTransmissionInUnitInState : byte
    {
        /// <summary>
        /// "не отработан с приходом"
        /// </summary>
        Not = 0,

        /// <summary>
        /// "отработан с приходом"
        /// </summary>
        Yes = 1,
    }
    public enum InvoiceForTransmissionInUnitState : byte
    {
        /// <summary>
        /// "не отработан"
        /// </summary>
        NotWork = 0,

        /// <summary>
        /// "отработан как факт"
        /// </summary>
        WorkFact = 2,

        /// <summary>
        ///  "отработан как план"
        /// </summary>
        WorkPlan = 1,
    }
    public enum ActInputControlState : byte
    {
        /// <summary>
        /// The new.
        /// </summary>
        New = 0,

        /// <summary>
        /// The close.
        /// </summary>
        Close = 1
    }

    public enum HeatTreatmentCoolingAmbients : byte
    {
        Air = 1,
        Oil = 2,
        Water = 3,
        Furnace = 4
    }

    public enum HeatTreatmentOperations : byte
    {
        Hardening = 1,
        Annealing = 2,
        Normalization =3,
        Preheating = 4,
        Heating = 5,
        ArgonNormalization = 6,
        ArgonQuenching = 7,
        ArgonAnnealing = 8,
        Abatement = 9,
        SubzeroTreatment = 10,
        Aging = 11,
        AgingKD = 12,
        AgingTU = 13,
        Cooling = 14
    }

    public enum TestKinds : byte
    {
        Metallographic = 0,
        Chemical = 1,
        Nondestructive = 2,
        Mechanical = 3
    }

    public enum TestSheetState : byte
    {
        NotСonfirm = 0,
        Confirm = 1,
        Close = 2
    }
    public enum PlanReceiptOrderState : byte { NotСonfirm = 0, Confirm = 1, PartWork = 2, Close = 3 }
    public enum ManufacturersCertificatePassState : byte { FirstState = 0, SecondState = 1 }
    public enum ManufacturersCertificateDestinationState : byte { FirstState = 0, SecondState = 1 }
    public enum ActInputControlDestinationState : byte { New = 0, Close = 1 }
    public enum SpecificationState : byte { New = 0, Close = 1 }
    public enum WorkOrderState : byte { New = 0, Close = 1 }
    public enum PlanCertificateState : byte { NotСonfirm = 0, Confirm = 1, PartWork = 2, Close = 3 }
    public enum PlanReceiptOrderPersonalAccountState : byte { NotСonfirm = 0, Confirm = 1, Close = 2 }
    public enum ContractStatusState : byte { NotApproved = 0, Approved = 1, Cloused = 2 }
    public enum CuttingOrderState : byte { FirstState = 0, SecondState = 1 }
    public enum CuttingOrderPriority : byte { FirstPriority = 0, SecondPriority = 1 }
    public enum CuttingOrderSpecificationState : byte { FirstState = 0, SecondState = 1 }
    public enum ActSelectionOfProbeState : byte { Create = 0, Complete = 1,InitializationSampling =2, SamplingComplate=3, ControlOTK=4, ControlCustomer=5, NonControlСustomer=6, Close=7 }
    public enum ChemicalAnalysisState : byte { FirstState = 0, SecondState = 1 }
    public enum ChemicalAnalysisResultState : byte { FirstState = 0, SecondState = 1 }
    public enum MechanicalTestState : byte { FirstState = 0, SecondState = 1 }
    public enum MechanicalTestCookingSchedState : byte { FirstState = 0, SecondState = 1 }
    public enum MechanicalTestNondestructiveState : byte { FirstState = 0, SecondState = 1 }
    public enum MechanicalTestResultState : byte
    {
        FirstState = 0,
        SecondState = 1
    }
    public enum MetallographicAnalysisCookState : byte
    {
        FirstState = 0,
        SecondState = 1
    }
    public enum MetallographicAnalysisResultAnalysisState : byte
    {
        FirstState = 0,
        SecondState = 1
    }
    public enum MetallographicAnalysisResultTestState : byte
    {
        FirstState = 0,
        SecondState = 1
    }
    public enum NondestructiveTestingState : byte
    {
        FirstState = 0,
        SecondState = 1
    }
    public enum NondestructiveTestingResultState : byte
    {
        FirstState = 0,
        SecondState = 1
    }
    public enum MetallographicAnalysisState : byte
    {
        FirstState = 0,
        SecondState = 1
    }
    public enum PermissionMaterialState : byte
    {
        /// <summary>
        /// "Новый"
        /// </summary>
        New = 0,

        /// <summary>
        /// "Согласуется"
        /// </summary>
        Confirming = 1,

        /// <summary>
        /// "Согласуется продление"
        /// </summary>
        ConfirmingExtension = 2,

        /// <summary>
        /// "Согласован"
        /// </summary>
        Confirmed = 3,

        /// <summary>
        /// "Не согласован"
        /// </summary>
        NotConfirmed = 4,

        /// <summary>
        /// "Закрыт"
        /// </summary>
        Closed = 5
    }
    public enum PermissionMaterialExtensionState : byte
    {
        /// <summary>
        /// "Новый"
        /// </summary>
        New = 0,

        /// <summary>
        /// "Согласуется"
        /// </summary>
        Confirming = 1,

        /// <summary>
        /// "Согласован"
        /// </summary>
        Confirmed = 2,

        /// <summary>
        /// "Не согласован"
        /// </summary>
        NotConfirmed = 3,

        /// <summary>
        /// "Закрыт"
        /// </summary>
        Closed = 4
    }
    public enum PermissionMaterialUserState : byte
    {
        /// <summary>
        /// "В ожидании"
        /// </summary>
        Expecting = 0,

        /// <summary>
        /// "Согласован"
        /// </summary>
        Confirmed = 1,

        /// <summary>
        /// "Не согласован"
        /// </summary>
        NotConfirmed = 2
    }
    public enum StageStatusState : byte { Close = 0, Open = 1, Abolition = 2 }
    public enum WarehouseQualityCertificateState : byte { Open = 0, Close = 1 }
    public enum QualityCertificateState : byte { NotСonfirm = 0, Confirm = 1 }
    public enum CreditSlipState : byte { NotFulfilled = 0, FulfilledPlan = 1, FulfilledFact = 2 }
}