using System;
using System.Runtime.InteropServices;
using Zola.MsfClient.Models;

namespace Zola.Database.Models
{
	public class Effect
	{
		public Effect(string name)
		{
			Name = name;
		}
        public string Id { get; set; } = Guid.NewGuid().ToString();
		public string Name { get; set; }
		//public string Description { get; set; }
		//public EffectAlignment Alignment { get; set; }
		//public EffectExpiration Expires { get; set; }
		//public Effect Opposite { get; set; }
	}

	public enum EffectAlignment
	{
        Positive, Negative, Other
	}

	public enum EffectExpiration
	{
        EndOfTurn,
        StartOfTurn,
		OnCounter,
		OnDeathProof,
		OnBlock,
		OnEvade,
		EndOfAnyTurn,
		Never
    }
    
}

