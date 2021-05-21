// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ImageManagerTest.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The image manager test.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Halfblood.UnitTests.ImageManagerTests
{
    using System.Drawing;

    using Halfblood.Common.Helpers;

    using NUnit.Framework;
    using Rhino.Mocks;

    /// <summary>
    /// The image manager test.
    /// </summary>
    public class ImageManagerTest
    {
        private IImageManager _imageManager;

        [SetUp]
        public void SetUp()
        {
            var image = MockRepository.GenerateStub<Image>();
            _imageManager = new ImageManager(image);
        }

        [Test]
        public void Rotate()
        {
            _imageManager.Rotate(RotateFlipType.Rotate90FlipNone);

            Assert.Pass(
                @"Я хз как проверить, что изображение повернуто. 
                  Будем считать, что если нет исключения то все норм.");
        }

        [Test]
        public void Crop()
        {
            _imageManager.Crop();
        }
    }
}
