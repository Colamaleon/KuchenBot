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

            //Login
            discord.ExecuteAndWait(async () => 
			{
				await discord.Connect("Mjk4OTE5ODgyMDIyNTg0MzIx.C8bOxw.lRppHNesnRCqwOS0vTMVm187jEo", TokenType.Bot);
                Console.WriteLine("-------- DONE --------");
            });

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
