// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Company.cs" company="VZ">
//   maraoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the Company type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DataAccessLogic.Infrastructure
{
    public class Company
    {
        public virtual long Rn { get; set; }
        public virtual string Name { get; set; }
        public virtual string FullName { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
