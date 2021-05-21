using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Reactive.Linq;
using System.Windows;
using System.Windows.Input;
using Buisness.Entities.TestSheetDomain;
using Halfblood.Common.Helpers;
using ReactiveUI;
using UI.Infrastructure;
using UI.Infrastructure.ViewModels.TestSheetsDomain;
using UI.ProcessComponents.EditViewModels;

namespace UI.ProcessComponents.TestSheetsDomain
{
    // Редактирование результата анализа
    [Export(typeof (IEditableTestResultViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class EditableTestResultsViewModel : EditableViewModelBase<TestResultDto>, IEditableTestResultViewModel
    {
        private readonly IMessenger _messenger;
        private SampleResultSetDto _headerRow;
        private IList<SampleResultSetDto> _resultSets;
        private SampleResultSetDto _selectedSampleResultSet;

        [ImportingConstructor]
        public EditableTestResultsViewModel(
            IScreen screen,
            IMessenger messenger)
            : base(screen)
        {
            _messenger = messenger;
        }

        public SampleResultSetDto SelectedSampleResultSet
        {
            get { return _selectedSampleResultSet; }
            set { this.RaiseAndSetIfChanged(ref _selectedSampleResultSet, value); }
        }

        public bool HasResultSets
        {
            get { return ResultSets.Count > 0; }
        }

        public SampleResultSetDto HeaderRow
        {
            get
            {
                if (_headerRow == null)
                {
                    _headerRow = ResultSets.FirstOrDefault(x => !x.IsRow);
                    if (_headerRow != null)
                        ResultSets.Remove(_headerRow);
                    else
                        _headerRow = new SampleResultSetDto {IsRow = false};
                }
                return _headerRow;
            }
            set { this.RaiseAndSetIfChanged(ref _headerRow, value); }
        }

        public IList<SampleResultSetDto> ResultSets
        {
            get
            {
                if (_resultSets == null)
                {
                    var context = new CopyContext<IList<SampleResultSetDto>>(EditableObject.SampleResultSets);
                    context.Commit();
                    _resultSets = context.Value;
                }
                return _resultSets;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref _resultSets, value);
                raisePropertyChanged("HasResultSets");
            }
        }

        public string UrlPathSegment
        {
            get { return "/EditableTestResultsViewModel"; }
        }

        public ICommand InsertSampleTestsCommand
        {
            get
            {
                var command = new ReactiveCommand(CanSampleTestsCommandExecute(EditState.Insert));
                command.Subscribe(x =>
                {
                    ResultSets.Add(new SampleResultSetDto
                    {
                        IsRow = true,
                        Title = TestSheetsHelper.TryGetNextFieldValue(ResultSets, "Title")
                    });
                    raisePropertyChanged("HasResultSets");
                });
                return command;
            }
        }

        public ICommand InsertAvgSampleTestsCommand
        {
            get
            {
                var command = new ReactiveCommand(Observable.Empty<bool>());
                command.Subscribe(x =>
                {
                    ResultSets.Add(TestSheetsHelper.CreateSampleResultsItemByGroupFunc(ResultSets,
                        TestSheetsHelper.GroupFunc.Average));
                    raisePropertyChanged("HasResultSets");
                });
                return command;
            }
        }

        public ICommand InsertMaxSampleTestsCommand
        {
            get
            {
                var command = new ReactiveCommand(Observable.Empty<bool>());
                command.Subscribe(x =>
                {
                    ResultSets.Add(TestSheetsHelper.CreateSampleResultsItemByGroupFunc(ResultSets,
                        TestSheetsHelper.GroupFunc.Max));
                    raisePropertyChanged("HasResultSets");
                });
                return command;
            }
        }

        public ICommand InsertMinSampleTestsCommand
        {
            get
            {
                var command = new ReactiveCommand(Observable.Empty<bool>());
                command.Subscribe(x =>
                {
                    ResultSets.Add(TestSheetsHelper.CreateSampleResultsItemByGroupFunc(ResultSets,
                        TestSheetsHelper.GroupFunc.Min));
                    raisePropertyChanged("HasResultSets");
                });
                return command;
            }
        }

        public ICommand CloneSampleTestsCommand
        {
            get
            {
                var command = new ReactiveCommand(CanSampleTestsCommandExecute(EditState.Clone));
                command.Subscribe(x =>
                {
                    var context = new CopyContext<SampleResultSetDto>(SelectedSampleResultSet);
                    context.Commit();
                    context.Value.Rn = 0;
                    context.Value.IsRow = true;
                    context.Value.Title = TestSheetsHelper.TryGetNextFieldValue(ResultSets, "Title");
                    ResultSets.Add(context.Value);
                    raisePropertyChanged("HasResultSets");
                });
                return command;
            }
        }

        public ICommand DeleteSampleTestsRowCommand
        {
            get
            {
                var command = new ReactiveCommand(CanSampleTestsCommandExecute(EditState.Delete));
                command.Subscribe(_ => _messenger.AskToObservable("Удалить строку?", MessageBoxButton.YesNo,
                    result =>
                    {
                        if (result == MessageBoxResult.Yes)
                        {
                            ResultSets.Remove(SelectedSampleResultSet);
                            raisePropertyChanged("HasResultSets");
                        }
                    }));
                return command;
            }
        }

        public ICommand ClearTableCommand
        {
            get
            {
                var command = new ReactiveCommand(Observable.Empty<bool>());
                command.Subscribe(_ => _messenger.AskToObservable("Очистить таблицу?", MessageBoxButton.YesNo,
                    result =>
                    {
                        if (result == MessageBoxResult.Yes)
                        {
                            ResultSets.Clear();
                            raisePropertyChanged("ResultSets");
                            HeaderRow = null;
                            raisePropertyChanged("HeaderRow");
                        }
                    }));
                return command;
            }
        }

        protected override void ApplyAction(TestResultDto editObject)
        {
            editObject.SampleResultSets.Clear();
            if (string.IsNullOrEmpty(HeaderRow.Value1) && string.IsNullOrEmpty(HeaderRow.Value2) &&
                string.IsNullOrEmpty(HeaderRow.Value3) && string.IsNullOrEmpty(HeaderRow.Value4) &&
                string.IsNullOrEmpty(HeaderRow.Value5) && string.IsNullOrEmpty(HeaderRow.Value6) &&
                string.IsNullOrEmpty(HeaderRow.Value7) && string.IsNullOrEmpty(HeaderRow.Value8) &&
                string.IsNullOrEmpty(HeaderRow.Value9) && string.IsNullOrEmpty(HeaderRow.Value10) &&
                string.IsNullOrEmpty(HeaderRow.Title)) return;
            editObject.SampleResultSets.Add(HeaderRow);
            ResultSets.DoForEach(dto => editObject.SampleResultSets.Add(dto));
        }


        private IObservable<bool> CanSampleTestsCommandExecute(EditState editState)
        {
            return editState == EditState.Insert
                ? Observable.Return(true)
                : this.WhenAny(x => x.SelectedSampleResultSet, a => new {row = a.Value}).Select(x => x.row != null);
        }
    }
}