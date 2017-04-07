using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Discord;
using Discord.Commands;

namespace DiscBot.Actions.ShitsAndGiggles
{
    class Sing : GLaDOSCommand
    {
        public static void Register(CommandService service)
        {
            service.CreateCommand("sing")
                .Description("Greetings")
                .Do(Run);
        }

        public static async Task Run(CommandEventArgs args)
        {
            await args.Channel.SendMessage("https://www.youtube.com/watch?v=Y6ljFaKRTrI");
        }

    }
}
