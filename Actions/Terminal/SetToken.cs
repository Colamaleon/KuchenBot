using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Discord;
using Discord.Commands;

namespace DiscBot.Actions.Terminal
{
    class SetToken
    {
        static GLaDOSManager manager;

        public static void Register(CommandService service, GLaDOSManager manager)
        {
            service.CreateCommand("SetToken")
                .Description("Registers a new local token used by the bot.  Requires: sudo  Warning: This will start a reconnect which may crash the bot!")
                .Parameter("password", ParameterType.Optional)
                .Parameter("token", ParameterType.Optional)
                .Do(new ParameterChecker("token", new PasswordChecker("sudo", Run).Check).Check);
            SetToken.manager = manager;
        }

        public static async Task Run(CommandEventArgs args)
        {
            string token = args.GetArg("token");

            await args.Channel.SendMessage("Setting new token...");
            await Task.Delay(500);

            IOModule.SetLocalToken(token);
            manager.GetGlados().Reconnect();
        }
    }
}
