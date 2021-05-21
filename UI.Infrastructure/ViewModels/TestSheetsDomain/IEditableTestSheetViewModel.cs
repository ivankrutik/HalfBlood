using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using Buisness.Entities.TestSheetDomain;
using Buisness.Filters.TestSheetsDomain;
using ParusModelLite.TestSheetsDomain;
using ReactiveUI;
using UI.Entities.TestSheetsDomain;

namespace UI.Infrastructure.ViewModels.TestSheetsDomain
{
    public interface IEditableTestSheetViewModel : IEditableViewModel<TestSheet>, IRoutableViewModel
    {
        IList<TestSheetLiteDto> ParentDtoList { get; set; }
        TestSheetLiteDto SelectedDto { get; set; }

        HeatTreatmentDto SelectedHeatTreatment { get; set; }
        TestResultDto SelectedTestResult { get; set; }

        IFilterViewModel<TestResultFilter, TestResultDto> TestResultsFilter { get; }
        IFilterViewModel<HeatTreatmentFilter, HeatTreatmentDto> HeatTreatmentsFilter { get; }

        bool IsVisibleHeatTreatments { get; }

        ICommand HeatTreatmentVisibilityCommand { get; }
        ICommand TableResultsCommand { get; }
        ICommand InsertHeatTreatmentCommand { get; }
        ICommand CloneHeatTreatmentCommand { get; }
        ICommand DeleteHeatTreatmentCommand { get; }
        ICommand InsertTestResultCommand { get; }
        ICommand CloneTestResultCommand { get; }
        ICommand DeleteTestResultCommand { get; }
    }
}