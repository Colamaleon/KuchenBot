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
    class IsDirectMessageChecker : Discord.Commands.Permissions.IPermissionChecker
    {
        public bool CanRun(Command command, User user, Channel channel, out string errorMessage)
        {
            errorMessage = "";
            if (channel == user.PrivateChannel)
            {
                return true;
            }else
            {
                errorMessage = "This command can only be run via a direct message";
                channel.SendMessage(errorMessage);
                return false;
            }
        }
    }
}
