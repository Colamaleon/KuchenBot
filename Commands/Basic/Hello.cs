using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Discord.Commands;
using Discord;

namespace DiscBot.Commands.Basic
{
    class Hello : GLaDOSCommand
    {
        public static void Register(CommandService service)
        {
            service.CreateCommand("hello")
                .Alias(new string[] { "hi" })
                .Description("Greetings")
                .Do(Run);
        }

        public static async Task Run(CommandEventArgs args)
        {
            await args.Channel.SendMessage("Welcome," + args.User.NicknameMention + " ,\nMy name is GLaDOS, the \n\n**G**ames \n**L**ab \n**a**nd \n**D**eveloper \n**O**perating \n**S**ystem. \n\nNice to meet you.");
        }
    }
}
