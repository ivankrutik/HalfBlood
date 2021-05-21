namespace Halfblood.AcceptanceTests.Integration
{
    using System.Linq;

    using Buisness.Filters;

    using Halfblood.AcceptanceTests.Steps;
    using Halfblood.Common.Mappers;

    using NUnit.Framework;

    using ParusModelLite.DepartmentOrderDomain;

    using UI.Entities.CertificateQualityDomain.ManufacturersCertificateDomain;
    using UI.Entities.DepartmentOrderDomain;
    using UI.Infrastructure;
    using UI.Infrastructure.ViewModels.DepartmentOrderDomain;
    using UI.Infrastructure.ViewModels.Filters;
    using UI.ProcessComponents.EditViewModels;

    // Юзер товаровед
    // получаю сообшение о визировке
    // открываю программу
    // вижу свои заявки
    // открываю заявку указываю количество и возможно конкретный сертификат
    // сохраняю
    // отправляется сообщение кладовщику о выдаче материала
    public class GoodsManagerTest : StepBase
    {
        [Test]
        public void EditAndSaveDepartmentOrderTest()
        {
            var filterFactory = Bootstrapper.IoC.GetExportedValue<IFilterViewModelFactory>();

            var filteringObject = filterFactory.Create<DepartmentOrderFilter, DepartmentOrderLiteDto>();
            filteringObject.Wait();

            var departmentOrder = filteringObject.Result.First().MapTo<DepartmentOrder>();

            var editSightViewModel = Bootstrapper.IoC.GetExportedValue<IEditDepartmentOrderViewModel>();
            editSightViewModel.SetEditableObject(departmentOrder, EditState.Edit);
            editSightViewModel.EditableObject.ConfirmedQuantity = 100;
            editSightViewModel.EditableObject.Specifications.Add(new DepartmentOrderSpecification(100));

            editSightViewModel.ApplyCommand.Execute(null);

            ((EditableContext<DepartmentOrder>)editSightViewModel).Wait();

            Assert.That(editSightViewModel.EditableObject.Rn, Is.GreaterThanOrEqualTo(1));
        }

        public void SendMessage()
        {
            // Отправка сообщения
        }
    }
}
