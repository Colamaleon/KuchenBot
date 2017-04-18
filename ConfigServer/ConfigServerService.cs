using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Discord;
using Discord.Commands;

namespace DiscBot.ConfigServer
{
    /// <summary>
    /// The service for communicating with the config server.
    /// </summary>
    class ConfigServerService : IService
    {
        public DiscordClient client { get; private set; }
        public ulong ConfigServerID { get; private set; }

        public ConfigServerIO IOModule { get; private set; }

        public void Install(DiscordClient client)
        {
            this.client = client;
            IOModule = new ConfigServerIO(this);
        }

        /// <summary>
        ///  Try looking up the config server
        /// </summary>
        private Server FindConfigServer()
        {
            if(client.FindServers(">GLaDOS").First() != null)
            {
                Server ser = client.FindServers(">GLaDOS").First();
                Console.WriteLine("Found possible config server match... " + ser.Id);
                return ser;
            }else
            {
                throw new Exception("ConfigServerService :: Config server not found!");
            }

        }

    }
}
