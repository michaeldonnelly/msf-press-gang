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
using PressGang.Core.DatabaseContext;
using PressGang.Core.Reports;
using PressGang.Core.StaticModels;

namespace PressGang.Core.DatabaseOperations
{
    public static class Import
    {
        public static void ImportAll(PressGangContext context, string dataDirectory)
        {
            Console.WriteLine("Importing datafiles (record count before / after)");

            Precount(context, "Campaigns");
            ImportCampaigns(context, dataDirectory);
            Postcount(context, "Campaigns");

            Precount(context, "Locations", "Campaign Levels");
            GenerateCampaignLevels(context);
            Postcount(context, "Locations");

            Precount(context, "Locations", "Stores");
            ImportStores(context, dataDirectory);
            Postcount(context, "Locations");

            Precount(context, "Characters");
            ImportCharactersAndAliases(context, dataDirectory);
            Postcount(context, "Characters");

            //Precount(context, "Oppotunities");
            //ImportCharactersAndLocations(context, dataDirectory);
            //Postcount(context, "Oppotunities");

            //Precount(context, "Prerequisites");
            //ImportPrereqs(context, dataDirectory);
            //Postcount(context, "Prerequisites");
            //Console.WriteLine("Import complete\r\n");
        }

        private static void Precount(PressGangContext context, string tableName, string subType = "")
        {
            int recordsBefore = StaticReports.RowsInTable(context, tableName);

            string formattedSubtype = "";
            if (!String.IsNullOrEmpty(subType))
            {
                formattedSubtype = $" [{subType}]";
            }
            Console.Write($"  {tableName}{formattedSubtype} ({recordsBefore.ToString()} / ");
        }

        private static void Postcount(PressGangContext context, string tableName)
        {
            int recordsAfter = StaticReports.RowsInTable(context, tableName);
            Console.WriteLine($"{recordsAfter.ToString()})");
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

        private static void ImportCharactersAndAliases(PressGangContext context, string dataDirectory)
        {
            string path = dataDirectory + "/characterAlias.csv";
            List<CharacterAlias> aliases = ReadCharacters(path);
            int line = 0;
            foreach(CharacterAlias characterAlias in aliases)
            {
                line++;
                Console.Write($"    {line.ToString().PadLeft(4)}. {characterAlias.CharacterKey}: ");
                if (IsSummonedCharacter(characterAlias.CharacterKey))
                {
                    Console.WriteLine("summoned");
                    continue;
                }

                Character character = context.Characters.Where<Character>(c => c.CharacterKey == characterAlias.CharacterKey).FirstOrDefault();
                if (character == null)
                {
                    string firstAlias = characterAlias.Aliases.First<string>();
                    string characterName = FormatCharacterName(firstAlias);
                    character = new(characterName)
                    {
                        CharacterKey = characterAlias.CharacterKey
                    };
                    foreach (string alias in characterAlias.Aliases.Skip(1))
                    {
                        // TODO: add alias to character
                    }
                    context.Add(character);
                    Console.WriteLine("added");
                }
                else
                {
                    Console.WriteLine("exists");
                }
            }
            context.SaveChanges();
        }

        private static bool IsSummonedCharacter(string characterName)
        {
            return characterName.StartsWith("S_");
        }

        private static string FormatCharacterName(string rawName)
        {
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            string characterName = textInfo.ToTitleCase(rawName);
            return characterName;
        }

        private static List<CharacterAlias> ReadCharacters(string path)
        {
            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<CharacterAliasMap>();
                IEnumerable<CharacterAlias> rows = csv.GetRecords<CharacterAlias>();
                List<CharacterAlias> characters = rows.ToList<CharacterAlias>();
                return characters;
            }
        }


        private static void ImportCharactersAndLocations(PressGangContext context, string dataDirectory)
        {
            string path = dataDirectory + "/shard-locations.csv";
            List<CharacterLocation> characterLocations = ReadCharacterLocations(path);
            Debug.WriteLine(characterLocations.Count);
            AddCharacters(context, characterLocations);
        }

        private static void ImportPrereqs(PressGangContext context , string dataDirectory)
        {
            string jsonString = File.ReadAllText(dataDirectory + "/prerequisites.json");
            PrerequisiteList prerequisiteList = JsonConvert.DeserializeObject<PrerequisiteList>(jsonString);
            foreach (PrerequisiteListEntry entry in prerequisiteList.Prerequisites)
            {
                Character character = LookUp.Character(context, entry.Character);
                if (character == null)
                {
                    character = new(entry.Character);
                    context.Add(character);
                }
                foreach (string dependsOnName in entry.DependsOn)
                {
                    Character dependsOn = LookUp.Character(context, dependsOnName);
                    if (dependsOn == null)
                    {
                        dependsOn = new(dependsOnName);
                        context.Add(dependsOn);
                    }

                    Prerequisite prerequisite = LookUp.Prerequisite(context, character, dependsOn);
                    if (prerequisite == null)
                    {
                        prerequisite = new(character, dependsOn, entry.YellowStars);
                        context.Add(prerequisite);
                    }
                }
                context.SaveChanges();
            }
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

    class CharacterAlias
    {
        public string CharacterKey { get; set; }
        public List<String> Aliases { get; set; }
    }

    sealed class CharacterAliasMap : ClassMap<CharacterAlias>
    {
        public CharacterAliasMap()
        {
            Map(ca => ca.CharacterKey);
            Map(ca =>ca.Aliases).Index(1);
        }
    }

    class PrerequisiteList
    {
        public List<PrerequisiteListEntry> Prerequisites { get; set; }
    }

    class PrerequisiteListEntry
    {
        public string Character { get; set; }
        public int YellowStars { get; set; }
        public List<string> DependsOn { get; set; }
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
