namespace Halfblood.AcceptanceTests.Integration
{
    using System;
    using System.Threading;

    using Halfblood.AcceptanceTests.Steps;

    using NUnit.Framework;

    using ParusModelLite.CertificateQualityDomain.ManufacturersCertificateDomain;

    using UI.Entities.DepartmentOrderDomain;
    using UI.Infrastructure;
    using UI.Infrastructure.ViewModels.DepartmentOrderDomain;
    using UI.ProcessComponents.EditViewModels;

    // Юзер цеха
    public class UserOfShopTest : StepBase
    {
        // Открываю прогрумма  и вижу все заявки
        [Test]
        public void TesFilteringDepartmentOrder()
        {
            var departmentOrdersViewModel = Bootstrapper.IoC.GetExportedValue<IDepartmentOrderViewModel>();
            departmentOrdersViewModel.DepartmentOrderFilteringObject.InvokeCommand.Execute(null);

            departmentOrdersViewModel.DepartmentOrderFilteringObject.Wait();

            Assert.That(departmentOrdersViewModel.DepartmentOrderFilteringObject.Result, Is.Not.Null);
            Assert.That(departmentOrdersViewModel.DepartmentOrderFilteringObject.Result.Count, Is.GreaterThanOrEqualTo(1));
        }

        // Создаю новую заявку.
        [Test]
        public void PreparingInsertingClaim()
        {
            var departmentOrdersViewModel = Bootstrapper.IoC.GetExportedValue<IDepartmentOrderViewModel>();

            departmentOrdersViewModel.HostScreen.Router.NavigationStack.ItemsAdded.Subscribe(
                routableViewModel => Assert.That(routableViewModel, Is.InstanceOf<IEditDepartmentOrderViewModel>()));

            departmentOrdersViewModel.PreparingForAddDepartmentOrderCommand.Execute(null);

            Thread.Sleep(500);
        }

        // смотрю какие есть сертификаты завода изготовителя на складах
        [Test]
        public void FilteringCertificateFiltering()
        {
            var editSightViewModel = Bootstrapper.IoC.GetExportedValue<IEditDepartmentOrderViewModel>();
            editSightViewModel.CertificateQualityFilteringObject.InvokeCommand.Execute(null);

            editSightViewModel.CertificateQualityFilteringObject.Wait();

            Assert.That(editSightViewModel.CertificateQualityFilteringObject.Result, Is.Not.Null);
            Assert.That(editSightViewModel.CertificateQualityFilteringObject.Result.Count, Is.GreaterThanOrEqualTo(1));
        }

        // проверяю не создавал ли кто уже заявку на данный материал (ищу завяку на этот материал)
        [Test]
        public void FilteringClaims()
        {
            var editSightViewModel = Bootstrapper.IoC.GetExportedValue<IEditDepartmentOrderViewModel>();
            editSightViewModel.DepartmentOrderFilteringObject.InvokeCommand.Execute(null);

            editSightViewModel.DepartmentOrderFilteringObject.Wait();

            Assert.That(editSightViewModel.DepartmentOrderFilteringObject.Result, Is.Not.Null);
            Assert.That(editSightViewModel.DepartmentOrderFilteringObject.Result.Count, Is.GreaterThanOrEqualTo(1));
        }

        // выбираю сертификат
        [Test]
        public void SelectedCertificate()
        {
            var editSightViewModel = Bootstrapper.IoC.GetExportedValue<IEditDepartmentOrderViewModel>();
            var selectedCertificate = new CertificateQualityLiteDto();

            editSightViewModel.SelectedCertificate = selectedCertificate;

            Assert.That(object.ReferenceEquals(editSightViewModel.SelectedCertificate, selectedCertificate));
        }

        // заполняю поля и сохраняю
        // отправляется сообщение визирования товароведу
        [Test]
        public void SaveDepartmentOrder()
        {
            var editSightViewModel = Bootstrapper.IoC.GetExportedValue<IEditDepartmentOrderViewModel>();
            editSightViewModel.SetEditableObject(new DepartmentOrder(), EditState.Insert);
            editSightViewModel.EditableObject.Comments.Add(new DepartmentOrderComment { Comment = "SASAI LALKA!" });

            editSightViewModel.ApplyCommand.Execute(null);

            ((EditableContext<DepartmentOrder>)editSightViewModel).Wait();

            Assert.That(editSightViewModel.EditableObject.Rn, Is.GreaterThanOrEqualTo(1));
        }

        [Test]
        public void SendMessage()
        {
            // Тут пока не понятно, нудно ли передовать в фасад сервиса - IMailManager
            // var service = 
        }
    }
}
