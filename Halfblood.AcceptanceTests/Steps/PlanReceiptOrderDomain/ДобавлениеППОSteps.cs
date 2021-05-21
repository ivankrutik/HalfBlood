// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ДобавлениеППОSteps.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the ДобавлениеППОПлановогоПриходногоОрдераSteps type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Halfblood.AcceptanceTests.Steps.PlanReceiptOrderDomain
{
    using System;
    using System.Linq;

    using Halfblood.Common;
    using Halfblood.Common.Helpers;

    using TechTalk.SpecFlow;

    using UI.Entities.CommonDomain;
    using UI.Entities.PlanReceiptOrderDomain;
    using UI.Infrastructure;
    using UI.Infrastructure.ViewModels;
    using UI.Infrastructure.ViewModels.PlanReceiptOrderDomain;
    using UI.ProcessComponents.EditViewModels;

    [Binding]
    public class ДобавлениеППОПлановогоПриходногоОрдераSteps : StepBase
    {
        private readonly IEditablePlanReceiptOrderViewModel _viewModel;
        //private readonly IFilterViewModelFactory _filterViewModelFactory;
        private readonly IGetCatalogAccess _getCatalogAccess;

        public ДобавлениеППОПлановогоПриходногоОрдераSteps()
        {
            this._viewModel = this.Bootstrapper.IoC.GetExportedValue<IEditablePlanReceiptOrderViewModel>();
            //this._filterViewModelFactory = this.Bootstrapper.IoC.GetExportedValue<IFilterViewModelFactory>();
            this._getCatalogAccess = this.Bootstrapper.IoC.GetExportedValue<IGetCatalogAccess>();
        }

        [Given(@"Я хочу добавить ППО")]
        public void ДопустимЯХочуДобавитьППО()
        {
            this._viewModel.SetEditableObject(new PlanReceiptOrder(), EditState.Insert);
        }

        [Given(@"я ввожу каталог (.*)")]
        public void ДопустимЯВвожуКаталог(string p0)
        {
            _getCatalogAccess.LoadForEntity(typeof(PlanReceiptOrder), TypeActionInSystem.TheStandardAddition);
            _getCatalogAccess.Wait();
            
            var catalogs = _getCatalogAccess.Result.Union(_getCatalogAccess.Result.SelectMany(x => x.Childs));
            Catalog catalog = catalogs.Where(x => x.Name == p0).Select(x => new Catalog(x.Rn)).FirstOrDefault();

            if (catalog == null)
            {
                throw new Exception("Не могу найти каталог с именем {0}".StringFormat(p0));
            }

            _viewModel.EditableObject.Catalog = catalog;
        }

        [Given(@"ввожу склад (.*)")]
        public void ДопустимВвожуСклад(string p0)
        {
            this._viewModel.EditableObject.StoreGasStationOilDepot = new StoreGasStationOilDepot(long.Parse(p0));
        }

        [Given(@"ввожу тип (.*) документа основания")]
        public void ДопустимВвожуТипДокументаОснования(string p0)
        {
            this._viewModel.EditableObject.GroundTypeOfDocument = new TypeOfDocument(long.Parse(p0));
        }

        [Given(@"ввожу № (.*) документа основания")]
        public void ДопустимВвожуДокументаОснования(string p0)
        {
            this._viewModel.EditableObject.GroundDocumentNumb = p0;
        }

        [Given(@"ввожу дату (.*) документа основания")]
        public void ДопустимВвожуДатуДокументаОснования(string p0)
        {
            this._viewModel.EditableObject.GroundDocumentDate = DateTime.Parse(p0);
        }

        [Given(@"ввожу тип (.*) документа основания для получения")]
        public void ДопустимВвожуТипДокументаОснованияДляПолучения(string p0)
        {
            this._viewModel.EditableObject.GroundReceiptTypeOfDocument = new TypeOfDocument(long.Parse(p0));
        }

        [Given(@"ввожу № (.*) документа основания для получения")]
        public void ДопустимВвожуДокументаОснованияДляПолучения(string p0)
        {
            this._viewModel.EditableObject.GroundReceiptDocumentNumb = p0;
        }

        [Given(@"ввожу дату (.*) документа основания для получения")]
        public void ДопустимВвожуДатуДокументаОснованияДляПолучения(string p0)
        {
            this._viewModel.EditableObject.GroundReceiptDocumentDate = DateTime.Parse(p0);
        }

        [Given(@"ввожу поставщика (.*)")]
        public void ДопустимВвожуПоставщика(string p0)
        {
            this._viewModel.EditableObject.UserContractor = new User(long.Parse(p0));
        }

        [Given(@"ввожу примечание (.*)")]
        public void ДопустимВвожуПримечание(string p0)
        {
            this._viewModel.EditableObject.Note = p0;
        }

        [When(@"я нажимаю кнопку Сохранить")]
        public void ЕслиЯНажимаюКнопкуСохранить()
        {
            this._viewModel.ApplyCommand.Execute(null);
            ((EditableContext<PlanReceiptOrder>)this._viewModel).Wait();
        }

        [Then(@"я вижу окно c сообщением - успешно добалено")]
        public void ТоЯВижуОкноCСообщением_УспешноДобалено()
        {
            if (_viewModel.EditableObject.Rn <= 0)
            {
                throw new Exception("Rn добавляемого элемента при успешном добавлении должен быть больше чем 0");
            }
        }
    }
}
