namespace UI.ProcessComponents.InitializationStrategies
{
    using System.ComponentModel.Composition;
    using System.Threading.Tasks;

    using Buisness.Entities.AttachedDocumentDomain;
    using Buisness.Filters;

    using Halfblood.Common.Helpers;
    using Halfblood.Common.Mappers;

    using UI.Entities.AttachedDocumentDomain;
    using UI.Infrastructure.ViewModels.Filters;
    using UI.ProcessComponents.PlanReceiptOrderDomain.PlanCertificateDomain;

    [InitializationFor(typeof(AttachedDocumentViewModel))]
    public class InitAttachedDocumentManager : IInitializationStrategy<AttachedDocumentViewModel>
    {
        private readonly IFilterViewModelFactory _filterViewModelFactory;

        [ImportingConstructor]
        public InitAttachedDocumentManager(IFilterViewModelFactory filterViewModelFactory)
        {
            this._filterViewModelFactory = filterViewModelFactory;
        }

        public Task InitViewModel(AttachedDocumentViewModel viewModel)
        {
            var taskDocType =
                _filterViewModelFactory.Create<AttachedDocumentTypeFilter, AttachedDocumentTypeDto>().GetInvokedTask();

            return Task.Factory.ContinueWhenAll(
                new Task[] { taskDocType },
                tasks =>
                {
                    viewModel.AttachedDocumentTypes = taskDocType.Result.MapTo<AttachedDocumentType>();
                });
        }

        public Task InitViewModel(object viewModel)
        {
            return InitViewModel((AttachedDocumentViewModel)viewModel);
        }
    }
}
