using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Discord;
using Discord.Commands;

namespace DiscBot.Commands
{
    class GladosPermissionCheck : IPermissionChecker
    {
        public bool CanRun(Command command, User user, Channel channel)
        {
            return true;
        }
    }
}
