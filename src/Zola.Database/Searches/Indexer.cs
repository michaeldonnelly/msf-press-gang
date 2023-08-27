using System;
using Microsoft.EntityFrameworkCore;
using Zola.Database.Models;
using Zola.MsfClient.Models;

namespace Zola.Database.Searches
{
	public class Indexer
	{
		MsfDbContext Context;

        public Indexer(MsfDbContext context)
		{
			Context = context;
        }

        public int IndexEffects()
		{
            //int count = 0;

            Context.Effects.Load();
            Context.EffectIndices.ExecuteDelete();
         


#if true
            foreach (CharacterInfo character in Context.Characters)
            {
                //count++;
                //if (count > 32)
                //{
                //    break;
                //}
                Console.Write(character.Name);
                _ = Context.LoadCharacter(character.Id);
                Console.WriteLine();

                IndexEffectsForCharacter(character);
                //string searchTerm = "Disrupted";
                //SearchAbilityKit(character.AbilityKit, searchTerm, out int? basicLevel, out int? specialLevel, out int? ultimateLevel, out int? passiveLevel);
                //Console.WriteLine($"  basic: {basicLevel}\r\n  special: {specialLevel}\r\n  ult: {ultimateLevel}\r\n  passive: {passiveLevel}");
            }
#endif
            return Context.SaveChanges();
        }

        private void IndexEffectsForCharacter(CharacterInfo character)
        {
            //int count = 0;
            foreach (Effect effect in Context.Effects)
            {
                //count++;
                //if (count > 10)
                //{
                //    break;
                //}
                //Console.WriteLine(" " + effect.Name);
                IndexEffectForCharacter(effect, character);
            }
        }

        private void IndexEffectForCharacter(Effect effect, CharacterInfo character)
        {
            SearchAbilityKit(character.AbilityKit, effect.Name, out int? basicLevel, out int? specialLevel, out int? ultimateLevel, out int? passiveLevel);
            //Console.WriteLine($"  basic: {basicLevel}\r\n  special: {specialLevel}\r\n  ult: {ultimateLevel}\r\n  passive: {passiveLevel}");
            if (basicLevel is not null)
            {
                AddEffectIndex(effect, character, AbilityType.Basic, (int)basicLevel);
            }
            if (specialLevel is not null)
            {
                AddEffectIndex(effect, character, AbilityType.Special, (int)specialLevel);
            }
            if (ultimateLevel is not null)
            {
                AddEffectIndex(effect, character, AbilityType.Ultimate, (int)ultimateLevel);
            }
            if (passiveLevel is not null)
            {
                AddEffectIndex(effect, character, AbilityType.Passive, (int)passiveLevel);
            }
            //Console.WriteLine("");
        }

        private void AddEffectIndex(Effect effect, CharacterInfo character, AbilityType abilityType, int abilityLevel)
        {
            EffectIndex effectIndex = new EffectIndex(effect, character, abilityType, abilityLevel);
            Console.WriteLine(effectIndex);
            Context.Add(effectIndex);
        }

        private void SearchAbilityKit(AbilityKit abilityKit, string searchTerm, out int? basicLevel, out int? specialLevel, out int? ultimateLevel, out int? passiveLevel)
        {
            basicLevel = SearchAbility(abilityKit.Basic, searchTerm);
            specialLevel = SearchAbility(abilityKit.Special, searchTerm);
            ultimateLevel = SearchAbility(abilityKit.Special, searchTerm);
            passiveLevel = SearchAbility(abilityKit.Passive, searchTerm);

        }

        private int? SearchAbility(Ability ability, string searchTerm)
        {
            for (int level = 1; level <= 8; level++)
            {
                try
                {
                    AbilityLevel abilityLevel = ability.AbilityLevels[level];
                    if (abilityLevel.Description.Contains(searchTerm))
                    {
                        //Console.WriteLine(abilityLevel.Description);
                        return level;
                    }
                }
                catch (KeyNotFoundException)
                {
                    break; 
                }
            }

            return null;
        }
    }
}

