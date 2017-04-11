using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Discord;
using Discord.Commands;

namespace DiscBot.Actions
{
    abstract class CustomChecker
    {
        protected Func<CommandEventArgs, Task> successAction;

        protected class ResultUtil
        {
            public bool On { get; private set; }
            public async Task TurnOn(CommandEventArgs args)
            {
                On = true;
            }
        }

        public CustomChecker(Func<CommandEventArgs, Task> successAction)
        {
            this.successAction = successAction;
        }

        /// <summary>
        /// Run the Check.
        /// </summary>
        public virtual async Task Check(CommandEventArgs args)
        { throw new NotImplementedException(); }

    }
}
