using Discord.WebSocket;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace BotListAPI
{
    public class ListAPI
    {
        public readonly string Name;
        public readonly string Website;
        public string API;
        public readonly ListOwner Owner;
        public bool Enabled = true;
        public HttpClient Http;
        public ListAPI(string name, string website, string api, ListOwner owner)
        {
            Name = name;
            Website = website;
            API = api;
            Owner = owner;
        }

        public bool Post(BaseSocketClient client, string token)
        {
            if (Http == null)
            {
                Http = new HttpClient();
                Http.DefaultRequestHeaders.Add("Authorization", token);
                API = API.Replace("{0}", client.CurrentUser.Id.ToString());
            }
            try
            {
                StringContent Content = new StringContent("{ \"server_count\": 0 }".Replace("0", client.Guilds.Count.ToString()), Encoding.UTF8, "application/json");
                Http.PostAsync(API, Content);
            }
            catch(Exception)
            {
                return false;
            }
            return true;
        }
    }
    public class ListOwner
    {
        public ListOwner(string name, ulong id)
        {
            Name = name;
            Id = id;
        }
        public string Name;
        public ulong Id;
    }
}
