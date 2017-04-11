using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Discord;
using Discord.Commands;

namespace DiscBot.Actions
{
    /// <summary>
    /// Combines multiple checker into one single check. 
    /// </summary>
    class MultiChecker
    {
        Func<CommandEventArgs, Task> successAction;
        Func<CommandEventArgs, bool> checkFunction;

        public MultiChecker(Func<CommandEventArgs, Task> successAction, Func<CommandEventArgs, bool> checkFunction)
        {
            this.successAction = successAction;
            this.checkFunction = checkFunction;
        }

        public async Task Check(CommandEventArgs args)
        {
            if (checkFunction(args))
            {
                await successAction.Invoke(args);
            }
        }

    }

}
