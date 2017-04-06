using Discord;
using Discord.Commands;

using System;

using DiscBot.UI;

namespace DiscBot
{
    public class GLaDOS
    {
        #region Attributes

        private static string AppDataPath
        { get { return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\GLaDOS"; } }
        private static string TokenPath
        { get { return AppDataPath + "\\localtoken.txt"; } }
        private static bool TokenExists
        { get { return System.IO.File.Exists(TokenPath); } }

        DiscordClient discord;
        
        #endregion

        #region Init

        public GLaDOS()
        {
            discord = new DiscordClient((obj) =>
            {
                obj.LogLevel = LogSeverity.Info;
                obj.LogHandler = Log;
            });

            //Set up commands
            discord.UsingCommands(x =>
            {
                x.PrefixChar = '!';
                x.AllowMentionPrefix = false;
            });

            // Welcome
            Welcome();
            
            // Check for local token
            if (!TokenExists)
            {
                RegisterLocalToken();
            }

            // Register Commands
            var comService = discord.GetService<CommandService>();
            Commands.Basic.WipeAll.Register(comService);

            // Login
            Login();

        }

        private void Welcome()
        {
            Console.WriteLine(AsciiArt.GetHeader());
            Console.WriteLine(AsciiArt.PadForConsole(UI.AsciiArt.GetCake()));
            Console.WriteLine(AsciiArt.GetGlados());
            Console.WriteLine(AsciiArt.GetCloser());
            Console.WriteLine();
        }

        protected void Login()
        {
            try
            {
                discord.ExecuteAndWait(async () =>
                {
                    await discord.Connect(GetLocalToken(), TokenType.Bot);

                    // Start command listener
                    CommandListener();
                });
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("GLaDOS could not be started. ");
                Console.WriteLine(ex.Message);
                Console.WriteLine("");

                // Register new local token
                RegisterLocalToken();
            }
        }

        protected string GetLocalToken()
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

        protected bool SetLocalToken(string token)
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

        protected void RegisterLocalToken()
        {
            Console.WriteLine("Please enter the bot token");
            string token = Console.ReadLine();
            SetLocalToken(token);
            Console.WriteLine("");

            Login();
        }

        #endregion

        #region CommandLine

        protected void CommandListener()
        {
            bool runCommands = true;
            while (runCommands)
            {
                string command = Console.ReadLine();
                if (command == "exit")
                {
                    Disconnect();
                    runCommands = false;
                    continue;
                }
                if (command.StartsWith("registertoken "))
                {
                    string token = command.Replace("registertoken ", "");
                    SetLocalToken(token);

                    Disconnect();
                    Console.WriteLine("");
                    Login();

                    continue;
                }

                Console.WriteLine("No such command");
            }
        }

        #endregion

        public async void Disconnect()
        {
            await discord.Disconnect();
        }

        private void Log(object sender, LogMessageEventArgs args)
        {
            Console.WriteLine(args.Message);
        }

    }
}
