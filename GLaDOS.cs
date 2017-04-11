using Discord;
using Discord.Commands;

using System;
using System.Threading.Tasks;

using DiscBot.UI;
using System.Collections.Generic;

namespace DiscBot
{
    public class GLaDOS
    {



        #region Attributes
        
        DiscordClient discord;
        GLaDOSManager manager;

        #endregion

        #region Init

        public async Task Test(CommandEventArgs args)
        {

        }

        public GLaDOS()
        {
            // Bind manager
            manager = new GLaDOSManager(this);

            // Init discord
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
                x.HelpMode = HelpMode.Public;
            });

            // Welcome
            Welcome();

            // Check for local token
            if (!IOModule.TokenExists)
            {
                RegisterLocalToken();
            }

            //DEBUG: Add ChannelBlacklistService
            discord.AddService<Services.ChannelBlackListService>();
            discord.AddService<Services.ChannelWhiteListService>();

            // Register all commands
            RegisterCommands();

            //Add the message logger
            discord.MessageReceived += OnMessage;

            // Login
            Connect();
        }

        private void Welcome()
        {
            Console.WriteLine(AsciiArt.GetHeader());
            Console.WriteLine(AsciiArt.PadForConsole(UI.AsciiArt.GetCake()));
            Console.WriteLine(AsciiArt.GetGlados());
            Console.WriteLine(AsciiArt.GetCloser());
            Console.WriteLine();
        }

        protected void RegisterLocalToken()
        {
            Console.WriteLine("Please enter the bot token");
            string token = Console.ReadLine();
            IOModule.SetLocalToken(token);
            Console.WriteLine("");

            Connect();
        }

        #endregion

        #region Commands

        protected void RegisterCommands()
        {
            CommandService cs = discord.GetService<CommandService>();

            Actions.Basic.Hello.Register(cs);
            Actions.Basic.DebugMC.Register(cs);

            //new DiscBot.Actions.CommandLine.RegisterToken().Register(discord.GetService<CommandService>(), manager);
            Actions.ShitsAndGiggles.Sing.Register(cs);
            Actions.ShitsAndGiggles.Cake.Register(cs);
            Actions.ShitsAndGiggles.OhNo.Register(cs);

            Actions.Terminal.GetToken.Register(cs, manager);
            Actions.Terminal.SetToken.Register(cs, manager);

            Actions.Basic.GeneratePass.Register(cs);
        }

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
                    IOModule.SetLocalToken(token);

                    Disconnect();
                    Console.WriteLine("");
                    Connect();

                    continue;
                }
                Console.WriteLine("No such command");
            }
        }

        #endregion

        protected void Connect()
        {
            try
            {
                discord.ExecuteAndWait(async () =>
                {
                    await discord.Connect(IOModule.GetLocalToken(), TokenType.Bot);

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

        public async void Reconnect()
        {
            await discord.Disconnect();
            Connect();
        }

        public async void Disconnect()
        {
            await discord.Disconnect();
        }

        

        private void Log(object sender, LogMessageEventArgs args)
        {
            Console.WriteLine(args.Message);
        }


        #region EventHandler

        private void OnMessage(object sender, MessageEventArgs args)
        {
            //TODO: Log commands for crash tracking
            NonCommandActions.MensaHandler.HandleMessage(args);

            Console.WriteLine(args.Message.RawText);
        }

        #endregion

    }
}
