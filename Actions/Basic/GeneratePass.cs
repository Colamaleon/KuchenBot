using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Discord;
using Discord.Commands;
using Discord.Net;

namespace DiscBot.Actions.Basic
{
    class GeneratePass
    {
        public static void Register(CommandService service)
        {
            //TODO Check if this is Run in a pm
            service.CreateCommand("generatepassword")
                .AddCheck(new IsDirectMessageChecker())
                .Alias(new string[] { "genpass", "passpls", "getpass"})
                .Parameter("pass", ParameterType.Required)
                .Description("Generate a user specific password. Use this pass to run various commands that require them.")
                .Do(Run);
        }

        public static async Task Run(CommandEventArgs args)
        {
            try
            {
                Channel pmChannel = await args.User.CreatePMChannel();
                string pass = DiscordUtility.GenerateUserPass(args.User);
                await pmChannel.SendMessage(string.Format(MessageStrings.passMessage, args.User.Nickname, pass));
            }catch (HttpException he)
            {

            }
        }
    }
}
