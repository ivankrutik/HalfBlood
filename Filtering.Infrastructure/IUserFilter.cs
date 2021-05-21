// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUserFilter.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The UserFilter interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Filtering.Infrastructure
{
    using System.ComponentModel;

    using Halfblood.Common;

    /// <summary>
    /// The UserFilter interface.
    /// </summary>
    public interface IUserFilter : IHasUid
    {
    }

    /// <summary>
    /// The UserFilter interface.
    /// </summary>
    public interface IUserFilter<out TKey> : IUserFilter, IHasUid<TKey>, INotifyPropertyChanged
    {
        /// <summary>
        /// Gets or sets the skip.
        /// </summary>
        int Skip { get; set; }

        /// <summary>
        /// Gets or sets the take.
        /// </summary>
        int Take { get; set; }
    }
}