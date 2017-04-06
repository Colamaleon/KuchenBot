using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Discord.Commands;
using Discord;

using DiscBot.Commands.Attributes;

namespace DiscBot.Commands.Basic
{
    [Attributes.Password("sure!")]
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
            if(((Password)Attribute.GetCustomAttribute(typeof(WipeAll), typeof(Password))).CheckPass(args))
            {
                Console.WriteLine("Correct Pass!");
            }else
            {
                Console.WriteLine("Wrong Pass!");
            }

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
