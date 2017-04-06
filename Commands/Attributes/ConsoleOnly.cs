using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Discord.Commands;
using Discord;

namespace DiscBot.Actions.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    class ConsoleOnly : Restrict
    {
        public ConsoleOnly() : base(RestrictionType.Include, () => { return new ulong[] { }; })
        {

        }
    }
}
