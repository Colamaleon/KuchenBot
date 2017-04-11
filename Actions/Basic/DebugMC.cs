using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Discord;
using Discord.Commands;

namespace DiscBot.Actions.Basic
{
    class DebugMC
    {
        public static void Register(CommandService service)
        {
            service.CreateCommand("debug")
                .Description("Test the multiChecker feature")
                .Parameter("password", ParameterType.Optional)
                .Do(new MultiChecker(Run, (args) =>
                {
                    return true;
                }).Check);
        }

        public static async Task Run(CommandEventArgs args)
        {
            await args.Channel.SendMessage("success!");
        }

    }
}
