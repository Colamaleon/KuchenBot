using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Discord;
using Discord.Commands;

namespace KuchenBot
{
    /// <summary>
    /// Misc methods for checking privileges, channelIDs and such...
    /// </summary>
    static class CommandUtil
    {

        /// <summary>
        /// Checks if the user posted in their own private channel (aka did they dm the bot)
        /// </summary>
        /// <param name="args">the eventargs</param>
        /// <param name="shouldNotifyUser">should the user receive a notification if they posted in a non dm channel</param>
        /// <returns></returns>
        public static bool IsDirectMessage(CommandEventArgs args, bool shouldNotifyUser = true)
        {
            bool valid = args.Channel.Id == args.User.PrivateChannel.Id;
            if(!valid && shouldNotifyUser)
            {
                args.User.PrivateChannel.SendMessage("This command can be only be used via direct message!");
            }
            return valid;
        }
    }
}
