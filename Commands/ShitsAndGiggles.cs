using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Discord;
using Discord.Commands;

namespace KuchenBot.Commands
{
    /// <summary>
    /// Contains all the commands are just for Shits and Giggles. Can be used anywhere, and don't check for permissions
    /// </summary>
    class ShitsAndGiggles
    {
        public static void Init(CommandService service)
        {
            //Register the group. Once created, you can't add a command.

            //Register loose
            DoYouLoveMe.Register(service);
            Hello.Register(service);
            LetsBeFriends.Register(service);
        }

        #region CommandDefinitions

        public class DoYouLoveMe{

            public static void Register(CommandService service)
            {
                service.CreateCommand("doyouloveme")
                    .Alias(new string[] { "doyouloveme?" })
                    .Description("Answers the question you've been dying to ask.")
                    .Do(Run);
            }

            public static async Task Run(CommandEventArgs args)
            {
                await args.Channel.SendMessage("I am a robot, and therefore incapable of experiencing emotions such as love.\nI am sorry to disappoint you.");
            }
        }

        public class Hello
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

        public class LetsBeFriends
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

        #endregion

    }
}
