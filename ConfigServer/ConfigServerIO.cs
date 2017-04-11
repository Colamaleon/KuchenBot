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

        public ulong OutputChannel
        {
            get { return 0; }
            private set { }
        }

        public async Task PrintMessage(Channel channel, string message, string customPrefix = "")
        {

        }

        private ulong GetOutputChannelID()
        {
            IEnumerable<Channel> channelmatches = service.client.GetServer(service.ConfigServerID).FindChannels("output", ChannelType.Text);

            throw new NotImplementedException();
        }

    }
}
