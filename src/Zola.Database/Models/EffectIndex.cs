using System;
using Zola.MsfClient.Models;

namespace Zola.Database.Models
{
	public class EffectIndex
	{
        public EffectIndex()
        { }

        public EffectIndex(Effect effect, CharacterInfo character, AbilityType abilityType, int abilityLevel)
        {
            Effect = effect;
            Character = character;
            AbilityType = abilityType;
            AbilityLevel = abilityLevel;
        }

        public string Id { get; set; } = Guid.NewGuid().ToString();
		public Effect Effect { get; set; }
        public CharacterInfo Character { get; set; }
        public AbilityType AbilityType { get; set; }
        public int AbilityLevel { get; set; }

        public override string ToString()
        {
            return $"{Effect.Name}: {Character.Name} {AbilityType} level {AbilityLevel}";
        }
    }


}

