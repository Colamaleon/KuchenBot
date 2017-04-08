using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Discord;
using Discord.Commands;
using Discord.Commands.Permissions;

namespace DiscBot.Services
{
    abstract class CustomIDListService : IService
    {
        protected enum IDType { channel, user };
        protected IDType idType;

        protected enum ListType { blacklist, whitelist };
        protected ListType listType;

        private string typeSuffix { get { return (listType == ListType.blacklist) ? "bl" : "wl"; } }
        private string idSuffix { get { return idType.ToString(); } }

        protected string filennameSuffix { get { return idSuffix + typeSuffix + ".txt"; } }

        protected Dictionary<string, ulong[]> ChannelMap { get; private set; }


        protected CustomIDListService(IDType idType, ListType listType)
        {
            ChannelMap = new Dictionary<string, ulong[]>();
            this.idType = idType;
            this.listType = listType;
        }

        public void Install(DiscordClient client)
        {
            Console.WriteLine(string.Format("Installing new ListService... type :: {0} :: {1}", idSuffix, typeSuffix));
        }

        /// <summary>
        /// Access the IDList for this command. Load if it's not part of the Dictionary yet.
        /// </summary>
        /// <param name="command"></param>
        public ulong[] GetIDList(Command command)
        {
            var commandName = command.Text;
            var lFilename = commandName + filennameSuffix;

            ulong[] list;

            //check if this already has a list
            if (!ChannelMap.TryGetValue(commandName, out list))
            {
                //if not, try loading the list
                list = IOModule.LoadIDList(lFilename).ToArray();
                //add that to the list, even if it's empty
                ChannelMap.Add(commandName, list);
            }
            //if there is none, create it
            return list;
        }

        /// <summary>
        /// Reload the List
        /// </summary>
        /// <param name="command"></param>
        public void UpdateIDList(Command command)
        {
            var commandName = command.Text;
            var lFilename   = commandName + filennameSuffix;

            ulong[] list;

            //load up the Blacklist
            list = IOModule.LoadIDList(lFilename).ToArray();

            if (ChannelMap.Keys.Contains(commandName))
            {
                ChannelMap.Remove(commandName);
            }

            ChannelMap.Add(commandName, list);
        }

    }
}
