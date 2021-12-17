using System;
namespace PressGang.Core.System
{
    public partial class Resource
    {
        public Resource()
        {
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ResourceLocation ResourceLocation { get; set; }
    }
}
