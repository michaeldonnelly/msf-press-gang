using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Options;
using PressGang.Core.DatabaseContext;

namespace PressGang.Bot.Commands
{
    public class AdminHandlers : HandlerCore
    {
        public PressGangContext PressGangContext { private get; set; }

        public AdminHandlers(IOptions<DiscordOptions> options) : base(options)
        { }

        [Command("ping")]
        [Description("Confirm that the bot is up and running")]
        public async Task PingCommand(CommandContext ctx)
        {
            await DiscordUtils.Respond(ctx, "ack");
        }

        [Command("wait")]
        [RequireOwner]
        [Description("Sleep for while")]
        public async Task WaitCommand(CommandContext ctx, int milliseconds)
        {
            Thread.Sleep(milliseconds);
            string response = String.Format("Waited for {0} seconds", (milliseconds / 1000).ToString());
            await DiscordUtils.Respond(ctx, response);
        }

        [Command("database")]
        [Aliases("db")]
        [RequireOwner]
        public async Task DbCommand(CommandContext ctx)
        {
            Queue<string> response = new();
            response.Enqueue("PressGang Database Status");
            response.Enqueue(DiscordUtils.MonospaceUnderline(25));
            try
            {
                response.Enqueue("CanConnect: " + PressGangContext.Database.CanConnect().ToString());
                response.Enqueue("ProviderName: " + PressGangContext.Database.ProviderName.ToString());
                response.Enqueue("Record counts");
                IRelationalModel relationalModel = PressGangContext.Model.GetRelationalModel();
                foreach (ITable table in relationalModel.Tables)
                {
                    string tableName = table.Name;
                    IEnumerable<object> set = (IEnumerable<object>)PressGangContext.GetType().GetProperty(tableName).GetValue(PressGangContext, null);
                    int recordCount = set.Count();
                    response.Enqueue(String.Format("\t{0}: {1}", tableName, recordCount.ToString()));
                }

                await DiscordUtils.Respond(ctx, response);
            }
            catch (Exception ex)
            {
                await DiscordUtils.HandleError(ctx, ex);
            }
        }




    }
}
