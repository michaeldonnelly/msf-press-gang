using System;
using System.Collections.Generic;

namespace PressGang.Bot
{
    public class DiscordOptions
    {
        public const string Discord = nameof(Discord);

        public string TokenFilePath { get; set; }

        /// <summary>
        /// The Discord User ID of the person who owns the bot.  This determines who gets error messages and who can run admin commands.
        /// </summary>
        public ulong OwnerUserId { get; set; }

        public string BotName { get; set; } = "$BotName not set";

        public string AllianceName { get; set; } = "$AllianceName not set";

        public bool EnablePressGang { get; set; }

        public AllianceData AllianceData { get; set; }
    }

    public class AllianceData
    {
        public AllianceMaps Maps { get; set; }
    }

    public class AllianceMaps
    {
        public List<RaidLane> RaidLanes { get; set; }
    }

    public class RaidLane
    {
        public string Raid { get; set; }
        public int Level { get; set; }
        public string MapUrl { get; set; }
    }
}
