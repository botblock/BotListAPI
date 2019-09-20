using System;
using System.Collections.Generic;
using System.Text;

namespace BotListAPI
{
    public class ListType
    {
        public ListType(ListClient Client)
        {
            BotListSpace = new ListAPI(Client, BotListType.BotListSpace);
            BotsForDiscord = new ListAPI(Client, BotListType.BotsForDiscord);
            BotsOnDiscord = new ListAPI(Client, BotListType.BotsOnDiscord);
            DiscordBoats = new ListAPI(Client, BotListType.DiscordBoats);
            DiscordBotListv2 = new ListAPI(Client, BotListType.DiscordBotListv2);
            DiscordApps = new ListAPI(Client, BotListType.DiscordApps);
            DiscordBotWorld = new ListAPI(Client, BotListType.DiscordBotWorld);
            DiscordBots = new ListAPI(Client, BotListType.DiscordBots);
            DiscordBestBots = new ListAPI(Client, BotListType.DiscordBestBots);
            DivineBotList = new ListAPI(Client, BotListType.DivineBotList);
            DiscordBotList = new ListAPI(Client, BotListType.DiscordBotList);
            LBots = new ListAPI(Client, BotListType.LBots);
            Carbonitex = new ListAPI(Client, BotListType.Carbonitex);
        }
        
        /// <summary> Botlist Space | https://botlist.space </summary>
        public ListAPI BotListSpace;

        /// <summary> Bots For Discord | https://botsfordiscord.com </summary>
        public ListAPI BotsForDiscord;

        /// <summary> Bots On Discord | https://bots.ondiscord.xyz </summary>
        public ListAPI BotsOnDiscord;

        /// <summary> Discord Boats | https://discord.boats </summary>
        public ListAPI DiscordBoats;

        /// <summary> Discord Bot List v2 | https://discordbotlist.com </summary>
        public ListAPI DiscordBotListv2;

        /// <summary> DiscordApps | https://discordapps.dev </summary>
        public ListAPI DiscordApps;

        /// <summary> Discord Bot World | https://discordbot.world </summary>
        public ListAPI DiscordBotWorld;

        /// <summary> Discord Bots | https://discord.bots.gg </summary>
        public ListAPI DiscordBots;

        /// <summary> Discord Bot List | https://discordbots.org </summary>
        public ListAPI DiscordBotList;

        /// <summary> Divine Best Bots | https://discordsbestbots.xyz </summary>
        public ListAPI DiscordBestBots;

        /// <summary> Divine Bot List | https://divinediscordbots.com </summary>
        public ListAPI DivineBotList;

        /// <summary> LBots | https://lbots.org </summary>
        public ListAPI LBots;

        /// <summary> Carbonitex | https://carbonitex.net </summary>
        public ListAPI Carbonitex;
    }

    public enum BotListType
    {
        BotListSpace, BotsForDiscord, BotsOnDiscord, DiscordBoats,
        DiscordBotList, DiscordBotListv2,
        DiscordApps, DiscordBotWorld, DiscordBots,
        DiscordBestBots,
        DivineBotList, LBots, Carbonitex,
    }
}
