using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Discord;
using Discord.Commands;

namespace DiscBot.Services
{
    /// <summary>
    /// The service for communicating with the config server.
    /// </summary>
    class ConfigServerService : IService
    {
        public DiscordClient client { get; private set; }
        public ulong ConfigServerID { get; private set; }

        public void Install(DiscordClient client)
        {
            this.client = client;
        }

        /// <summary>
        ///  As soon as the client is ready, try looking up the id of the config server
        /// </summary>
        private void FindConfigServer(object sender, EventArgs args)
        {
            IEnumerable<Server> matches = client.FindServers(">GLaDOS");
            if ( matches.Count() > 0 && matches.First() != null)
            {
                Server ser = client.FindServers(">GLaDOS").First();
                Console.WriteLine("Found possible config server match... " + ser.Id);
                this.ConfigServerID = ser.Id;
            }else
            {
                Console.WriteLine("Could not connect to config server! Please check if the server is available.");
            }
        }

    }
}
