using Discord.WebSocket;
using System;
using System.ComponentModel;

namespace BotListAPI
{
    public class ListClient
    {
        private readonly TokenConfig Config;
        private readonly BaseSocketClient Client;
        private BackgroundWorker Worker = new BackgroundWorker();
        private bool WorkerEnabled = false;
        public ListClient(BaseSocketClient client, TokenConfig config)
        {
            Client = client;
            Config = config;
            Worker.DoWork += new DoWorkEventHandler(PostCount);
        }

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
                DiscordBots.Post(Client, Config.DiscordBots);
            }
        }

        public ListAPI DiscordBots = new ListAPI("Discord Bots", "https://bots.discord.pw", "https://discordbots.org/api/bots/{0}/stats", new ListOwner("meew0#9811", 66237334693085184));

        public ListAPI DiscordBotList = new ListAPI("Discord Bot List", "https://discordbots.org", "", new ListOwner("Oliy#0330", 129908908096487424));

        public ListAPI DiscordBotListv2 = new ListAPI("Discord Bot List v2", "https://discordbotlist.com", "", new ListOwner("luke#0123", 149505704569339904));

        public ListAPI BotsForDiscord = new ListAPI("Bots For Discord", "https://botsfordiscord.com", "", new ListOwner("Habchy#1665", 162780049869635584));

        public ListAPI Carbonitex = new ListAPI("Carbonitex", "https://www.carbonitex.net", "", new ListOwner("jet#9999", 228290260239515649));

        public ListAPI BotListSpace = new ListAPI("Bot List Space", "https://botlist.space", "", new ListOwner("PassTheMayo#1281", 153173425844781056));

        public ListAPI BotsOnDiscord = new ListAPI("Bots On Discord", "https://bots.ondiscord.xyz", "", new ListOwner("Brussell#0660", 95286900801146880));

        public ListAPI DiscordBotWorld = new ListAPI("Discord Bot World", "https://discordbot.world", "", new ListOwner("Tetrabyte#0001", 156114103033790464));

        public ListAPI DiscordBotsGroup = new ListAPI("Discord Bots Group", "https://discordbots.group", "", new ListOwner("DetectiveHuman#0767", 423220263161692161));

        public ListAPI DiscordListApp = new ListAPI("Discord List App", "https://bots.discordlist.app", "", new ListOwner("Auxim#0001", 66166172835385344));

        public ListAPI DiscordServices = new ListAPI("Discord Services", "http://discord.services", "", new ListOwner("Tails#0420", 472573259108319237));

        public ListAPI DivineBotList = new ListAPI("Divine Bot List", "https://divinediscordbots.com", "", new ListOwner("Sworder#1234", 240508683455299584));
    }
}
