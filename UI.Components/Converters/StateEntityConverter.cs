using System.Diagnostics.Eventing.Reader;

namespace UI.Components.Converters
{
    using Halfblood.Common;
    using System;
    using System.Windows.Data;
    using UI.Resources;

    public class PlanReceiptOrderStateConverter : IValueConverter
    {
        private static PlanReceiptOrderStateConverter _instance;

        /// <summary>
        /// Gets the instance.
        /// </summary>
        public static PlanReceiptOrderStateConverter Instance
        {
            get { return _instance ?? (_instance = new PlanReceiptOrderStateConverter()); }
        }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return value;
            switch ((PlanReceiptOrderState)value)
            {
                case PlanReceiptOrderState.Close: { value = StateEntity.PlanReceiptOrderStateClose; break; }
                case PlanReceiptOrderState.Confirm: { value = StateEntity.PlanReceiptOrderStateConfirm; break; }
                case PlanReceiptOrderState.NotСonfirm: { value = StateEntity.PlanReceiptOrderStateNotСonfirm; break; }
                case PlanReceiptOrderState.PartWork: { value = StateEntity.PlanReceiptOrderStatePartWork; break; }
                default: { value = StateEntity.NotFound; break; }
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class PlanCertificateStateConverter : IValueConverter
    {
        private static PlanCertificateStateConverter _instance;

        /// <summary>
        /// Gets the instance.
        /// </summary>
        public static PlanCertificateStateConverter Instance
        {
            get { return _instance ?? (_instance = new PlanCertificateStateConverter()); }
        }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return value;
            switch ((PlanCertificateState)value)
            {
                case PlanCertificateState.Close: { value = StateEntity.PlanCertificateStateClose; break; }
                case PlanCertificateState.Confirm: { value = StateEntity.PlanCertificateStateConfirm; break; }
                case PlanCertificateState.NotСonfirm: { value = StateEntity.PlanCertificateStateNotСonfirm; break; }
                case PlanCertificateState.PartWork: { value = StateEntity.PlanCertificateStatePartWork; break; }
                default: { value = StateEntity.NotFound; break; }
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class PlanReceiptOrderPersonalAccountStateConverter : IValueConverter
    {
        private static PlanReceiptOrderPersonalAccountStateConverter _instance;

        /// <summary>
        /// Gets the instance.
        /// </summary>
        public static PlanReceiptOrderPersonalAccountStateConverter Instance
        {
            get { return _instance ?? (_instance = new PlanReceiptOrderPersonalAccountStateConverter()); }
        }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return value;
            switch ((PlanReceiptOrderPersonalAccountState)value)
            {
                case PlanReceiptOrderPersonalAccountState.Close: { value = StateEntity.PlanReceiptOrderPersonalAccountStateClose; break; }
                case PlanReceiptOrderPersonalAccountState.Confirm: { value = StateEntity.PlanReceiptOrderPersonalAccountStateConfirm; break; }
                case PlanReceiptOrderPersonalAccountState.NotСonfirm: { value = StateEntity.PlanReceiptOrderPersonalAccountStateNotСonfirm; break; }
                default: { value = StateEntity.NotFound; break; }
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class ContractStateConverter : IValueConverter
    {
        private static ContractStateConverter _instance;

        /// <summary>
        /// Gets the instance.
        /// </summary>
        public static ContractStateConverter Instance
        {
            get { return _instance ?? (_instance = new ContractStateConverter()); }
        }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return value;
            switch ((ContractStatusState)value)
            {
                case ContractStatusState.Approved: { value = StateEntity.ContractStateApproved; break; }
                case ContractStatusState.NotApproved: { value = StateEntity.ContractStateNotApproved; break; }
                case ContractStatusState.Cloused: { value = StateEntity.ContractStateClose; break; }
                default: { value = StateEntity.NotFound; break; }
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class ContractStageStateConverter : IValueConverter
    {
        private static ContractStageStateConverter _instance;

        /// <summary>
        /// Gets the instance.
        /// </summary>
        public static ContractStageStateConverter Instance
        {
            get { return _instance ?? (_instance = new ContractStageStateConverter()); }
        }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return value;
            switch ((StageStatusState)value)
            {
                case StageStatusState.Close: { value = StateEntity.ContractStageStateClose; break; }
                case StageStatusState.Abolition: { value = StateEntity.ContractStageStateAbolition; break; }
                case StageStatusState.Open: { value = StateEntity.ContractStageStateOpen; break; }
                default: { value = StateEntity.NotFound; break; }
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class WarehouseQualityCertificateStateConverter : IValueConverter
    {
        private static WarehouseQualityCertificateStateConverter _instance;

        /// <summary>
        /// Gets the instance.
        /// </summary>
        public static WarehouseQualityCertificateStateConverter Instance
        {
            get { return _instance ?? (_instance = new WarehouseQualityCertificateStateConverter()); }
        }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return value;
            switch ((WarehouseQualityCertificateState)value)
            {
                case WarehouseQualityCertificateState.Close: { value = StateEntity.ContractStageStateClose; break; }
                case WarehouseQualityCertificateState.Open: { value = StateEntity.ContractStageStateOpen; break; }
                default: { value = StateEntity.NotFound; break; }
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class QualityCertificateStateConverter : IValueConverter
    {
        private static QualityCertificateStateConverter _instance;

        /// <summary>
        /// Gets the instance.
        /// </summary>
        public static QualityCertificateStateConverter Instance
        {
            get { return _instance ?? (_instance = new QualityCertificateStateConverter()); }
        }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return value;
            switch ((QualityCertificateState)value)
            {
                case QualityCertificateState.NotСonfirm: { value = StateEntity.QualityCertificateStateNotСonfirm; break; }
                case QualityCertificateState.Confirm: { value = StateEntity.QualityCertificateStateСonfirm; break; }
                default: { value = StateEntity.NotFound; break; }
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class HeatTreatmentOperationConverter : IValueConverter
    {
        private static HeatTreatmentOperationConverter _instance;

        /// <summary>
        /// Gets the instance.
        /// </summary>
        public static HeatTreatmentOperationConverter Instance
        {
            get { return _instance ?? (_instance = new HeatTreatmentOperationConverter()); }
        }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null) return StateEntity.NotFound;
            if (string.IsNullOrEmpty(value.ToString()))
                return StateEntity.NotFound;

            switch ((HeatTreatmentOperations)value)
            {
                case HeatTreatmentOperations.Hardening: { value = StateEntity.HeatTreatmentOperationHardening; break; }
                case HeatTreatmentOperations.Annealing: { value = StateEntity.HeatTreatmentOperationAnnealing; break; }
                case HeatTreatmentOperations.Normalization: { value = StateEntity.HeatTreatmentOperationNormalization; break; }
                case HeatTreatmentOperations.Preheating: { value = StateEntity.HeatTreatmentOperationPreheating; break; }
                case HeatTreatmentOperations.Heating: { value = StateEntity.HeatTreatmentOperationHeating; break; }
                case HeatTreatmentOperations.ArgonNormalization: { value = StateEntity.HeatTreatmentOperationArgonNormalization; break; }
                case HeatTreatmentOperations.ArgonQuenching: { value = StateEntity.HeatTreatmentOperationArgonQuenching; break; }
                case HeatTreatmentOperations.ArgonAnnealing: { value = StateEntity.HeatTreatmentOperationArgonAnnealing; break; }
                case HeatTreatmentOperations.Abatement: { value = StateEntity.HeatTreatmentOperationAbatement; break; }
                case HeatTreatmentOperations.SubzeroTreatment: { value = StateEntity.HeatTreatmentSubzero; break; }
                case HeatTreatmentOperations.AgingKD: { value = StateEntity.HeatTreatmentAgingKD; break; }
                case HeatTreatmentOperations.AgingTU: { value = StateEntity.HeatTreatmentAgingTU; break; }
                case HeatTreatmentOperations.Aging: { value = StateEntity.HeatTreatmentAging; break; }
                case HeatTreatmentOperations.Cooling: { value = StateEntity.HeatTreatmentOperationCooling; break; }
                default: { value = StateEntity.NotFound; break; }
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class HeatTreatmentCoolingConverter : IValueConverter
    {
        private static HeatTreatmentCoolingConverter _instance;

        /// <summary>
        /// Gets the instance.
        /// </summary>
        public static HeatTreatmentCoolingConverter Instance
        {
            get { return _instance ?? (_instance = new HeatTreatmentCoolingConverter()); }
        }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null) return StateEntity.NotFound;
            if (string.IsNullOrEmpty(value.ToString()))
                return StateEntity.NotFound;

            switch ((HeatTreatmentCoolingAmbients)value)
            {

                case HeatTreatmentCoolingAmbients.Air: { value = StateEntity.HeatTreatmentCoolingAir; break; }
                case HeatTreatmentCoolingAmbients.Oil: { value = StateEntity.HeatTreatmentCoolingOil; break; }
                case HeatTreatmentCoolingAmbients.Water: { value = StateEntity.HeatTreatmentCoolingWater; break; }
                case HeatTreatmentCoolingAmbients.Furnace: { value = StateEntity.HeatTreatmentCoolingFurnace; break; }
                default: { value = StateEntity.NotFound; break; }
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class TestKindConverter : IValueConverter
    {
        private static TestKindConverter _instance;

        /// <summary>
        /// Gets the instance.
        /// </summary>
        public static TestKindConverter Instance
        {
            get { return _instance ?? (_instance = new TestKindConverter()); }
        }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null) return StateEntity.NotFound;
            if (string.IsNullOrEmpty(value.ToString()))
                return StateEntity.NotFound;

            switch ((TestKinds)value)
            {
                case TestKinds.Metallographic: { value = StateEntity.TestKindMetallographic; break; }
                case TestKinds.Chemical: { value = StateEntity.TestKindChemical; break; }
                case TestKinds.Nondestructive: { value = StateEntity.TestKindNondestructive; break; }
                case TestKinds.Mechanical: { value = StateEntity.TestKindMechanical; break; }
                default: { value = StateEntity.NotFound; break; }
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class TestSheetStateConverter : IValueConverter
    {
        private static TestSheetStateConverter _instance;

        /// <summary>
        /// Gets the instance.
        /// </summary>
        public static TestSheetStateConverter Instance
        {
            get { return _instance ?? (_instance = new TestSheetStateConverter()); }
        }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null) return StateEntity.NotFound;
            if (string.IsNullOrEmpty(value.ToString()))
                return StateEntity.NotFound;

            switch ((TestSheetState)value)
            {
                case TestSheetState.NotСonfirm: { value = StateEntity.TestSheetStateNotConfirm; break; }
                case TestSheetState.Confirm: { value = StateEntity.TestSheetStateConfirm; break; }
                case TestSheetState.Close: { value = StateEntity.TestSheetStateClose; break; }
                default: { value = StateEntity.NotFound; break; }
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class PermissionMaterialStateConverter : IValueConverter
    {
        private static PermissionMaterialStateConverter _instance;

        public static PermissionMaterialStateConverter Instance
        {
            get { return _instance ?? (_instance = new PermissionMaterialStateConverter()); }
        }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null) return null;
            switch ((PermissionMaterialState)value)
            {
                case PermissionMaterialState.New: { value = StateEntity.PermissionMaterialStateNew; break; }
                case PermissionMaterialState.Confirming: { value = StateEntity.PermissionMaterialStateConfirming; break; }
                case PermissionMaterialState.ConfirmingExtension: { value = StateEntity.PermissionMaterialStateConfirmingExtension; break; }
                case PermissionMaterialState.Confirmed: { value = StateEntity.PermissionMaterialStateConfirmed; break; }
                case PermissionMaterialState.NotConfirmed: { value = StateEntity.PermissionMaterialStateNotConfirmed; break; }
                case PermissionMaterialState.Closed: { value = StateEntity.PermissionMaterialStateClosed; break; }
                default: { value = StateEntity.NotFound; break; }
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class PermissionMaterialExtensionStateConverter : IValueConverter
    {
        private static PermissionMaterialExtensionStateConverter _instance;

        public static PermissionMaterialExtensionStateConverter Instance
        {
            get { return _instance ?? (_instance = new PermissionMaterialExtensionStateConverter()); }
        }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null) return null;
            switch ((PermissionMaterialExtensionState)value)
            {
                case PermissionMaterialExtensionState.New: { value = StateEntity.PermissionMaterialExtensionStateNew; break; }
                case PermissionMaterialExtensionState.Confirming: { value = StateEntity.PermissionMaterialExtensionStateConfirming; break; }
                case PermissionMaterialExtensionState.Confirmed: { value = StateEntity.PermissionMaterialExtensionStateConfirmed; break; }
                case PermissionMaterialExtensionState.NotConfirmed: { value = StateEntity.PermissionMaterialExtensionStateNotConfirmed; break; }
                case PermissionMaterialExtensionState.Closed: { value = StateEntity.PermissionMaterialExtensionStateClosed; break; }
                default: { value = StateEntity.NotFound; break; }
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class PermissionMaterialUserStateConverter : IValueConverter
    {
        private static PermissionMaterialUserStateConverter _instance;

        public static PermissionMaterialUserStateConverter Instance
        {
            get { return _instance ?? (_instance = new PermissionMaterialUserStateConverter()); }
        }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null) return null;
            switch ((PermissionMaterialUserState)value)
            {
                case PermissionMaterialUserState.Expecting: { value = StateEntity.PermissionMaterialUserStateExpecting; break; }
                case PermissionMaterialUserState.Confirmed: { value = StateEntity.PermissionMaterialUserStateConfirmed; break; }
                case PermissionMaterialUserState.NotConfirmed: { value = StateEntity.PermissionMaterialUserStateNotConfirmed; break; }
                default: { value = StateEntity.NotFound; break; }
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class ActSelectionOfProbeStateConverter : IValueConverter
    {
        private static ActSelectionOfProbeStateConverter _instance;

        public static ActSelectionOfProbeStateConverter Instance
        {
            get { return _instance ?? (_instance = new ActSelectionOfProbeStateConverter()); }
        }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null) return null;
            switch ((ActSelectionOfProbeState)value)
            {
                case ActSelectionOfProbeState.Create: { value = StateEntity.ActSelectionOfProbeStateCreate; break; }
                case ActSelectionOfProbeState.Complete: { value = StateEntity.ActSelectionOfProbeStateComplete; break; }
                case ActSelectionOfProbeState.InitializationSampling: { value = StateEntity.ActSelectionOfProbeStateInitializationSampling; break; }
                case ActSelectionOfProbeState.SamplingComplate: { value = StateEntity.ActSelectionOfProbeStateSamplingComplate; break; }
                case ActSelectionOfProbeState.ControlOTK: { value = StateEntity.ActSelectionOfProbeStateControlOTK; break; }
                case ActSelectionOfProbeState.ControlCustomer: { value = StateEntity.ActSelectionOfProbeStateControlCustomer; break; }
                case ActSelectionOfProbeState.NonControlСustomer: { value = StateEntity.ActSelectionOfProbeStateNonControlCustomer; break; }
                case ActSelectionOfProbeState.Close: { value = StateEntity.ActSelectionOfProbeStateClose; break; }
                default: { value = StateEntity.NotFound; break; }
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}