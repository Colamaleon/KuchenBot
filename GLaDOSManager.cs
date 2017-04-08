using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DiscBot.Actions;

namespace DiscBot
{
    class GLaDOSManager
    {
        GLaDOS gladosInstance;

        public GLaDOSManager(GLaDOS instance)
        {
            gladosInstance = instance;
        }

        public GLaDOS GetGlados()
        {
            // TODO check wether to allow access
            return gladosInstance;
        }
    }
}
