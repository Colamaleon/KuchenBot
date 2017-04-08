using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Discord;
using Discord.Commands;

namespace DiscBot.Actions.Checkers
{
    class MultiChecker : CustomChecker
    {
        CustomChecker[] checkers;
        string expression;

        public MultiChecker(Func<CommandEventArgs, Task> func, string expression, params CustomChecker[] checkers) : base(func)
        {
            this.successAction = func;
            this.checkers = checkers;
            this.expression = expression;
        }

        public override async Task Check(CommandEventArgs args)
        {
            await successAction.Invoke(args);
        }

    }
}
