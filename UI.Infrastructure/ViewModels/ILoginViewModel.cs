// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ILoginViewModel.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the ILoginViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



namespace UI.Infrastructure.ViewModels
{
    using System.Windows.Input;

    using Halfblood.Common.Connection;

    using ReactiveUI;

    using System.Collections.Generic;

    /// <summary>
    /// The LoginViewModel interface.
    /// </summary>
    public interface ILoginViewModel : IRoutableViewModel, IHasAuthentificationMetadata
    {
        /// <summary>
        /// Gets the authorize command.
        /// </summary>
        ICommand AuthorizeCommand { get; }

        /// <summary>
        /// Gets the authorization metadata.
        /// </summary>
        AuthorizationMetadata AuthorizationMetadata { get; }

        IDictionary<string, string> LastUsersMetadata { get; set; }
        /// <summary>
        /// Gets a value indicating whether is connecting.
        /// </summary>
        bool IsConnecting { get; }

        /// <summary>
        /// Gets a value indicating whether is connected.
        /// </summary>
        bool IsConnected { get; }

        /// <summary>
        /// The wait.
        /// </summary>
        void Wait();
    }
}
