// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SwitcherPageTest.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The navigation framework.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Halfblood.UnitTests.NavigationTest
{
    using System;

    using Halfblood.Common.Navigations;
    using Halfblood.Navigation;

    using NUnit.Framework;

    using Rhino.Mocks;

    /// <summary>
    /// The navigation framework.
    /// </summary>
    public class SwitcherPageTest
    {
        private SwitcherPage _switcherPage;

        [SetUp]
        public void SetUp()
        {
            _switcherPage = new SwitcherPage();
        }

        [Test]
        public void Create()
        {
            Assert.That(_switcherPage, Is.Not.Null);
        }

        [Test]
        public void AddPage()
        {
            Assert.That(_switcherPage.Pages.Count, Is.EqualTo(0));

            _switcherPage.AddPage(MockRepository.GenerateStub<IPage>());
            Assert.That(_switcherPage.Pages.Count, Is.EqualTo(1));
        }

        [Test]
        public void Switch()
        {
            var page1 = new Page("page1", "/page1");
            var page2 = new Page("page2", "/page2");
            var page3 = new Page("page3", "/page3");

            Assert.That(_switcherPage.ActivePage, Is.Null);

            _switcherPage.AddPage(page1);
            _switcherPage.AddPage(page2);

            Assert.That(_switcherPage.ActivePage, Is.Null);
            
            _switcherPage.Switch(page1);
            Assert.That(_switcherPage.ActivePage, Is.EqualTo(page1));

            _switcherPage.Switch(page2);
            Assert.That(_switcherPage.ActivePage, Is.EqualTo(page2));

            try
            {
                _switcherPage.Switch(page3);
            }
            catch (InvalidOperationException e)
            {
                Assert.Pass();
                return;
            }

            Assert.Fail();
        }
    }
}
