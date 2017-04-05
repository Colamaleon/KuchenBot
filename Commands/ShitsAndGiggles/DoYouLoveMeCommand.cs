using Discord;
using Discord.Commands;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuchenBot.Commands.ShitsAndGiggles
{
    class DoYouLoveMeCommand
    {
        static DoYouLoveMeCommand instance;

        private DoYouLoveMeCommand(CommandService service)
        {
            service.CreateCommand("doyouloveme")
                .Alias(new string[] { "doyouloveme?" })
                .Description("Answers the question you've been dying to ask.")
                .Do(async (e) =>
                {
                    await e.Channel.SendMessage("I am a robot, and therefore I am unable to experience emotions such as love.\nI am sorry to disappoint you.");
                });
        }

        public static void Register(CommandService service)
        {
            if (instance == null)
            { instance = new DoYouLoveMeCommand(service); }
        }

    }
}
