// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EditableChemicalViewModelTest.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the EditableChemicalViewModelTest type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Halfblood.ViewModels.Test
{
    using System;
    using System.Collections.Generic;
    using System.Reactive.Linq;
    using System.Threading;

    using Buisness.Entities.CertificateQualityDomain.ManufacturersCertificateDomain;
    using Buisness.Filters;

    using Halfblood.Test.MockObjects;

    using NUnit.Framework;

    using ReactiveUI;

    using UI.Entities.CertificateQualityDomain.ManufacturersCertificateDomain;
    using UI.Infrastructure.ViewModels.Filters;
    using UI.ProcessComponents.EditViewModels;
    using UI.ProcessComponents.FilterViewModels;

    [TestFixture]
    public class EditableChemicalViewModelTest : TestBase
    {
        private EditableChemicalViewModel _viewModel;

        [SetUp]
        public void SetUp()
        {
            _viewModel = new EditableChemicalViewModel(
                new FakeScreen(),
                new FilterViewModelFactory(new FakeUnitOfWorkFactory()));
        }

        [Test]
        public void Test()
        {
            var cq = new CertificateQuality(100);

            _viewModel.SetEditableObject(cq.ChemicalIndicatorValues);
            _viewModel.EditableObject.Add(new ChemicalIndicatorValue());
            _viewModel.ApplyCommand.Execute(null);

            Thread.Sleep(500);

            Assert.That(_viewModel.EditableObject[0].CertificateQuality, Is.Not.Null);
            Assert.That(_viewModel.EditableObject[0].CertificateQuality.Rn, Is.EqualTo(100));
        }

        [Test]
        public void SetEditableObject()
        {
            var chemicalIndicators = new List<ChemicalIndicatorValue>();
            _viewModel.SetEditableObject(chemicalIndicators);

            Assert.That(_viewModel.EditableObject, Is.Not.Null);
            Assert.That(_viewModel.EditableObject, Is.InstanceOf<List<ChemicalIndicatorValue>>());
            Assert.That(_viewModel.EditableObject.Count, Is.EqualTo(chemicalIndicators.Count));
        }

        [Test]
        public void Update()
        {
            var chemicalIndicators = new List<ChemicalIndicatorValue>();
            _viewModel.SetEditableObject(chemicalIndicators);

            _viewModel.EditableObject.Add(new ChemicalIndicatorValue());
            _viewModel.EditableObject.Add(new ChemicalIndicatorValue());
            _viewModel.EditableObject.Add(new ChemicalIndicatorValue());

            Assert.That(chemicalIndicators.Count, Is.EqualTo(0));

            AsyncTestHelper.ExecuteOperationTest(
                () => _viewModel,
                vm => vm.WhenAny(x => x.IsBusy, x => x.Value).Where(isBusy => !isBusy).Skip(1),
                vm => Assert.That(chemicalIndicators.Count, Is.EqualTo(3)),
                vm => vm.ApplyCommand.Execute(null),
                1000,
                () => Assert.Fail("Test is timeout"));
        }
    }

    public class EditableChemicalViewModel : EditableViewModelBase<IList<ChemicalIndicatorValue>>
    {
        public bool IsLoad { get; private set; }
        public IList<ChemicalIndicatorValueDto> ChemicalIndicatorValues { get; private set; }

        public EditableChemicalViewModel(IScreen screen, IFilterViewModelFactory filterViewModelFactory)
            : base(screen)
        {
            var loader = filterViewModelFactory.Create<ChemicalIndicatorValueFilter, ChemicalIndicatorValueDto>();

            loader.WhenAny(x => x.IsBusy, x => x.Value).Subscribe(isBusy => IsLoad = isBusy);
            loader.WhenAny(x => x.Result, x => x.Value)
                  .Subscribe(res => ChemicalIndicatorValues = res);

            loader.InvokeCommand.Execute(null);
        }

        protected override void ApplyAction(IList<ChemicalIndicatorValue> permissionMaterial)
        {
        }
    }
}
