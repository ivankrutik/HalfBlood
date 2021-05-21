using System;
using System.ComponentModel;
using Filtering.Infrastructure;
using Halfblood.Common;

namespace Buisness.Filters.TestSheetsDomain
{
    public class TestSheetFilter : IUserFilter<long>
    {
        public TestSheetFilter()
        {
            TestSheetCreationDate = new Between<DateTime?>();
            ActSelectionCreationDate = new Between<DateTime?>();
        }

        public Between<DateTime?> ActSelectionCreationDate { get; set; }

        public Between<DateTime?> TestSheetCreationDate { get; set; }

        object IHasUid.Rn
        {
            get { return Rn; }
        }

        public long Rn { get; set; }

        public int Skip { get; set; }

        public int Take { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}