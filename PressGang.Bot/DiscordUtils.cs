using System;
using System.Collections.Generic;
using System.Threading;
using DSharpPlus.CommandsNext;

namespace PressGang.Bot
{
    public static class DiscordUtils
    {
        public static async void Respond(CommandContext ctx, Queue<string> responseQueue)
        {
            const string codeMarkdown = "```";
            string responseString = codeMarkdown;
            while (responseQueue.Count > 0)
            {
                string line = responseQueue.Dequeue();
                if (responseString.Length + line.Length > 1800)
                {
                    responseString += codeMarkdown;
                    await ctx.RespondAsync(responseString);
                    responseString = codeMarkdown;
                    Thread.Sleep(250);
                }
                responseString += line;
                responseString += "\r\n";
            }
            responseString += codeMarkdown;
            await ctx.RespondAsync(responseString);
        }

        public static void HandleError(CommandContext ctx, Exception ex)
        {
            if (ctx.User.Id == 559173272306974740)
            {
                ctx.RespondAsync(ex.ToString());
            }
            else
            {
                // TODO: log errors
            }
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
