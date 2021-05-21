// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EditPlanReceiptOrderViewModelTest.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the EditPlanReceiptOrderViewModelTest type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Halfblood.ViewModels.Test.PlanReceiptOrderDomain
{
    using FizzWare.NBuilder;

    using FluentValidation;

    using Halfblood.Test.MockObjects;

    using NUnit.Framework;

    using ReactiveUI;

    using Rhino.Mocks;

    using UI.Entities.CommonDomain;
    using UI.Entities.PlanReceiptOrderDomain;
    using UI.Infrastructure;
    using UI.Infrastructure.ViewModels;
    using UI.Infrastructure.ViewModels.Filters;
    using UI.Infrastructure.ViewModels.PlanReceiptOrderDomain;
    using UI.ProcessComponents.PlanReceiptOrderDomain;
    using UI.Resources;

    /// <summary>
    /// The edit plan receipt order view model test.
    /// </summary>
    public class EditPlanReceiptOrderViewModelTest : TestBase
    {
        [Test]
        public void Create()
        {
            IEditablePlanReceiptOrderViewModel vm = CreateViewModel();

            Assert.That(vm, Is.Not.Null);
            Assert.That(vm, Is.InstanceOf<EditablePlanReceiptOrderViewModel>());
        }
        [Test]
        public void Edit()
        {
            IMessenger messanger = new FakeMessenger();
            AsyncTestHelper.SaveOrUpdate(
                () => CreateViewModel(messanger),
                () => new EditableMetadata<PlanReceiptOrder>(EditState.Edit, this.CreateEditableObject()),
                edit => edit.Note = "NoteNoteNote",
                edit =>
                {
                    Assert.That(edit, Is.Not.Null);
                    Assert.That(edit.Note, Is.EqualTo("NoteNoteNote"));
                    Assert.That(messanger.Messages.Count, Is.EqualTo(1));
                    Assert.That(messanger.Messages[0].Body, Is.EqualTo(CustomMessages.UpdatedSuccessfully));
                });
        }
        [Test]
        public void Add()
        {
            IMessenger messanger = new FakeMessenger();
            AsyncTestHelper.SaveOrUpdate(
                () => CreateViewModel(messanger),
                () => new EditableMetadata<PlanReceiptOrder>(EditState.Insert, this.CreateEditableObject()),
                edit => { },
                edit =>
                {
                    Assert.That(edit, Is.Not.Null);
                    Assert.That(edit.Rn, Is.GreaterThan(0));
                    Assert.That(messanger.Messages.Count, Is.EqualTo(1));
                    Assert.That(messanger.Messages[0].Body, Is.EqualTo(CustomMessages.AddedSuccessfully));
                });
        }

        private PlanReceiptOrder CreateEditableObject()
        {
            return
                Builder<PlanReceiptOrder>.CreateNew()
                    .With(x => x.UserContractor, Builder<User>.CreateNew().Build())
                    .With(x => x.UserCreator, Builder<User>.CreateNew().Build())
                    .Build();
        }
        private IEditablePlanReceiptOrderViewModel CreateViewModel(IMessenger messenger = null)
        {
            return new EditablePlanReceiptOrderViewModel(
                new FakeScreen(),
                new FakeUnitOfWorkFactory(),
                MockRepository.GenerateMock<IFilterViewModelFactory>(),
                MockRepository.GenerateStub<IMessageBus>(),
                MockRepository.GenerateStub<IValidatorFactory>());
        }
    }
}