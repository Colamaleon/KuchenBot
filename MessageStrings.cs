using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscBot
{
    public static class MessageStrings
    {
        #region CommandSpecific

        public const string PASS = "Hey {0},\nHier ist das Passwort, nach dem du gefragt hat.\n{1}\n Beachte, dass es sich jeden Tag ändert und nur du selbst es benutzen kannst.";

        public const string HELLO = "Welcome {0},\nMy name is GLaDOS, the \n\n**G**ames \n**L**ab \n**a**nd \n**D**eveloper \n**O**perating \n**S**ystem. \n\nNice to meet you.";

        public const string DOYOULOVEME = "I am a robot, and therefore incapable of experiencing emotions such as love.\nI am sorry to disappoint you.";

        #endregion

        public const string MENSA_REQUEST = "Hey {0},\nBitte poste Mensaanfragen lieber in den #mensa channel.\nDanke!";

        #region Errors

        public const string PERMISSION_FAIL = "You are not allowed to run this command. Reason :: {0}";

        public const string DM_FAIL = "This command can only be run via a direct message!";

        #endregion

    }
}
