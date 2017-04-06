using Discord;
using Discord.Commands;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuchenBot.Commands
{
    /// <summary>
    /// Commands that can only be used by talking directly to the bot.
    /// </summary>
    class DMOnly
    {
        public static void Init(CommandService service)
        {
            //Register the group. Once created, you can't add a command.

            //Register loose
            GeneratePass.Register(service);
        }

        public class GeneratePass
        {
            public static void Register(CommandService service)
            {
                service.CreateCommand("genPass")
                    .Alias(new string[] { "generatePass", "generatePassword", "passPls"})
                    .Description("Generates a user specific password. It's generated using the users unique id, so only that user can use the pass. It might be required for some commands (such as wipeall)")
                    .Do(Run);
            }

            public static async Task Run(CommandEventArgs args)
            {
                /*
                if (CommandUtil.IsDirectMessage(args, true))
                {
                    await args.User.PrivateChannel.SendMessage(args.User.Id.GetHashCode().ToString());
                }*/
            }
        }


    }
}
