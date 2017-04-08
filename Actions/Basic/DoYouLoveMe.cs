using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Discord.Commands;
using Discord;

namespace DiscBot.Actions.Basic
{
    class DoYouLoveMe : GLaDOSCommand
    {
        public void Register(CommandService service)
        {
            service.CreateCommand("doyouloveme")
                .Alias(new string[] { "doyouloveme?" })
                .Description("Answers the question you've been dying to ask.")
                .Do(Run);
        }

        public async Task Run(CommandEventArgs args)
        {
            await args.Channel.SendMessage(MessageStrings.DOYOULOVEME);
        }
    }
}
