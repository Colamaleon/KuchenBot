using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Discord;
using Discord.Commands;

namespace DiscBot.Actions.Terminal
{
    class GetToken : GLaDOSCommand
    {
        static GLaDOSManager manager;

        public static void Register(CommandService service, GLaDOSManager manager)
        {
            service.CreateCommand("GetToken")
                .Description("Returns the local token used by the bot.")
                .Do(Run);
            GetToken.manager = manager;
        }

        public static async Task Run(CommandEventArgs args)
        {
            string token = IOModule.GetLocalToken();
            await args.Channel.SendMessage(token);
        }
    }
}
