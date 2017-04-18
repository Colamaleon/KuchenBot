using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Discord;
using Discord.Commands;

namespace DiscBot.ConfigServer
{
    class ConfigServerIO
    {
        private ConfigServerService service;

        public ConfigServerIO(ConfigServerService service)
        {
            this.service = service;
        }

        //channel IDs
        public Channel ConsoleChannel
        { get { return GetConfigChannel("console"); } }
        public Channel OutputChannel
        { get { return GetConfigChannel("output"); } }
        public Channel ConfigChannel
        { get { return GetConfigChannel("commandconfigs"); }}


        /// <summary>
        /// Print the message to the output channel
        /// </summary>
        public async Task PrintOutput(string message, string prefix = "")
        {
            await OutputChannel.SendMessage(prefix + message);
        }

        /// <summary>
        ///  Get the Channel object of the specified channel 
        /// </summary>
        private Channel GetConfigChannel(string channelname)
        {
            IEnumerable<Channel> channelmatches = service.client.GetServer(service.ConfigServerID).FindChannels(channelname, ChannelType.Text);
            foreach (Channel match in channelmatches)
            {
                Console.WriteLine(string.Format("GetChannelID :: {0} :: Found possible match {1} : {2}"));
                return match;
            }
            return null;
        }

    }
}
