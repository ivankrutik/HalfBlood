// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FakeUnitOfWork.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the FakeUnitOfWork type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Halfblood.Test.MockObjects
{
    using System;
    using System.Management.Instrumentation;

    using Halfblood.Common.Helpers;

    using ServiceContracts;

    /// <summary>
    /// The fake unit.
    /// </summary>
    public class FakeUnitOfWork : IUnitOfWork
    {
        public TService Create<TService>()
        {
            var serviceName = "Halfblood.Test.MockObjects.Fake{0}".StringFormat(typeof(TService).Name.Remove(0, 1));
            Type serviceType = Type.GetType(serviceName);

            if (serviceType == null)
            {
                throw new InstanceNotFoundException("service with type {0} not found".StringFormat(serviceName));
            }

            return (TService)Activator.CreateInstance(serviceType);
        }

        public void Rollback() { }
        public void Commit() { }
        public void Dispose() { }
    }
}
