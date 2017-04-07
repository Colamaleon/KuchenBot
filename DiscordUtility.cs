using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Discord;
using Discord.Commands;

namespace DiscBot
{
    public static class DiscordUtility
    {

        public static string GenerateUserPass(User user)
        {
            //TODO: Find a proper function to generate a pass

            return user.Id.ToString();
        }

    }
}
