using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Discord.Commands;
using Discord;

namespace DiscBot.Commands.Basic
{
    class WipeAll
    {
        public static void Register(CommandService service)
        {
            service.CreateCommand("wipeall")
                .Description("wipes all the messages in the current channel")
                .Do(Run);
        }

        public static async Task Run(CommandEventArgs args)
        {
            Console.WriteLine("Deleting Messages...");
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
