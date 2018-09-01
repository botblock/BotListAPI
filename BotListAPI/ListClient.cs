using Discord.WebSocket;
using System;
using System.ComponentModel;

namespace BotListAPI
{
    public class ListClient
    {
        public readonly ListConfig Config = new ListConfig();
        public readonly BaseSocketClient Discord;
        private BackgroundWorker Worker = new BackgroundWorker();
        private bool WorkerEnabled = false;
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

        public ListAPI DiscordBots;

        public ListAPI DiscordBotList;

        public ListAPI DiscordBotListv2;

        public ListAPI BotsForDiscord;

        public ListAPI Carbonitex;

        public ListAPI BotListSpace;

        public ListAPI BotsOnDiscord;

        public ListAPI DiscordBotWorld;

        public ListAPI DiscordBotsGroup;

        public ListAPI DiscordListApp;

        public ListAPI DiscordServices;

        public ListAPI DivineBotList;

        /// <summary>
        /// Start posting server count every 5 minutes
        /// </summary>
        public void Start()
        {
            if (!WorkerEnabled)
            {
                WorkerEnabled = true;
                Worker.RunWorkerAsync();
                Log(LogType.Debug, "Enabled auto posting");
            }
        }

        /// <summary>
        /// Stop posting server count
        /// </summary>
        public void Stop()
        {
            
            if (WorkerEnabled)
            {
                WorkerEnabled = false;
                Worker.CancelAsync();
                Log(LogType.Debug, "Disabled auto posting");
            }
        }

        private void PostCount(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                System.Threading.Thread.Sleep(new TimeSpan(0, 5, 0));
                if (DiscordBots.Enabled && Config.DiscordBots != "")
                    DiscordBots.Post(LogType);

                if (DiscordBotList.Enabled && Config.DiscordBotList != "")
                    DiscordBotList.Post(LogType);

                if (DiscordBotListv2.Enabled && Config.DiscordBotListv2 != "")
                    DiscordBotListv2.Post(LogType);

                if (BotsForDiscord.Enabled && Config.BotsForDiscord != "")
                    BotsForDiscord.Post(LogType);


                //if (Carbonitex.Enabled && Config.Carbonitex != "")
                //    Carbonitex.Post(LogType);

                if (BotListSpace.Enabled && Config.BotListSpace != "")
                    BotListSpace.Post(LogType);

                if (BotsOnDiscord.Enabled && Config.BotsOnDiscord != "")
                    BotsOnDiscord.Post(LogType);

                if (DiscordBotWorld.Enabled && Config.DiscordBotWorld != "")
                    DiscordBotWorld.Post(LogType);

                //if (DiscordBotsGroup.Enabled && Config.DiscordBotsGroup != "")
                //    DiscordBotsGroup.Post(Debug);

                if (DiscordListApp.Enabled && Config.DiscordListApp != "")
                    DiscordListApp.Post(LogType);

                if (DiscordServices.Enabled && Config.DiscordServices != "")
                    DiscordServices.Post(LogType);

                if (DivineBotList.Enabled && Config.DivineBotList != "")
                    DivineBotList.Post(LogType);
            }
        }

        public void Log(LogType type, string text)
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
