using System;
using System.Collections.Generic;
using System.Text;

namespace BotListAPI
{
    public class ListAPI
    {
        public readonly string Name;
        public readonly string Website;
        public readonly ListOwner Owner;
        public bool Enabled = true;
        public ListAPI(string name, string website, ListOwner owner)
        {
            Name = name;
            Website = website;
            Owner = owner;
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
