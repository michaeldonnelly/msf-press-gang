using System;
using Figgle;
using Zola.Database.Models;
using Zola.MsfClient.Models;

namespace Zola.Database.Reports
{
	public class GameReports
	{
		private readonly MsfDbContext Context;

		public GameReports(MsfDbContext dbContext)
		{
			Context = dbContext;
		}

		public string OneCharacter(string id)
		{
			string report = "";
			//CharacterInfo? character = Context.Characters.Where(c => c.Id == id).FirstOrDefault();
			CharacterInfo? character = Context.LoadCharacter(id);
			if (character is null)
			{
				report = $"No character was found in the DB with id==\"{id}\"";
				return report;
			}

			report = FiggleFonts.Basic.Render(character.Name);

            report += $"{character.Description}\r\n\r\n";

            report += FiggleFonts.Small.Render("Traits");
            if (character.Traits is not null)
			{
				report += "   " + string.Join(", ", character.Traits) + "\r\n";
			}

			report += "\r\n";
			report += FiggleFonts.Small.Render("Gear Tiers");
			report += "   " + "Tier Health Damage Armor Focus Resist\r\n";
			report += "   " + "---- ------ ------ ----- ----- ------\r\n";
			for (int tier = 1; tier <= (character.GearTiers.Count()); tier++)
			{
				GearTier gearTier;
				try
				{
					gearTier = character.GearTiers[tier];
				}
				catch(IndexOutOfRangeException)
				{
					continue;
				}

				Stats? stats = gearTier.Stats;
				if (stats is null)
				{
					continue;
				}

				string row = $"{tier.ToString().PadLeft(4)} ";
                row += $"{IntToPaddedString(stats.Health, 6)} ";
                row += $"{IntToPaddedString(stats.Damage, 6)} ";
                row += $"{IntToPaddedString(stats.Armor, 5)} ";
                row += $"{IntToPaddedString(stats.Focus, 5)} ";
                row += $"{IntToPaddedString(stats.Resist, 6)} ";
                report += "   " + row + "\r\n";
			}

			report += "\r\n";
			report += FiggleFonts.Small.Render("Abilities");
			AbilityKit abilityKit = character.AbilityKit;

            report += "   " + $"Basic: {abilityKit.Basic.Name}\r\n";
            report += "   " + "   " + $"{abilityKit.Basic.AbilityLevels[6].Description}\r\n";

            report += "   " + $"Special: {abilityKit.Special.Name}\r\n";
            report += "   " + "   " + $"{abilityKit.Special.AbilityLevels[6].Description}\r\n";

			if (abilityKit.Ultimate.Name is not null)
			{
				report += "   " + $"Ultimate: {abilityKit.Ultimate.Name}\r\n";
				report += "   " + "   " + $"{abilityKit.Ultimate.AbilityLevels[6].Description}\r\n";
			}

            report += "   " + $"Passive: {abilityKit.Passive.Name}\r\n";
            report += "   " + "   " + $"{abilityKit.Passive.AbilityLevels[4].Description}\r\n";





            return report;
        }

		public string CharactersWithAllEffects()
		{
			string report = "";
			foreach (Effect effect in Context.Effects)
			{
				//report += effect.Name + "\r\n";
				report += CharactersWithEffect(effect.Id, false) + "\r\n\r\n";
			}
			return report;
		}

		public List<string> CharactersWithEffect(string id)
		{
            Effect? effect = Context.Effects.Where(e => e.Id == id).FirstOrDefault();
			if (effect is null)
			{
				throw new Exception("No effect found with that ID");
			}

            List<EffectIndex> index = Context.EffectIndices.Where(i => i.Effect.Id == effect.Id).ToList();
			HashSet<string> response = new();
            foreach (EffectIndex effectIndex in index)
			{
				response.Add(effectIndex.Character.Name);
			}
			
			return response.ToList();
        }

        public string CharactersWithEffect(string id, bool alwaysPrintEffectName = true, bool commaList = false)
		{
			string report = "";
			Effect? effect = Context.Effects.Where(e => e.Id == id).FirstOrDefault();
			if (effect is null)
			{
				report = $"No effect was found in the DB with id==\"{id}\"";
				return report;
			}

			List<EffectIndex> index = Context.EffectIndices.Where(i => i.Effect.Id == effect.Id).ToList();
			bool indexHasMembers = (index.Count > 0);

			if ((indexHasMembers || alwaysPrintEffectName) && !commaList)
			{
				report += FiggleFonts.Basic.Render(effect.Name);
			}

			if (indexHasMembers)
			{
				if (!commaList)
				{
					report += "   " + "Character                Ability  Level\r\n";
					report += "   " + "---------                -------  -----\r\n";
				}

				foreach (EffectIndex effectIndex in index)
				{
					if (commaList)
					{
						if (report.Length > 0)
						{
							report += ", ";
						}
						report += effectIndex.Character.Name;
					}
					else
					{
						string row = effectIndex.Character.Name.PadRight(25);
						row += effectIndex.AbilityType.ToString().PadRight(11);
						row += effectIndex.AbilityLevel;
						//report += effectIndex + "\r\n";
						report += "   " + row + "\r\n";
					}
				}
			}
			else
			{
				report += $"No characters have abilities that reference {effect.Name}.\r\n";
            }

            return report;
        }


#nullable disable
        private string IntToPaddedString(int? numberInt, int padding)
		{
			string numberString = "";
			if (numberInt is not null)
			{
				numberString = numberInt.ToString();
			}
			return numberString.PadLeft(padding);
		}
#nullable enable

    }
}

