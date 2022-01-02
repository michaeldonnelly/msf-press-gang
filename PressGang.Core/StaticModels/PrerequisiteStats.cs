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

        public int RequiredCharacterLevel { get; set; }

        public int RequiredGearTier { get; set; }

        public int RequiredIso8ClassLevel { get; set; }

    }
}
