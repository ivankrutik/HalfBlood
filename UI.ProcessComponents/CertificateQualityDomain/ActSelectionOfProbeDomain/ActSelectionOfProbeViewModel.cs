// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ActSelectionOfProbeViewModel.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The act selection of probe view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------


using System.Linq;
using ParusModelLite.CertificateQualityDomain.ManufacturersCertificateDomain;

namespace UI.ProcessComponents.CertificateQualityDomain.ActSelectionOfProbeDomain
{
    using System;
    using System.ComponentModel.Composition;
    using System.Windows.Input;

    using Buisness.Filters;

    using ParusModelLite.CertificateQualityDomain.ActSelectionOfProbeDomain;

    using ReactiveUI;

    using ServiceContracts;

    using UI.Infrastructure;
    using UI.Infrastructure.ViewModels;
    using UI.Infrastructure.ViewModels.ActSelectionOfProbeDomain;
    using UI.Infrastructure.ViewModels.Filters;
    using System.Reactive.Linq;
    using Halfblood.Common.Mappers;
    using ServiceContracts.Facades;
    using UI.Entities.CertificateQualityDomain.ActSelectionOfProbeDomain;
    using System.Collections.ObjectModel;
    using System.Windows;
    using Halfblood.Common.Reporting;
    using Halfblood.Reports;

