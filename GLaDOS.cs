using Discord;
using Discord.Commands;

using System;

namespace KuchenBot
{
	public class GLaDOS
	{
        #region Attributes

        DiscordClient discord;

        #endregion
        #region init

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
				x.PrefixChar 			= '!';
				x.AllowMentionPrefix 	= false;
			});

            CreateCommands();

            // Check for local token
            if (!TokenExists)
            {
                RegisterLocalToken();
            }

            // Login
            Login();
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

        private static string AppDataPath
        { get { return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\GLaDOS"; } }
        private static string TokenPath
        { get { return AppDataPath + "\\localtoken.txt"; } }
        private static bool TokenExists
        { get { return System.IO.File.Exists(TokenPath); } }
        protected void CommandListener()
        {
            bool runCommands = true;
            while (runCommands)
            {
                string command = Console.ReadLine();
                if (command == "exit")
                {
                    discord.Disconnect();
                    runCommands = false;
                    continue;
                }
                if (command.StartsWith("registertoken "))
                {
                    string token = command.Replace("registertoken ", "");
                    SetLocalToken(token);

                    discord.Disconnect();
                    Console.WriteLine("");
                    Login();

                    continue;
                }

                Console.WriteLine("No such command");
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

        private void Log(object sender, LogMessageEventArgs args)
		{
			Console.WriteLine(args.Message);
		}

        #endregion
        #region createCommands

        private void CreateCommands()
        {
            var commands = discord.GetService<CommandService>();

            //Register new Commands here

            #region BaseCommands

            commands.CreateCommand("hello")
                .Do(async (e) =>
                {
                    await e.Channel.SendMessage("Welcome," + e.User.NicknameMention + ",\nMy name is GLaDOS, the \n\n**G**ames \n**L**ab \n**a**nd \n**D**eveloper \n**O**perating \n**S**ystem. \n\nNice to meet you.");
                });

            commands.CreateCommand("doyouloveme?")
                .Do(async (e) =>
                {
                    await e.Channel.SendMessage("I am a robot, and therefore unable to experience emotions such as love.\nI am sorry to disappoint you.");
                });

            commands.CreateCommand("status")
                .Do(async (e) =>
                {
                    await e.Channel.SendMessage("alive");
                });

            commands.CreateCommand("wipeAll")
                .Do(async (e) =>
                {
                    Console.WriteLine("Deleting Messages...");
                    Message[] messages = await e.Channel.DownloadMessages();

                    while(messages.Length > 0)
                    {
                        messages = await e.Channel.DownloadMessages();
                        await e.Channel.DeleteMessages(messages);
                    }
                    Console.WriteLine("Deletion Complete...");

                    await e.Channel.SendMessage("Wiped Logs... scrub.");
                });

            #endregion
            #region KuchenCommands

            commands.CreateCommand("kuchen")
                .Do(async (e) =>
                {
                    await e.Channel.SendMessage("alive");
                });

            #endregion

        }

        #endregion

    }
}
