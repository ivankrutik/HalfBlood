// --------------------------------------------------------------------------------------------------------------------
// <copyright file="User.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the User type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Entities.CommonDomain
{
    using System;
    using System.ComponentModel;

    using Halfblood.Common;

    /// <summary>
    /// The user.
    /// </summary>
    public class User : IUiEntity
    {
        object IHasUid.Rn { get { return Rn; } }

        /// <summary>
        /// Gets the Rn.
        /// </summary>
        public long Rn { get; private set; }

        /// <summary>
        /// Gets or sets the catalog.
        /// </summary>
        public Catalog Catalog { get; set; }

        /// <summary>
        /// Gets or sets the table number.
        /// </summary>
        public string TableNumber { get; set; }

        /// <summary>
        /// Gets or sets the firstname.
        /// </summary>
        public string Firstname { get; set; }

        /// <summary>
        /// Gets or sets the lastname.
        /// </summary>
        public string Lastname { get; set; }

        /// <summary>
        /// The name of organization.
        /// </summary>
        public string OrganizationName { get; set; }

        public string NameShort { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        /// <param name="rn">
        /// The Rn.
        /// </param>
        public User(long rn)
        {
            this.Rn = rn;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        public User()
        {
        }

        /// <summary>
        /// The to string.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public override string ToString()
        {
            if (!string.IsNullOrWhiteSpace(Firstname))
            {
                return string.Format("{0} {1} ({2})", Firstname, Lastname, TableNumber);
            }
            return OrganizationName;
        }

        /// <summary>
        /// The equals.
        /// </summary>
        /// <param name="obj">
        /// The obj.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj is User == false)
            {
                return false;
            }

            if (Object.ReferenceEquals(this, obj))
            {
                return true;
            }

            if (Object.ReferenceEquals(this, null) || Object.ReferenceEquals(obj, null))
            {
                return false;
            }

            var user = obj as User;

            return this.Rn == user.Rn &&
                   this.TableNumber == user.TableNumber;
        }

        /// <summary>
        /// The get hash code.
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public override int GetHashCode()
        {
            int tableNumberHash = string.IsNullOrWhiteSpace(this.TableNumber) ? 0 : this.TableNumber.GetHashCode();
            int uidHash = this.Rn.GetHashCode();

            return uidHash ^ tableNumberHash;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