    /// <summary>
    /// The act selection of probe view model.
    /// </summary>
    [Export(typeof(IActSelectionOfProbeViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ActSelectionOfProbeViewModel : ReactiveObject, IActSelectionOfProbeViewModel
    {
        #region private fields
        private readonly IFilterViewModelFactory _filterViewModelFactory;
        private readonly IRoutableViewModelManager _routableViewModelManager;
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly IMessenger _messenger;
        private readonly IPrintManager _printManager;
        private bool _isBusy;
        private IFilterViewModel<ActSelectionOfProbeFilter, ActSelectionOfProbeLiteDto> _actSelectionOfProbeFilter;
        private IFilterViewModel<CertificateQualityFilter, CertificateQualityLiteDto> _Filter;
        private ActSelectionOfProbeDepartmentLiteDto _selectedActSelectionOfProbeDepartment;
        private ActSelectionOfProbeDepartmentRequirementLiteDto _selectedActSelectionOfProbeDepartmentRequirement;
        private ActSelectionOfProbeLiteDto _selectedActSelectionOfProbe;

        private ReactiveCommand _preparingForEditActSelectionOfProbeCommand;
        private ReactiveCommand _preparingForRemoveActSelectionOfProbeCommand;
        private ReactiveCommand _prepatingForAddActSelectionOfProbeDepartmentCommand;
        private ReactiveCommand _prepatingForEditActSelectionOfProbeDepartmentCommand;
        private ReactiveCommand _prepatingForRemoveActSelectionOfProbeDepartmentCommand;

        private ReactiveCommand _prepatingForAddActSelectionOfProbeDepartmentRequirementCommand;
        private ReactiveCommand _prepatingForEditActSelectionOfProbeDepartmentRequirementCommand;
        private ReactiveCommand _prepatingForRemoveActSelectionOfProbeDepartmentRequirementCommand;
        private ReactiveCommand _printerLabelForActSelectionOfProbeDepartmentCommand;
        #endregion


        [ImportingConstructor]
        public ActSelectionOfProbeViewModel(
            IScreen screen,
            IFilterViewModelFactory filterViewModelFactory,
            IUnitOfWorkFactory unitOfWorkFactory,
            IRoutableViewModelManager routableViewModelManager,
            IPrintManager printManager,
            IMessenger messenger)
        {
            _messenger = messenger;
            _printManager = printManager;
            _filterViewModelFactory = filterViewModelFactory;
            HostScreen = screen;
            _filterViewModelFactory = filterViewModelFactory;
            _unitOfWorkFactory = unitOfWorkFactory;
            _routableViewModelManager = routableViewModelManager;
            _Filter = _filterViewModelFactory.Create<CertificateQualityFilter, CertificateQualityLiteDto>();

        }


        public bool IsBusy
        {
            get { return this._isBusy; }
            private set { this.RaiseAndSetIfChanged(ref _isBusy, value); }
        }

        /// <summary>
        /// Gets the url path segment.
        /// </summary>
        public string UrlPathSegment
        {
            get { return "/ActSelectionOfProbe"; }
        }

        /// <summary>
        /// Gets the host screen.
        /// </summary>
        public IScreen HostScreen { get; private set; }

        /// <summary>
        /// Gets the selection of probe filter view model.
        /// </summary>
        public IFilterViewModel<ActSelectionOfProbeFilter, ActSelectionOfProbeLiteDto> ActSelectionOfProbeFilter
        {
            get
            {
                if (_actSelectionOfProbeFilter == null)
                {
                    _actSelectionOfProbeFilter = _filterViewModelFactory.Create<ActSelectionOfProbeFilter, ActSelectionOfProbeLiteDto>();
                    _actSelectionOfProbeFilter.SetConverter(
                        dtos =>
                        {
                            dtos.DoForEach(x =>
                            {
                                x.ActSelectionOfProbeDepartments = new ObservableCollection
                                    <ActSelectionOfProbeDepartmentLiteDto>(
                                    x.ActSelectionOfProbeDepartments);
                                x.ActSelectionOfProbeDepartments.DoForEach(z =>
                                {
                                    z.ActSelectionOfProbeDepartmentRequirements =
                                        new ObservableCollection<ActSelectionOfProbeDepartmentRequirementLiteDto>(
                                            z.ActSelectionOfProbeDepartmentRequirements);
                                });
                            });
                            return dtos;
                        }
                        );
                }
                return _actSelectionOfProbeFilter;
            }
        }
        public IFilterViewModel<CertificateQualityFilter, CertificateQualityLiteDto> Filter
        {
            get
            {
                if (_Filter == null)
                {
                    _Filter = _filterViewModelFactory.Create<CertificateQualityFilter, CertificateQualityLiteDto>();

                }
                return _Filter;
            }
        }

        /// <summary>
        /// Gets or sets the selected act selection of probe destination.
        /// </summary>
        public ActSelectionOfProbeLiteDto SelectedActSelectionOfProbe
        {
            get { return _selectedActSelectionOfProbe; }
            set
            {
                this.RaiseAndSetIfChanged(
                    ref _selectedActSelectionOfProbe,
                    value);

            }
        }

        /// <summary>
        /// Gets or sets the selected making sample.
        /// </summary>
        public ActSelectionOfProbeDepartmentLiteDto SelectedActSelectionOfProbeDepartment
        {
            get { return _selectedActSelectionOfProbeDepartment; }
            set
            {
                this.RaiseAndSetIfChanged(
                    ref _selectedActSelectionOfProbeDepartment,
                    value);
            }
        }

        /// <summary>
        /// Gets or sets the selected requiremens.
        /// </summary>
        public ActSelectionOfProbeDepartmentRequirementLiteDto SelectedActSelectionOfProbeDepartmentRequirement
        {
            get { return _selectedActSelectionOfProbeDepartmentRequirement; }
            set
            {
                this.RaiseAndSetIfChanged(
                    ref _selectedActSelectionOfProbeDepartmentRequirement,
                    value);
            }
        }



        public ICommand PreparingForEditActSelectionOfProbeCommand
        {
            get
            {
                var canExecute =
                    this.WhenAnyValue(x => x.SelectedActSelectionOfProbe).Select(selectedItem => selectedItem != null);

                return _preparingForEditActSelectionOfProbeCommand ?? (_preparingForEditActSelectionOfProbeCommand =
                    GetCommandEditableActSelectionOfProbe(EditState.Edit, canExecute));
            }
        }

        public ICommand PreparingForRemoveActSelectionOfProbeCommand
        {
            get
            {
                var canExecute =
                   this.WhenAnyValue(x => x.SelectedActSelectionOfProbe).Select(selectedItem => selectedItem != null);
                return _preparingForRemoveActSelectionOfProbeCommand ??
                       (_preparingForRemoveActSelectionOfProbeCommand =
                           GetCommandRemoveActSelectionOfProbe(canExecute));
            }
        }

        public ICommand PrepatingForAddActSelectionOfProbeDepartmentCommand
        {
            get
            {
                var canExecute =
                 this.WhenAnyValue(x => x.SelectedActSelectionOfProbe).Select(selectedItem => selectedItem != null);

                return _prepatingForAddActSelectionOfProbeDepartmentCommand ??
                       (_prepatingForAddActSelectionOfProbeDepartmentCommand =
                           GetCommandEditableActSelectionOfProbeDepartment(EditState.Insert, canExecute));
            }
        }

        public ICommand PrepatingForEditActSelectionOfProbeDepartmentCommand
        {
            get
            {
                var canExecute =
                   this.WhenAnyValue(x => x.SelectedActSelectionOfProbe).Select(selectedItem => selectedItem != null);
                return _prepatingForEditActSelectionOfProbeDepartmentCommand ??
                       (_prepatingForEditActSelectionOfProbeDepartmentCommand =
                           GetCommandEditableActSelectionOfProbeDepartment(EditState.Edit, canExecute));
            }
        }
        public ICommand PrepatingForRemoveActSelectionOfProbeDepartmentCommand
        {
            get
            {
                var canExecute =
                    this.WhenAnyValue(x => x.SelectedActSelectionOfProbe).Select(selectedItem => selectedItem != null);
                return _prepatingForRemoveActSelectionOfProbeDepartmentCommand ??
                       (_prepatingForRemoveActSelectionOfProbeDepartmentCommand =
                           GetCommandRemoveActSelectionOfProbeDepartment(canExecute));
            }
        }
        public ICommand PrepatingForAddActSelectionOfProbeDepartmentRequirementCommand
        {
            get
            {
                var canExecute =
                    this.WhenAnyValue(x => x.SelectedActSelectionOfProbeDepartment).Select(selectedItem => selectedItem != null);
                return _prepatingForAddActSelectionOfProbeDepartmentRequirementCommand ??
                       (_prepatingForAddActSelectionOfProbeDepartmentRequirementCommand =
                           GetCommandEditableActSelectionOfProbeDepartmentRequirement(EditState.Insert, canExecute));
            }
        }

        public ICommand PrepatingForEditActSelectionOfProbeDepartmentRequirementCommand
        {
            get
            {
                var canExecute =
                    this.WhenAnyValue(x => x.SelectedActSelectionOfProbeDepartment).Select(selectedItem => selectedItem != null);
                return _prepatingForEditActSelectionOfProbeDepartmentRequirementCommand ??
                       (_prepatingForEditActSelectionOfProbeDepartmentRequirementCommand =
                           GetCommandEditableActSelectionOfProbeDepartmentRequirement(EditState.Edit, canExecute));
            }
        }
        public ICommand PrepatingForRemoveActSelectionOfProbeDepartmentRequirementCommand
        {
            get
            {
                var canExecute =
                    this.WhenAnyValue(x => x.SelectedActSelectionOfProbeDepartment).Select(selectedItem => selectedItem != null);
                return _prepatingForRemoveActSelectionOfProbeDepartmentRequirementCommand ??
                       (_prepatingForRemoveActSelectionOfProbeDepartmentRequirementCommand =
                           GetCommandRemoveActSelectionOfProbeDepartmentRequirement(canExecute));
            }
        }

        public ICommand PrinterLabelForActSelectionOfProbeDepartmentCommand
        {
            get
            {
                var canExecute =
                    this.WhenAnyValue(x => x.SelectedActSelectionOfProbeDepartment).Select(selectedItem => selectedItem != null);

                return _printerLabelForActSelectionOfProbeDepartmentCommand ?? (
                    _printerLabelForActSelectionOfProbeDepartmentCommand =
                    GetCommandPrinterLabelForActSelectionOfProbeDepartment(canExecute));
            }
        }

        private ReactiveCommand GetCommandPrinterLabelForActSelectionOfProbeDepartment(IObservable<bool> canExecute)
        {
            var command = new ReactiveCommand(canExecute);

            command.RegisterAsyncAction(_ =>
            {
                var report = new LabelActSelectionOfProbe(SelectedActSelectionOfProbeDepartment.Rn);
                _printManager.OpenReportInBrowser(report);
            });

            return command;
        }

        private ReactiveCommand GetCommandEditableActSelectionOfProbe(EditState editState, IObservable<bool> canExecute)
        {
            var command =
                new ReactiveCommand(canExecute);

            command.RegisterAsyncFunction(o =>
            {
                Filter.SetFilter(new CertificateQualityFilter { Rn = SelectedActSelectionOfProbe.RnCertificate }).Wait();
                return GetActSelectionOfProbe(editState);
            }).Subscribe(
                result =>
                {
                    var viewModel = _routableViewModelManager.Get<IEditableActSelectionOfProbeViewModel>();

                    viewModel.CertificateQuality = Filter.Result.FirstOrDefault();
                    viewModel.SetEditableObject(result, editState);
                    HostScreen.Router.Navigate.Execute(viewModel);
                });
            command.IsExecuting.Subscribe(isExecuting => IsBusy = isExecuting);
            return command;
        }
        private ReactiveCommand GetCommandEditableActSelectionOfProbeDepartment(EditState editState, IObservable<bool> canExecute)
        {
            var command =
                  new ReactiveCommand(canExecute);

            command.RegisterAsyncFunction(_ => GetActSelectionOfProbeDepartment(editState)).Subscribe(
                result =>
                {
                    var viewModel = _routableViewModelManager.Get<IEditableActSelectionOfProbeDepartmentViewModel>();
                    viewModel.SetEditableObject(result, editState);
                    HostScreen.Router.Navigate.Execute(viewModel);
                });
            command.IsExecuting.Subscribe(isExecuting => IsBusy = isExecuting);
            return command;
        }

        private ReactiveCommand GetCommandRemoveActSelectionOfProbeDepartment(IObservable<bool> canExecute = null)
        {
            var command = new ReactiveCommand(canExecute);

            command.RegisterAsync(
                _ => _messenger.AskToObservable(
                    "Удалить?",
                    MessageBoxButton.YesNo,
                    result =>
                    {
                        if (result == MessageBoxResult.Yes)
                        {
                            var removingItem = SelectedActSelectionOfProbeDepartment;

                            if (removingItem == null)
                            {
                                return;
                            }

                            RemoveActSelectionOfProbeDepartment(removingItem.Rn);

                            Application.Current.Dispatcher.Invoke(() =>
                            {
                                SelectedActSelectionOfProbe.ActSelectionOfProbeDepartments.Remove(removingItem);
                            });

                        }
                    })).Subscribe();

            command.ThrownExceptions.Subscribe(OnError);
            command.IsExecuting.Subscribe(isExecuting => IsBusy = isExecuting);
            return command;
        }
        private ReactiveCommand GetCommandRemoveActSelectionOfProbe(IObservable<bool> canExecute = null)
        {

            var command = new ReactiveCommand(canExecute);

            command.RegisterAsync(
                _ => _messenger.AskToObservable(
                    "Удалить?",
                    MessageBoxButton.YesNo,
                    result =>
                    {
                        if (result == MessageBoxResult.Yes)
                        {
                            var removingItem = SelectedActSelectionOfProbe;

                            if (removingItem == null)
                            {
                                return;
                            }

                            RemoveActSelectionOfProbe(removingItem.Rn);
                            ActSelectionOfProbeFilter.Result.Remove(removingItem);
                        }
                    })).Subscribe();

            command.ThrownExceptions.Subscribe(OnError);
            command.IsExecuting.Subscribe(isExecuting => IsBusy = isExecuting);
            return command;
        }
        private ReactiveCommand GetCommandRemoveActSelectionOfProbeDepartmentRequirement(IObservable<bool> canExecute)
        {
            var command = new ReactiveCommand(canExecute);

            command.RegisterAsync(
                _ => _messenger.AskToObservable(
                    "Удалить?",
                    MessageBoxButton.YesNo,
                    result =>
                    {
                        if (result == MessageBoxResult.Yes)
                        {
                            var removingItem = SelectedActSelectionOfProbeDepartmentRequirement;

                            if (removingItem == null)
                            {
                                return;
                            }

                            RemovectSelectionOfProbeDepartmentRequirement(removingItem.Rn);
                            Application.Current.Dispatcher.Invoke(() =>
                            {
                                SelectedActSelectionOfProbeDepartment.ActSelectionOfProbeDepartmentRequirements.Remove(
                                    removingItem);
                            });

                        }
                    })).Subscribe();

            command.ThrownExceptions.Subscribe(OnError);
            command.IsExecuting.Subscribe(isExecuting => IsBusy = isExecuting);
            return command;
        }
        private ReactiveCommand GetCommandEditableActSelectionOfProbeDepartmentRequirement(EditState editState, IObservable<bool> canExecute)
        {
            var command =
                      new ReactiveCommand(canExecute);

            command.RegisterAsyncFunction(_ => GetActSelectionOfProbeDepartmentRequirement(editState)).Subscribe(
                result =>
                {
                    var viewModel = _routableViewModelManager.Get<IEditableActSelectionOfProbeDepartmentRequirementViewModel>();
                    viewModel.SetEditableObject(result, editState);
                    HostScreen.Router.Navigate.Execute(viewModel);
                });
            command.IsExecuting.Subscribe(isExecuting => IsBusy = isExecuting);
            return command;
        }


        private void RemoveActSelectionOfProbe(long rn)
        {
            using (IUnitOfWork unitOfWork = _unitOfWorkFactory.Create())
            {
                var service = unitOfWork.Create<IActSelectionOfProbeService>();
                service.RemoveActSelectionOfProbe(rn);

                unitOfWork.Commit();
            }
        }
        private void RemoveActSelectionOfProbeDepartment(long rn)
        {
            using (IUnitOfWork unitOfWork = _unitOfWorkFactory.Create())
            {
                var service = unitOfWork.Create<IActSelectionOfProbeService>();
                service.RemoveActSelectionOfProbeDepartment(rn);

                unitOfWork.Commit();
            }
        }
        private void RemovectSelectionOfProbeDepartmentRequirement(long rn)
        {
            using (IUnitOfWork unitOfWork = _unitOfWorkFactory.Create())
            {
                var service = unitOfWork.Create<IActSelectionOfProbeService>();
                service.RemoveActSelectionOfProbeDepartmentRequirement(rn);

                unitOfWork.Commit();
            }
        }

        private ActSelectionOfProbe GetActSelectionOfProbe(EditState editState)
        {
            IsBusy = true;
            if (editState == EditState.Edit)
            {
                using (IUnitOfWork unitOfWork = _unitOfWorkFactory.Create())
                {
                    var service = unitOfWork.Create<IActSelectionOfProbeService>();
                    return
                        service.GetActSelectionOfProbeDto(SelectedActSelectionOfProbe.Rn)
                            .MapTo<ActSelectionOfProbe>();
                }
            }

            return new ActSelectionOfProbe();
        }
        private ActSelectionOfProbeDepartment GetActSelectionOfProbeDepartment(EditState editState)
        {
            if (editState == EditState.Edit)
            {
                using (IUnitOfWork unitOfWork = this._unitOfWorkFactory.Create())
                {
                    var service = unitOfWork.Create<IActSelectionOfProbeService>();
                    return
                        service.GetActSelectionOfProbeDepartmentDto(SelectedActSelectionOfProbeDepartment.Rn)
                            .MapTo<ActSelectionOfProbeDepartment>();
                }
            }

            return new ActSelectionOfProbeDepartment
            {
                ActSelectionOfProbe = new ActSelectionOfProbe(SelectedActSelectionOfProbe.Rn)
            };
        }
        private ActSelectionOfProbeDepartmentRequirement GetActSelectionOfProbeDepartmentRequirement(EditState editState)
        {
            if (editState == EditState.Edit)
            {
                using (IUnitOfWork unitOfWork = _unitOfWorkFactory.Create())
                {
                    var service = unitOfWork.Create<IActSelectionOfProbeService>();
                    return
                        service.GetActSelectionOfProbeDepartmentRequirementDto(SelectedActSelectionOfProbeDepartmentRequirement.Rn)
                            .MapTo<ActSelectionOfProbeDepartmentRequirement>();
                }
            }

            return new ActSelectionOfProbeDepartmentRequirement
            {
                ActSelectionOfProbeDepartment = new ActSelectionOfProbeDepartment(SelectedActSelectionOfProbeDepartment.Rn)
            };
        }
        private void OnError(Exception exception)
        {
            UserError.Throw("Удаление маршрута движения образцов", exception);
        }
    }
}