using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Discord;
using Discord.Commands;
using Discord.Commands.Permissions;

namespace DiscBot.Services
{
    /// <summary>
    /// A service to exclude certain channels from running commands.
    /// </summary>
    class ChannelBlackListService : CustomIDListService
    {

        public ChannelBlackListService() : base(IDType.channel, ListType.blacklist)
        { 
        }

        /// <summary>
        /// Access the Whitelist for this command.
        /// </summary>
        public ulong[] GetBlackList(Command command)
        {
            return GetIDList(command);
        }

        /// <summary>
        /// Reload the Whitelist
        /// </summary>
        public void UpdateBlackList(Command command)
        {
            UpdateIDList(command);
        }

    }
}
