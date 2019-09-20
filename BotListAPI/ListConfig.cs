﻿using Discord.WebSocket;
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

        /// <summary> Discord Bot List token | https://discordbots.org </summary>
        public string DiscordBotList = "";

        /// <summary> Discord Bot List v2 token | https://discordbotlist.com </summary>
        public string DiscordBotListv2 = "";

        /// <summary> Discord Bot List v3 token | https://discordbotlist.xyz </summary>
        public string DiscordBotListv3 = "";

        /// <summary> DiscordApps token | https://discordapps.dev </summary>
        public string DiscordApps = "";

        /// <summary> Discord Bot World token | https://discordbot.world </summary>
        public string DiscordBotWorld = "";

        /// <summary> Discord Bots token | https://discord.bots.gg </summary>
        public string DiscordBots = "";

        /// <summary> Divine Best Bots token | https://discordsbestbots.xyz </summary>
        public string DiscordBestBots = "";
        
        /// <summary> Discords Extreme List token | https://discordsextremelist.tk </summary>
        public string DiscordsExtremeList = "";

        /// <summary> Divine Bot List token | https://divinediscordbots.com </summary>
        public string DivineBotList = "";

        /// <summary> LBots | https://lbots.org </summary>
        public string LBots = "";

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
            DiscordBotListv2 = config.DiscordBotListv2;
            DiscordApps = config.DiscordApps;
            DiscordBotWorld = config.DiscordBotWorld;
            DiscordBots = config.DiscordBots;
            DiscordBestBots = config.DiscordBestBots;
            DivineBotList = config.DivineBotList;
            LBots = config.LBots;
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

        [JsonProperty(PropertyName = "discordbotlist.com")]
        public string DiscordBotListv2 = "";

        [JsonProperty(PropertyName = "discordbot.world")]
        public string DiscordBotWorld = "";

        [JsonProperty(PropertyName = "discordapps.dev")]
        public string DiscordApps = "";

        [JsonProperty(PropertyName = "discord.bots.gg")]
        public string DiscordBots = "";

        [JsonProperty(PropertyName = "discordbots.group")]
        public string DiscordBotsGroup = "";

        [JsonProperty(PropertyName = "discord.services")]
        public string DiscordServices = "";

        [JsonProperty(PropertyName = "discordsbestbots.xyz")]
        public string DiscordBestBots = "";

        [JsonProperty(PropertyName = "divinediscordbots.com")]
        public string DivineBotList = "";

        [JsonProperty(PropertyName = "lbots.org")]
        public string LBots = "";
    }
}
