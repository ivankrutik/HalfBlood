// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConfigureWorkflow.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the ConfigureWorkflow type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Workflows
{
    using System;
    using System.ComponentModel.Composition;
    using System.ComponentModel.Composition.Hosting;
    using System.Reflection;

    using AutoMapper;

    using Buisness.Entities.CommonDomain;
    using Buisness.Workflows.Mapping;

    using DataAccessLogic.Infrastructure;

    using Halfblood.Common;
    using Halfblood.Common.Mappers;

    /// <summary>
    /// The configure workflow.
    /// </summary>
    [Export(typeof(IMefProfileLauncher))]
    public class ConfigureWorkflow : IMefProfileLauncher
    {
        /// <summary>
        /// The load profiles.
        /// </summary>
        /// <param name="container">
        /// The container.
        /// </param>
        public void LoadProfiles(CompositionContainer container)
        {
            ReflectExtension.GetTypesMarkedAttribute<AutoMapperProfileAttribute>(
                Assembly.GetAssembly(this.GetType()),
                (type, attribute) => Mapper.AddProfile((Profile)Activator.CreateInstance(type)));

            foreach (TypeMap typeMap in Mapper.GetAllTypeMaps())
            {
                if (typeMap.SourceType.HasInterface<IDto>() && typeMap.DestinationType.HasInterface<IEntity>())
                {
                    if (typeMap.SourceType == typeof(TaxDto))
                    {

                    }

                    BusinessRelation.Instance.Relation(typeMap.SourceType, typeMap.DestinationType);
                }
            }

            ServiceLocator.Container = container;
        }
    }
}