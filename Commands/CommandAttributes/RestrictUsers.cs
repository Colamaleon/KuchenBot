using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Discord.Commands;
using Discord;

namespace KuchenBot.Commands.CommandAttributes
{
    class RestrictUsers : Restrict
    {

        public override bool CheckValidUse(CommandEventArgs args)
        {
            throw new NotImplementedException();
        }

    }
}
