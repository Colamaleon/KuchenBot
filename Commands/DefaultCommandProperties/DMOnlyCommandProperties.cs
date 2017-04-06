using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuchenBot.Commands.DefaultCommandProperties
{
    class DMOnlyCommandProperties : GLaDOSCommandProperties
    {
        public DMOnlyCommandProperties()
        {
            passwordGetter = null;
            allowDM = true;

            channelRestrictions = PermissionRestrictions.Allow;
            roleRestrictions    = PermissionRestrictions.Ignore;
            userRestrictions    = PermissionRestrictions.Ignore;

            shouldNotifyOnWrongChannel = false;
            respondViaPM = false;
        }
    }
}
