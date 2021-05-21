namespace Halfblood.AcceptanceTests.Integration.SZI
{
    using Buisness.Entities.CommonDomain;

    using Halfblood.AcceptanceTests.Steps;

    using NUnit.Framework;

    using ParusModelLite.CertificateQualityDomain.ManufacturersCertificateDomain;

    using UI.Infrastructure;

    public class BuildSSHTest : StepBase
    {
        private IDummyViewModel _dummyViewModel;

        [SetUp]
        public void SetUp()
        {
            _dummyViewModel = Bootstrapper.IoC.GetExportedValue<IDummyViewModel>();
        }

        [Test]
        public void BuildSSH()
        {
            var certificateQuality = new CertificateQualityRestLiteDto();
            var viewModel = _dummyViewModel;

            viewModel.CertificateQuality = certificateQuality;
            viewModel.InStoreGasStationOilDepot = new StoreGasStationOilDepotDto { Rn = 777 };
            viewModel.Quantity = 10;

            viewModel.DealCommand.Execute(null);
            viewModel.Wait();
        }
    }
}
