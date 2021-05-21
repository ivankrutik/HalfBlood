// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FakePlanReceiptOrderPersonalAccountFilterViewModel.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the FakePlanReceiptOrderPersonalAccountFilterViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Halfblood.Test.MockObjects.Filters
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Windows.Input;

    using Buisness.Filters;

    using FizzWare.NBuilder;

    using ParusModelLite.PlanReceiptOrderDomain;

    using ReactiveUI;

    using UI.Entities.CommonDomain;
    using UI.Entities.ContractDomain;
    using UI.Entities.PlanReceiptOrderDomain;
    using UI.Infrastructure.ViewModels;
    using UI.Infrastructure.ViewModels.Filters;

    /// <summary>
    /// The fake plan receipt order personal account filter view model.
    /// </summary>
    public class FakePlanReceiptOrderPersonalAccountFilterViewModel : FakeFilterViewModelBase<PlanReceiptOrderPersonalAccountFilter, PersonalAccountOfPlanReceiptOrderLiteDto>,
        IPlanReceiptOrderPersonalAccountFilterViewModel
    {
    }

    /// <summary>
    /// The fake personal account filter view model.
    /// </summary>
    public class FakePersonalAccountFilterViewModel
        : FakeFilterViewModelBase<PersonalAccountFilter, PersonalAccount>
    {
        public override IList<PersonalAccount> Generate()
        {
            return
                Builder<PersonalAccount>.CreateListOfSize(10)
                                        .All()
                                        .With(x => x.StagesOfTheContract, Builder<StagesOfTheContract>.CreateNew().Build())
                                        .Build();
        }
    }

    /// <summary>
    /// The pro filter view model fake.
    /// </summary>
    public class PROFilterViewModelFake : FakeFilterViewModelBase<PlanReceiptOrderFilter, PlanReceiptOrder>, IProFilterViewModel
    {
        public ICommand ClearFilterCommand { get; private set; }
        public IList<PlanReceiptOrderLiteDto> Result { get; private set; }
        public IObservable<IList<PlanReceiptOrderLiteDto>> LoadCompletedNotification { get; private set; }

        public Task<IList<PlanReceiptOrderLiteDto>> GetTaskLoad()
        {
            throw new NotImplementedException();
        }

        public IFilterViewModel<PlanReceiptOrderFilter, PlanReceiptOrderLiteDto> SetFilter(PlanReceiptOrderFilter filter)
        {
            throw new NotImplementedException();
        }

        public Task<IList<PlanReceiptOrderLiteDto>> GetInvokedTask()
        {
            throw new NotImplementedException();
        }

        IAyncRunner<IList<PlanReceiptOrderLiteDto>> IAyncRunner<IList<PlanReceiptOrderLiteDto>>.SetConverter(Func<IList<PlanReceiptOrderLiteDto>, IList<PlanReceiptOrderLiteDto>> converterFunction)
        {
            throw new NotImplementedException();
        }

        public void SetConverter(Func<IList<PlanReceiptOrderLiteDto>, IList<PlanReceiptOrderLiteDto>> converterFunction)
        {
            throw new NotImplementedException();
        }

        public string UrlPathSegment { get; private set; }
        public IScreen HostScreen { get; private set; }
    }
}
