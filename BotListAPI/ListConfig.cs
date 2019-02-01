using Discord.WebSocket;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BotListAPI
{
    public class ListConfig
    {
        /// <summary> Botlist Space token | https://botlist.space </summary>
        public string BotListSpace = "";

        /// <summary> Bots For Discord token | https://botsfordiscord.com </summary>
        public string BotsForDiscord = "";

        /// <summary> Bots On Discord token | https://bots.ondiscord.xyz </summary>
        public string BotsOnDiscord = "";
        
        /// <summary> Discord Boats token | https://discord.boats </summary>
        public string DiscordBoats = "";

        /// <summary> Discord Boats v2 token | https://discordboats.club </summary>
        public string DiscordBoatsv2 = "";
        
        /// <summary> Discord Bot Index token | https://discordbotindex.com </summary>
        public string DiscordBotIndex = "";

        /// <summary> Discord Bot List token | https://discordbots.org </summary>
        public string DiscordBotList = "";

        /// <summary> Discord Bot List v2 token | https://discordbotlist.com </summary>
        public string DiscordBotListv2 = "";

        /// <summary> Discord Bot List v3 token | https://discordbotlist.xyz </summary>
        public string DiscordBotListv3 = "";
        
        /// <summary> Terminal token | https://ls.terminal.ink </summary>
        public string TerminalInk = "";

        /// <summary> Discord Bot World token | https://discordbot.world </summary>
        public string DiscordBotWorld = "";

        /// <summary> Discord Bots token | https://discord.bots.gg </summary>
        public string DiscordBots = "";

        /// <summary> Discord Bots Group token | https://discordbots.group </summary>
        public string DiscordBotsGroup = "";

        /// <summary> Discord Services token | https://discord.services </summary>
        public string DiscordServices = "";

        /// <summary> Divine Best Bots token | https://discordsbestbots.xyz </summary>
        public string DiscordBestBots = "";
        
        /// <summary> Discords Extreme List token | https://discordsextremelist.tk </summary>
        public string DiscordsExtremeList = "";

        /// <summary> Divine Bot List token | https://divinediscordbots.com </summary>
        public string DivineBotList = "";
        
        /// <summary> Carbonitex token | https://carbonitex.net </summary>
        public string Carbonitex = "";
    }

    public class ListJson
    {
        public ListJson(BaseSocketClient client, ListConfig config)
        {
            if (client == null || client.CurrentUser == null)
                return;
            server_count = client.Guilds.Count;
            bot_id = client.CurrentUser.Id;
            BotListSpace = config.BotListSpace;
            BotsForDiscord = config.BotsForDiscord;
            BotsOnDiscord = config.BotsOnDiscord;
            DiscordBoats = config.DiscordBoats;
            DiscordBoatsv2 = config.DiscordBoatsv2;
            DiscordBotIndex = config.DiscordBotIndex;
            DiscordBotListv2 = config.DiscordBotListv2;
            DiscordBotListv3 = config.DiscordBotListv3;
            TerminalInk = config.TerminalInk;
            DiscordBotWorld = config.DiscordBotWorld;
            DiscordBots = config.DiscordBots;
            DiscordBotsGroup = config.DiscordBotsGroup;
            DiscordServices = config.DiscordServices;
            DiscordBestBots = config.DiscordBestBots;
            DiscordsExtremeList = config.DiscordsExtremeList;
            DivineBotList = config.DivineBotList;
        }

        public int server_count = 0;
        public ulong bot_id = 0;

        [JsonProperty(PropertyName = "botlist.space")]
        public string BotListSpace = "";

        [JsonProperty(PropertyName = "botsfordiscord.com")]
        public string BotsForDiscord = "";

        [JsonProperty(PropertyName = "bots.ondiscord.xyz")]
        public string BotsOnDiscord = "";

        [JsonProperty(PropertyName = "discord.boats")]
        public string DiscordBoats = "";

        [JsonProperty(PropertyName = "discordboats.club")]
        public string DiscordBoatsv2 = "";

        [JsonProperty(PropertyName = "discordbotindex.com")]
        public string DiscordBotIndex = "";

        [JsonProperty(PropertyName = "discordbotlist.com")]
        public string DiscordBotListv2 = "";

        [JsonProperty(PropertyName = "discordbotlist.xyz")]
        public string DiscordBotListv3 = "";

        [JsonProperty(PropertyName = "ls.terminal.ink")]
        public string TerminalInk = "";

        [JsonProperty(PropertyName = "discordbot.world")]
        public string DiscordBotWorld = "";

        [JsonProperty(PropertyName = "discord.bots.gg")]
        public string DiscordBots = "";

        [JsonProperty(PropertyName = "discordbots.group")]
        public string DiscordBotsGroup = "";

        [JsonProperty(PropertyName = "discord.services")]
        public string DiscordServices = "";

        [JsonProperty(PropertyName = "discordsbestbots.xyz")]
        public string DiscordBestBots = "";

        [JsonProperty(PropertyName = "discordsextremelist.tk")]
        public string DiscordsExtremeList = "";

        [JsonProperty(PropertyName = "divinediscordbots.com")]
        public string DivineBotList = "";
    }
}
