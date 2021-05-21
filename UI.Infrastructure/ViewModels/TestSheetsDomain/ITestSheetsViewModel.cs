// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ITestSheetsViewModel.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the ITestSheetsViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Windows.Input;
using Buisness.Filters.TestSheetsDomain;
using ParusModelLite.TestSheetsDomain;
using ReactiveUI;

namespace UI.Infrastructure.ViewModels.TestSheetsDomain
{
    public interface ITestSheetsViewModel : IRoutableViewModel
    {
        bool IsBusy { get; set; }

        IFilterViewModel<TestSheetFilter, TestSheetLiteDto> TestSheetsFilter { get; }

        TestSheetLiteDto SelectedTestSheetLiteDto { get; set; }

        ICommand InsertTestSheetCommand { get; }
        ICommand UpdateTestSheetCommand { get; }
        ICommand DeleteTestSheetCommand { get; }
    }
}