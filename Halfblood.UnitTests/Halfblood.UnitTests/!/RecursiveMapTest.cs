// --------------------------------------------------------------------------------------------------------------------
// <copyright file="test.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the IEntity type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Halfblood.UnitTests.__
{
    using System.Collections.Generic;

    using AutoMapper;

    using NUnit.Framework;

    interface IEntity { }
    interface IDto { }

    class Parent : IEntity
    {
        public Parent()
        {
            Childs = new List<Child>();
        }

        public IList<Child> Childs { get; set; }
    }
    class Child : IEntity
    {
        public IEntity Parent { get; set; }
    }
    class ChildDto : IDto
    {
        public IDto Parent { get; set; }
    }
    class ParentDto : IDto
    {
        public IList<ChildDto> Childs { get; set; }
    }

    class RecursiveTest
    {
        [Test]
        public void Test()
        {
            //Mapper.CreateMap<Parent, IDto>().BeforeMap((entity, dto) => { });
//            .ForMember(
//                x => x.Parent,
//                o => o.ResolveUsing(
//                    x =>
//                        {
//                            var sourceType = x.Parent.GetType();
//                            var destType =
//                                (from maps in Mapper.GetAllTypeMaps() where maps.SourceType == sourceType select maps)
//                                    .FirstOrDefault().DestinationType;
//
//                            return Mapper.Map(x.Parent, sourceType, destType);
//                        }));

            Mapper.CreateMap<Child, ChildDto>();
            Mapper.CreateMap<ChildDto, Child>();
            Mapper.CreateMap<Parent, IDto>().As<ParentDto>();
            Mapper.CreateMap<Parent, ParentDto>();
            Mapper.CreateMap<ParentDto, Parent>();

            var parent = new Parent();
            var child = new Child { Parent = parent };
            parent.Childs.Add(child);

            var parentDto = Mapper.Map<ParentDto>(parent);
        }
    }
}