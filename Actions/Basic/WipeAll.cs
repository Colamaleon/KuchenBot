using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Discord.Commands;
using Discord;

using DiscBot.Actions;

namespace DiscBot.Actions.Basic
{
    class WipeAll
    {
        public static void Register(CommandService service)
        {
            service.CreateCommand("wipeall")
                .Alias(new string[] {"fullwipe"})
                .Parameter("pass", ParameterType.Required)
                .Description("wipes all the messages in the current channel")
                .Do(Run);
        }

        public static async Task Run(CommandEventArgs args)
        {
            Message[] messages = await args.Channel.DownloadMessages();

            while (messages.Length > 0)
            {
                messages = await args.Channel.DownloadMessages();
                await args.Channel.DeleteMessages(messages);
            }
            Console.WriteLine("Deletion Complete...");

            await args.Channel.SendMessage("Wiped Logs... scrub, scrub.");
        }
    }
}
