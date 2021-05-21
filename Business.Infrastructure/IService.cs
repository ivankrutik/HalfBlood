// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IService.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the IService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Business.Infrastructure
{
    using System;
    using System.ComponentModel.Composition;

    /// <summary>
    /// The Service interface.
    /// </summary>
    public interface IService
    {
    }

    /// <summary>
    /// The ServiceMetadata interface.
    /// </summary>
    public interface IServiceMetadata
    {
        /// <summary>
        /// Gets the rigister as interface.
        /// </summary>
        Type RigisterAsInterface { get; }
    }

    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public sealed class ServiceAttribute : ExportAttribute
    {
        public ServiceAttribute(Type type)
            : base(typeof(IService))
        {
            RigisterAsInterface = type;
        }

        public Type RigisterAsInterface { get; private set; }
    }
}
