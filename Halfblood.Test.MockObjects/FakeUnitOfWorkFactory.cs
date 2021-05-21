// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FakeUnitOfWorkFactory.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the FakeUnitOfWorkFactory type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Halfblood.Test.MockObjects
{
    using System.ComponentModel.Composition;

    using ServiceContracts;

    [Export(typeof(IUnitOfWorkFactory))]
    public class FakeUnitOfWorkFactory : IUnitOfWorkFactory
    {
        public IUnitOfWork Create()
        {
            return new FakeUnitOfWork();
        }
    }
}
