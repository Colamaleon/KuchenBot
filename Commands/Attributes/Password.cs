using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Discord.Commands;
using Discord;

namespace KuchenBot.Commands.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    class Password : Attribute
    {
        private Func<CommandEventArgs, string, bool> passfunction;
        private string pass;

        public Password(string staticPass)
        {
            pass = staticPass;
        }

        public Password(Func<CommandEventArgs, string, bool> passfunction, string pass = "")
        {
            this.passfunction = passfunction;
        }

        public bool CheckPass(CommandEventArgs args)
        {
            if(passfunction != null)
            {
                //Run the pass function if it's set
                return passfunction(args, pass);
            }
            else
            {
                //check if the user passed the correct pass.
                string givenpass = "";
                if (args.GetArg("password") != null)
                {
                    givenpass = args.GetArg("password");
                }

                return pass.Equals(givenpass);
            }
        }

    }
}
