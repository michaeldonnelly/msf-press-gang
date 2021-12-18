using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using PressGang.Core.System.Mode;

namespace PressGang.Core.Data
{
    public static class Import
    {
        public static void ImportCampaigns(PressGangContext context, string dataDirectory)
        {
            string jsonString = File.ReadAllText(dataDirectory + "/campaigns.json");
            CampaignList campaigns = JsonConvert.DeserializeObject<CampaignList>(jsonString);
            Debug.WriteLine(campaigns.Campaigns.Count.ToString());
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
