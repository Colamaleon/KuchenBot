using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Discord.Commands;
using Discord;

namespace DiscBot.Commands.CommandLine
{
    class RegisterToken : GLaDOSCommand
    {
        public static void Register(CommandService service)
        {
            service.CreateCommand("copytoken")
                .Alias(new string[] { })
                .Description("Copy the locally used token into the clipboard.")
                .Parameter("password", ParameterType.Required)
                .Do(Run);
        }

        public static async Task Run(CommandEventArgs args)
        {
            args.GetArg("password");
        }
    }
    class CopyToken : GLaDOSCommand
    {
        public static void Register(CommandService service)
        {
            service.CreateCommand("copytoken")
                .Alias(new string[] { })
                .Description("Copy the locally used token into the clipboard.")
                .Do(Run);
        }

        public static async Task Run(CommandEventArgs args)
        {
            await args.Channel.SendMessage("DENIED");
        }
    }
}
