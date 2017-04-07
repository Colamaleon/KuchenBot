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
    /// Check if the command was posted in a direct message channel
    /// </summary>
    class IsDirectMessageChecker : IPermissionChecker
    {
        public bool CanRun(Command command, User user, Channel channel)
        {
            return channel == user.PrivateChannel;
        }
    }
}
