using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Discord.Commands;
using Discord;

using DiscBot.Actions.Attributes;

namespace DiscBot.Actions.Terminal
{
    [ConsoleOnly]
    class RegisterToken : GLaDOSCommand
    {
        static GLaDOSManager manager;

        public void Register(CommandService service, GLaDOSManager manager)
        {
            RegisterToken.manager = manager;
            service.CreateCommand("registertoken")
                .Alias(new string[] { })
                .Description("Register a new locally used token.")
                .Parameter("token", ParameterType.Required)
                .Do(Run);
        }

        public async Task Run(CommandEventArgs args)
        {
            string token = args.GetArg("token");
            manager.GetGlados(this);
        }
    }
    //class CopyToken : GLaDOSCommand
    //{
    //    public static void Register(CommandService service)
    //    {
    //        service.CreateCommand("copytoken")
    //            .Alias(new string[] { })
    //            .Description("Copy the locally used token into the clipboard.")
    //            .Do(Run);
    //    }

    //    public static async Task Run(CommandEventArgs args)
    //    {
    //        await args.Channel.SendMessage("DENIED");
    //    }
    //}
}
