// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InitEditablePlanCertificateStrategy.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the InitEditablePlanCertificateStrategy type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.ProcessComponents.InitializationStrategies
{
    using System.ComponentModel.Composition;
    using System.Diagnostics.Contracts;
    using System.Linq;
    using System.Threading.Tasks;

    using Buisness.Entities.CommonDomain;
    using Buisness.Filters;

    using Halfblood.Common.Helpers;
    using Halfblood.Common.Mappers;

    using ParusModelLite.CommonDomain;

    using UI.Entities.CommonDomain;
    using UI.Infrastructure.ViewModels.Filters;
    using UI.ProcessComponents.PlanReceiptOrderDomain.PlanCertificateDomain;

    /// <summary>
    /// The initialization editable plan certificate view model strategy.
    /// </summary>
    [InitializationFor(typeof(EditablePlanCertificateViewModel))]
    public class InitEditablePlanCertificateStrategy : IInitializationStrategy<EditablePlanCertificateViewModel>
    {
        private readonly IFilterViewModelFactory _filterViewModelFactory;

        [ImportingConstructor]
        public InitEditablePlanCertificateStrategy(IFilterViewModelFactory filterViewModelFactory)
        {
            this._filterViewModelFactory = filterViewModelFactory;
        }

        public Task InitViewModel(EditablePlanCertificateViewModel viewModel)
        {
            Contract.Requires(viewModel != null, "The view model must be not null");
            Contract.Requires(viewModel.EditableObject != null, "The editable object must be not null");
            Contract.Ensures(Contract.Result<Task>() != null);

            var taskUnitOfMeasure = _filterViewModelFactory.Create<UnitOfMeasureFilter, UnitOfMeasureDto>().GetInvokedTask();
            var taskNameOfCurrency = _filterViewModelFactory.Create<EmptyFilter, NameOfCurrencyDto>().GetInvokedTask();
            var taskTaxBand = _filterViewModelFactory.Create<TaxBandFilter, TaxBandLiteDto>().GetInvokedTask();

            return Task.Factory.ContinueWhenAll(
                new Task[] { taskUnitOfMeasure, taskNameOfCurrency, taskTaxBand },
                tasks =>
                {
                    viewModel.UnitOfMeasures = taskUnitOfMeasure.Result.MapTo<UnitOfMeasure>();
                    viewModel.NameOfCurrencies = taskNameOfCurrency.Result.MapTo<NameOfCurrency>();
                    viewModel.TaxBands = taskTaxBand.Result.MapTo<TaxBand>();

                    viewModel.EditableObject.Measure = viewModel.UnitOfMeasures.FirstOrDefault(x => x.MEASMNEMO == "КГ");
                    viewModel.EditableObject.NameOfCurrency =
                        viewModel.NameOfCurrencies.FirstOrDefault(x => x.Code == "RUB");
                    viewModel.EditableObject.TaxBand = viewModel.TaxBands.FirstOrDefault(x => x.Code == "НДС 18%");
                });
        }

        Task IInitializationStrategy.InitViewModel(object viewModel)
        {
            Contract.Requires(viewModel != null, "The view model must be not null");
            Contract.Requires(
                viewModel as EditablePlanCertificateViewModel != null,
                "The view model must be type of EditablePlanCertificateViewModel");
            Contract.Ensures(Contract.Result<Task>() != null);

            return this.InitViewModel((EditablePlanCertificateViewModel)viewModel);
        }
    }
}
