using System;
namespace PressGang.Core.StaticModels
{
    public class PrerequisiteStats
    {
        public PrerequisiteStats()
        {
        }

        public int Id { get; set; }

        public int CharacterId { get; set; }

        public virtual Character Character { get; set; }

        public int YellowStars { get; set; }

        public int CharacterLevel { get; set; }

        public int GearTier { get; set; }

        public int Iso8ClassLevel { get; set; }

    }
}
