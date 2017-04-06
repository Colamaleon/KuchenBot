using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Discord.Commands;
using Discord;

namespace KuchenBot.Commands
{
    /// <summary>
    /// The baseclass for all of GLaDOS' commands.
    /// </summary>
    class GLaDOSCommand
    {
        public enum PermissionRestrictions { Ignore, Allow, Exclude };

        #region Restrictions

        protected Func<string> passwordGetter;
        protected bool requirePassword { get { return passwordGetter != null; } }

        protected bool allowDM;
        protected PermissionRestrictions channelRestrictions; 
        protected List<ulong> channelList;                      // a list of channels. Whether the command includes or excludes these channels is determined by channelRestrictions.

        protected PermissionRestrictions roleRestrictions;
        protected List<ulong> roleList;

        protected PermissionRestrictions userRestrictions;
        protected List<ulong> userList;

        #endregion
        #region Notifications

        protected bool shouldNotifyOnWrongChannel;              //should the bot send a message if the user posted the command to the wrong chat
        protected bool respondViaPM;                            //should this notification be a pm or should it be posted directly to that channel

        protected string wrongChannelResponse = "You cannot use this command in this channel";

        #endregion

        /// <summary>
        /// Run checks for this command using the attributes above.
        /// </summary>
        /// <param name="args">the commandArgs being passed</param>
        /// <returns>Is this a valid use of this command?</returns>
        protected bool RunChecks(CommandEventArgs args)
        {

            //Did they post to the correct channel?
            switch (channelRestrictions)
            {
                case PermissionRestrictions.Allow:

                    break;

                case PermissionRestrictions.Exclude:

                    break;

                default:

                    break;
            }

            //Is this user explicitly allowed to run this command?
            switch (userRestrictions)
            {
                case PermissionRestrictions.Allow:

                    break;

                case PermissionRestrictions.Exclude:

                    break;

                default:

                    break;
            }

            //Do they have permission to run this command? 
            switch (roleRestrictions)
            {
                case PermissionRestrictions.Allow:

                    break;

                case PermissionRestrictions.Exclude:

                    break;

                default:

                    break;
            }


            throw new NotImplementedException();
        }

        ///TODO: Put something to edit the configuration here

        /// <summary>
        /// Create/Save a config file for this command. So, even if the Bot crashes things like permission setups won't be lost.
        /// </summary>
        public static void SaveConfig()
        {

        }

    }
}
