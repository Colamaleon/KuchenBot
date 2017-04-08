using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Net;

namespace DiscBot.NonCommandActions
{
    /// <summary>
    /// Politely ask people to post mensa requests into the mensa channel.
    /// </summary>
    class MensaHandler
    {
        public static async void HandleMessage(MessageEventArgs args)
        {
            if (args.Message.RawText.ToLower().Contains("mensa") && !args.Channel.Name.ToLower().Contains("mensa"))
            {
                string message = string.Format(MessageStrings.MENSA_REQUEST, args.User.Nickname);
                try
                {
                    Channel pmChannel = await args.User.CreatePMChannel();
                    await pmChannel.SendMessage(message);
                }catch (HttpException he)
                {
                    Console.WriteLine(he.Message);
                }
            }
        }

    }
}
