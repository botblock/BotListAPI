using Discord.WebSocket;
using System;
using System.ComponentModel;

namespace BotListAPI
{
    /// <summary> BotListAPI client to post server count </summary>
    public class ListClient
    {
        public readonly ListConfig Config = new ListConfig();
        /// <summary> Discord client can be normal or sharded </summary>
        public readonly BaseSocketClient Discord;
        private BackgroundWorker Worker = new BackgroundWorker();
        /// <summary> Log type for auto posting, </summary>
        public LogType LogType = LogType.Info;
        public ListClient(BaseSocketClient client, ListConfig config)
        {
            Discord = client;
            Config = config;
            Worker.DoWork += new DoWorkEventHandler(PostCount);
            DiscordBots = new ListAPI(this, ListType.DiscordBots);
            DiscordBotList = new ListAPI(this, ListType.DiscordBotList);
            DiscordBotListv2 = new ListAPI(this, ListType.DiscordBotListv2);
            BotsForDiscord = new ListAPI(this, ListType.BotsForDiscord);
            Carbonitex = new ListAPI(this, ListType.Carbonitex);
            BotListSpace = new ListAPI(this, ListType.BotListSpace);
            BotsOnDiscord = new ListAPI(this, ListType.BotsOnDiscord);
            DiscordBotWorld = new ListAPI(this, ListType.DiscordBotWorld);
            DiscordBotsGroup = new ListAPI(this, ListType.DiscordBotsGroup);
            DiscordListApp = new ListAPI(this, ListType.DiscordListApp);
            DiscordServices = new ListAPI(this, ListType.DiscordServices);
            DivineBotList = new ListAPI(this, ListType.DivineBotList);
        }

        /// <summary> Discord Bots | https://bots.discord.pw </summary>
        public ListAPI DiscordBots;

        /// <summary> Discord Bot List | https://discordbots.org </summary>
        public ListAPI DiscordBotList;

        /// <summary> Discord Bot List v2 | https://discordbotlist.com </summary>
        public ListAPI DiscordBotListv2;

        /// <summary> Bots For Discord | https://botsfordiscord.com </summary>
        public ListAPI BotsForDiscord;

        /// <summary> Carbonitex | https://carbonitex.net </summary>
        public ListAPI Carbonitex;

        /// <summary> Botlist Space | https://botlist.space </summary>
        public ListAPI BotListSpace;

        /// <summary> Bots On Discord | https://bots.ondiscord.xyz </summary>
        public ListAPI BotsOnDiscord;

        /// <summary> Discord Bot World | https://discordbot.world </summary>
        public ListAPI DiscordBotWorld;

        /// <summary> Discord Bots Group | https://discordbots.group </summary>
        public ListAPI DiscordBotsGroup;

        /// <summary> Discord List App | https://bots.discordlist.app </summary>
        public ListAPI DiscordListApp;

        /// <summary> Discord Services | https://discord.services </summary>
        public ListAPI DiscordServices;

        /// <summary> Divine Bot List | https://divinediscordbots.com </summary>
        public ListAPI DivineBotList;

        /// <summary> Start posting server count every 10 minutes </summary>
        public void Start()
        {
            if (!Worker.IsBusy)
            {
                Worker.RunWorkerAsync();
                Log(LogType.Info, "Enabled auto posting server count");
            }
        }

        /// <summary> Stop auto posting server count </summary>
        public void Stop()
        {
            if (Worker.IsBusy)
            {
                Worker.CancelAsync();
                Log(LogType.Info, "Disabled auto posting server count");
            }
        }

        /// <summary> Post server count to all bots list, dont use this too much or you will get ratelimited </summary>
        public void PostAll(LogType type)
        {
            if (Config.DiscordBots != "")
                DiscordBots.Post(type);

            if (Config.DiscordBotList != "")
                DiscordBotList.Post(type);

            if (Config.DiscordBotListv2 != "")
                DiscordBotListv2.Post(type);

            if (Config.BotsForDiscord != "")
                BotsForDiscord.Post(type);
            
            if (Config.Carbonitex != "")
                Carbonitex.Post(type);

            if (Config.BotListSpace != "")
                BotListSpace.Post(type);

            if (Config.BotsOnDiscord != "")
                BotsOnDiscord.Post(type);

            if (Config.DiscordBotWorld != "")
                DiscordBotWorld.Post(type);

            if (Config.DiscordBotsGroup != "")
                DiscordBotsGroup.Post(type);

            if (Config.DiscordListApp != "")
                DiscordListApp.Post(type);

            if (Config.DiscordServices != "")
                DiscordServices.Post(type);

            if (Config.DivineBotList != "")
                DivineBotList.Post(type);
        }

        private void PostCount(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                System.Threading.Thread.Sleep(new TimeSpan(0, 10, 0));
                if (DiscordBots.Enabled && Config.DiscordBots != "")
                    DiscordBots.Post(LogType);

                if (DiscordBotList.Enabled && Config.DiscordBotList != "")
                    DiscordBotList.Post(LogType);

                if (DiscordBotListv2.Enabled && Config.DiscordBotListv2 != "")
                    DiscordBotListv2.Post(LogType);

                if (BotsForDiscord.Enabled && Config.BotsForDiscord != "")
                    BotsForDiscord.Post(LogType);


                if (Carbonitex.Enabled && Config.Carbonitex != "")
                    Carbonitex.Post(LogType);

                if (BotListSpace.Enabled && Config.BotListSpace != "")
                    BotListSpace.Post(LogType);

                if (BotsOnDiscord.Enabled && Config.BotsOnDiscord != "")
                    BotsOnDiscord.Post(LogType);

                if (DiscordBotWorld.Enabled && Config.DiscordBotWorld != "")
                    DiscordBotWorld.Post(LogType);

                if (DiscordBotsGroup.Enabled && Config.DiscordBotsGroup != "")
                    DiscordBotsGroup.Post(LogType);

                if (DiscordListApp.Enabled && Config.DiscordListApp != "")
                    DiscordListApp.Post(LogType);

                if (DiscordServices.Enabled && Config.DiscordServices != "")
                    DiscordServices.Post(LogType);

                if (DivineBotList.Enabled && Config.DivineBotList != "")
                    DivineBotList.Post(LogType);
            }
        }

        private void Log(LogType type, string text)
        {
            if (LogType >= type)
                Console.WriteLine("[BotListAPI] " + text);
        }
    }
    public enum ListType
    {
        DiscordBots, DiscordBotList, DiscordBotListv2, BotsForDiscord, Carbonitex, BotListSpace, BotsOnDiscord, DiscordBotWorld, DiscordBotsGroup, DiscordListApp, DiscordServices, DivineBotList
    }
    public enum LogType
    {
        /// <summary>Dont log anything to console</summary>
        None,

        /// <summary>Log success/fail to console</summary>
        Info,

        /// <summary>Log everything including request responses in json to console</summary>
        Debug
    }
}
