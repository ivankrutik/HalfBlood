// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FakeConnection.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the FakeConnection type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Halfblood.Test.MockObjects
{
    using Halfblood.Common.Connection;
    using System.ComponentModel.Composition;

    [Export(typeof(IConnection))]
    public class FakeConnection : IConnection
    {
        public void Connecting(AuthorizationMetadata metadata)
        {
            Connecting(metadata.Login, metadata.Password, metadata.Database);
        }

        public void Connecting(string login, string password, string database)
        {
            
        }
    }
}
