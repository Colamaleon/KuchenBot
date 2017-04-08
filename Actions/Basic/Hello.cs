using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Discord.Commands;
using Discord;

namespace DiscBot.Actions.Basic
{
    class Hello : GLaDOSCommand
    {
        public static void Register(CommandService service)
        {
            service.CreateCommand("hello")
                .Alias(new string[] { "hi", "greetings" })
                .Description("Greetings")
                .Do(Run);
        }

        public static async Task Run(CommandEventArgs args)
        {
            await args.Channel.SendMessage(MessageStrings.HELLO);
        }
    }
}
