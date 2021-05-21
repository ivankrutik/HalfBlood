// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NhConnectionAdapter.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   The hibernate connection.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Components
{
    using System.ComponentModel.Composition;

    using Halfblood.Common.Connection;

    using NhConnection;
    using NhConnection.Infrasctructure;

    /// <summary>
    /// The hibernate connection.
    /// </summary>
    [Export(typeof(IConnection))]
    [Export(typeof(INhConnection))]
    public class NhConnectionAdapter : NhConnection, IConnection
    {
    }
}