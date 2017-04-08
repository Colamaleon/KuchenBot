using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Discord;
using Discord.Commands;

namespace DiscBot.Actions.Terminal
{
    class SetToken : GLaDOSCommand
    {
        static GLaDOSManager manager;

        public static void Register(CommandService service, GLaDOSManager manager)
        {
            service.CreateCommand("SetToken")
                .Description("Registers a new local token used by the bot.  Requires: sudo  Warning: This will start a reconnect which may crash the bot!")
                .Parameter("password", ParameterType.Optional)
                .Parameter("token", ParameterType.Optional)
                .Do(new PasswordChecker("sudo", Run).Check);
            SetToken.manager = manager;
        }

        public static async Task Run(CommandEventArgs args)
        {
            string token = args.GetArg("token");
            if (string.IsNullOrWhiteSpace(token))
            {
                await args.Channel.SendMessage("token parameter missing.");
                return;
            }
            
            await args.Channel.SendMessage("Setting new token...");
            await Task.Delay(500);

            manager.GetGlados().SetLocalToken(token);
            manager.GetGlados().Reconnect();
        }
    }
}
