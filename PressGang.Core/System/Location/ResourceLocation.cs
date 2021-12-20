using System;
namespace PressGang.Core.System.Location
{
    public class ResourceLocation
    {
        public ResourceLocation(string name)
        {
            Name = name;
        }

        public ResourceLocation(string name, Type type)
        {
            Name = name;
            LocationType = type.Name;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string LocationType { get; set; }

        public Type GetLocationType()
        {
            return Type.GetType(LocationType);
        }
    }
}
