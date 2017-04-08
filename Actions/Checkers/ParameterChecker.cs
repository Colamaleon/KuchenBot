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
    class ParameterChecker : CustomChecker
    {
        string parameter;

        public ParameterChecker(string parameter, Func<CommandEventArgs, Task> func) : base(func)
        {
            this.parameter = parameter;
            this.successAction = func;
        }

        public override async Task Check(CommandEventArgs args)
        {
            string param = args.GetArg(parameter);
            if (string.IsNullOrWhiteSpace(param))
            {
                await args.Channel.SendMessage(parameter + " parameter missing.");
                return;
            }

            await successAction.Invoke(args);
        }
    }
}
