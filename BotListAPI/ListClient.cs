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
        public bool Debug = false;
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
            WorkerEnabled = true;
            if (!WorkerEnabled)
                Worker.RunWorkerAsync();
        }

        /// <summary>
        /// Stop posting server count
        /// </summary>
        public void Stop()
        {
            WorkerEnabled = false;
            if (WorkerEnabled)
                Worker.CancelAsync();
        }

        private void PostCount(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                System.Threading.Thread.Sleep(new TimeSpan(0, 5, 0));
                if (DiscordBots.Enabled && Config.DiscordBots != "")
                    DiscordBots.Post(Debug);

                if (DiscordBotList.Enabled && Config.DiscordBotList != "")
                    DiscordBotList.Post(Debug);

                if (DiscordBotListv2.Enabled && Config.DiscordBotListv2 != "")
                    DiscordBotListv2.Post(Debug);

                if (BotsForDiscord.Enabled && Config.BotsForDiscord != "")
                    BotsForDiscord.Post(Debug);


                //if (Carbonitex.Enabled && Config.Carbonitex != "")
                //    Carbonitex.Post(Debug);

                if (BotListSpace.Enabled && Config.BotListSpace != "")
                    BotListSpace.Post(Debug);

                if (BotsOnDiscord.Enabled && Config.BotsOnDiscord != "")
                    BotsOnDiscord.Post(Debug);

                if (DiscordBotWorld.Enabled && Config.DiscordBotWorld != "")
                    DiscordBotWorld.Post(Debug);

                //if (DiscordBotsGroup.Enabled && Config.DiscordBotsGroup != "")
                //    DiscordBotsGroup.Post(Debug);

                if (DiscordListApp.Enabled && Config.DiscordListApp != "")
                    DiscordListApp.Post(Debug);

                if (DiscordServices.Enabled && Config.DiscordServices != "")
                    DiscordServices.Post(Debug);

                if (DivineBotList.Enabled && Config.DivineBotList != "")
                    DivineBotList.Post(Debug);
            }
        }

        public void Log(string text)
        {
            Console.WriteLine("[BotListAPI] " + text);
        }
    }
    public enum ListType
    {
        DiscordBots, DiscordBotList, DiscordBotListv2, BotsForDiscord, Carbonitex, BotListSpace, BotsOnDiscord, DiscordBotWorld, DiscordBotsGroup, DiscordListApp, DiscordServices, DivineBotList
    }
}
