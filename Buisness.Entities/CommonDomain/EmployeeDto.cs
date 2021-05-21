namespace Buisness.Entities.CommonDomain
{
    using System;
    using Halfblood.Common;

    public class EmployeeDto : IDto<long>
    {
        object IHasUid.Rn { get { return Rn; } }
        public virtual string PersNumb { get; set; }
        public virtual string Fullname { get; set; }
        public virtual string PsdepName { get; set; }
        public virtual string Dept { get; set; }
        public virtual DateTime JobbeginDate { get; set; }
        public virtual int Iswork { get; set; }
        public virtual int Ispluralist { get; set; }
        public virtual string PersAuthid { get; set; }
        public virtual long Rn { get; set; }

        public override string ToString()
        {
            return string.Format("{0} ({1} - {2})", Fullname, Dept, PsdepName);
        }
    }
}
