using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.Json.Serialization;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PressGang.Core.System;
using PressGang.Core.System.Mode;

namespace PressGang.Core.Data
{
    public static class Import
    {
        public static void ImportAll(PressGangContext context, string dataDirectory)
        {
            ImportCampaigns(context, dataDirectory);
            //GenerateCampaignLevels(context);
            ImportCharactersAndLocations(context, dataDirectory);
        }

        private static void ImportCampaigns(PressGangContext context, string dataDirectory)
        {
            string jsonString = File.ReadAllText(dataDirectory + "/campaigns.json");
            CampaignList campaignList = JsonConvert.DeserializeObject<CampaignList>(jsonString);
            foreach (Campaign campaign in campaignList.Campaigns)
            {
                try
                {
                    _ = context.Campaigns.First<Campaign>(c => c.Name == campaign.Name);
                }
                catch(InvalidOperationException)
                {
                    context.Add(campaign);
                }
            }
            context.SaveChanges();
        }

        //private static void GenerateCampaignLevels(PressGangContext context)
        //{
        //    foreach (Campaign campaign in context.Campaigns)
        //    {
        //        for (int level = 1; level <= campaign.Levels; level++)
        //        {
        //            for (int node = 1; node <= campaign.NodesPerLevel; node++)
        //            {
        //                try
        //                {
        //                    _ = context.CampaignNodes.First<CampaignNode>(
        //                        n => (
        //                            (n.Campaign == campaign)
        //                            && (n.Level == level)
        //                            && (n.Node == node)
        //                        ));
        //                }
        //                catch(InvalidOperationException)
        //                {
        //                    CampaignNode campaignNode = new(campaign, level, node);
        //                    context.Add(campaignNode);
        //                }
        //            }
        //        }
        //    }
        //    context.SaveChanges();
        //}

        private static void ImportCharactersAndLocations(PressGangContext context, string dataDirectory)
        {
            string path = dataDirectory + "/shard-locations.csv";
            List<CharacterLocation> characterLocations = ReadCharacterLocations(path);
            Debug.WriteLine(characterLocations.Count);
            AddCharacters(context, characterLocations);
        }

        private static void AddCharacters(PressGangContext context, List<CharacterLocation> characterLocations)
        {
            foreach(CharacterLocation characterLocation in characterLocations)
            {
                string characterName = characterLocation.CharacterName;
                try
                {
                    _ = context.Characters.First(c => c.Name == characterName);
                }
                catch (InvalidOperationException)
                {
                    Character character = new(characterName);
                    CharacterShard characterShard = new(character);
                    Debug.WriteLine(characterName);
                    context.Add(character);
                    //context.Add(characterShard);
                    context.SaveChanges();
                }
            }
        }


        private static List<CharacterLocation> ReadCharacterLocations(string path)
        {
            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                List<CharacterLocation> characterLocations = csv.GetRecords<CharacterLocation>().ToList<CharacterLocation>();
                return characterLocations;
            }
        }

          
    }

    class CampaignList
    {
        public List<Campaign> Campaigns { get; set; }
    }

    class CharacterLocation
    {
        [Name(CsvHeaders.CharacterName)]
        public string CharacterName { get; set; }

        [Name(CsvHeaders.Location)]
        public string Location { get; set; }

        [Name(CsvHeaders.CampaignLevel)]
        public int? CampaignLevel { get; set; }

        [Name(CsvHeaders.CampaignNode)]
        public int? CampaignNode { get; set; }

        [Name(CsvHeaders.Cost)]
        public int Cost { get; set; }
    }

    static class CsvHeaders
    {
        public const string CharacterName = "Character"; 
        public const string Location = "Location"; 
        public const string CampaignLevel = "Level"; 
        public const string CampaignNode = "Node"; 
        public const string Cost = "Cost"; 
    }
}
