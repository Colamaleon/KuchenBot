using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Discord.Commands;
using Discord;

namespace KuchenBot.Commands.Attributes
{
    /// <summary>
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    class Restrict : Attribute
    {
        /// <summary>
        /// The message to be sent when the command use is invalid
        /// </summary>
        public string failMessage;
        /// <summary>
        /// Should the fail message be posted to channel, or to the user?
        /// </summary>
        public bool failMessagePM;

        public RestrictionType restriction;
        protected Func<ulong[]> getFunction;
        public ulong[] idsToCheck { get { return (getFunction != null) ? getFunction() : null; } }

        public Restrict(RestrictionType restriction, Func<ulong[]> getFunction, string failMessage = "", bool failMessagePM = false)
        {
            this.restriction    = restriction;
            this.getFunction    = getFunction;
            this.failMessage    = failMessage;
            this.failMessagePM  = failMessagePM;
        }

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

        public bool CheckValidUse(CommandEventArgs args)
        {
            bool inList = (idsToCheck.Contains<ulong>(args.User.Id));

            switch (restriction)
            {
                case RestrictionType.Include:
                    if (!inList)
                    { RunFailActions(args); }
                    return inList;
                case RestrictionType.Exclude:
                    if (!inList)
                    { RunFailActions(args); }
                    return !inList;
            }

            throw new NotImplementedException("Attribute does not check for this restriction type!");
        }
    }
}
