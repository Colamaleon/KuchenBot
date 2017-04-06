using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Discord.Commands;
using Discord;

namespace KuchenBot.Commands.CommandAttributes
{
    [AttributeUsage(AttributeTargets.Class)]
    abstract class Restrict : Attribute
    {
        /// <summary>
        /// The message to be sent when the command use is invalid
        /// </summary>
        public string failMessage;
        /// <summary>
        /// Should the fail message be posted to channel, or to the user?
        /// </summary>
        public bool failMessagePM;

        protected async void RunFailActions(CommandEventArgs args)
        {
            if (failMessage == null || failMessage == "") return; //Don't send empty messages

            if (failMessagePM)
            {
                await args.User.PrivateChannel.SendMessage(failMessage);
            }
            else
            {
                await args.Channel.SendMessage(failMessage);
            }
        }

        public abstract bool CheckValidUse(CommandEventArgs args);

    }
}
