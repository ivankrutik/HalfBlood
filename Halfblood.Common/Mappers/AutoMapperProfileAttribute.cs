// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AutoMapperProfileAttribute.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the AutoMapperProfileAttribute type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Halfblood.Common.Mappers
{
    using System;

    /// <summary>
    /// The auto mapper attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public sealed class AutoMapperProfileAttribute : Attribute
    {
    }
}