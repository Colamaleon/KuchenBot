using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

using Discord.Commands.Permissions.Userlist;

namespace DiscBot
{
    /// <summary>
    /// Utility for Loading and storing files
    /// </summary>
    class IOModule
    {
        private const string _errorPrefix = "__IOModule Error:: ";

        public static string AppDataPath
        { get { return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\GLaDOS"; } }

        public static string TokenPath
        { get { return AppDataPath + "\\localtoken.txt"; } }
        public static bool TokenExists
        { get { return File.Exists(TokenPath); } }


        public static string IDListsPath
        { get { return AppDataPath + "\\ID\\IDLists"; } }
        public static bool IDListsFolderExists
        { get { return Directory.Exists(IDListsPath); } }


        public static List<string> LoadTextResource(string filename)
        {
            var lines = new List<string>();

            try
            {
                using (StreamReader reader = new StreamReader("./Resources/" + filename))
                {
                    while (!reader.EndOfStream)
                    {
                        lines.Add(reader.ReadLine());
                    }
                }

                return lines;
            }
            catch (Exception e)
            {
                Console.WriteLine(_errorPrefix + " Could not load requested file " + filename);
                return null;    
            }
        }

        #region Token

        /// <summary>
        /// Load up the file containing this Bots login token.
        /// </summary>
        /// <returns>The token, or "" if the file could not be found.</returns>
        public static string GetLocalToken()
        {
            try
            {
                return System.IO.File.ReadAllText(TokenPath);
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        /// <summary>
        /// Register a login token
        /// </summary>
        /// <returns>true if the operation was successful</returns>
        public static bool SetLocalToken(string token)
        {
            try
            {
                if (!System.IO.Directory.Exists(AppDataPath))
                {
                    System.IO.Directory.CreateDirectory(AppDataPath);
                }
                System.IO.StreamWriter file = new System.IO.StreamWriter(TokenPath);
                file.WriteLine(token);
                file.Close();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #endregion

        #region Userlist

        /// <summary>
        /// Add an Id (a user or channel ID) to the idList, if it's not on there already
        /// </summary>
        /// <returns>whether or not the operation could be completed</returns>
        public static bool AddIDToList(ulong id, string filename)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Remove an Id (a user or channel ID) from the idList, if the id is on that List
        /// </summary>
        /// <returns>whether or not the operation could be completed</returns>
        public static void RemoveIDFromList(ulong id, string filename)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Load the specified ID list
        /// </summary>
        public static List<ulong> LoadIDList(string filename)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Store the specified ID list
        /// </summary>
        public static List<ulong> StoreIDList(string filename, WhitelistService service)
        {
            if (File.Exists(filename))
            {

            }

            throw new NotImplementedException();
        }

        /// <summary>
        /// Store the specified ID list
        /// </summary>
        public static List<ulong> StoreIDList(string filename, BlacklistService service)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
