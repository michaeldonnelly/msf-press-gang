using System;
namespace PressGang.Core.System.Location
{
    public partial class ResourceLocation
    {
        public ResourceLocation(string name)
        {
            Name = name;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
