using System.Collections.Generic;
using System.Windows.Input;
using Buisness.Entities.TestSheetDomain;
using ReactiveUI;

namespace UI.Infrastructure.ViewModels.TestSheetsDomain
{
    public interface IEditableTestResultViewModel : IEditableViewModel<TestResultDto>, IRoutableViewModel
    {
        IList<SampleResultSetDto> ResultSets { get; set; }

        ICommand InsertSampleTestsCommand { get; }
        ICommand InsertAvgSampleTestsCommand { get; }
        ICommand InsertMaxSampleTestsCommand { get; }
        ICommand InsertMinSampleTestsCommand { get; }
        ICommand CloneSampleTestsCommand { get; }
        ICommand DeleteSampleTestsRowCommand { get; }
        ICommand ClearTableCommand { get; }

    }
}