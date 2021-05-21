// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PersonalAccount.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the PersonalAccount type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Entities.CommonDomain
{
    using ContractDomain;

    /// <summary>
    /// The personal account.
    /// </summary>
    public class PersonalAccount : EntityBase<PersonalAccount>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PersonalAccount"/> class.
        /// </summary>
        /// <param name="rn">
        /// The rn.
        /// </param>
        public PersonalAccount(long rn)
        {
            this.Rn = rn;
        }
        public PersonalAccount()
        {
        }

        public string Numb { get; set; }
        public StagesOfTheContract StagesOfTheContract { get; set; }

        public override string ToString()
        {
            return Numb;
        }
    }
}
