﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Discord.Commands;
using Discord;

namespace DiscBot.Actions.ShitsAndGiggles
{
    class LetsBeFriends
    {
        public static void Register(CommandService service)
        {
            service.CreateCommand("letsbefriends")
                .Alias(new string[] { "areyoumyfriend?", "wannabefriends?" })
                .Description("Ask GLaDOS if she wants to be your friend.")
                .Do(Run);
        }

        public static async Task Run(CommandEventArgs args)
        {
            await args.Channel.SendMessage(args.User.NicknameMention + ", DENIED");
        }
    }
}
