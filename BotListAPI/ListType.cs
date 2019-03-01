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
            DiscordBoatsv2 = new ListAPI(Client, BotListType.DiscordBoatsv2);
            DiscordBotListv2 = new ListAPI(Client, BotListType.DiscordBotListv2);
            TerminalInk = new ListAPI(Client, BotListType.TerminalInk);
            DiscordBotWorld = new ListAPI(Client, BotListType.DiscordBotWorld);
            DiscordBots = new ListAPI(Client, BotListType.DiscordBots);
            DiscordBotsGroup = new ListAPI(Client, BotListType.DiscordBotsGroup);
            DiscordServices = new ListAPI(Client, BotListType.DiscordServices);
            DiscordBestBots = new ListAPI(Client, BotListType.DiscordBestBots);
            DivineBotList = new ListAPI(Client, BotListType.DivineBotList);
            DiscordBotList = new ListAPI(Client, BotListType.DiscordBotList);
            Carbonitex = new ListAPI(Client, BotListType.Carbonitex);
        }

        public void PostAll(LogType type)
        {
            if (BotListSpace.Enabled && BotListSpace.ValidToken())
                BotListSpace.Post(type);

            if (BotsForDiscord.Enabled && BotsForDiscord.ValidToken())
                BotsForDiscord.Post(type);

            if (BotsOnDiscord.Enabled && BotsOnDiscord.ValidToken())
                BotsOnDiscord.Post(type);

            if (DiscordBoats.Enabled && DiscordBoats.ValidToken())
                DiscordBoats.Post(type);

            if (DiscordBoatsv2.Enabled && DiscordBoatsv2.ValidToken())
                DiscordBoatsv2.Post(type);

            if (DiscordBotListv2.Enabled && DiscordBotListv2.ValidToken())
                DiscordBotListv2.Post(type);

            if (TerminalInk.Enabled && TerminalInk.ValidToken())
                TerminalInk.Post(type);

            if (DiscordBotWorld.Enabled && DiscordBotWorld.ValidToken())
                DiscordBotWorld.Post(type);

            if (DiscordBots.Enabled && DiscordBots.ValidToken())
                DiscordBots.Post(type);

            if (DiscordBotsGroup.Enabled && DiscordBotsGroup.ValidToken())
                DiscordBotsGroup.Post(type);

            if (DiscordServices.Enabled && DiscordServices.ValidToken())
                DiscordServices.Post(type);

            if (DiscordBestBots.Enabled && DiscordBestBots.ValidToken())
                DiscordBestBots.Post(type);

            if (DivineBotList.Enabled && DivineBotList.ValidToken())
                DivineBotList.Post(type);

            if (DiscordBotList.Enabled && DiscordBotList.ValidToken())
                DiscordBotList.Post(type);

            if (Carbonitex.Enabled && Carbonitex.ValidToken())
                Carbonitex.Post(type);
        }
        
        /// <summary> Botlist Space | https://botlist.space </summary>
        public ListAPI BotListSpace;

        /// <summary> Bots For Discord | https://botsfordiscord.com </summary>
        public ListAPI BotsForDiscord;

        /// <summary> Bots On Discord | https://bots.ondiscord.xyz </summary>
        public ListAPI BotsOnDiscord;

        /// <summary> Discord Boats | https://discord.boats </summary>
        public ListAPI DiscordBoats;

        /// <summary> Discord Boats v2 | https://discordboats.club </summary>
        public ListAPI DiscordBoatsv2;

        /// <summary> Discord Bot List v2 | https://discordbotlist.com </summary>
        public ListAPI DiscordBotListv2;

        /// <summary> Terminal | https://ls.terminal.ink </summary>
        public ListAPI TerminalInk;

        /// <summary> Discord Bot World | https://discordbot.world </summary>
        public ListAPI DiscordBotWorld;

        /// <summary> Discord Bots | https://discord.bots.gg </summary>
        public ListAPI DiscordBots;

        /// <summary> Discord Bot List | https://discordbots.org </summary>
        public ListAPI DiscordBotList;

        /// <summary> Discord Bots Group | https://discordbots.group </summary>
        public ListAPI DiscordBotsGroup;

        /// <summary> Discord Services | https://discord.services </summary>
        public ListAPI DiscordServices;

        /// <summary> Divine Best Bots | https://discordsbestbots.xyz </summary>
        public ListAPI DiscordBestBots;

        /// <summary> Divine Bot List | https://divinediscordbots.com </summary>
        public ListAPI DivineBotList;

        /// <summary> Carbonitex | https://carbonitex.net </summary>
        public ListAPI Carbonitex;
    }

    public enum BotListType
    {
        BotListSpace, BotsForDiscord, BotsOnDiscord, DiscordBoats,
        DiscordBoatsv2, DiscordBotList, DiscordBotListv2,
        TerminalInk, DiscordBotWorld, DiscordBots,
        DiscordBotsGroup, DiscordServices, DiscordBestBots,
        DivineBotList, Carbonitex,
    }
}
