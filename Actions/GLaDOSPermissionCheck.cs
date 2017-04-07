﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Discord;
using Discord.Commands;

namespace DiscBot.Actions
{
    /// <summary>
    /// Base Permission checker. Determines if a user is allowed to run commands at all.
    /// </summary>
    class GLaDOSPermissionCheck : Discord.Commands.Permissions.IPermissionChecker
    {
        public bool CanRun(Command command, User user, Channel channel, out string errorMessage)
        {
            errorMessage = "";
            return true;
        }

    }
}