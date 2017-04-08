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

        public CustomChecker(Func<CommandEventArgs, Task> successAction)
        {
            this.successAction = successAction;
        }

        public virtual async Task Check(CommandEventArgs args)
        { await args.Channel.SendMessage("ERROR :: Check function lacks override!"); }
        
    }
}
