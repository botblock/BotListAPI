using Discord;
using Discord.WebSocket;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace BotListAPI
{
    /// <summary> Class for bot list API </summary>
    public class ListAPI
    {
        /// <summary> ID of the bot list </summary>
        public readonly ulong Id;
        /// <summary> Name of the bot list </summary>
        public readonly string Name;
        /// <summary> Website for the bot list </summary>
        public readonly string Website;
        /// <summary> API for the bot list </summary>
        public string API;
        /// <summary> Owner of the bot list </summary>
        public readonly ListOwner Owner;
        /// <summary> Enable/Disable auto posting </summary>
        public bool Enabled = true;
        private HttpClient Http;
        private ListClient Client;
        private ListType Type;
        public ListAPI(ListClient client, ListType type)
        {
            Client = client;
            Type = type;
            switch (Type)
            {
                case ListType.DiscordBots:
                    Id = 110373943822540800;
                    Name = "Discord Bots";
                    Website = "https://bots.discord.pw";
                    API = Website + "/api/bots/{0}/stats";
                    Owner = new ListOwner("meew0#9811", 66237334693085184);
                    break;
                case ListType.DiscordBotList:
                    Id = 264445053596991498;
                    Name = "Discord Bot List";
                    Website = "https://discordbots.org";
                    API = Website + "/api/bots/{0}/stats";
                    Owner = new ListOwner("Oliy#0330", 129908908096487424);
                    break;
                case ListType.DiscordBotListv2:
                    Id = 450100127256936458;
                    Name = "Discord Bot List v2";
                    Website = "https://discordbotlist.com";
                    API = Website + "/api/bots/{0}/stats";
                    Owner = new ListOwner("luke#0123", 149505704569339904);
                    break;
                case ListType.DiscordBotListv3:
                    Id = 477792727577395210;
                    Name = "Discord Bot List v3";
                    Website = "https://discordbotlist.xyz";
                    API = Website + "/api/stats/{0}";
                    Owner = new ListOwner("Ankrad#0597", 297403616468140032);
                    break;
                case ListType.BotsForDiscord:
                    Id = 374071874222686211;
                    Name = "Bots For Discord";
                    Website = "https://botsfordiscord.com";
                    API = Website + "/api/v1/bots/{0}";
                    Owner = new ListOwner("Habchy#1665", 162780049869635584);
                    break;
                case ListType.Carbonitex:
                    Id = 112319935652298752;
                    Name = "Carbonitex";
                    Website = "https://www.carbonitex.net";
                    API = Website + "/discord/data/botdata.php";
                    Owner = new ListOwner("jet#9999", 228290260239515649);
                    break;
                case ListType.BotListSpace:
                    Id = 387812458661937152;
                    Name = "Bot List Space";
                    Website = "https://botlist.space";
                    API = Website + "/api/bots/{0}";
                    Owner = new ListOwner("PassTheMayo#1281", 153173425844781056);
                    break;
                case ListType.BotsOnDiscord:
                    Id = 446425626988249089;
                    Name = "Bots On Discord";
                    Website = "https://bots.ondiscord.xyz";
                    API = Website + "/bot-api/bots/{0}/guilds";
                    Owner = new ListOwner("Brussell#0660", 95286900801146880);
                    break;
                case ListType.DiscordBotWorld:
                    Id = 396440418507816960;
                    Name = "Discord Bot World";
                    Website = "https://discordbot.world";
                    API = Website + "/api/bot/{0}/stats";
                    Owner = new ListOwner("Tetrabyte#0001", 156114103033790464);
                    break;
                case ListType.DiscordBotsGroup:
                    Id = 447469952044105728;
                    Name = "Discord Bots Group";
                    Website = "https://discordbots.group";
                    API = Website + "/api/bot/{0}";
                    Owner = new ListOwner("DetectiveHuman#0767", 423220263161692161);
                    break;
                case ListType.DiscordListApp:
                    Id = 475571221946171393;
                    Name = "Discord List App";
                    Website = "https://bots.discordlist.app";
                    API = Website + "/api/bot/{0}/stats";
                    Owner = new ListOwner("Auxim#0001", 66166172835385344);
                    break;
                case ListType.DiscordServices:
                    Id = 294505571317710849;
                    Name = "Discord Services";
                    Website = "http://discord.services";
                    API = Website + "/api/bots/{0}";
                    Owner = new ListOwner("Tails#0420", 472573259108319237);
                    break;
                case ListType.DivineBotList:
                    Id = 454933217666007052;
                    Name = "Divine Bot List";
                    Website = "https://divinediscordbots.com";
                    API = Website + "/api/bots/{0}/stats";
                    Owner = new ListOwner("Sworder#1234", 240508683455299584);
                    break;
                case ListType.DiscordBestBots:
                    Id = 446682534135201793;
                    Name = "Discord Best Bots";
                    Website = "https://discordsbestbots.xyz/";
                    API = Website + "/api/bots/{0}";
                    Owner = new ListOwner("Ice#1234", 302604426781261824);
                    break;
            }
        }

        public IGuild GetGuild()
        {
            return Client.Discord.GetGuild(Id);
        }

        public async Task<IGuild> GetGuildAsync()
        {
            return await (Client.Discord as IDiscordClient).GetGuildAsync(Id);
        }

        public async Task<IGuildUser> GetOwnerAsync()
        {
            IGuild Guild = await (Client.Discord as IDiscordClient).GetGuildAsync(Id);
            return await Guild.GetUserAsync(Owner.Id);
        }

        public IGuildUser GetOwner()
        {
            return Client.Discord.GetGuild(Id).GetUser(Owner.Id);
        }

        public bool Ping(LogType type)
        {
            Ping pinger = null;

            try
            {
                pinger = new Ping();
                PingReply reply = pinger.Send(Website);
                if (reply.Status == IPStatus.Success)
                {
                        Log($"Successfully pinged, {Website} | {reply.RoundtripTime}ms");
                    return true;
                }
                else
                {
                    Log($"Could not ping, {Website} | {reply.Status}");
                    return false;
                }
            }
            catch (PingException ex)
            {
                Log($"Could not ping, {Website} | {ex.Message}");
                return false;
            }
        }

        private void Log(string text)
        {
            Console.WriteLine($"[BotListAPI] " + text);
        }

        /// <summary> Get the token for this bot list </summary>
        public string GetToken()
        {
            switch (Type)
            {
                case ListType.DiscordBots:
                    return Client.Config.DiscordBots;
                case ListType.DiscordBotList:
                    return Client.Config.DiscordBotList;
                case ListType.DiscordBotListv2:
                    return Client.Config.DiscordBotListv2;
                case ListType.DiscordBotListv3:
                    return Client.Config.DiscordBotListv3;
                case ListType.BotsForDiscord:
                    return Client.Config.BotsForDiscord;
                case ListType.Carbonitex:
                    return Client.Config.Carbonitex;
                case ListType.BotListSpace:
                    return Client.Config.BotListSpace;
                case ListType.BotsOnDiscord:
                    return Client.Config.BotsOnDiscord;
                case ListType.DiscordBotWorld:
                    return Client.Config.DiscordBotWorld;
                case ListType.DiscordBotsGroup:
                    return Client.Config.DiscordBotsGroup;
                case ListType.DiscordListApp:
                    return Client.Config.DiscordListApp;
                case ListType.DiscordServices:
                    return Client.Config.DiscordServices;
                case ListType.DivineBotList:
                    return Client.Config.DivineBotList;
                case ListType.DiscordBestBots:
                    return Client.Config.DiscordBestBots;
            }
            return "";
        }

        /// <summary> Post server count to this bot list </summary>
        public bool Post(LogType type)
        {
            if (Client.Discord == null)
            {
                if (type >= LogType.Error)
                    Log("Cannot post server count, Discord client is null");
                return false;
            }
            if (Http == null)
            {
                if (Client.Discord.CurrentUser == null)
                {
                    if (type >= LogType.Error)
                        Log("Cannot post server count, CurrentUser is null");
                    return false;
                }
                Http = new HttpClient();
                if (Type != ListType.Carbonitex)
                {
                    if (Type == ListType.DiscordBotListv2)
                        Http.DefaultRequestHeaders.Add("Authorization", "Bot " + GetToken());
                    else
                        Http.DefaultRequestHeaders.Add("Authorization", GetToken());
                }
                API = API.Replace("{0}", Client.Discord.CurrentUser.Id.ToString());
                Http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                Http.DefaultRequestHeaders.Add("User-Agent", "BotListAPI - " + Client.Discord.CurrentUser.ToString());
            }
            try
            {
                ICount Count;
                switch (Type)
                {
                    case ListType.BotsOnDiscord:
                        Count = new GuildCount(Client.Discord);
                        break;
                    case ListType.DiscordBotListv2:
                    case ListType.DiscordBestBots:
                        Count = new Guilds(Client.Discord);
                        break;
                    case ListType.DiscordBotWorld:
                    case ListType.DiscordBotListv3:
                        Count = new Guild_Count(Client.Discord);
                        break;
                    case ListType.Carbonitex:
                        Count = new ServerCount(Client);
                        break;
                    case ListType.DiscordBotsGroup:
                        Count = new Count(Client.Discord);
                        break;
                    default:
                        Count = new Server_Count(Client.Discord);
                        break;
                }

                StringContent Content = new StringContent(JsonConvert.SerializeObject(Count), Encoding.UTF8, "application/json");
                Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                HttpResponseMessage Res = Http.PostAsync(API, Content).GetAwaiter().GetResult();
                if (Res.IsSuccessStatusCode)
                {
                    if (type >= LogType.Info)
                        Log($"Successfully posted server count to {Name}");
                    if (type == LogType.Debug)
                        Log("Request response in JSON\n" + JsonConvert.SerializeObject(Res, Formatting.Indented));
                    return true;
                }
                else
                {
                    if (type >= LogType.Info)
                        Log($"Error could not post server count to {Name}, {(int)Res.StatusCode} {Res.ReasonPhrase}");
                    if (type == LogType.Debug)
                        Log("Request response in JSON\n" + JsonConvert.SerializeObject(Res, Formatting.Indented));
                    return false;
                }
                
            }
            catch (Exception ex)
            {
                if (type >= LogType.Info)
                    Log($"Error could not post server count to {Name}, {ex.Message}");
                if (type == LogType.Debug)
                    Log("Exception\n" + ex.ToString());
                return false;
            }
        }
        internal interface ICount { };
        internal class GuildCount : ICount
        {
            public GuildCount(BaseSocketClient client)
            {
                guildCount = client.Guilds.Count;
            }
            public int guildCount;
        }
        internal class Guilds : ICount
        {
            public Guilds(BaseSocketClient client)
            {
                guilds = client.Guilds.Count;
            }
            public int guilds;
        }
        internal class Guild_Count : ICount
        {
            public Guild_Count(BaseSocketClient client)
            {
                guild_count = client.Guilds.Count;
            }
            public int guild_count;
        }
        internal class ServerCount : ICount
        {
            public ServerCount(ListClient client)
            {
                servercount = client.Discord.Guilds.Count;
                key = client.Config.Carbonitex;
            }

            public int servercount;
            public string key;
        }
        internal class Count : ICount
        {
            public Count(BaseSocketClient client)
            {
                count = client.Guilds.Count;
            }
            public int count;
        }
        internal class Server_Count : ICount
        {
            public Server_Count(BaseSocketClient client)
            {
                server_count = client.Guilds.Count;
            }
            public int server_count;
        }
    }
    public class ListOwner
    {
        public ListOwner(string name, ulong id)
        {
            Name = name;
            Id = id;
        }
        public string Name;
        public ulong Id;
    }
}
