// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EqualsTest.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   The equals test.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Halfblood.UnitTests.EqualsTests
{
    using FizzWare.NBuilder;

    using NUnit.Framework;

    using UI.Entities.CertificateQualityDomain;
    using UI.Entities.CertificateQualityDomain.ManufacturersCertificateDomain;

    /// <summary>
    /// The equals test.
    /// </summary>
    public class EqualsTest
    {
        [Test]
        public void ChemicalIndicatorValueTest()
        {
            var dictValue = new DictionaryChemicalIndicator { Rn = 100 };
            var value =
                Builder<ChemicalIndicatorValue>.CreateNew()
                    .With(x => x.DictChemicalIndicator, dictValue)
                    .With(x => x.Value, "200")
                    .Build();
            var value2 =
                Builder<ChemicalIndicatorValue>.CreateNew()
                    .With(x => x.DictChemicalIndicator, dictValue)
                    .With(x => x.Value, "200")
                    .Build();
            var value3 =
                Builder<ChemicalIndicatorValue>.CreateNew()
                    .With(x => x.DictChemicalIndicator, dictValue)
                    .With(x => x.Value, "300")
                    .Build();

            var value4 =
                Builder<ChemicalIndicatorValue>.CreateNew()
                    .With(x => x.Value, "300")
                    .Build();
            var value5 =
                Builder<ChemicalIndicatorValue>.CreateNew()
                    .With(x => x.Value, "300")
                    .Build();
            var value6 =
                Builder<ChemicalIndicatorValue>.CreateNew()
                    .With(x => x.Value, "400")
                    .Build();


            Assert.AreEqual(value, value2);
            Assert.AreNotEqual(value, value3);

            Assert.AreEqual(value4, value5);
            Assert.AreNotEqual(value4, value6);
        }
    }
}
