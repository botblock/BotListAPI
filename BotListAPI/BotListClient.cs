using System;

namespace BotListAPI
{
    public class BotListClient
    {
        private readonly BotListConfig Config;
        public BotListClient(BotListConfig config)
        {
            Config = config;
        }
    }
}
