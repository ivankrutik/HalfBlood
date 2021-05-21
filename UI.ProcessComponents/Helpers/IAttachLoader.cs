// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IAttachLoader.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the IAttachLoader type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.ProcessComponents.Helpers
{
    using System;

    using UI.Entities.AttachedDocumentDomain;

    /// <summary>
    /// The AttachLoader interface.
    /// </summary>
    public interface IAttachLoader
    {
        /// <summary>
        /// Gets the attaching completed notification.
        /// </summary>
        IObservable<AttachedDocument> AttachingCompletedNotification { get; }

        /// <summary>
        /// The set observable.
        /// </summary>
        /// <param name="observable">
        /// The observable.
        /// </param>
        void SetObservable(IObservable<AttachedDocument> observable);
    }
}