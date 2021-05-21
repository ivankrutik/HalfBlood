namespace Halfblood.UnitTests.ViewLocatorTests
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Reactive;
    using System.Reactive.Disposables;

    using Halfblood.Common;

    using NUnit.Framework;

    using ReactiveUI;

    using Rhino.Mocks;

    using UI.Components;

    public class ViewLocatorTest
    {
        [Test]
        public void ResolveViewTest()
        {
            var dependencyResolver = MockRepository.GenerateStub<IDependencyResolver>();
            var viewLocator = new ViewLocatorEx(dependencyResolver);
            dependencyResolver.Stub(x => x.GetService(typeof(IViewFor<ITestViewModel>))).Return(new TestView());
            IViewFor view = viewLocator.ResolveView(new TestViewModel());

            dependencyResolver.AssertWasCalled(x => x.GetService(typeof(IViewFor<ITestViewModel>)));

            Assert.That(view, Is.InstanceOf<TestView>());
        }

        //Не доделан
        public void BindableAndCreateView()
        {
            var view = MockRepository.GenerateMock<IBindableView>();
            var initView = MockRepository.GenerateStub<IInitView>();
            initView.Init(view);

            view.AssertWasCalled(x => x.Binding());
        }

        class TestView : IViewFor<ITestViewModel>
        {
            object IViewFor.ViewModel
            {
                get { return ViewModel; }
                set { ViewModel = (ITestViewModel)value; }
            }

            public ITestViewModel ViewModel { get; set; }
        }
        class TestViewModel : ITestViewModel
        {
        }
        internal interface ITestViewModel
        {
        }
    }

    public interface IInitView
    {
        void Init(IBindableView view);
    }

    public class InitView : IInitView, IDisposable
    {
        private readonly ConcurrentDictionary<IBindableView, DisposableObject> _dictionary =
            new ConcurrentDictionary<IBindableView, DisposableObject>();

        public void Init(IBindableView view)
        {
            var disposableObject = new DisposableObject();

            disposableObject.Add(view.Binding());
            IDisposable disposable = Disposable.Empty;

            disposable = view.DisposableNotification().Subscribe(
                _ =>
                {
                    disposable.Dispose();
                    disposableObject.Dispose();

                    DisposableObject obj;
                    _dictionary.TryRemove(view, out obj);
                });

            _dictionary.TryAdd(view, disposableObject);
        }

        public void Dispose()
        {
            
        }
    }

    public interface IBindableView
    {
        IEnumerable<IDisposable> Binding();
        IObservable<Unit> DisposableNotification();
    }
}
