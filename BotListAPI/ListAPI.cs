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
        private readonly BotListType Type;
        private readonly string Token = "";
        public bool ValidToken()
        {
            if (Token == "")
                return false;
            return true;
        }
        public ListAPI(ListClient client, BotListType type)
        {
            Client = client;
            Type = type;
            switch (Type)
            {
                case BotListType.BotListSpace:
                    {
                        Id = 387812458661937152;
                        Name = "Bot List Space";
                        Website = "https://botlist.space";
                        API = Website + "/api/bots/{0}";
                        Owner = new ListOwner("PassTheMayo#1281", 153173425844781056);
                        Token = Client.Config.BotListSpace;
                    }
                    break;
                case BotListType.BotsForDiscord:
                    {
                        Id = 374071874222686211;
                        Name = "Bots For Discord";
                        Website = "https://botsfordiscord.com";
                        API = Website + "/api/bot/{0}";
                        Owner = new ListOwner("Habchy#1665", 162780049869635584);
                        Token = Client.Config.BotsForDiscord;
                    }
                    break;
                case BotListType.BotsOnDiscord:
                    {
                        Id = 446425626988249089;
                        Name = "Bots On Discord";
                        Website = "https://bots.ondiscord.xyz";
                        API = Website + "/bot-api/bots/{0}/guilds";
                        Owner = new ListOwner("Brussell#0660", 95286900801146880);
                        Token = Client.Config.BotsOnDiscord;
                    }
                    break;
                case BotListType.DiscordBoats:
                    {
                        Id = 439866052684283905;
                        Name = "Discord Boats";
                        Website = "https://discord.boats";
                        API = Website + "/api/bot/{0}";
                        Owner = new ListOwner("untocodes#7880", 386941684723744768);
                        Token = Client.Config.DiscordBoats;
                    }
                    break;
                case BotListType.DiscordBoatsv2:
                    {
                        Id = 421630709585805312;
                        Name = "Discord Boats";
                        Website = "https://discordboats.club";
                        API = Website + "/api/public/bot/stats";
                        Owner = new ListOwner("Anthony#3912", 233823931830632449);
                        Token = Client.Config.DiscordBoatsv2;
                    }
                    break;
                case BotListType.DiscordBotIndex:
                    {
                        Id = 482922868410417163;
                        Name = "Discord Bot Index";
                        Website = "https://discordbotindex.com";
                        API = Website + "/apiv1/bot/{0}";
                        Owner = new ListOwner("ohlookitsderpy#3939", 145557815287611393);
                        Token = Client.Config.DiscordBotIndex;
                    }
                    break;
                case BotListType.DiscordBotListv2:
                    {
                        Id = 450100127256936458;
                        Name = "Discord Bot List v2";
                        Website = "https://discordbotlist.com";
                        API = Website + "/api/bots/{0}/stats";
                        Owner = new ListOwner("luke#0123", 149505704569339904);
                        Token = Client.Config.DiscordBotListv2;
                    }
                    break;
                case BotListType.DiscordBotListv3:
                    {
                        Id = 477792727577395210;
                        Name = "Discord Bot List v3";
                        Website = "https://discordbotlist.xyz";
                        API = Website + "/api/stats/{0}";
                        Owner = new ListOwner("Ankrad#0597", 297403616468140032);
                        Token = Client.Config.DiscordBotListv3;
                    }
                    break;
                case BotListType.TerminalInk:
                    {
                        Id = 330777295952543744;
                        Name = "Terminal";
                        Website = "https://ls.terminal.ink";
                        API = Website + "/api/v2/bots/{0}";
                        Owner = new ListOwner("7coil#3175", 190519304972664832);
                        Token = Client.Config.TerminalInk;
                    }
                    break;
                case BotListType.DiscordBotsReview:
                    {
                        Id = 500658335217876997;
                        Name = "Discord Bots Review";
                        Website = "https://discordbotsreview.tk";
                        API = Website + "/api/bot/{0}/stats";
                        Owner = new ListOwner("RaZeFeiXX#9432", 469716275786940416);
                        Token = Client.Config.DiscordBotsReview;
                    }
                    break;
                case BotListType.DiscordBotWorld:
                    {
                        Id = 396440418507816960;
                        Name = "Discord Bot World";
                        Website = "https://discordbot.world";
                        API = Website + "/api/bot/{0}/stats";
                        Owner = new ListOwner("Tetrabyte#0001", 156114103033790464);
                        Token = Client.Config.DiscordBotWorld;
                    }
                    break;
                case BotListType.DiscordBots:
                    {
                        Id = 110373943822540800;
                        Name = "Discord Bots";
                        Website = "https://discord.bots.gg";
                        API = Website + "/api/v1/bots/{0}/stats";
                        Owner = new ListOwner("meew0#9811", 66237334693085184);
                        Token = Client.Config.DiscordBots;
                    }
                    break;
                case BotListType.DiscordBotsList:
                    {
                        Id = 494311015484358687;
                        Name = "Discord Bots List";
                        Website = "https://discordbotslist.com";
                        API = Website + "/api/post.php";
                        Owner = new ListOwner("Solar#6173", 287722879481675777);
                        Token = Client.Config.DiscordBotsList;
                    }
                    break;
                case BotListType.DiscordBotsGroup:
                    {
                        Id = 447469952044105728;
                        Name = "Discord Bots Group";
                        Website = "https://discordbots.group";
                        API = Website + "/api/bot/{0}";
                        Owner = new ListOwner("DetectiveHuman#0767", 423220263161692161);
                        Token = Client.Config.DiscordBotsGroup;
                    }
                    break;
                case BotListType.DiscordServices:
                    {
                        Id = 294505571317710849;
                        Name = "Discord Services";
                        Website = "http://discord.services";
                        API = Website + "/api/bots/{0}";
                        Owner = new ListOwner("Tails#0420", 472573259108319237);
                        Token = Client.Config.DiscordServices;
                    }
                    break;
                case BotListType.DiscordBestBots:
                    {
                        Id = 446682534135201793;
                        Name = "Discord Best Bots";
                        Website = "https://discordsbestbots.xyz";
                        API = Website + "/api/bots/{0}";
                        Owner = new ListOwner("Ice#1234", 302604426781261824);
                        Token = Client.Config.DiscordBestBots;
                    }
                    break;
                case BotListType.DiscordsExtremeList:
                    {
                        Id = 513277571329294337;
                        Name = "Discord Extreme List";
                        Website = "https://discordsextremelist.tk";
                        API = Website + "/apt/bot/{0}";
                        Owner = new ListOwner("Cairo#4883", 208105877838888960);
                        Token = Client.Config.DiscordsExtremeList;
                    }
                    break;
                case BotListType.DivineBotList:
                    {
                        Id = 454933217666007052;
                        Name = "Divine Bot List";
                        Website = "https://divinediscordbots.com";
                        API = Website + "/api/bots/{0}/stats";
                        Owner = new ListOwner("Sworder#1234", 240508683455299584);
                        Token = Client.Config.DivineBotList;
                    }
                    break;
                case BotListType.DiscordBotList:
                    {
                        Id = 264445053596991498;
                        Name = "Discord Bot List";
                        Website = "https://discordbots.org";
                        API = Website + "/api/bots/{0}/stats";
                        Owner = new ListOwner("Oliy#0330", 129908908096487424);
                        Token = Client.Config.DiscordBotList;
                    }
                    break;
                case BotListType.Carbonitex:
                    {
                        Id = 112319935652298752;
                        Name = "Carbonitex";
                        Website = "https://www.carbonitex.net";
                        API = Website + "/discord/data/botdata.php";
                        Owner = new ListOwner("jet#9999", 228290260239515649);
                        Token = Client.Config.Carbonitex;
                    }
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
                    Client.Log(type, LogType.None, $"Successfully pinged, {Website} | {reply.RoundtripTime}ms");
                    return true;
                }
                else
                {
                    Client.Log(type, LogType.None, $"Could not ping, {Website} | {reply.Status}");
                    return false;
                }
            }
            catch (PingException ex)
            {
                Client.Log(type, LogType.None, $"Could not ping, {Website} | {ex.Message}");
                return false;
            }
        }

        /// <summary> Post server count to this bot list </summary>
        public bool Post(LogType type)
        {
            if (Client.Discord == null)
            {
                Client.Log(type, LogType.Error, "Cannot post server count, Discord client is null");
                return false;
            }
            if (Http == null)
            {
                if (Client.Discord.CurrentUser == null)
                {
                    Client.Log(type, LogType.Error, "Cannot post server count, CurrentUser is null");
                    return false;
                }
                Http = new HttpClient();
                if (Type != BotListType.Carbonitex)
                {
                    if (Type == BotListType.DiscordBotListv2)
                        Http.DefaultRequestHeaders.Add("Authorization", "Bot " + Token);
                    else
                        Http.DefaultRequestHeaders.Add("Authorization", Token);
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
                    case BotListType.DiscordBots:
                    case BotListType.BotsOnDiscord:
                        Count = new GuildCount(Client.Discord);
                        break;
                    case BotListType.DiscordBotListv2:
                    case BotListType.DiscordBestBots:
                    case BotListType.DiscordBotsList:
                        Count = new Guilds(Client.Discord);
                        break;
                    case BotListType.DiscordBotWorld:
                    case BotListType.DiscordBotListv3:
                        Count = new Guild_Count(Client.Discord);
                        break;
                    case BotListType.Carbonitex:
                        Count = new ServerCount(Client);
                        break;
                    case BotListType.DiscordBotsGroup:
                    case BotListType.DiscordsExtremeList:
                        Count = new Count(Client.Discord);
                        break;
                    case BotListType.TerminalInk:
                        Count = new Terminal_Count(Client.Discord);
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
                    Client.Log(type, LogType.Info, $"Successfully posted server count to {Name}");
                    Client.Log(type, LogType.Debug, "Request response in JSON\n" + JsonConvert.SerializeObject(Res, Formatting.Indented));
                    return true;
                }
                else
                {
                    Client.Log(type, LogType.Error, $"Error could not post server count to {Name}, {(int)Res.StatusCode} {Res.ReasonPhrase}");
                    Client.Log(type, LogType.Debug, "Request response in JSON\n" + JsonConvert.SerializeObject(Res, Formatting.Indented));
                    return false;
                }

            }
            catch (Exception ex)
            {
                Client.Log(type, LogType.Error, $"Error could not post server count to {Name}, {ex.Message}");
                Client.Log(type, LogType.Debug, "Exception\n" + ex.ToString());
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
       
        internal class Server_Count : ICount
        {
            public Server_Count(BaseSocketClient client)
            {
                server_count = client.Guilds.Count;
            }
            public int server_count;
        }

        internal class Count : ICount
        {
            public Count(BaseSocketClient client)
            {
                count = client.Guilds.Count;
            }
            public int count;
        }
        internal class Terminal_Count : ICount
        {
            public Terminal_Count(BaseSocketClient client)
            {
                bot = new Count(client);
            }
            public Count bot;
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
