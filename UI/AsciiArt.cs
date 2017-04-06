using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscBot.UI
{
    public class AsciiArt
    {
        public static string GetHeader()
        {
            return @"--------------------------------- Now Booting ---------------------------------
-------------------------------------------------------------------------------";
        }

        public static string GetCloser()
        {
            string version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            return "-------------------------------------------------------------------------------\n" +
string.Format(@"---------------------------------------------------------------------- V. {0} ----", version).Remove(0, version.Length);
        }

        public static string GetCake()
        {
            return
@"            ,:/+/-
            / M /              .,-=;//;-
       .:/= ; MH /,    ,=/ +%$XH @MM#@:
      -$##@+$###@H@MMM#######H:.    -/H#
 .,H @H@ X######@ -H#####@+-     -+H###@X
  .,@##H;      +XM##M/,     =%@###@X;-
X % -  :M##########$.    .:%M###@%:
M##H,   +H@@@$/-.  ,;$M###@%,          -
M####M=,,---,.-%%H####M$:          ,+@##
@##################@/.         :%H##@$-
M###############H,         ;HM##M$=
#################.    .=$M##M$=
################H..;XM##M$=          .:+
M###################@%=           =+@MH%
@#################M/.         =+H#X%=
= +M###############M,      ,/X#H+:,
  .; XM###########H=   ,/X#H+:;
     .= +HM#######M+/+HM@+=.
         ,:/% XM####H/.
              ,.:= -.";
        }

        public static string GetGlados()
        {
            return @"    #########  ###                         #########    ##########    #########
  ###########  ###                         ##########   ##########   #########
 ###      ###  ###             ###### ###  ##     ####  ##    # ##  ###
###            ###           ###########   ##      ###  ##   #  ##   ###
###  ########  ###          ###     ###    ##      ###  ##  #   ##    #######
###  ##   ###  ###         ###     ###     ##      ###  ## #    ##         ###
###      ####  ###         ###     ###     ##     ####  ###     ##          ###
 ###########   ##########  ###########     ##########   ##########   #########
  #########    ##########    ###### ###    #########    ##########  #########";
        }

        public static string PadForConsole(string source, int charsPerLine = 80)
        {
            string[] lines = source.Split('\n');
            int longestLineLength = 0;

            for (int i = 0; i < lines.Length; i++)
            {
                lines[i].TrimEnd(); //ignore trailing whitespace
                longestLineLength = Math.Max(longestLineLength, lines[i].Length); // find the longest line
            }

            int leftwhitespace = (int)Math.Floor((double)((charsPerLine - longestLineLength) / 2D));
            if (leftwhitespace < 0)
            {
                //art is too long.
                return source;
            }
            else
            {
                string result = "";

                for (int a = 0; a < lines.Length; a++)
                {
                    for (int b = 0; b < leftwhitespace; b++)
                    {
                        lines[a] = " " + lines[a];
                    }
                    result += lines[a] + '\n';
                }

                return result.TrimEnd('\n');
            }
        }
    }
}
