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
using PressGang.Core.StaticModels;

namespace PressGang.Core.DatabaseContext
{
    public static class Import
    {
        public static void ImportAll(PressGangContext context, string dataDirectory)
        {
            ImportCampaigns(context, dataDirectory);
            GenerateCampaignLevels(context);
            ImportStores(context, dataDirectory);
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

        private static void ImportStores(PressGangContext context, string dataDirectory)
        {
            string jsonString = File.ReadAllText(dataDirectory + "/stores.json");
            StoreList storeList = JsonConvert.DeserializeObject<StoreList>(jsonString);
            foreach (Location store in storeList.Stores)
            {
                store.LocationType = LocationType.Store;
                try
                {
                    _ = context.Locations.First(l =>
                        (l.LocationType == LocationType.Store)
                        &&(l.Name == store.Name)
                    );
                }
                catch (InvalidOperationException)
                {
                    Debug.WriteLine(store.Name);
                    context.Add(store);
                }
            }
            context.SaveChanges();

        }

        private static void GenerateCampaignLevels(PressGangContext context)
        {
            foreach (Campaign campaign in context.Campaigns)
            {
                for (int level = 1; level <= campaign.Levels; level++)
                {
                    for (int node = 1; node <= campaign.NodesPerLevel; node++)
                    {
                        try
                        {
                            _ = context.Locations.First(
                                n => (
                                    (n.LocationType == LocationType.CampaignNode)
                                    && (n.Campaign == campaign)
                                    && (n.Level == level)
                                    && (n.Node == node)
                                ));
                        }
                        catch (InvalidOperationException)
                        {
                            Location campaignNode = new(campaign, level, node);
                            context.Add(campaignNode);
                        }
                    }
                }
            }
            context.SaveChanges();
        }

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
                Resource characterShard;

                try
                {
                    Character character = context.Characters.First(c => c.Name == characterName);
                    characterShard = LookUp.Shard(context, character);
                }
                catch (InvalidOperationException)
                {
                    Character character = new(characterName);
                    characterShard = new(character);
                    Debug.WriteLine(characterName);
                    context.Add(character);
                    context.Add(characterShard);
                    context.SaveChanges();
                }

                Location location = FindLocation(context, characterLocation);
                if (location != null)
                {
                    try
                    {
                        _ = context.Opportunties.First(o =>
                            (o.Resource == characterShard)
                            && (o.Location == location)
                        );
                    }
                    catch
                    {
                        Opportunity opportunity = new(characterShard, location);
                        context.Add(opportunity);
                        context.SaveChanges();
                    }
                }
            }
        }

        private static Location FindLocation(PressGangContext context, CharacterLocation characterLocation)
        {
            // TODO: Do we need this if we have all the stores built?
            try
            {
                if (characterLocation.CampaignLevel != null)
                {
                    Campaign campaign = context.Campaigns.First(c => c.NickName == characterLocation.Location);
                    Location location = context.Locations.First(l =>
                        (l.LocationType == LocationType.CampaignNode)
                        && (l.Campaign == campaign)
                        && (l.Level == (int)characterLocation.CampaignLevel)
                        && (l.Node == (int)characterLocation.CampaignNode)
                    );
                    return location;
                }
                else
                {
                    Location location = context.Locations.First(l =>
                        (l.LocationType != LocationType.CampaignNode)
                        && (l.Name == characterLocation.Location)
                    );
                    return location;
                }
            }
            catch(InvalidOperationException)
            {
                return null;
            }
        }


        private static List<CharacterLocation> ReadCharacterLocations(string path)
        {
            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                IEnumerable<CharacterLocation> rows = csv.GetRecords<CharacterLocation>();
                List<CharacterLocation> characterLocations = rows.ToList<CharacterLocation>();
                return characterLocations;
            }
        }

          
    }

    class CampaignList
    {
        public List<Campaign> Campaigns { get; set; }
    }

    class StoreList
    {
        public List<Location> Stores { get; set; }
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
        public int? Cost { get; set; }
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
