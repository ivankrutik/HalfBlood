
namespace Halfblood.Common
{
    using System;
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public sealed class RelationEntityToDtoAttribute : Attribute
    {
        public String TypeOfDto { get; private set; }

        public RelationEntityToDtoAttribute(String typeOfDto)
        {
            this.TypeOfDto = typeOfDto;
        }
    }
}
