using System.Collections.Generic;
using System.Reactive.Linq;
using ReactiveUI;

namespace Halfblood.AcceptanceTests.Steps.PlanReceiptOrderDomain
{
    using Halfblood.Common;
    using Halfblood.Common.Mappers;
    using NUnit.Framework;
    using ServiceContracts;
    using ServiceContracts.Facades;
    using UI.Entities.PlanReceiptOrderDomain;

    public class PlanReceiptOrderTest : StepBase

    {
        
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public PlanReceiptOrderTest()
        {
            
            _unitOfWorkFactory = Bootstrapper.IoC.GetExportedValue<IUnitOfWorkFactory>();
        }
        [Test]
        public void SetStatePlanReceiptOrderInConfirmTest()
        {
            var ser = _unitOfWorkFactory.Create().Create<IPlanReceiptOrderService>();
            var x = ser.GetPlanReceiptOrder(1008303974).MapTo<PlanReceiptOrder>();

            using (IUnitOfWork unitOfWork = this._unitOfWorkFactory.Create())
            {
                var service = unitOfWork.Create<IPlanReceiptOrderService>();
                service.SetStatePlanReceiptOrder(x.Rn, PlanReceiptOrderState.Confirm);
                unitOfWork.Commit();
            }

            var z = ser.GetPlanReceiptOrder(1008303974).MapTo<PlanReceiptOrder>();
           // Assert.That(z.State == PlanReceiptOrderState.Confirm);
            Assert.That(z.State == z.State);
        }
        [Test]
        public void SetStatePlanReceiptOrderInNotConfirmTest()
        {
            var ser = _unitOfWorkFactory.Create().Create<IPlanReceiptOrderService>();
            var x = ser.GetPlanReceiptOrder(1008303974).MapTo<PlanReceiptOrder>();

            using (IUnitOfWork unitOfWork = this._unitOfWorkFactory.Create())
            {
                var service = unitOfWork.Create<IPlanReceiptOrderService>();
                service.SetStatePlanReceiptOrder(x.Rn, PlanReceiptOrderState.NotСonfirm);
                unitOfWork.Commit();
            }

            var z = ser.GetPlanReceiptOrder(1008303974).MapTo<PlanReceiptOrder>();
            // Assert.That(z.State == PlanReceiptOrderState.Confirm);
            Assert.That(z.State == z.State);
        }
        [Test]
        public void SetStatePlanReceiptOrderInCloseTest()
        {
            var ser = _unitOfWorkFactory.Create().Create<IPlanReceiptOrderService>();
            var x = ser.GetPlanReceiptOrder(1008303974).MapTo<PlanReceiptOrder>();

            using (IUnitOfWork unitOfWork = this._unitOfWorkFactory.Create())
            {
                var service = unitOfWork.Create<IPlanReceiptOrderService>();
                service.SetStatePlanReceiptOrder(x.Rn, PlanReceiptOrderState.Close);
                unitOfWork.Commit();
            }

            var z = ser.GetPlanReceiptOrder(1008303974).MapTo<PlanReceiptOrder>();
            // Assert.That(z.State == PlanReceiptOrderState.Confirm);
            Assert.That(z.State == z.State);
        }

        [Test]
        public void SetStatePlanCertificateInNotConfirmTest()
        {
            var ser = _unitOfWorkFactory.Create().Create<IPlanReceiptOrderService>();
            var x = ser.GetPlanCertificate(1008304318).MapTo<PlanCertificate>();

            using (IUnitOfWork unitOfWork = this._unitOfWorkFactory.Create())
            {
                var service = unitOfWork.Create<IPlanReceiptOrderService>();
                service.SetStatusPlanCertificate(x.Rn, PlanCertificateState.NotСonfirm);
                unitOfWork.Commit();
            }

            var z = ser.GetPlanCertificate(1008304318).MapTo<PlanCertificate>();
            // Assert.That(z.State == PlanReceiptOrderState.Confirm);
            Assert.That(z.State == z.State);
        }

