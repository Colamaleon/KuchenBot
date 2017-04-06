using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuchenBot.Commands.DefaultCommandProperties
{
    public class GLaDOSCommandProperties
    {
        #region Properties

        public enum PermissionRestrictions { Ignore, Allow, Exclude };

        #region Restrictions

        public Func<string> passwordGetter;
        public bool requirePassword { get { return passwordGetter != null; } }

        public bool allowDM;
        public PermissionRestrictions channelRestrictions;
        public List<ulong> channelList;                      // a list of channels. Whether the command includes or excludes these channels is determined by channelRestrictions.

        public PermissionRestrictions roleRestrictions;
        public List<ulong> roleList;

        public PermissionRestrictions userRestrictions;
        public List<ulong> userList;

        #endregion
        #region Notifications

        public bool shouldNotifyOnWrongChannel;              //should the bot send a message if the user posted the command to the wrong chat
        public bool respondViaPM;                            //should this notification be a pm or should it be posted directly to that channel

        #endregion
        #region Messages

        public string wrongChannelResponse = "You cannot use this command in this channel";

        #endregion

        #endregion

        #region AccessLists

        public List<ulong> GetChannelList()
        {
            return channelList;
        }

        public List<ulong> GetUserList()
        {
            return userList;
        }

        public List<ulong> GetRoleList()
        {
            return roleList;
        }

        #endregion


        public GLaDOSCommandProperties()
        {
            passwordGetter = null;
            allowDM = true;

            channelRestrictions = PermissionRestrictions.Ignore;
            roleRestrictions = PermissionRestrictions.Ignore;
            userRestrictions = PermissionRestrictions.Ignore;

            shouldNotifyOnWrongChannel = false;
            respondViaPM = false;
        }

    }
}
