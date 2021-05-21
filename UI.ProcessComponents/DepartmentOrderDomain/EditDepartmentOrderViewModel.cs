// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EditDepartmentOrderViewModel.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the EditDepartmentOrderViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.ProcessComponents.DepartmentOrderDomain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Linq;
    using System.Reactive.Disposables;
    using System.Windows.Input;

    using Buisness.Entities.CommonDomain;
    using Buisness.Entities.DepartmentOrderDomain;
    using Buisness.Filters;

    using FluentValidation;

    using Halfblood.Common.Mappers;

    using ParusModelLite.CertificateQualityDomain.ManufacturersCertificateDomain;
    using ParusModelLite.DepartmentOrderDomain;

    using ReactiveUI;

    using ServiceContracts;
    using ServiceContracts.Facades;

    using UI.Entities.DepartmentOrderDomain;
    using UI.Infrastructure;
    using UI.Infrastructure.ViewModels;
    using UI.Infrastructure.ViewModels.CertificateQualityServiceDomain.ManufacturersCertificateDomain;
    using UI.Infrastructure.ViewModels.DepartmentOrderDomain;
    using UI.Infrastructure.ViewModels.Filters;
    using UI.ProcessComponents.EditViewModels;

    [Export(typeof(IEditDepartmentOrderViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class EditDepartmentOrderViewModel : PolicyEditableViewModelBase<DepartmentOrder>, IEditDepartmentOrderViewModel
    {
        #region private fields
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly IFilterViewModelFactory _filterViewModelFactory;
        private readonly IRoutableViewModelManager _routableViewModelManager;
        private CertificateQualityLiteDto _selectedCertificate;
        private ReactiveCommand _navigateToFindCertificateCommand;
        private IFilterViewModel<DepartmentOrderFilter, DepartmentOrderLiteDto> _departmentOrderFilteringObject;
        private IFilterViewModel<CertificateQualityFilter, CertificateQualityLiteDto> _certificateQualityFilteringObject;
        private IFilterViewModel<GoodsManagerFilter, GoodsManagerDto> _goodsManagerFilterObject;
        private IManufacturersCertificateViewModel _manufacturersCertificateViewModel;
        #endregion

        [ImportingConstructor]
        public EditDepartmentOrderViewModel(
            IScreen screen,
            IUnitOfWorkFactory unitOfWorkFactory,
            IFilterViewModelFactory filterViewModelFactory,
            IRoutableViewModelManager routableViewModelManager,
            IValidatorFactory validatorFactory = null,
            IMessageBus messageBus = null)
            : base(screen, messageBus, validatorFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            _filterViewModelFactory = filterViewModelFactory;
            _routableViewModelManager = routableViewModelManager;
            NavigateBack().ToList();
        }

        public ICommand NavigateToFindCertificateCommand
        {
            get
            {
                if (_navigateToFindCertificateCommand == null)
                {
                    _navigateToFindCertificateCommand = new ReactiveCommand();
                    _navigateToFindCertificateCommand.Subscribe(
                        _ =>
                        {
                            if (this._manufacturersCertificateViewModel == null)
                            {
                                this._manufacturersCertificateViewModel = _routableViewModelManager.Get<IManufacturersCertificateViewModel>();
                            }

                            HostScreen.Router.Navigate.Execute(this._manufacturersCertificateViewModel);
                        });
                }

                return this._navigateToFindCertificateCommand;
            }
        }
        public IFilterViewModel<DepartmentOrderFilter, DepartmentOrderLiteDto> DepartmentOrderFilteringObject
        {
            get
            {
                return _departmentOrderFilteringObject
                       ?? (_departmentOrderFilteringObject =
                           _filterViewModelFactory.Create<DepartmentOrderFilter, DepartmentOrderLiteDto>());
            }
        }
        public IFilterViewModel<CertificateQualityFilter, CertificateQualityLiteDto> CertificateQualityFilteringObject
        {
            get
            {
                return _certificateQualityFilteringObject
                       ?? (_certificateQualityFilteringObject =
                           _filterViewModelFactory.Create<CertificateQualityFilter, CertificateQualityLiteDto>());
            }
        }
        public IFilterViewModel<GoodsManagerFilter, GoodsManagerDto> GoodsManagerFilterObject
        {
            get
            {
                return _goodsManagerFilterObject
                       ?? (_goodsManagerFilterObject =
                           _filterViewModelFactory.Create<GoodsManagerFilter, GoodsManagerDto>());
            }
        }
        public CertificateQualityLiteDto SelectedCertificate
        {
            get { return this._selectedCertificate; }
            set { this.RaiseAndSetIfChanged(ref _selectedCertificate, value); }
        }
        public string UrlPathSegment
        {
            get { return "EditDepartmentOrderViewModel"; }
        }

        protected override void ApplyAction(DepartmentOrder editObject)
        {
            using (IUnitOfWork unitOfWork = _unitOfWorkFactory.Create())
            {
                var service = unitOfWork.Create<IDepartmentOrderService>();
                if (EditState == EditState.Insert)
                {
                    var insertedValue = service.InsertDepartmentOrderDto(editObject.MapTo<DepartmentOrderDto>());
                    EditableObject.Rn = insertedValue.Rn;
                }
                else if (EditState == EditState.Edit)
                {
                    service.UpdateDepartmentOrder(editObject.MapTo<DepartmentOrderDto>());
                }

                unitOfWork.Commit();
            }
        }

        private IEnumerable<IDisposable> NavigateBack()
        {
            yield return this.WhenNavigatedTo(
                () =>
                    {
                        if (_manufacturersCertificateViewModel != null)
                        {
                            var certificate = _manufacturersCertificateViewModel.SelectedCertificateQuality;
                            _manufacturersCertificateViewModel = null;
                            // Если сертификат не нулл и если такого нет в этой коллекции, то добавляем
                            EditableObject.Specifications.Add(new DepartmentOrderSpecification());
                        }

                        return Disposable.Empty;
                    });
        }
    }
}
