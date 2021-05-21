// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EditPlanCertificateViewModelTest.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the EditPlanCertificateViewModelTest type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Halfblood.ViewModels.Test.PlanReceiptOrderDomain
{
    using System;

    using Filtering.Infrastructure;

    using FizzWare.NBuilder;

    using FluentValidation;

    using Halfblood.Common;
    using Halfblood.Common.Helpers;
    using Halfblood.Test.MockObjects;

    using NUnit.Framework;

    using ReactiveUI;

    using Rhino.Mocks;

    using UI.Entities.CertificateQualityDomain.ManufacturersCertificateDomain;
    using UI.Entities.CommonDomain;
    using UI.Entities.NomeclatorDomain;
    using UI.Entities.PlanReceiptOrderDomain;
    using UI.Infrastructure;
    using UI.Infrastructure.ViewModels;
    using UI.Infrastructure.ViewModels.Filters;
    using UI.Infrastructure.ViewModels.PlanReceiptOrderDomain;
    using UI.ProcessComponents.FilterViewModels;
    using UI.ProcessComponents.PlanReceiptOrderDomain.PlanCertificateDomain;
    using UI.Resources;

    /// <summary>
    /// The edit plan certificate view model test.
    /// </summary>
    public class EditPlanCertificateViewModelTest1 : TestBase
    {
        [Test]
        public void CreateEditPlanCertificatViewModel()
        {
            IEditablePlanCertificateViewModel vm = CreateViewModel(new FakeFilterViewModelFactory());

            Assert.That(vm, Is.Not.Null);
            Assert.That(vm, Is.InstanceOf<EditablePlanCertificateViewModel>());
        }

        [Test]
        public void Edit()
        {
            IMessenger messanger = new FakeMessenger();
            AsyncTestHelper.SaveOrUpdate(
                () => CreateViewModel(new FakeFilterViewModelFactory()),
                () => new EditableMetadata<PlanCertificate>(EditState.Edit, FakeCreateEntity()),
                edit => edit.CountByDocument = 999,
                edit =>
                {
                    Assert.That(edit, Is.Not.Null);
                    Assert.That(edit.CountByDocument, Is.EqualTo(999));
                    Assert.That(messanger.Messages.Count, Is.EqualTo(1));
                    Assert.That(messanger.Messages[0].Body, Is.EqualTo(CustomMessages.UpdatedSuccessfully));
                });
        }

        [Test]
        public void Add()
        {
            IMessenger messanger = new FakeMessenger();
            AsyncTestHelper.SaveOrUpdate(
                () => CreateViewModel(new FakeFilterViewModelFactory()),
                () => new EditableMetadata<PlanCertificate>(EditState.Insert, FakeCreateEntity()),
                edit => { },
                edit =>
                {
                    Assert.That(edit, Is.Not.Null);
                    Assert.That(edit.Rn, Is.GreaterThan(0));
                    Assert.That(messanger.Messages.Count, Is.EqualTo(1));
                    Assert.That(messanger.Messages[0].Body, Is.EqualTo(CustomMessages.AddedSuccessfully));
                });
        }

        private PlanCertificate FakeCreateEntity()
        {
            return Builder<PlanCertificate>.CreateNew()
                .With(x => x.CertificateQuality, Builder<CertificateQuality>.CreateNew().Build())
                .With(x => x.ModificationNomenclature, Builder<NomenclatureNumberModification>.CreateNew().Build())
                .With(x => x.NameOfCurrency, Builder<NameOfCurrency>.CreateNew().Build())
                .With(x => x.PlanReceiptOrder, Builder<PlanReceiptOrder>.CreateNew().Build())
                .With(x => x.StoreGasStationOilDepot, Builder<StoreGasStationOilDepot>.CreateNew().Build())
                .With(x => x.UserCreator, Builder<User>.CreateNew().Build())
                .Build();
        }
        private IEditablePlanCertificateViewModel CreateViewModel(
            IFilterViewModelFactory filterViewModelFactory = null,
            IValidatorFactory validatorFactory = null)
        {
            return new EditablePlanCertificateViewModel(
                new FakeScreen(),
                new FakeUnitOfWorkFactory(),
                MockRepository.GenerateMock<IRoutableViewModelManager>(),
                filterViewModelFactory ?? MockRepository.GenerateMock<IFilterViewModelFactory>(),
                validatorFactory ?? MockRepository.GenerateMock<IValidatorFactory>(),
                MockRepository.GenerateMock<IMessageBus>(),
                MockRepository.GenerateMock<IInitializationManager>());
        }
    }

    public class FakeFilterViewModelFactory : IFilterViewModelFactory
    {
        public IFilterViewModel<TFilter, TEntity> Create<TFilter, TEntity>(IObservable<bool> observable = null, bool doRunning = false)
            where TFilter : class, IUserFilter, new()
            where TEntity : IDto
        {
            return new GenericFilterViewModel<TFilter, TEntity>(new FakeUnitOfWorkFactory());
        }
    }
}