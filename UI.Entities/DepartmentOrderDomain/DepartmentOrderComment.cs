namespace UI.Entities.DepartmentOrderDomain
{
    using System;
    using UI.Entities.CommonDomain;

    public class DepartmentOrderComment : EntityBase<DepartmentOrderComment>
    {
        public DepartmentOrderComment()
        {
        }
        public DepartmentOrderComment(long rn)
            : this()
        {
            Rn = rn;
        }

        public DateTime CreationDate { get; set; }
        public User UserCreator { get; set; }
        public string Comment { get; set; }
        public DepartmentOrder DepartmentOrder { get; set; }
        public string NameSectionOfSystem { get; protected set; }
    }
}
