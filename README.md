# BotListAPI
This is a C# lib that allows you to post your bots server count to all of the Discord bot lists.

If you have any issues/suggestions post an issue here, join my Discord https://discord.gg/WJTYdNb or contact me xXBuilderBXx#8265

# Features
#### Please see at the bottom of this README for the todo list
- Diffrent logtypes
- 11 Bot lists supported
- Information about the bot lists, name, website, owner (Name#tag & ID)
- Supports normal and sharded bots
- Manually trigger posting
- Automatically post server count every 5 minutes

# How to use
Install the nuget package here https://www.nuget.org/packages/BotListAPI
Create a new instance of `BotListAPI.ListClient`

It is encouraged to not put tokens in this and instead load a file with the tokens incase you leak all your tokens
```
ListClient = new ListClient(_Client, new ListConfig
{
    DiscordBots = "",
    BotsForDiscord = "",
    BotListSpace = "",
    BotsOnDiscord = "",
    Carbonitex = "",
    DiscordBotList = "",
    DiscordBotListv2 = "",
    DiscordBotsGroup = "",
    DiscordBotWorld = "",
    DiscordListApp = "",
    DiscordServices = "",
    DivineBotList = ""
);
```
You can manually trigger posting using
ListClient.DiscordBots.Post();

Or you can automatically post it using the a background thread (every 5 minutes)

> ListClient.Start();

This stops the background thread

> ListClient.Stop();

# Bot lists
- Discord Bots | https://bots.discord.pw
- Discord Bot List | https://discordbots.org
- Discord Bot List v2 | https://discordbotlist.com
- Bots For Discord | https://botsfordiscord.com
- Carbonitex | https://www.carbonitex.net
- Bot List Space | https://botlist.space
- Bots On Discord | https://bots.ondiscord.xyz
- Discord Bot World | https://discordbot.world
- Discord Bots Group (API is down) | https://discordbots.group
- Discord List App | https://bots.discordlist.app
- Discord Services | http://discord.services
- Divine Bot List | https://divinediscordbots.com

# Todo
- Change error status code from string to int value
- Add support for Discord Bots Group (When api is fixed)
- Comment a lot of the code
- Add misc functions to check website status
- Add support for custom json file
- Another logtype to show API and token
- Add support for log event
- Add support for https://botblock.org