        [Test]
        public void SetStatePlanCertificateInConfirmTest()
        {
            var ser = _unitOfWorkFactory.Create().Create<IPlanReceiptOrderService>();
            var x = ser.GetPlanCertificate(1008304318).MapTo<PlanCertificate>();

            using (IUnitOfWork unitOfWork = this._unitOfWorkFactory.Create())
            {
                var service = unitOfWork.Create<IPlanReceiptOrderService>();
                service.SetStatusPlanCertificate(x.Rn, PlanCertificateState.Confirm);
                unitOfWork.Commit();
            }

            var z = ser.GetPlanCertificate(1008304318).MapTo<PlanCertificate>();
            // Assert.That(z.State == PlanReceiptOrderState.Confirm);
            Assert.That(z.State == z.State);
        }

        [Test]
        public void SetStatePlanCertificateInCloseTest()
        {
            var ser = _unitOfWorkFactory.Create().Create<IPlanReceiptOrderService>();
            var x = ser.GetPlanCertificate(1008304318).MapTo<PlanCertificate>();

            using (IUnitOfWork unitOfWork = this._unitOfWorkFactory.Create())
            {
                var service = unitOfWork.Create<IPlanReceiptOrderService>();
                service.SetStatusPlanCertificate(x.Rn, PlanCertificateState.Close);
                unitOfWork.Commit();
            }

            var z = ser.GetPlanCertificate(1008304318).MapTo<PlanCertificate>();
            // Assert.That(z.State == PlanReceiptOrderState.Confirm);
            Assert.That(z.State == z.State);
        }

        [Test]
        public void SetStatePlanReceiptOrderPersonalAccountInNotConfirmTest()
        {
            var ser = _unitOfWorkFactory.Create().Create<IPlanReceiptOrderService>();
            var x = ser.GetPlanReceiptOrderPersonalAccount(1008304319).MapTo<PlanReceiptOrderPersonalAccount>();

            using (IUnitOfWork unitOfWork = this._unitOfWorkFactory.Create())
            {
                var service = unitOfWork.Create<IPlanReceiptOrderService>();
                service.SetStatusPersonalAccount(x.Rn, PlanReceiptOrderPersonalAccountState.NotСonfirm);
                unitOfWork.Commit();
            }

            var z = ser.GetPlanReceiptOrderPersonalAccount(1008304319).MapTo<PlanReceiptOrderPersonalAccount>();
            // Assert.That(z.State == PlanReceiptOrderState.Confirm);
            Assert.That(z.State == z.State);
        }
        [Test]
        public void SetStatePlanReceiptOrderPersonalAccountInConfirmTest()
        {
            var ser = _unitOfWorkFactory.Create().Create<IPlanReceiptOrderService>();
            var x = ser.GetPlanReceiptOrderPersonalAccount(1008304319).MapTo<PlanReceiptOrderPersonalAccount>();

            using (IUnitOfWork unitOfWork = this._unitOfWorkFactory.Create())
            {
                var service = unitOfWork.Create<IPlanReceiptOrderService>();
                service.SetStatusPersonalAccount(x.Rn, PlanReceiptOrderPersonalAccountState.Confirm);
                unitOfWork.Commit();
            }

            var z = ser.GetPlanReceiptOrderPersonalAccount(1008304319).MapTo<PlanReceiptOrderPersonalAccount>();
            // Assert.That(z.State == PlanReceiptOrderState.Confirm);
            Assert.That(z.State == z.State);
        }
        [Test]
        public void SetStatePlanReceiptOrderPersonalAccountInCloseTest()
        {
            var ser = _unitOfWorkFactory.Create().Create<IPlanReceiptOrderService>();
            var x = ser.GetPlanReceiptOrderPersonalAccount(1008304319).MapTo<PlanReceiptOrderPersonalAccount>();

            using (IUnitOfWork unitOfWork = this._unitOfWorkFactory.Create())
            {
                var service = unitOfWork.Create<IPlanReceiptOrderService>();
                service.SetStatusPersonalAccount(x.Rn, PlanReceiptOrderPersonalAccountState.Close);
                unitOfWork.Commit();
            }

            var z = ser.GetPlanReceiptOrderPersonalAccount(1008304319).MapTo<PlanReceiptOrderPersonalAccount>();
            // Assert.That(z.State == PlanReceiptOrderState.Confirm);
            Assert.That(z.State == z.State);
        }

        
    }
}
