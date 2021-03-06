﻿using System;
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
    class UserWhiteListChecker
    {

        private DiscordClient client;

        public UserWhiteListChecker(DiscordClient client)
        {
            this.client = client;
        }

        public bool CanRun(Command command, User user, Channel channel, out string error)
        {
            error = "";

            //get the ChannelBlackListService
            UserWhiteListService service = client.GetService<UserWhiteListService>();

            //load list using the commandName
            ulong[] whitelist = service.GetWhiteList(command);

            //check if this channel is on that list
            var onList = whitelist.Contains(channel.Id);
            if (!onList)
            {
                error = string.Format(MessageStrings.PERMISSION_FAIL, "not whitelisted");
                channel.SendMessage(error);
            }

            return onList;
        }

    }
}
