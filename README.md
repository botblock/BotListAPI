# BotListAPI
This is a C# lib that allows you to post your bots server count to all of the Discord bot lists.

If you have any issues/suggestions post an issue here, join my Discord https://discord.gg/susQ6XA or contact me xXBuilderBXx#8265

# Features
#### Please see at the bottom of this README for the todo list
- Diffrent logtypes (none, error only, info, debug)
- 15 Bot lists supported
- Information about the bot lists, name, website, owner (Name#tag & ID)
- Supports normal and sharded bots
- Supports .net framework and .net core
- Manually trigger posting
- Automatically post server count every 10 minutes

# How to use
Install the nuget package here https://www.nuget.org/packages/BotListAPI

Create a new instance of `BotListAPI.ListClient`

It is encouraged to not put tokens in this and instead load a file with the tokens incase you leak all your tokens
```
ListClient = new ListClient(_Client, new ListConfig
{
    "BotListSpace": "",
    "BotsForDiscord": "",
    "BotsOnDiscord": "",
    "DiscordBoats": "",
    "DiscordBoatsv2": "",
    "DiscordBotIndex": "",
    "DiscordBotListv2": "",
    "DiscordBotListv3": "",
    "TerminalInk": "",
    "DiscordBotsReview": "",
    "DiscordBotWorld": "",
    "DiscordBots": "",
    "DiscordBotsList": "",
    "DiscordBotsGroup": "",
    "DiscordServices": "",
    "DiscordBestBots": "",
    "DiscordsExtremeList": "",
    "DivineBotList": "",
    "DiscordBotList": "",
    "Carbonitex": ""
);
```
You can manually trigger posting using
ListClient.ListType.DiscordBots.Post();

Or you can automatically post it using the a background task (every 10 minutes)

> ListClient.Start();

This stops the background task

> ListClient.Stop();

# Supports BotBlock.org

This uses less requests and is enabled by default with ListClient.BotBlock = true;

# Bot lists
- Botlist Space | https://botlist.space
- Bots For Discord | https://botsfordiscord.com
- Bots On Discord | https://bots.ondiscord.xyz
- Discord Boats | https://discord.boats
- Discord Boats v2 | https://discordboats.club
- Discord Bot List v2 | https://discordbotlist.com
- Terminal | https://ls.terminal.ink
- Discord Bot World | https://discordbot.world
- Discord Bots | https://discord.bots.gg
- Discord Bots Group | https://discordbots.group
- Discord Services | https://discord.services
- Divine Best Bots | https://discordsbestbots.xyz
- Divine Bot List | https://divinediscordbots.com
- Discord Bot List | https://discordbots.org 
- Carbonitex | https://carbonitex.net
