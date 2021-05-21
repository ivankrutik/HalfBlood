// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AsyncTestHelper.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the AsyncTestHelper type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Halfblood.Test.MockObjects
{
    using System;
    using System.Reactive.Linq;
    using System.Threading;

    using ReactiveUI;

    using UI.Infrastructure;
    using UI.Infrastructure.ViewModels;

    /// <summary>
    /// The view model helper.
    /// </summary>
    public static class AsyncTestHelper
    {
        /// <summary>
        /// The execute operation test.
        /// </summary>
        /// <param name="createViewModel">
        /// The create view model.
        /// </param>
        /// <param name="createEvent">
        /// The create event.
        /// </param>
        /// <param name="assert">
        /// The assert.
        /// </param>
        /// <param name="execute">
        /// The execute.
        /// </param>
        /// <typeparam name="TInstance">
        /// type of the view model
        /// </typeparam>
        /// <typeparam name="TRet">
        /// the return value
        /// </typeparam>
        public static void ExecuteOperationTest<TInstance, TRet>(
            Func<TInstance> createViewModel,
            Func<TInstance, IObservable<TRet>> createEvent,
            Action<TInstance> assert,
            Action<TInstance> execute,
            int timeout = 1000,
            Action testIsTimeout = null)
        {
            bool result = false;
            using (var waitHandle = new ManualResetEvent(false))
            {
                var viewModel = createViewModel();

                createEvent(viewModel)
                    .Subscribe(x =>
                    {
                        result = true;
                        assert(viewModel);
                        waitHandle.Set();
                    });

                execute(viewModel);
                WaitHandle.WaitAny(new WaitHandle[] { waitHandle }, timeout);
            }
            if (!result && testIsTimeout != null)
            {
                testIsTimeout();
            }
        }

        /// <summary>
        /// The save or update.
        /// </summary>
        /// <param name="createViewModel">
        /// The create view model.
        /// </param>
        /// <param name="createEditableMetadata">
        /// The create editable object.
        /// </param>
        /// <param name="editObject">
        /// The edit object.
        /// </param>
        /// <param name="assert">
        /// The assert.
        /// </param>
        /// <typeparam name="TViewModel">
        /// type of the view model
        /// </typeparam>
        /// <typeparam name="TEditableObject">
        /// type of the editable object
        /// </typeparam>
        public static void SaveOrUpdate<TViewModel, TEditableObject>(
            Func<TViewModel> createViewModel,
            Func<EditableMetadata<TEditableObject>> createEditableMetadata,
            Action<TEditableObject> editObject,
            Action<TEditableObject> assert)
            where TViewModel : IEditableViewModel<TEditableObject>
        {
            TViewModel viewModel = createViewModel();
            EditableMetadata<TEditableObject> editableMetadata = createEditableMetadata();

            viewModel.SetEditableObject(editableMetadata.EditableObject, editableMetadata.EditState);
            editObject(editableMetadata.EditableObject);

            ExecuteOperationTest(
                () => viewModel,
                vm => vm.WhenAny(x => x.IsBusy, x => x.Value).Skip(1).Where(isBusy => !isBusy),
                vm => assert(editableMetadata.EditableObject),
                vm => vm.ApplyCommand.Execute(null));
        }
    }

    /// <summary>
    /// The editable metadata.
    /// </summary>
    /// <typeparam name="TEditableObject">
    /// type of the editable object
    /// </typeparam>
    public class EditableMetadata<TEditableObject>
    {
        /// <summary>
        /// Gets or sets the edit state.
        /// </summary>
        public EditState EditState { get; set; }

        /// <summary>
        /// Gets or sets the editable object.
        /// </summary>
        public TEditableObject EditableObject { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EditableMetadata{TEditableObject}"/> class.
        /// </summary>
        /// <param name="editState">
        /// The edit state.
        /// </param>
        /// <param name="editableObject">
        /// The editable object.
        /// </param>
        public EditableMetadata(EditState editState, TEditableObject editableObject)
        {
            EditState = editState;
            EditableObject = editableObject;
        }
    }
}