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
    class PasswordChecker
    {
        string password;
        Func<CommandEventArgs, Task> func;

        public PasswordChecker(string pass, Func<CommandEventArgs, Task> func)
        {
            password = pass;
            this.func = func;
        }

        public async Task Check(CommandEventArgs args)
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
                await func.Invoke(args);
            }
            else
            {
                await args.Channel.SendMessage("Incorrect password.");
            }
        }
    }
}
