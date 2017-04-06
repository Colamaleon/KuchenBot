using System;
using System.Runtime.InteropServices;

namespace KuchenBot
{
	class MainClass
	{
        private static GLaDOS glados;

		public static void Main(string[] args)
        {
            Console.WriteLine("Booting GLaDOS...");
			glados = new GLaDOS();
		}
    }
}

