// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ScannerTest.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the ScannerTest type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Halfblood.Toolkit.Test
{
    using NUnit.Framework;
    using global::Toolkit.Scanner;

    class ScannerTest
    {
        [Test]
        public void TestScannigWithoutParam()
        {
            var d = new ScannerManager();
            var result = d.Scanning();
            Assert.NotNull(result);
        }
        [Test]
        public void TestScannigWithParam()
        {
            var d = new ScannerManager();
            d.SetParams(100, 100, false);
            var result = d.Scanning();
            Assert.NotNull(result);
        }
    }
}