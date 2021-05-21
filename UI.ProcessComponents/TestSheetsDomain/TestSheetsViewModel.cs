using System;
using System.ComponentModel.Composition;
using System.Linq;
using System.Reactive.Linq;
using System.Windows;
using System.Windows.Input;
using Buisness.Filters.TestSheetsDomain;
using Halfblood.Common;
using Halfblood.Common.Mappers;
using ParusModelLite.TestSheetsDomain;
using ReactiveUI;
using ServiceContracts;
using ServiceContracts.Facades;
using UI.Entities.TestSheetsDomain;
using UI.Infrastructure;
using UI.Infrastructure.ViewModels;
using UI.Infrastructure.ViewModels.Filters;
using UI.Infrastructure.ViewModels.TestSheetsDomain;

namespace UI.ProcessComponents.TestSheetsDomain
{
    [Export(typeof (ITestSheetsViewModel)), PartCreationPolicy(CreationPolicy.NonShared)]
    public class TestSheetsViewModel : ReactiveObject, ITestSheetsViewModel
    {
        private readonly IFilterViewModelFactory _filterViewModelFactory;
        private readonly IMessenger _messenger;
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly IRoutableViewModelManager _viewModelManager;
        private IFilterViewModel<TestSheetFilter, TestSheetLiteDto> _filter;
        private bool _isBusy;
        private TestSheetLiteDto _selectedTestSheet;

        [ImportingConstructor]
        public TestSheetsViewModel(
            IScreen screen,
            IMessenger messenger,
            IRoutableViewModelManager viewModelManager,
            IUnitOfWorkFactory unitOfWorkFactory,
            IFilterViewModelFactory filterViewModelFactory)
        {
            HostScreen = screen;
            _messenger = messenger;
            _viewModelManager = viewModelManager;
            _unitOfWorkFactory = unitOfWorkFactory;
            _filterViewModelFactory = filterViewModelFactory;
        }

        public IScreen HostScreen { get; private set; }

        public string UrlPathSegment
        {
            get { return "/TestSheetsViewModel"; }
        }

        public bool IsBusy
        {
            get { return _isBusy; }
            set { this.RaiseAndSetIfChanged(ref _isBusy, value); }
        }

        // загружаем испытатетльные листы
        public IFilterViewModel<TestSheetFilter, TestSheetLiteDto> TestSheetsFilter
        {
            get
            {
                if (_filter == null)
                {
                    _filter = _filterViewModelFactory.Create<TestSheetFilter, TestSheetLiteDto>();
                    _filter.SetConverter(x =>
                    {
                        var obsrv = new ReactiveList<TestSheetLiteDto>(x ?? Enumerable.Empty<TestSheetLiteDto>());
                        obsrv.ItemsAdded.Subscribe(z => SelectedTestSheetLiteDto = z);
                        return obsrv;
                    });
                    _filter.ObservableForProperty(x => x.IsBusy).Subscribe(x => IsBusy = x.Value);
                    _filter.InvokeCommand.Execute(null);
                    return _filter;
                }
                return _filter;
            }
        }

        // выбранный пользователем испытатетльный лист
        public TestSheetLiteDto SelectedTestSheetLiteDto
        {
            get { return _selectedTestSheet; }
            set { this.RaiseAndSetIfChanged(ref _selectedTestSheet, value); }
        }

        public ICommand InsertTestSheetCommand
        {
            get
            {
                var command = new ReactiveCommand(CanTestSheetCommandExecute(EditState.Insert));
                command.Subscribe(x =>
                {
                    var vm = _viewModelManager.Get<IEditableTestSheetViewModel>();
                    vm.SelectedDto = SelectedTestSheetLiteDto;
                    vm.ParentDtoList = TestSheetsFilter.Result;
                    vm.SetEditableObject(new TestSheet {TestCode = (TestKinds) x, CreationDate = DateTime.Now},
                        EditState.Insert);
                    HostScreen.Router.Navigate.Execute(vm);
                });
                return command;
            }
        }

        public ICommand UpdateTestSheetCommand
        {
            get
            {
                var command = new ReactiveCommand(CanTestSheetCommandExecute(EditState.Edit));
                command.Subscribe(x =>
                {
                    var vm = _viewModelManager.Get<IEditableTestSheetViewModel>();
                    vm.SelectedDto = SelectedTestSheetLiteDto;
                    vm.ParentDtoList = TestSheetsFilter.Result;
                    vm.SetEditableObject(SelectedTestSheetLiteDto.MapTo<TestSheet>(), EditState.Edit);
                    HostScreen.Router.Navigate.Execute(vm);
                });
                return command;
            }
        }

        public ICommand DeleteTestSheetCommand
        {
            get
            {
                var command = new ReactiveCommand(CanTestSheetCommandExecute(EditState.Delete));
                command.Subscribe(
                    _ => _messenger.AskToObservable("Удалить?", MessageBoxButton.YesNo, result =>
                    {
                        if (result == MessageBoxResult.Yes)
                        {
                            using (IUnitOfWork unitOfWork = _unitOfWorkFactory.Create())
                            {
                                var service = unitOfWork.Create<ITestSheetsService>();
                                service.RemoveTestSheet(SelectedTestSheetLiteDto.Rn);
                                unitOfWork.Commit();
                            }
                            TestSheetsFilter.Result.Remove(SelectedTestSheetLiteDto);
                        }
                    }));
                return command;
            }
        }

        private IObservable<bool> CanTestSheetCommandExecute(EditState editState)
        {
            return editState == EditState.Insert
                ? Observable.Return(true)
                : this.WhenAny(x => x.SelectedTestSheetLiteDto, x => x.IsBusy,
                    (item, isBusy) => new {selecteditem = item.Value, b = isBusy})
                    .Select(x => x.selecteditem != null && !IsBusy);
        }
    }
}