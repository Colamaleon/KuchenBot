using Discord;
using Discord.Commands;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuchenBot.Commands
{
    class Basic
    {
        public static void Init(CommandService service)
        {

            //Register loose
            WipeAll.Register(service);
            Status.Register(service);
        }

        public class WipeAll
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

        public class Status
        {
            public static void Register(CommandService service)
            {
                service.CreateCommand("status")
                    .Description("Responds if the bot is online")
                    .Do(Run);
            }

            public static async Task Run(CommandEventArgs args)
            {
                await args.Channel.SendMessage("still alive");
            }
        }

    }
}
