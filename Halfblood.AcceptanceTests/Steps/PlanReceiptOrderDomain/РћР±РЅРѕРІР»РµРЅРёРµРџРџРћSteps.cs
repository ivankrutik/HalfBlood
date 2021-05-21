// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ОбновлениеППОSteps.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the ОбновлениеППОПлановогоПриходногоОрдераSteps type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Halfblood.AcceptanceTests.Steps.PlanReceiptOrderDomain
{
    using System;
    using System.Reactive.Linq;
    using System.Threading;

    using Halfblood.Common.Mappers;

    using ReactiveUI;

    using ServiceContracts;
    using ServiceContracts.Facades;

    using TechTalk.SpecFlow;

    using UI.Entities.CommonDomain;
    using UI.Entities.PlanReceiptOrderDomain;
    using UI.Infrastructure;
    using UI.Infrastructure.ViewModels.PlanReceiptOrderDomain;

    [Binding]
    public class ОбновлениеППОПлановогоПриходногоОрдераSteps : StepBase
    {
        private IEditablePlanReceiptOrderViewModel _viewModel;
        private IPlanReceiptOrderService _service;

        [Given(@"Я хочу изменить существующий ППО")]
        public void ДопустимЯХочуИзменитьСуществующийППО()
        {
            this._viewModel = this.Bootstrapper.IoC.GetExportedValue<IEditablePlanReceiptOrderViewModel>();
            var factory = this.Bootstrapper.IoC.GetExportedValue<IUnitOfWorkFactory>();
            _service = factory.Create().Create<IPlanReceiptOrderService>();
        }

        [Given(@"я достаю из бд существующий ППО с Rn = (.*)")]
        public void ДопустимЯДостаюИзБдСуществующийППОСRN(int p0)
        {
            var dto = _service.GetPlanReceiptOrder(p0);
            var planReceiptOrder = dto.MapTo<PlanReceiptOrder>();
            _viewModel.SetEditableObject(planReceiptOrder, EditState.Edit);
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

        [Given(@"изменяю дату (.*)\.(.*)\.(.*) документа основания")]
        public void ДопустимИзменяюДату_ДокументаОснования(int p0, int p1, int p2)
        {
            //this._viewModel.EditableObject.GroundDocumentDate = DateTime.Parse(p0);
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

        [Given(@"изменяю дату (.*)\.(.*)\.(.*) документа основания для получения")]
        public void ДопустимИзменяюДату_ДокументаОснованияДляПолучения(int p0, int p1, int p2)
        {
            //this._viewModel.EditableObject.GroundReceiptDocumentDate = DateTime.Parse(p0);
        }

        [Given(@"изменяю поставщика (.*)")]
        public void ДопустимИзменяюПоставщика(int p0)
        {
            this._viewModel.EditableObject.UserContractor = new User(p0);
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
            this._viewModel.WhenAny(x => x.IsBusy, x => x.Value).Where(isBusy => !isBusy).Subscribe(_ => this.WaitHandle.Set());
        }

        [Then(@"я вижу окно c сообщением - успешно обновлено")]
        public void ТоЯВижуОкноCСообщением_УспешноОбновлено()
        {
            // Если никаких ексепшенов нет, то подключились нормально
            System.Threading.WaitHandle.WaitAny(new WaitHandle[] { this.WaitHandle }, 10000);
            this.Dispose();
        }
    }
}
