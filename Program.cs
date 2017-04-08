using System;
using System.Runtime.InteropServices;

namespace DiscBot
{
	class MainClass
	{
        private static GLaDOS glados;

		public static void Main(string[] args)
        {
            Console.WindowHeight = 55;
            Console.Title = "GLaDOS";

            glados = new GLaDOS();
		}
    }
}

