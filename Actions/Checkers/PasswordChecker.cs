using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Discord;
using Discord.Commands;
using Discord.Commands.Permissions;

namespace DiscBot.Actions
{
    class PasswordChecker : CustomChecker
    {
        string password;

        public PasswordChecker(string pass, Func<CommandEventArgs, Task> func) : base(func)
        {
            this.password = pass;
            this.successAction = func;
        }

        public override async Task Check(CommandEventArgs args)
        {
            string pass = args.GetArg("password");

            // Password missing
            if (string.IsNullOrWhiteSpace(pass))
            {
                await args.Channel.SendMessage("Password missing.");
                return;
            }

            // Check password
            if (pass == password)
            {
                await successAction.Invoke(args);
            }
            else
            {
                await args.Channel.SendMessage("Incorrect password.");
            }
        }
    }
}
