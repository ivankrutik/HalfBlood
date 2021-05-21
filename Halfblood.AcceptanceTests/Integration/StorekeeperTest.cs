namespace Halfblood.AcceptanceTests.Integration
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;

    using Buisness.Filters;

    using Halfblood.AcceptanceTests.Steps;
    using Halfblood.Common.Mappers;
    using Halfblood.Common.Reporting;
    using Halfblood.Reports;

    using NUnit.Framework;

    using ParusModelLite.DepartmentOrderDomain;

    using Rhino.Mocks;

    using UI.Entities.CertificateQualityDomain.ManufacturersCertificateDomain;
    using UI.Entities.DepartmentOrderDomain;
    using UI.Infrastructure.ViewModels.DepartmentOrderDomain;
    using UI.Infrastructure.ViewModels.Filters;

    // Юзер кладовщица
    // получаю месагу о необходимости выдать материал
    // открываю программу
    // выбираю все заявки и печатаю гумашку черновик
    // бигу выдаю материал.
    // подхожу к ПК шелкаю по гумашке и указываю конкретное колчиество.
    // печатаю сертифкат складского хозяйства (бирку на материал)
    // закрываю заявку
    public class StorekeeperTest : StepBase
    {
        [Test]
        public void OpenSalesRepTest()
        {
            var reportMetaData = new SalesReport
            {
                PrintReportName = "report header",
                Uid = 728989149
            };

            var printManager = MockRepository.GenerateMock<IPrintManager>();
            printManager.OpenReportInBrowser(reportMetaData);
        }

        // Открывает браузер с отчетом
        [Test]
        public void OpenReportTest()
        {
            IList<DepartmentOrder> departmentOrders = new List<DepartmentOrder>();
            var reportMetadata = new DepartmentOrderReport();
            reportMetadata.SetDepartmentOrders(departmentOrders);

            var printManager = MockRepository.GenerateMock<IPrintManager>();
            printManager.OpenReportInBrowser(reportMetadata);
        }

        // подхожу к ПК шелкаю по гумашке и открываю окно редактирования заявки.
        [Test]
        public void FindDepartmentOrderByBarcodeTest()
        {
            var filterFactory = Bootstrapper.IoC.GetExportedValue<IFilterViewModelFactory>();

            var filteringObject = filterFactory.Create<DepartmentOrderFilter, DepartmentOrderLiteDto>();
            filteringObject.Wait();

            long rnDepartmentOrder = filteringObject.Result.First().MapTo<DepartmentOrder>().Rn;

            bool isNavigate = false;
            var departmentOrdersViewModel = Bootstrapper.IoC.GetExportedValue<IDepartmentOrderViewModel>();
            departmentOrdersViewModel.HostScreen.Router.NavigationStack.ItemsAdded.Subscribe(
                routableViewModel =>
                {
                    Assert.That(routableViewModel, Is.InstanceOf<IEditDepartmentOrderViewModel>());
                    isNavigate = true;
                });

            departmentOrdersViewModel.EnteredBarcode(rnDepartmentOrder.ToString());
            departmentOrdersViewModel.DepartmentOrderFilteringObject.Wait();

            Thread.Sleep(1000);

            Assert.IsTrue(isNavigate);
            Assert.That(departmentOrdersViewModel.DepartmentOrderFilteringObject.Result, Is.Not.Null);
            Assert.That(departmentOrdersViewModel.DepartmentOrderFilteringObject.Result.Count, Is.EqualTo(1));
            Assert.That(
                departmentOrdersViewModel.DepartmentOrderFilteringObject.Result.First().Rn,
                Is.EqualTo(rnDepartmentOrder));
        }

        // печатаю сертифкат складского хозяйства (бирку на материал)
        [Test]
        public void OpenReportCertificateQualityTest()
        {
            var certificateQuality = new CertificateQuality(100);
            var reportMetadata = new CertificateQualityReport();
            reportMetadata.SetCertificateQuality(certificateQuality);

            var printManager = MockRepository.GenerateMock<IPrintManager>();
            printManager.OpenReportInBrowser(reportMetadata);
        }

        public class DepartmentOrderReport : IReportMetadata
        {
            public long Uid { get; private set; }
            public string ReportName
            {
                get { return "FakeReport"; }
            }
            public void SetDepartmentOrders(IList<DepartmentOrder> departmentOrders)
            {
            }
            [Key("sFirstname")]
            public string Firstname { get; set; }
            [Key("sLastname")]
            public string Lastname { get; set; }
        }
        public class CertificateQualityReport : IReportMetadata
        {
            public long Uid { get; private set; }
            public string ReportName
            {
                get { return "CertificateQualityReport"; }
            }
            public void SetCertificateQuality(CertificateQuality certificateQuality)
            {
            }
        }
    }
}