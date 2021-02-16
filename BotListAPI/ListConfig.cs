using Discord.WebSocket;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;

namespace BotListAPI
{
    public class ListConfig
    {
        [JsonProperty(PropertyName = "arcane-center.xyz")]
        public string ArcaneBotList { get; set; } = "";

        [JsonProperty(PropertyName = "bladebotlist.xyz")]
        public string BladeBotList { get; set; } = "";

        [JsonProperty(PropertyName = "blist.xyz")]
        public string BList { get; set; } = "";

        [JsonProperty(PropertyName = "botlist.space")]
        public string BotListSpace { get; set; } = "";

        [JsonProperty(PropertyName = "botlists.com")]
        public string AstroBotList { get; set; } = "";

        [JsonProperty(PropertyName = "bots.discordlabs.org")]
        public string DiscordLabs { get; set; } = "";

        [JsonProperty(PropertyName = "bots.idledev.org")]
        public string IdleDev { get; set; } = "";

        [JsonProperty(PropertyName = "bots.ondiscord.xyz")]
        public string BotsOnDiscord { get; set; } = "";

        [JsonProperty(PropertyName = "botsdatabase.come")]
        public string BotsDatabase { get; set; } = "";

        [JsonProperty(PropertyName = "botsfordiscord.com")]
        public string BotsForDiscord { get; set; } = "";

        [JsonProperty(PropertyName = "discord.boats")]
        public string DiscordBoats { get; set; } = "";

        [JsonProperty(PropertyName = "discord.bots.gg")]
        public string DiscordBots { get; set; } = "";

        [JsonProperty(PropertyName = "discordapps.dev")]
        public string DiscordApps { get; set; } = "";

        [JsonProperty(PropertyName = "discordbotlist.com")]
        public string DiscordBotListv2 { get; set; } = "";

        [JsonProperty(PropertyName = "discordbots.co")]
        public string DiscordBotsCo { get; set; } = "";

        [JsonProperty(PropertyName = "discordextremelist.xyz")]
        public string DiscordExtremeList { get; set; } = "";

        [JsonProperty(PropertyName = "discordservices.net")]
        public string DiscordServices { get; set; } = "";

        [JsonProperty(PropertyName = "discordlistology.com")]
        public string DiscordListology { get; set; } = "";

        [JsonProperty(PropertyName = "disforge.com")]
        public string DisForge { get; set; } = "";

        [JsonProperty(PropertyName = "fateslist.xyz")]
        public string FatestList { get; set; } = "";

        [JsonProperty(PropertyName = "infinitybotlist.com")]
        public string InfinityBotList { get; set; } = "";

        [JsonProperty(PropertyName = "paradisebots.net")]
        public string ParadiseBots { get; set; } = "";

        [JsonProperty(PropertyName = "space-bot-list.xyz")]
        public string SpaceBotList { get; set; } = "";

        [JsonProperty(PropertyName = "top.gg")]
        public string TopGG { get; set; } = "";

        [JsonProperty(PropertyName = "voidbots.net")]
        public string VoidBots { get; set; } = "";

        [JsonProperty(PropertyName = "wonderbotlist.com")]
        public string WonderBotList { get; set; } = "";

        [JsonProperty(PropertyName = "yabl.xyz")]
        public string YetAnotherBotList { get; set; } = "";

        [JsonProperty(PropertyName = "topcord.xyz")]
        public string TopCord { get; set; } = "";

        public ListJson GetJson()
        {
            ListJson Json = new ListJson();
            PropertyDescriptorCollection sourceproperties = TypeDescriptor.GetProperties(new ListConfig());
            PropertyDescriptorCollection targetproperties = TypeDescriptor.GetProperties(new ListJson());
            foreach (PropertyDescriptor pd in targetproperties)
                foreach (PropertyDescriptor _pd in sourceproperties)
                    if (pd.Name == _pd.Name)
                        pd.SetValue(Json, _pd.GetValue(this));
            return Json;
        }
    }

    public class ListJson : ListConfig
    {
        public void SetCount(BaseSocketClient client)
        {
            if (client.CurrentUser != null)
            {
                server_count = client.Guilds.Count;
                bot_id = client.CurrentUser.Id.ToString();

                if (client is DiscordShardedClient ds)
                {
                    shard_count = ds.Shards.Count;
                    List<int> ShardTemp = new List<int>();
                    foreach (DiscordSocketClient s in ds.Shards)
                    {
                        ShardTemp.Add(s.Guilds.Count);
                    }
                    shards = ShardTemp;
                }
            }
        }

        public string bot_id = "";

        public int server_count = 0;

        public int shard_count = 0;

        public List<int> shards = new List<int>();
    }
}
