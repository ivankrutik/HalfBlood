// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Helper.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the Helper type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Workflows.Helper
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Buisness.Entities.CertificateQualityDomain.ManufacturersCertificateDomain;

    using Halfblood.Common;

    /// <summary>
    /// The helper.
    /// </summary>
    public static class Helper
    {
        /// <summary>
        /// The get section of system.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string GetSectionOfSystem(Type type)
        {
            var dd = type.GetCustomAttributes(typeof(RelationEntityToDtoAttribute), false);
            if (!dd.Any())
            {
                Halfblood.Common.Log.LogManager.Log.Debug(
                    string.Format("Для типа {0} не установлен атрибут  {1}", type, typeof(RelationEntityToDtoAttribute)));

                return string.Empty;
            }

            return ((RelationEntityToDtoAttribute)dd[0]).TypeOfDto;
        }

        /// <summary>
        /// The get section of system.
        /// </summary>
        /// <param name="dto">
        /// The dto.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string GetSectionOfSystem(this IDto dto)
        {
            Type type = dto.GetType();
            return GetSectionOfSystem(type);
        }

        /// <summary>
        /// The get type dto by section of system.
        /// </summary>
        /// <param name="sectionOfSystem">
        /// The section of system.
        /// </param>
        /// <returns>
        /// The <see cref="Type"/>.
        /// </returns>
        public static Type GetTypeDtoBySectionOfSystem(string sectionOfSystem)
        {
            Type expectedType = null;

            ReflectExtension.GetTypesMarkedAttribute<RelationEntityToDtoAttribute>(
                new[] { Assembly.GetAssembly(typeof(CertificateQualityDto)) },
                (type, attribute) => { if (attribute.TypeOfDto == sectionOfSystem) expectedType = type; });

            return expectedType;
        }
    }
}
