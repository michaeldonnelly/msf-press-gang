using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PressGang.Core.System.Mode;

namespace PressGang.Core.Data
{
    public static class Import
    {
        public static void ImportAll(PressGangContext context, string dataDirectory)
        {
            ImportCampaigns(context, dataDirectory);
            GenerateCampaignLevels(context);
        }

        public static void ImportCampaigns(ModelBuilder modelBuilder, string dataDirectory)
        {
            string jsonString = File.ReadAllText(dataDirectory + "/campaigns.json");
            CampaignList campaignList = JsonConvert.DeserializeObject<CampaignList>(jsonString);
            foreach (Campaign campaign in campaignList.Campaigns)
            {
                modelBuilder.Entity<Campaign>().HasData(campaign);
            }
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

        private static void GenerateCampaignLevels(PressGangContext context)
        {
            var foo = context.Campaigns.ToList();
            Debug.WriteLine(foo.ToString());

            foreach (Campaign bar in context.Campaigns)
            {
                Debug.WriteLine(bar.Name);

            }



           // foreach (Campaign campaign in context.Campaigns)
           // {
           //     Debug.WriteLine(campaign.Name + " " + campaign.Levels.ToString());
           // }
        }

        public static void ImportCharacters(PressGangContext context, string dataDirectory)
        {
            string jsonString = File.ReadAllText(dataDirectory + "/characters.json");

        }

        
    }

    class CampaignList
    {
        public List<Campaign> Campaigns { get; set; }
    }
}
