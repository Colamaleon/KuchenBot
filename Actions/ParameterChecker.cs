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
    class ParameterChecker
    {
        string parameter;
        Func<CommandEventArgs, Task> func;

        public ParameterChecker(string parameter, Func<CommandEventArgs, Task> func)
        {
            this.parameter = parameter;
            this.func = func;
        }

        public async Task Check(CommandEventArgs args)
        {
            string param = args.GetArg(parameter);
            if (string.IsNullOrWhiteSpace(param))
            {
                await args.Channel.SendMessage(parameter + " parameter missing.");
                return;
            }

            await func.Invoke(args);
        }
    }
}
