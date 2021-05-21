using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Reactive.Linq;
using System.Windows;
using System.Windows.Input;
using Buisness.Entities.TestSheetDomain;
using Buisness.Filters.TestSheetsDomain;
using Halfblood.Common.Helpers;
using Halfblood.Common.Mappers;
using ParusModelLite.TestSheetsDomain;
using ReactiveUI;
using ServiceContracts;
using ServiceContracts.Facades;
using UI.Components.Converters;
using UI.Entities.TestSheetsDomain;
using UI.Infrastructure;
using UI.Infrastructure.ViewModels;
using UI.Infrastructure.ViewModels.Filters;
using UI.Infrastructure.ViewModels.TestSheetsDomain;
using UI.ProcessComponents.EditViewModels;

namespace UI.ProcessComponents.TestSheetsDomain
{
    // Редактирование испытательного листа
    [Export(typeof (IEditableTestSheetViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class EditableTestSheetViewModel : EditableViewModelBase<TestSheet>, IEditableTestSheetViewModel
    {
        private readonly IFilterViewModelFactory _filterViewModelFactory;
        private readonly IMessenger _messenger;
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly IRoutableViewModelManager _viewModelManager;
        private IFilterViewModel<HeatTreatmentFilter, HeatTreatmentDto> _heatTreatmentsFilter;
        private bool _isVisibleHeatTreatments;
        private HeatTreatmentDto _selectedHeatTreatment;

        private TestResultDto _selectedTestResult;
        private IFilterViewModel<TestResultFilter, TestResultDto> _testResultsFilter;

        [ImportingConstructor]
        public EditableTestSheetViewModel(
            IRoutableViewModelManager viewModelManager,
            IFilterViewModelFactory filterViewModelFactory,
            IMessenger messenger,
            IScreen screen,
            IUnitOfWorkFactory unitOfWork)
            : base(screen)
        {
            _filterViewModelFactory = filterViewModelFactory;
            _messenger = messenger;
            _viewModelManager = viewModelManager;
            _unitOfWorkFactory = unitOfWork;
            _isVisibleHeatTreatments = false;
        }

        public string HeatTreatmentTitle
        {
            get
            {
                // формирование стрики рецепта термообработки
                if (HeatTreatmentsFilter.Result == null) return string.Empty;
                string title = HeatTreatmentsFilter.Result.Aggregate(string.Empty,(current, t) => current +
                                    string.Format("{0} T {1}°C, воздействие {2} мин., выдержка {3} мин., охлаждение - {4}; ",
                                        HeatTreatmentOperationConverter.Instance.Convert(t.Operation, null, null, null),
                                        t.AmbientTemperature, t.HeatingTime, t.HoldingTime,
                                        HeatTreatmentCoolingConverter.Instance.Convert(t.Ambience, null, null, null)));
                return EditableObject.FixingCardNumber == null
                    ? title : title + " Ф.К. №" + EditableObject.FixingCardNumber;
            }
        }

        public string UrlPathSegment
        {
            get { return "/EditableTestSheetViewModel"; }
        }

        public bool IsVisibleHeatTreatments
        {
            get { return _isVisibleHeatTreatments; }
            set { this.RaiseAndSetIfChanged(ref _isVisibleHeatTreatments, value); }
        }

        public IFilterViewModel<TestResultFilter, TestResultDto> TestResultsFilter
        {
            get
            {
                if (_testResultsFilter == null)
                {
                    _testResultsFilter = _filterViewModelFactory.Create<TestResultFilter, TestResultDto>();
                    _testResultsFilter.Filter.RnTestSheet = EditableObject.Rn;
                    _testResultsFilter.SetConverter(x =>
                    {
                        var dtoList = new ReactiveList<TestResultDto>(x ?? Enumerable.Empty<TestResultDto>());
                        TestSheetsHelper.FillRowNumbers(dtoList);
                        dtoList.ItemsAdded.Subscribe(z => SelectedTestResult = z);
                        return dtoList;
                    });
                    _testResultsFilter.ObservableForProperty(x => x.IsBusy).Subscribe(x => IsBusy = x.Value);
                    _testResultsFilter.InvokeCommand.Execute(null);
                }
                return _testResultsFilter;
            }
        }

        public IFilterViewModel<HeatTreatmentFilter, HeatTreatmentDto> HeatTreatmentsFilter
        {
            get
            {
                if (_heatTreatmentsFilter == null)
                {
                    _heatTreatmentsFilter = _filterViewModelFactory.Create<HeatTreatmentFilter, HeatTreatmentDto>();
                    _heatTreatmentsFilter.Filter.RnTestSheet = EditableObject.Rn;
                    _heatTreatmentsFilter.SetConverter(x =>
                    {
                        var dtoList = new ReactiveList<HeatTreatmentDto>(x ?? Enumerable.Empty<HeatTreatmentDto>());
                        TestSheetsHelper.FillRowNumbers(dtoList);
                        dtoList.ItemsAdded.Subscribe(z => SelectedHeatTreatment = z);
                        dtoList.CountChanged.Subscribe(z => raisePropertyChanged("HeatTreatmentsFilter"));
                        return dtoList;
                    });
                    _heatTreatmentsFilter.ObservableForProperty(x => x.IsBusy).Subscribe(x => IsBusy = x.Value);
                    _heatTreatmentsFilter.CompletedNotification.Subscribe(
                        x => raisePropertyChanged("HeatTreatmentTitle"));
                    _heatTreatmentsFilter.InvokeCommand.Execute(null);
                }
                return _heatTreatmentsFilter;
            }
        }

        public ICommand TableResultsCommand
        {
            get
            {
                var command = new ReactiveCommand(CanTableResultsCommandExecute());
                command.Subscribe(x =>
                {
                    var vm = _viewModelManager.Get<IEditableTestResultViewModel>();
                    vm.SetEditableObject(SelectedTestResult, EditState.Edit);
                    HostScreen.Router.Navigate.Execute(vm);
                });
                return command;
            }
        }

        public ICommand InsertHeatTreatmentCommand
        {
            get
            {
                var command = new ReactiveCommand(CanHeatTreatmentCommandExecute(EditState.Insert));
                command.Subscribe(
                    x => HeatTreatmentsFilter.Result.Add(new HeatTreatmentDto
                    {
                        Number = TestSheetsHelper.GetNextNumber(HeatTreatmentsFilter.Result),
                        CreationDate = DateTime.Now
                    }));
                return command;
            }
        }

        public ICommand CloneHeatTreatmentCommand
        {
            get
            {
                var command = new ReactiveCommand(CanHeatTreatmentCommandExecute(EditState.Clone));
                command.Subscribe(x =>
                {
                    var context = new CopyContext<HeatTreatmentDto>(SelectedHeatTreatment);
                    context.Commit();
                    context.Value.Rn = 0;
                    context.Value.CreationDate = DateTime.Now;
                    context.Value.Number = TestSheetsHelper.GetNextNumber(HeatTreatmentsFilter.Result);
                    HeatTreatmentsFilter.Result.Add(context.Value);
                });
                return command;
            }
        }

        public ICommand DeleteHeatTreatmentCommand
        {
            get
            {
                var command = new ReactiveCommand(CanHeatTreatmentCommandExecute(EditState.Delete));
                command.Subscribe(_ => _messenger.AskToObservable("Удалить?", MessageBoxButton.YesNo,
                    result =>
                    {
                        if (result == MessageBoxResult.Yes)
                            HeatTreatmentsFilter.Result.Remove(SelectedHeatTreatment);
                    }));
                return command;
            }
        }

        public ICommand InsertTestResultCommand
        {
            get
            {
                var command = new ReactiveCommand(CanTestResultCommandExecute(EditState.Insert));
                command.Subscribe(x => TestResultsFilter.Result.Add(new TestResultDto
                {
                    Number = TestSheetsHelper.GetNextNumber(TestResultsFilter.Result),
                    AnalysesRange = TestSheetsHelper.TryGetNextFieldValue(TestResultsFilter.Result, "AnalysesRange"),
                    CreationDate = DateTime.Now
                }));
                return command;
            }
        }

        public ICommand CloneTestResultCommand
        {
            get
            {
                var command = new ReactiveCommand(CanTestResultCommandExecute(EditState.Clone));
                command.Subscribe(x =>
                {
                    var context = new CopyContext<TestResultDto>(SelectedTestResult);
                    context.Commit();
                    context.Value.Rn = 0;
                    context.Value.SampleResultSets.DoForEach(item => item.Rn = 0);
                    context.Value.Number = TestSheetsHelper.GetNextNumber(TestResultsFilter.Result);
                    TestResultsFilter.Result.Add(context.Value);
                });
                return command;
            }
        }

        public ICommand DeleteTestResultCommand
        {
            get
            {
                var command = new ReactiveCommand(CanTestResultCommandExecute(EditState.Delete));
                command.Subscribe(_ => _messenger.AskToObservable("Удалить?", MessageBoxButton.YesNo,
                    result =>
                    {
                        if (result == MessageBoxResult.Yes)
                            TestResultsFilter.Result.Remove(SelectedTestResult);
                    }));
                return command;
            }
        }

        public ICommand HeatTreatmentVisibilityCommand
        {
            get
            {
                var command = new ReactiveCommand(Observable.Return(true));
                command.Subscribe(x => IsVisibleHeatTreatments = !IsVisibleHeatTreatments);
                return command;
            }
        }

        public IList<TestSheetLiteDto> ParentDtoList { get; set; }
        public TestSheetLiteDto SelectedDto { get; set; }

        public HeatTreatmentDto SelectedHeatTreatment
        {
            get { return _selectedHeatTreatment; }
            set
            {
                this.RaiseAndSetIfChanged(ref _selectedHeatTreatment, value);
                raisePropertyChanged("HeatTreatmentTitle");
            }
        }

        // выбранный результат
        public TestResultDto SelectedTestResult
        {
            get { return _selectedTestResult; }
            set { this.RaiseAndSetIfChanged(ref _selectedTestResult, value); }
        }

        protected override void ApplyAction(TestSheet entity)
        {
            HeatTreatmentsFilter.Result.DoForEach(x =>
            {
                var item = x.MapTo<HeatTreatment>();
                item.TestSheet = EditableObject;
                EditableObject.HeatTreatments.Add(item);
            });

            TestResultsFilter.Result.DoForEach(dtoTestResult =>
            {
                dtoTestResult.SampleResultSets.DoForEach(z => z.TestResult = dtoTestResult);
                var item = dtoTestResult.MapTo<TestResult>();
                item.TestSheet = EditableObject;
                EditableObject.TestResults.Add(item);
            });

            ///////////////////////////////////////////////////////////

            using (IUnitOfWork unitOfWork = _unitOfWorkFactory.Create())
            {
                var service = unitOfWork.Create<ITestSheetsService>();

                switch (EditState)
                {
                    case EditState.Edit:
                        service.UpdateTestSheet(entity.MapTo<TestSheetDto>());
                        break;
                    default:
                        EditableObject.Rn = service.InsertTestSheet(entity.MapTo<TestSheetDto>()).Rn;
                        break;
                }
                unitOfWork.Commit();
            }
        }

        protected override void CompleteAction(TestSheet instance)
        {
            base.CompleteAction(instance);
            if (EditState == EditState.Edit)
                ParentDtoList.Remove(SelectedDto);
            var dto = instance.MapTo<TestSheetLiteDto>();
            ParentDtoList.Add(dto);
        }

        private IObservable<bool> CanHeatTreatmentCommandExecute(EditState editState)
        {
            return editState == EditState.Insert
                ? this.WhenAny(x => x.IsBusy, isBusy => new {b = isBusy}).Select(x => !IsBusy)
                : this.WhenAny(x => x.SelectedHeatTreatment, x => x.IsBusy,
                    (item, isBusy) => new {selecteditem = item.Value, b = isBusy})
                    .Select(x => x.selecteditem != null && !IsBusy);
        }

        private IObservable<bool> CanTestResultCommandExecute(EditState editState)
        {
            return editState == EditState.Insert
                ? this.WhenAny(x => x.IsBusy, isBusy => new {b = isBusy}).Select(x => !IsBusy)
                : this.WhenAny(x => x.SelectedTestResult, x => x.IsBusy,
                    (item, isBusy) => new {selecteditem = item.Value, b = isBusy})
                    .Select(x => x.selecteditem != null && !IsBusy);
        }

        private IObservable<bool> CanTableResultsCommandExecute()
        {
            return CanTestResultCommandExecute(EditState.Edit);
        }
    }
}