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
    class UserWhiteListService : CustomIDListService
    {

        public UserWhiteListService() : base(IDType.user, ListType.whitelist)
        {
        }

        /// <summary>
        /// Access the Whitelist for this command.
        /// </summary>
        public ulong[] GetWhiteList(Command command)
        {
            return GetIDList(command);
        }

        /// <summary>
        /// Reload the Whitelist
        /// </summary>
        public void UpdateWhiteList(Command command)
        {
            UpdateIDList(command);
        }

    }
}
