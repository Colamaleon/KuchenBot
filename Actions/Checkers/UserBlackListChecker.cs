using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Discord;
using Discord.Commands;
using Discord.Commands.Permissions;

using DiscBot.Services;

namespace DiscBot.Actions.Checkers
{
    class UserBlackListChecker 
    {

        private DiscordClient client;

        public UserBlackListChecker(DiscordClient client)
        {
            this.client = client;
        }

        public bool CanRun(Command command, User user, Channel channel, out string error)
        {
            error = "";

            //get the ChannelBlackListService
            UserBlackListService service = client.GetService<UserBlackListService>();

            //load list using the commandName
            ulong[] blacklist = service.GetBlackList(command);

            //check if this channel is on that list
            var onList = blacklist.Contains(channel.Id);
            if (onList)
            {
                error = string.Format(MessageStrings.PERMISSION_FAIL, "blacklisted");
                channel.SendMessage(error);
            }

            return !onList;
        }

    }
}
