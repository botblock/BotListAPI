# BotListAPI
This is a C# lib that allows you to post your bots server count to all of the Discord bot lists.

If you have any issues/suggestions post an issue here, join my Discord https://discord.gg/TjF6QDC or contact me xXBuilderBXx#0001

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
   "Botlist": {
    "botlist.space": "",
	"bots.ondiscord.xyz": "",
	"botsfordiscord.com": "",
	"cloud-botlist.xyz": "",
	"discord.boats": "",
	"discord.bots.gg": "",
	"discordapps.dev": "",
	"discordbot.world": "",
	"discordbotlist.com": "",
	"discordextremelist.xyz": "",
	"divinediscordbots.com": "",
	"lbots.org": "",
	"mythicalbots.xyz": "",
	"top.gg": "",
	"yabl.xyz": ""
  }
);
```
You can manually trigger posting using
ListClient.ListType.DiscordBots.Post();

Or you can automatically post it using the a background task (every 10 minutes)

> ListClient.Start();

This stops the background task

> ListClient.Stop();
