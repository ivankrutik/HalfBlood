// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExportProviderMixin.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The export provider mixin.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Halfblood.Common.Helpers
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.Composition.Hosting;
    using System.Linq;

    using Halfblood.Common.Log;

    /// <summary>
    /// The export provider mixin.
    /// </summary>
    public static class ExportProviderMixin
    {
        /// <summary>
        /// The get exported value.
        /// </summary>
        /// <param name="exportProvider">
        /// The export provider.
        /// </param>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public static object GetExportedValue(this ExportProvider exportProvider, Type type)
        {
            var res =
                typeof(ExportProvider).GetMethod("GetExportedValue", new Type[] { })
                    .MakeGenericMethod(type)
                    .Invoke(exportProvider, null);

            return res;
        }

        /// <summary>
        /// The get exported values.
        /// </summary>
        /// <param name="exportProvider">
        /// The export provider.
        /// </param>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public static IEnumerable<object> GetExportedValues(this ExportProvider exportProvider, Type type)
        {
            var res =
                (IList)
                typeof(ExportProvider).GetMethod("GetExportedValues")
                    .MakeGenericMethod(type)
                    .Invoke(exportProvider, null);

            return res.Cast<object>();
        }

        /// <summary>
        /// The try get exported value.
        /// </summary>
        /// <param name="exportProvider">
        /// The export provider.
        /// </param>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public static object TryGetExportedValue(this ExportProvider exportProvider, Type type)
        {
            try
            {
                var res =
                    typeof(ExportProvider).GetMethod("GetExportedValue", new Type[] { })
                        .MakeGenericMethod(type)
                        .Invoke(exportProvider, null);
                return res;
            }
            catch (Exception exception)
            {
                LogManager.Log.Debug(exception);
                return null;
            }
        }
    }
}