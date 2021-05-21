// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FakeScreen.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the FakeScreen type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Halfblood.Test.MockObjects
{
    using System;
    using System.ComponentModel;

    using Halfblood.Common.Navigations;

    using ReactiveUI;

    using INotifyPropertyChanging = ReactiveUI.INotifyPropertyChanging;
    using PropertyChangingEventHandler = ReactiveUI.PropertyChangingEventHandler;

    /// <summary>
    /// The fake screen.
    /// </summary>
    public class FakeScreen : IOwnerHostScreen
    {
        public IRoutingState Router
        {
            get
            {
                return new FakeRoutingState();
            }
        }
    }

    /// <summary>
    /// The fake routing state.
    /// </summary>
    public class FakeRoutingState : IRoutingState
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public event PropertyChangingEventHandler PropertyChanging;

        public IObservable<IObservedChange<object, object>> Changing { get; private set; }

        public IObservable<IObservedChange<object, object>> Changed { get; private set; }

        public IDisposable SuppressChangeNotifications()
        {
            throw new NotImplementedException();
        }

        public ReactiveList<IRoutableViewModel> NavigationStack { get; private set; }

        public IReactiveCommand NavigateBack { get; private set; }

        public INavigateCommand Navigate { get; private set; }

        public INavigateCommand NavigateAndReset { get; private set; }
        public IObservable<IRoutableViewModel> CurrentViewModel { get; private set; }

        public FakeRoutingState()
        {
            NavigateBack = new ReactiveCommand();
            Navigate = new NavigationReactiveCommand();
        }

        event PropertyChangingEventHandler INotifyPropertyChanging.PropertyChanging
        {
            add
            {
                throw new NotImplementedException();
            }
            remove
            {
                throw new NotImplementedException();
            }
        }
    }

    class NavigationReactiveCommand : ReactiveCommand, INavigateCommand { }
}
