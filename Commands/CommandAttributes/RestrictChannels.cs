using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Discord.Commands;
using Discord;

namespace KuchenBot.Commands.CommandAttributes
{
    class RestrictChannels : Restrict
    {
        public RestrictionType restriction;
        private Func<ulong[]> getChannelFunction;
        public ulong[] channels { get { return (getChannelFunction != null) ? getChannelFunction() : null; } }

        public RestrictChannels(RestrictionType rtype, Func<ulong[]> getChannelFunction)
        {
            this.getChannelFunction = getChannelFunction;
            this.restriction = rtype;
        }

        public override bool CheckValidUse(CommandEventArgs args)
        {
            bool inChannelList = (channels.Contains<ulong>(args.Channel.Id));

            switch (restriction)
            {
                case RestrictionType.Include:
                    if (!inChannelList)
                    { RunFailActions(args); }
                    return inChannelList;
                case RestrictionType.Exclude:
                    if (!inChannelList)
                    { RunFailActions(args); }
                    return !inChannelList;
            }

            throw new NotImplementedException("Attribute does not check for this restriction type!");
        }

    }
}
