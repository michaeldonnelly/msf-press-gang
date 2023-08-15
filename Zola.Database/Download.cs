using System;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Zola.MsfClient;
using Zola.MsfClient.Models;

namespace Zola.Database
{
	public class Download
	{
        private readonly ApiClient ApiClient;
        private readonly MsfDbContext MsfDbContext;
        public Download(ApiClient apiClient, MsfDbContext msfDbContext)
		{
            ApiClient = apiClient;
            MsfDbContext = msfDbContext;

        }


		public async Task<int> Traits()
		{
            var allTraits = await ApiClient.Game.V1.Traits.GetAsync();
            Console.WriteLine($"Retrieved {allTraits?.Data?.Count} traits.");
            int count = 0;
            if (allTraits is null || allTraits.Data is null)
            {
                throw new Exception("Failed to download traits");
            }

            foreach (var trait in allTraits.Data)
            {
                count++;
                if (count < 4)
                {
                    Console.WriteLine($"  {trait.Id}");
                }
                else if (count == 4)
                {
                    Console.WriteLine($"  ...");
                }

                if (MsfDbContext.Traits.Where(t => t.Id == trait.Id).Count() == 0)
                {
                    MsfDbContext.Add(trait);
                }
            }
            return MsfDbContext.SaveChanges();
        }

        public async Task<int> Characters()
        {
            var allCharacters = await ApiClient.Game.V1.Characters.GetAsync();
            if (allCharacters is null || allCharacters.Data is null)
            {
                throw new Exception("Failed to download characters");
            }

            Console.WriteLine($"Retrieved {allCharacters.Data.Count} characters.");
            foreach (CharacterInfo characterInfo in allCharacters.Data)
            {
                int result = await OneCharacter(characterInfo.Id);
                Console.WriteLine($"{characterInfo.Name} - {result}");
            }
            return MsfDbContext.SaveChanges();
        }

        public async Task<int> OneCharacter(string id)
        {

            var response = await ApiClient.Game.V1.Characters[id].GetAsync();
            if (response is null)
            {
                throw new Exception($"No response searching for id '{id}'");
            }

            CharacterInfo? character = response.Data;
            if (character is null)
            {
                throw new Exception($"No character found with id '{id}'");
            }

            int result;
            if (character.Status == CharacterInfo_status.Playable)
            {
                result = MsfDbContext.SafeAdd(character);
            }
            else
            {
                result = 0;
            }

            return result;
        }
    }
}

