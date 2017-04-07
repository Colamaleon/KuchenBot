using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace DiscBot
{
    class IOModule
    {
        private const string _errorPrefix = "__IOModule Error:: ";


        public static List<string> LoadTextResource(string filename)
        {
            var lines = new List<string>();

            try
            {
                using (StreamReader reader = new StreamReader("./Resources/" + filename))
                {
                    while (!reader.EndOfStream)
                    {
                        lines.Add(reader.ReadLine());
                    }
                }

                return lines;
            }
            catch (Exception e)
            {
                Console.WriteLine(_errorPrefix + " Could not load requested file " + filename);
                return null;    
            }
        }



    }
}
