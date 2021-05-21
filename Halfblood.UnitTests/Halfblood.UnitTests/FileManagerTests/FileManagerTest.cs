// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FileManagerTest.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The file manager test.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Halfblood.UnitTests.FileManagerTests
{
    using System;
    using System.IO;
    using System.Reactive.Linq;

    using Halfblood.Common.Helpers.FileManagers;
    using Halfblood.Test.MockObjects;

    using NUnit.Framework;
    using ReactiveUI;

    using Rhino.Mocks;

    using Toolkit.Infrastructure.Scanner;

    using UI.ProcessComponents.AttachedDocumentDomain;

    /// <summary>
    /// The file manager test.
    /// </summary>
    [TestFixture]
    public class FileManagerTest
    {
        [Test]
        public void GetFromFileSystem()
        {
            string fileName = Guid.NewGuid().ToString();
            File.Create(fileName).Dispose();

            IGetFileStrategy fileSystemStrategy = new FileSystemStrategy(fileName);
            byte[] buffer = fileSystemStrategy.GetFile();

            Assert.That(buffer, Is.Not.Null);
            File.Delete(fileName);
        }

        [Test]
        public void FileManagerViewModel()
        {
            var viewModel = new GetImageViewModel(
                MockRepository.GenerateStub<IScannerManager>(),
                MockRepository.GenerateStub<IScreen>());

            AsyncTestHelper.ExecuteOperationTest(
                () => viewModel,
                vm => vm.WhenAny(x => x.IsBusy, x => x.Value).Where(isBusy => !isBusy).Skip(1),
                vm => Assert.That(vm.Image, Is.Not.Null),
                vm => vm.ScanningCommand.Execute(null),
                1000, () => Assert.Fail("The test is timeout"));
        }
    }
}
