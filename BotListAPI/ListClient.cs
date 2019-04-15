using Discord.WebSocket;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Timers;

namespace BotListAPI
{
    /// <summary> BotListAPI client to post server count </summary>
    public class ListClient
    {
        public readonly ListConfig Config = new ListConfig();

        public ListType ListType;

        /// <summary> Discord client can be normal or sharded </summary>
        public readonly BaseSocketClient Discord;

        private readonly Timer Timer;

        /// <summary> Log event for when a log message is triggered </summary>
        public Action<LogType, string> MessageLog;

        private HttpClient Http;
        /// <summary> Log type for auto posting </summary>
        public LogType LogType = LogType.Info;

        public ListClient(BaseSocketClient client, ListConfig config)
        {
            Discord = client;
            Config = config;
            Timer = new Timer
            {
                Interval = 600000,
                Enabled = false
            };
            Timer.Elapsed += Timer_Elapsed;
            ListType = new ListType(this);
        }

        /// <summary> Enable using botblock.org to post server count (less requests) </summary>
        public bool BotBlock = true;

        /// <summary> Disable all auto posting </summary>
        public bool Disabled = false;

        /// <summary> Start posting server count every 10 minutes </summary>
        public void Start()
        {
            if (!Timer.Enabled)
            {
                Timer.Start();
                Log(LogType.None, LogType.None, "Enabled auto posting server count");
            }
        }

        /// <summary> Stop auto posting server count </summary>
        public void Stop()
        {
            if (Timer.Enabled)
            {
                Timer.Stop();
                Log(LogType.None, LogType.None, "Disabled auto posting server count");
            }
        }

        /// <summary> Post server count every 10 minutes  </summary>
        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (!Disabled)
                PostAll(LogType, BotBlock);
        }

        /// <summary> Post your server count to all botlist manually of with BotBlock.org  </summary>
        private void PostAll(LogType type, bool botblock)
        {
            if (botblock)
                SendBotBlock(type);
            else
            {
                ListType.PostAll(type);
            }
        }

        public readonly string Version = "3.4";

        /// <summary> Post server count to BotBlock.org </summary>
        public void SendBotBlock(LogType type)
        {
            bool isError = false;
            if (Http == null)
            {
                if (Discord == null)
                {
                    Log(type, LogType.Error, "Cannot post server count, Discord client is null");
                    isError = true;
                }
                else if (Discord.CurrentUser == null)
                {
                    Log(type, LogType.Error, "Cannot post server count, CurrentUser is null");
                    isError = true;
                }
                Http = new HttpClient();
                Http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                Http.DefaultRequestHeaders.Add("User-Agent", $"BotListAPI {Version} - " + Discord.CurrentUser.ToString());
            }
            if (!isError)
            {
                string JsonString = JsonConvert.SerializeObject(new ListJson(Discord, Config));

                try
                {
                    StringContent Content = new StringContent(JsonString, Encoding.UTF8, "application/json");
                    Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    HttpResponseMessage Res = Http.PostAsync("https://botblock.org/api/count", Content).GetAwaiter().GetResult();
                    if (Res.IsSuccessStatusCode)
                    {
                            Log(type, LogType.Info, $"Successfully posted server count to BotBlock");
                            Log(type, LogType.Debug, "Request response in JSON\n" + JsonConvert.SerializeObject(Res, Formatting.Indented));
                    }
                    else
                    {
                        Log(type, LogType.Error, $"Error could not post server count to BotBlock, {(int)Res.StatusCode} {Res.ReasonPhrase}");
                        Log(type, LogType.Debug, "Request response in JSON\n" + JsonConvert.SerializeObject(Res, Formatting.Indented));
                    }
                }
                catch (Exception ex)
                {
                    Log(type, LogType.Error, $"Error could not post server count to BotBlock, {ex.Message}");
                    Log(type, LogType.Debug, "Exception\n" + ex.ToString());
                }

                if (ListType.Carbonitex.Enabled && Config.Carbonitex != "")
                    ListType.Carbonitex.Post(type);

                if (ListType.DiscordBotList.Enabled && Config.DiscordBotList != "")
                    ListType.DiscordBotList.Post(type);
            }
        }

        internal void Log(LogType type, LogType Match, string text)
        {
            MessageLog?.Invoke(type, text);
            if (type >= Match)
                Console.WriteLine("[BotListAPI] " + text);
        }
    }
    
    public enum LogType
    {
        /// <summary> Dont log anything to console </summary>
        None,

        /// <summary> Only log errors </summary>
        Error,

        /// <summary> Log success and errors </summary>
        Info,

        /// <summary> Log everything including request responses in json to console </summary>
        Debug
    }
}
