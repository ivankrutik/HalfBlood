namespace Halfblood.AcceptanceTests.Steps.PlanReceiptOrderDomain
{
    using System;
    using System.Linq;

    using Buisness.Entities.CommonDomain;
    using Buisness.Filters;

    using Halfblood.Common.Helpers;
    using Halfblood.Common.Mappers;

    using ServiceContracts;
    using ServiceContracts.Facades;

    using TechTalk.SpecFlow;

    using UI.Entities.CommonDomain;
    using UI.Entities.PlanReceiptOrderDomain;
    using UI.Infrastructure;
    using UI.Infrastructure.ViewModels.Filters;
    using UI.Infrastructure.ViewModels.PlanReceiptOrderDomain;
    using UI.ProcessComponents.EditViewModels;

    [Binding]
    public class ОбновлениеППОПлановогоПриходногоОрдераSteps : StepBase
    {
        private IEditablePlanReceiptOrderViewModel _viewModel;
        private IPlanReceiptOrderService _service;
        private IFilterViewModelFactory _filterViewModelFactory;
        private IUnitOfWorkFactory _unitOfWorkFactory;

        [Given(@"Я хочу изменить существующий ППО")]
        public void ДопустимЯХочуИзменитьСуществующийППО()
        {
            this._viewModel = this.Bootstrapper.IoC.GetExportedValue<IEditablePlanReceiptOrderViewModel>();
            this._filterViewModelFactory = this.Bootstrapper.IoC.GetExportedValue<IFilterViewModelFactory>();
            _unitOfWorkFactory = this.Bootstrapper.IoC.GetExportedValue<IUnitOfWorkFactory>();
        }

        [Given(@"я достаю из бд существующий ППО с RN = (.*)")]
        public void ДопустимЯДостаюИзБдСуществующийППОСRN(int p0)
        {
            using (IUnitOfWork unitOfWork = _unitOfWorkFactory.Create())
            {
                _service = unitOfWork.Create<IPlanReceiptOrderService>();
                var dto = _service.GetPlanReceiptOrder(p0);
                if (dto == null)
                {
                    throw new ArgumentNullException("Не могу найти ППО с RN == {0}".StringFormat(p0));
                }

                var planReceiptOrder = dto.MapTo<PlanReceiptOrder>();
                _viewModel.SetEditableObject(planReceiptOrder, EditState.Edit);
            }
        }

        [Given(@"изменяю склад (.*)")]
        public void ДопустимИзменяюСклад(int p0)
        {
            _viewModel.EditableObject.StoreGasStationOilDepot = new StoreGasStationOilDepot(p0);
        }

        [Given(@"изменяю тип (.*) документа основания")]
        public void ДопустимИзменяюТипДокументаОснования(int p0)
        {
            this._viewModel.EditableObject.GroundTypeOfDocument = new TypeOfDocument(p0);
        }

        [Given(@"изменяю № (.*) документа основания")]
        public void ДопустимИзменяюДокументаОснования(int p0)
        {
            this._viewModel.EditableObject.GroundDocumentNumb = p0.ToString();
        }

        [Given(@"изменяю дату '(.*)' документа основания")]
        public void ДопустимИзменяюДатуДокументаОснования(string p0)
        {
            this._viewModel.EditableObject.GroundDocumentDate = DateTime.Parse(p0);
        }

        [Given(@"изменяю тип (.*) документа основания для получения")]
        public void ДопустимИзменяюТипДокументаОснованияДляПолучения(int p0)
        {
            this._viewModel.EditableObject.GroundReceiptTypeOfDocument = new TypeOfDocument(p0);
        }

        [Given(@"изменяю № (.*) документа основания для получения")]
        public void ДопустимИзменяюДокументаОснованияДляПолучения(int p0)
        {
            this._viewModel.EditableObject.GroundReceiptDocumentNumb = p0.ToString();
        }

        [Given(@"изменяю дату '(.*)' документа основания для получения")]
        public void ДопустимИзменяюДатуДокументаОснованияДляПолучения(string p0)
        {
            this._viewModel.EditableObject.GroundReceiptDocumentDate = DateTime.Parse(p0);
        }

        [Given(@"изменяю поставщика (.*)")]
        public void ДопустимИзменяюПоставщика(string p0)
        {
            var filterViewModel = _filterViewModelFactory.Create<UserFilter, UserDto>();
            filterViewModel.Wait();

            this._viewModel.EditableObject.UserContractor = filterViewModel.Result.First().MapTo<User>();
        }

        [Given(@"изменяю примечание примечание")]
        public void ДопустимИзменяюПримечаниеПримечание(string p0)
        {
            this._viewModel.EditableObject.Note = p0;
        }

        [When(@"я нажимаю кнопку Обновить")]
        public void ЕслиЯНажимаюКнопкуОбновить()
        {
            this._viewModel.ApplyCommand.Execute(null);
            ((EditableContext<PlanReceiptOrder>)this._viewModel).Wait();
        }

        [Then(@"я вижу окно c сообщением - успешно обновлено")]
        public void ТоЯВижуОкноCСообщением_УспешноОбновлено()
        {
        }
    }
}
