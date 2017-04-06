using System;
using System.Runtime.InteropServices;

namespace DiscBot
{
	class MainClass
	{
        private static GLaDOS glados;

		public static void Main(string[] args)
        {
            Console.WriteLine(UI.AsciiArt.GetHeader());
            Console.WriteLine(UI.AsciiArt.PadForConsole(UI.AsciiArt.GetCake()));
            Console.WriteLine(UI.AsciiArt.GetGLaDOS2());
            Console.WriteLine(UI.AsciiArt.GetCloser());
            //glados = new GLaDOS();
            Console.ReadKey();
		}
    }
}

