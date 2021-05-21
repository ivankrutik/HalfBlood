// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CatalogNotExistException.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the CatalogNotExistException type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ServiceContracts.Exceptions
{
    using System;

    using Halfblood.Common.Helpers;

    public class CatalogNotExistException : Exception
    {
        public CatalogNotExistException(string section)
            : base(Resource.CatalogNotExist.StringFormat(section))
        {
        }

        public CatalogNotExistException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
