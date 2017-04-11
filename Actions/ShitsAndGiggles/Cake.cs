using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Discord;
using Discord.Commands;

namespace DiscBot.Actions.ShitsAndGiggles
{
    class Cake
    {
        public static void Register(CommandService service)
        {
            service.CreateCommand("cake")
                .Description("Sends you a lie")
                .Do(Run);
        }

        public static async Task Run(CommandEventArgs args)
        {
            bool truth = System.DateTime.Now.Month == 4 && System.DateTime.Now.Day == 1;

            string[] lies = new string[]
            {
                String.Format("{0} equals 42", truth ? "6 * 7" : "4 * 9"),
                String.Format("{0} is the largest state in the United States by area.", truth ? "Alaska" : "Texas"),
                String.Format("The farmer in Grant Woods classic painting was modelled after {0}.", truth ? "his dentist" : "his butcher"),
                String.Format("Nephelococcygia is the practice of {0}.", truth ? "finding shapes in clouds" : "breaking glass with your voice"),
                String.Format("The term \"computer bug\" was inspired by a {0} that died within an early supercomputer." , truth ? "moth" : "roach"),
                String.Format("{0} once appeard on the television series \"Lauch-In\".", truth ? "Richard Nixon" : "Jimmy Carter"),
                String.Format("Paddington Bear, in the children's book series, is originally from {0}", truth ? "Peru" : "Iceland"),
                String.Format("The U.S. icon \"Uncle Sam\" was based on Samuel Wilsons, who worked during the War of 1812 as a {0}", truth ? "Meat inspector" : "mail deliverer"),
                String.Format("In greek mythology, the creature known as minotaur resembles a {0}.", truth ? "bull" : "deer"),
                String.Format("The programming of this bot took {0}.", truth ? "over a week" : "just 2 days"),
            };
            
            await args.Channel.SendTTSMessage(lies[new Random().Next(lies.Length)]);
        }

    }
}
