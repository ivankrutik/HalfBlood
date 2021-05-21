namespace Halfblood.Toolkit.Test
{
    using NUnit.Framework;
    using DeterminesTypeContent;

    class LibMagicTest
    {
        [Test]
        public void LibMagicTestForImageFile()
        {
            var x = new DeterminesTypeContent();
            var type = x.GetMimeType(@"1.png");
            x.Dispose();
            Assert.IsFalse(type != "PNG image, 5760 x 1080, 8-bit/color RGB, non-interlaced");
        }
    }
}
