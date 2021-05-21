// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LogManager.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the LogManager type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Halfblood.Common.Log
{
    using System.Reflection;

    using log4net;

    /// <summary>
    /// The log manager.
    /// </summary>
    public static class LogManager
    {
        private static ILog _log;

        /// <summary>
        /// Gets the log.
        /// </summary>
        public static ILog Log
        {
            get { return _log ?? (_log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)); }
        }
    }
}
