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
        /// <summary> Enable/Disable auto posting </summary>
        public bool Enabled = true;
        private readonly ListClient Client;
        private readonly BotListType Type;
        private readonly string Token = "";
        public string API = "";
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
                        Token = Client.Config.BotListSpace;
                    }
                    break;
                case BotListType.BotsForDiscord:
                    {
                        Id = 374071874222686211;
                        Name = "Bots For Discord";
                        Token = Client.Config.BotsForDiscord;
                    }
                    break;
                case BotListType.BotsOnDiscord:
                    {
                        Id = 446425626988249089;
                        Name = "Bots On Discord";
                        Token = Client.Config.BotsOnDiscord;
                    }
                    break;
                case BotListType.DiscordBoats:
                    {
                        Id = 439866052684283905;
                        Name = "Discord Boats";
                        Token = Client.Config.DiscordBoats;
                    }
                    break;
                case BotListType.DiscordBotListv2:
                    {
                        Id = 450100127256936458;
                        Name = "Discord Bot List v2";
                        Token = Client.Config.DiscordBotListv2;
                    }
                    break;
                case BotListType.DiscordApps:
                    {
                        Id = 330777295952543744;
                        Name = "DiscordApps";
                        Token = Client.Config.DiscordApps;
                    }
                    break;
                case BotListType.DiscordBotWorld:
                    {
                        Id = 396440418507816960;
                        Name = "Discord Bot World";
                        Token = Client.Config.DiscordBotWorld;
                    }
                    break;
                case BotListType.DiscordBots:
                    {
                        Id = 110373943822540800;
                        Name = "Discord Bots";
                        Token = Client.Config.DiscordBots;
                    }
                    break;
                case BotListType.DiscordBestBots:
                    {
                        Id = 446682534135201793;
                        Name = "Discord Best Bots";
                        Token = Client.Config.DiscordBestBots;
                    }
                    break;
                case BotListType.DivineBotList:
                    {
                        Id = 454933217666007052;
                        Name = "Divine Bot List";
                        Token = Client.Config.DivineBotList;
                    }
                    break;
                case BotListType.DiscordBotList:
                    {
                        Id = 264445053596991498;
                        Name = "Discord Bot List";
                        Token = Client.Config.DiscordBotList;
                    }
                    break;
                case BotListType.LBots:
                    {
                        Id = 431438368522371082;
                        Name = "LBots";
                        Token = Client.Config.LBots;
                    }
                    break;
                case BotListType.Carbonitex:
                    {
                        Id = 112319935652298752;
                        Name = "Carbonitex";
                        API = "https://www.carbonitex.net/discord/data/botdata.php";
                        Token = Client.Config.Carbonitex;
                    }
                    break;
            }
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
