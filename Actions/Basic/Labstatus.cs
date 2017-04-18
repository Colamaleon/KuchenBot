using System;
using System.Threading.Tasks;
using Discord.Commands;
using System.IO;
using System.Net;

using System.Drawing;

namespace DiscBot.Actions.Basic
{
    class Labstatus
    {
        public static string imageURL = "http://131.234.141.232/gameslab_status.jpg";

        public static void Register(CommandService service)
        {
            service.CreateCommand("labstatus")
                .Alias(new string[] { "status", "lab" })
                .Description("Displays the current status of the lab.")
                .Do(Run);
        }

        public static async Task Run(CommandEventArgs args)
        {
            Console.WriteLine("loading command...");
            string output = "";
            Color labcolor = LoadLabStatus();

            if(Color.Equals(labcolor, Color.Red))
            {
                output = "Das Lab ist geschlossen";
            }
            else if(Color.Equals(labcolor, Color.Green))
            {
                output = "Das Lab ist offen";
            }
            else
            {
                output = "Keine Ahnung";
            }


            Console.Write(output);
            await args.Channel.SendMessage(output);
        }


        /// <summary>
        /// TODO: Clean implementation. Or not, since it works, I guess.
        /// Loads up the wiki image showing the lab's status and checks whether green or red is the predominant color. 
        /// </summary>
        private static Color LoadLabStatus()
        {
            try
            {
                var stream = new MemoryStream(new WebClient().DownloadData(imageURL));
                //find the colorpalette
                var img = new Bitmap(stream);
                Color[] line = new Color[img.Width];

                for(int i = 0; i < img.Width/2; i++)
                {
                    line[i] = img.GetPixel(i, 15);
                }

                int reds = 0;
                int greens = 0;

                foreach(Color col in line)
                {
                    if(col.R > col.G + 20)
                    {
                        reds++;
                    }else if (col.G > col.R + 20)
                    {
                        greens++;
                    }
                }

                //evalute whether the image is green or not
                if(reds > greens + 10)
                {
                    return Color.Red;
                }else if(greens > reds + 10)
                {
                    return Color.Green;
                }else
                {
                    return Color.Black;
                }

            }catch (Exception e)
            {
                Console.WriteLine("error ::" + e.Message);
            }

            return Color.Black;
        }

    }
}
