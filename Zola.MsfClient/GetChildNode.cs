using System;
using Microsoft.Kiota.Abstractions.Serialization;
using Zola.MsfClient.Models;

namespace Zola.MsfClient
{
	public static class GetChildNode
	{
        public static AbilityLevel? GetAbilityLevel(string levelNumber, IParseNode n)
        {
            return GetChild<AbilityLevel>(levelNumber, n, AbilityLevel.CreateFromDiscriminatorValue);
        }

        public static GearTier? GetGearTier(string levelNumber, IParseNode n)
        {
            return GetChild<GearTier>(levelNumber, n, GearTier.CreateFromDiscriminatorValue);
        }

        private static T? GetChild<T>(string levelNumber, IParseNode n, ParsableFactory<IParsable> factory)
        {
            IParseNode? child = n.GetChildNode(levelNumber);
            if (child is null)
            {
                return default(T);
            }
            else
            {
                IParsable? childObject = child.GetObjectValue<IParsable>(factory);
                return (T?)childObject;
            }
        }
    }
}

