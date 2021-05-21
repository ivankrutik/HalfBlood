// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Pears.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the ITest_1 type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Halfblood.UnitTests.ServiceFactoryTest.Pears
{
    using Halfblood.Common;

    public interface ITest_1 { }
    public interface ITest_2 { }

    [Register(typeof(ITest_1))]
    public class Test_1 : ITest_1 { }

    [Register(typeof(ITest_2))]
    public class Test_2 : ITest_2 { }
}