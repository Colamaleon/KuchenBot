using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Discord.Commands;
using Discord;

namespace DiscBot.Commands
{
    /// <summary>
    /// The baseclass for all of GLaDOS' commands.
    /// </summary>
    public class GLaDOSCommand
    {
        //protected GLaDOSCommandProperties properties;

        #region Init

        /// <summary>
        /// Init this command using a dafault config. This default command can be run anywhere, by everyone and doesn't notify the user.
        /// </summary>
        protected GLaDOSCommand()
        {
            //properties = new GLaDOSCommandProperties();
        }

        #endregion

        #region Checks

        /// <summary>
        /// Run checks for this command using the attributes above.
        /// </summary>
        /// <param name="args">the commandArgs being passed</param>
        /// <returns>Is this a valid use of this command?</returns>
        protected bool RunChecks(CommandEventArgs args)
        {
            //Did they post to the correct channel?
            CheckChannel(args);

            //Is this user explicitly allowed to run this command?
            CheckUser(args);

            //Do they have permission to run this command? 
            CheckRole(args);

            throw new NotImplementedException();
        }

        /// <summary>
        /// Run actions to be taken after the command was executed.
        /// </summary>
        /// <param name="args">the commandArgs being passed</param>
        protected void RunPostActions(CommandEventArgs args)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Checks if the command was used in the correct channel
        /// </summary>
        /// <returns>Is this the correct channel?</returns>
        private bool CheckChannel(CommandEventArgs args)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Checks if the command was used by a permissioned user via id
        /// </summary>
        /// <returns>Is this user allowed to run this command?</returns>
        private bool CheckUser(CommandEventArgs args)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Checks if the command was used by a permissioned user via roles
        /// </summary>
        /// <returns>Is this role allowed to run this command?</returns>
        private bool CheckRole(CommandEventArgs args)
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
