using Discord.WebSocket;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace BotListAPI
{
    /// <summary> BotListAPI client to post server count </summary>
    public class ListClient
    {
        public readonly ListConfig Config = new ListConfig();

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
            if (config == null)
                throw new ArgumentException("The list config cannot be null");
            Discord = client;
            Config = config;
            if (Config.DiscordBotListv2 != "" && !Config.DiscordBotListv2.StartsWith("Bot"))
                Config.DiscordBotListv2 = "Bot " + Config.DiscordBotListv2;

            Timer = new Timer
            {
                Interval = 600000,
                Enabled = false
            };
            Timer.Elapsed += Timer_Elapsed;
        }

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
            if (Discord != null && !Disabled)
                _ = SendBotBlock(LogType);
        }

        public readonly string Version = "5.0";

        /// <summary> Post server count to BotBlock.org </summary>
        public async Task SendBotBlock(LogType type)
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
                ListJson Json = Config.GetJson();
                Json.SetCount(Discord);
                
                string JsonString = JsonConvert.SerializeObject(Json);
                try
                {
                    StringContent Content = new StringContent(JsonString, Encoding.UTF8, "application/json");
                    Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    HttpResponseMessage Res = await Http.PostAsync("https://botblock.org/api/count", Content);
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
