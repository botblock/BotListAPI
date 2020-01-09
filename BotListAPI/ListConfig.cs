using Discord.WebSocket;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BotListAPI
{
    public class ListConfig
    {
        public void SetCount(BaseSocketClient client)
        {
            if (client.CurrentUser != null)
            {
                server_count = client.Guilds.Count;
                bot_id = client.CurrentUser.Id.ToString();

                if (shardSupport && client is DiscordShardedClient ds)
                {
                    shard_count = ds.Shards.Count;
                    List<int> ShardTemp = new List<int>();
                    foreach(DiscordSocketClient s in ds.Shards)
                    {
                        ShardTemp.Add(s.Guilds.Count);
                    }
                    shards = ShardTemp;
                }
            }
        }
        public bool shardSupport = true;

        internal string bot_id = "";

        private int ServerCount = 0;
        public int server_count
        {
            get { return ServerCount; }
            internal set { ServerCount = value; }
        }

        private int ShardCount = 0;
        public int shard_count
        {
            get { return ShardCount; }
            internal set { ShardCount = value; }
        }

        private List<int> Shards = new List<int>();
        public List<int> shards
        {
            get { return Shards; }
            internal set { Shards = value; }
        }

        [JsonProperty(PropertyName = "botlist.space")]
        public string BotListSpace = "";

        [JsonProperty(PropertyName = "bots.ondiscord.xyz")]
        public string BotsOnDiscord = "";

        [JsonProperty(PropertyName = "botsfordiscord.com")]
        public string BotsForDiscord = "";

        [JsonProperty(PropertyName = "cloud-botlist.xyz")]
        public string CloudBotList = "";

        [JsonProperty(PropertyName = "discord.boats")]
        public string DiscordBoats = "";

        [JsonProperty(PropertyName = "discord.bots.gg")]
        public string DiscordBots = "";

        [JsonProperty(PropertyName = "discordapps.dev")]
        public string DiscordApps = "";

        [JsonProperty(PropertyName = "discordbot.world")]
        public string DiscordBotWorld = "";

        [JsonProperty(PropertyName = "discordbotlist.com")]
        public string DiscordBotListv2 = "";

        [JsonProperty(PropertyName = "discordbots.fun")]
        public string DiscordBotsFun = "";

        [JsonProperty(PropertyName = "discordextremelist.xyz")]
        public string DiscordExtremeList = "";

        [JsonProperty(PropertyName = "divinediscordbots.com")]
        public string DivineBotList = "";

        [JsonProperty(PropertyName = "lbots.org")]
        public string LBots = "";

        [JsonProperty(PropertyName = "mythicalbots.xyz")]
        public string MythicalBots = "";

        [JsonProperty(PropertyName = "top.gg")]
        public string TopGG = "";

        [JsonProperty(PropertyName = "wonderbotlist.com")]
        public string WonderBotList = "";

        [JsonProperty(PropertyName = "yabl.xyz")]
        public string YetAnotherBotList = "";
    }
}
