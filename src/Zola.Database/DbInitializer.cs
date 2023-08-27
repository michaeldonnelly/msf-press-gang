using System;
using Microsoft.EntityFrameworkCore;
using Zola.Database.Migrations;
using Zola.Database.Models;

namespace Zola.Database
{
	public static class DbInitializer
	{
		public static void Initialize(MsfDbContext context, DbSettings settings)
		{
            //context.Database.EnsureCreated();
            context.Database.Migrate();
            InitializeEffects(context);

            //var _ = context.Characters
            //    .Include(character => character.Traits)
            //    .Include(character => character.GearTierCollection)
            //    .ThenInclude(gearTier => gearTier.Stats)
            //    .Include(character => character.AbilityKit.Basic.AbilityLevelCollection)
            //    .Include(character => character.AbilityKit.Special.AbilityLevelCollection)
            //    .Include(character => character.AbilityKit.Passive.AbilityLevelCollection)
            //    .Include(character => character.AbilityKit.Ultimate.AbilityLevelCollection)
            //    //.ThenInclude(ultimate => ultimate.AbilityLevelCollection)
            //    .ToList();
        }

        public static void InitializeEffects(MsfDbContext context)
        {
            List<string> effectNames = new()
            {
                "Counterattack", "Deathproof", "Immunity", "Defense Up", "Deflect", "Evade", "Regeneration", "Safeguard", "Minor Defense Up", "Minor Deflect", "Minor Regeneration", "Minor Offense Up", "Offense Up", "Speed Up", "Stealth", "Taunt", "Ability Block", "Blind", "Disrupted", "Defense Down", "Bleed", "Heal Block", "Minor Bleed", "Trauma", "Minor Defense Down", "Minor Offense Down", "Offense Down", "Slow", "Stun", "Assist Now", "Charged", "Exhausted", "Exposed", "Iso - 8 Vulnerable", "Revive Once"
            };

            foreach (string name in effectNames)
            {
                //Console.Write(name + ": ");
                if (context.Effects.Where(e => e.Name == name).Count() == 0)
                {
                    Effect effect = new(name);
                    context.Add(effect);
                    //Console.Write("added");
                }
                else
                {
                    //Console.Write("exists");
                }
                //Console.WriteLine();
            }

            context.SaveChanges();
        }
    }
}

