// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PlanCertificateInsert.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the PlanCertificateInsert type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Halfblood.AcceptanceTests.Integration
{
    using System;
    using System.Linq;

    using Buisness.Entities.CertificateQualityDomain.ManufacturersCertificateDomain;
    using Buisness.Entities.CommonDomain;
    using Buisness.Entities.PlanReceiptOrderDomain;
    using Buisness.Filters;

    using Halfblood.AcceptanceTests.Steps;
    using Halfblood.Common;
    using Halfblood.Common.Mappers;

    using NUnit.Framework;

    using UI.Entities.CertificateQualityDomain.ManufacturersCertificateDomain;
    using UI.Entities.CommonDomain;
    using UI.Entities.PlanReceiptOrderDomain;
    using UI.Infrastructure;
    using UI.Infrastructure.ViewModels.Filters;
    using UI.Infrastructure.ViewModels.PlanReceiptOrderDomain;
    using UI.ProcessComponents.EditViewModels;

    public class PlanCertificateInsert : StepBase
    {
        [Test]
        public void InsertTest()
        {
            var filterFactory = Bootstrapper.IoC.GetExportedValue<IFilterViewModelFactory>();
            var routableViewModelManager = Bootstrapper.IoC.GetExportedValue<IRoutableViewModelManager>();
            var viewModel = routableViewModelManager.Get<IEditablePlanCertificateViewModel>();

            var planCertificate = new PlanCertificate
            {
                CertificateQuality = this.GetCertificateQuality(filterFactory),
                CountByDocument = 1,
                CreationDate = new DateTime(2013, 2, 2),
                Note = "sd",
                StateDate = new DateTime(2013, 2, 2),
                PlanReceiptOrder = GetPlanReceiptOrder(filterFactory),
                Price = 1,
                UserCreator = GetUser(filterFactory),
                CountFact = 3,
                State = PlanCertificateState.Close
            };

            viewModel.SetEditableObject(planCertificate, EditState.Insert);
            ((EditableContext<PlanCertificate>)viewModel).Wait();
        }

        private CertificateQuality GetCertificateQuality(IFilterViewModelFactory filterFactory)
        {
            var filterPC = filterFactory.Create<CertificateQualityFilter, CertificateQualityDto>();
            filterPC.Wait();

            return filterPC.Result.First().MapTo<CertificateQuality>();
        }

        private PlanReceiptOrder GetPlanReceiptOrder(IFilterViewModelFactory filterFactory)
        {
            var filterPC = filterFactory.Create<PlanReceiptOrderFilter, PlanReceiptOrderDto>();
            filterPC.Wait();

            return filterPC.Result.First().MapTo<PlanReceiptOrder>();
        }

        private User GetUser(IFilterViewModelFactory filterFactory)
        {
            var filterPC = filterFactory.Create<UserFilter, UserDto>();
            filterPC.Wait();

            return filterPC.Result.First().MapTo<User>();
        }
    }
}
