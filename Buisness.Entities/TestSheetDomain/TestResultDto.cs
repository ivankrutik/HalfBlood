using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Buisness.Entities.CommonDomain;
using Halfblood.Common;

namespace Buisness.Entities.TestSheetDomain
{
    public class TestResultDto : IDto<long>, IHasRowNumber
    {
        public TestResultDto()
        {
            SampleResultSets = new ObservableCollection<SampleResultSetDto>();
        }

        public IList<SampleResultSetDto> SampleResultSets { get; set; }

        // связь с предком
        public TestSheetDto TestSheet { get; set; }

        public long Number { get; set; }

        public string AnalysesRange { get; set; }
        public string IndicatorName { get; set; }
        public string Unit { get; set; }
        public string TestingMethod { get; set; }
        public string Requirements { get; set; }
        public string Equipment { get; set; }
        public string Value { get; set; }
        public string Note { get; set; }
        public UserDto Tester { get; set; }
        public DateTime TesterDate { get; set; }
        public DateTime CreationDate { get; set; }

        public long Rn { get; set; }

        object IHasUid.Rn
        {
            get { return Rn; }
        }
    }
}