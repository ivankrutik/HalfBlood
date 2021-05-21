// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ISwitcherViewModel.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the ISwitcherViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Infrastructure.ViewModels
{
    using System.Windows.Input;
    using ReactiveUI;

    /// <summary>
    /// The SwitcherViewModel interface.
    /// </summary>
    public interface ISwitcherViewModel : IRoutableViewModel
    {
        /// <summary>
        /// Gets the go to page command.
        /// </summary>
        ICommand GoToPageCommand { get; }
    }
}