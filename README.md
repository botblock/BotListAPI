# BotListAPI
This is a C# lib that allows you to post your bots server count to all of the Discord bot lists.

If you have any issues/suggestions post an issue here, join my Discord https://discord.gg/WJTYdNb or contact me xXBuilderBXx#8265

# Features
#### Please see at the bottom of this README for the todo list
- Diffrent logtypes
- 12 Bot lists supported
- Information about the bot lists, name, website, owner (Name#tag & ID)
- Supports normal and sharded bots
- Supports .net framework and .net core
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
- Discord Bot List v2 | https://discordbotlist.com
- Discord Services | http://discord.services
- Bots For Discord | https://botsfordiscord.com
- Carbonitex | https://www.carbonitex.net
- Bot List Space | https://botlist.space
- Bots On Discord | https://bots.ondiscord.xyz
- Discord Bot World | https://discordbot.world
- Discord Bots Group | https://discordbots.group
- Discord List App | https://bots.discordlist.app
- Divine Bot List | https://divinediscordbots.com
- Discord Bot List | https://discordbots.org

# Todo
- Add misc functions to check website status
- Add support for custom json file
- Add support for log event
- Add support for https://botblock.org
- Add get function to botlist to retrieve guild from DiscordClient
- Add Get function to botlist owner to retrieve user from DiscordClient
