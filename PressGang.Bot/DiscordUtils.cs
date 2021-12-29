using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;

namespace PressGang.Bot
{
    public static class DiscordUtils
    {
        public static Task Respond(CommandContext ctx, string responseString)
        {
            return ctx.RespondAsync("`" + responseString + "`");
        }

        public static Task Respond(CommandContext ctx, Queue<string> responseQueue)
        {
            const string codeMarkdown = "```";
            string responseString = codeMarkdown;
            while (responseQueue.Count > 0)
            {
                string line = responseQueue.Dequeue();
                if (responseString.Length + line.Length > 1800)
                {
                    responseString += codeMarkdown;
                    ctx.RespondAsync(responseString);
                    responseString = codeMarkdown;
                    Thread.Sleep(1000);
                }
                responseString += line;
                responseString += "\r\n";
            }
            responseString += codeMarkdown;
            return ctx.RespondAsync(responseString);
        }

        public static Task HandleError(CommandContext ctx, Exception ex)
        {
            return ctx.RespondAsync(ex.ToString());

            //if (ctx.User.Id == 559173272306974740)
            //{
            //    ctx.RespondAsync(ex.ToString());
            //}
            //else
            //{
            //    // TODO: log errors
            //}
        }

        public static Task Respond(CommandContext ctx, string title, string imageUrl)
        {
            DiscordEmbedBuilder embed = new()
            {
                Title = title,
                ImageUrl = imageUrl
            };
            return ctx.RespondAsync(embed);
        }

        public static string MonospaceUnderline(int length)
        {
            string result = "";
            for (int cursor = 0; cursor < length; cursor++)
            {
                result += "-";
            }
            return result;
        }
    }
}
