using System;
using Buisness.Entities.CommonDomain;
using Halfblood.Common;

namespace Buisness.Entities.TestSheetDomain
{
    public class SampleResultSetDto : IDto<long>
    {
        public SampleResultSetDto()
        {
            IsRow = true;
        }

        // связь с предком
        public TestResultDto TestResult { get; set; }

        public string Title { get; set; }
        public string Value1 { get; set; }
        public string Value2 { get; set; }
        public string Value3 { get; set; }
        public string Value4 { get; set; }
        public string Value5 { get; set; }
        public string Value6 { get; set; }
        public string Value7 { get; set; }
        public string Value8 { get; set; }
        public string Value9 { get; set; }
        public string Value10 { get; set; }
        public UserDto Creator { get; set; }
        public DateTime CreationDate { get; set; }

        public bool IsRow { get; set; }
        public long Rn { get; set; }

        object IHasUid.Rn
        {
            get { return Rn; }
        }
       
        ///////////////////////////////////////////
        
        public string HeaderRowTitle  {
            get
            {
                return IsRow ? Title : "№ обр.";
            }
        }

    }
}