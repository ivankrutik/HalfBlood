// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProfilesLoader.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the ProfilesLoader type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.ProcessComponents.Mappings
{
    using System;
    using System.ComponentModel.Composition;
    using System.Reflection;

    using AutoMapper;

    using Halfblood.Common;
    using Halfblood.Common.Mappers;

    using UI.Entities;

    /// <summary>
    /// The profiles loader.
    /// </summary>
    [Export(typeof(IProfileLauncher))]
    public class ProfilesLauncher : IProfileLauncher
    {
        /// <summary>
        /// The load profiles.
        /// </summary>
        public void LoadProfiles()
        {
            ReflectExtension.GetTypesMarkedAttribute<AutoMapperProfileAttribute>(
                Assembly.GetAssembly(GetType()),
                (type, attribute) => Mapper.AddProfile((Profile)Activator.CreateInstance(type)));

            foreach (TypeMap typeMap in Mapper.GetAllTypeMaps())
            {
                if (typeMap.SourceType.HasInterface<IDto>() && typeMap.DestinationType.HasInterface<IUiEntity>())
                {
                    ProcessRelation.Instance.Relation(typeMap.SourceType, typeMap.DestinationType);
                }
            }
        }
    }
}
