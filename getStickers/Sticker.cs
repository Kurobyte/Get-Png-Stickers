using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace getStickers
{
    [JsonObject(MemberSerialization.OptIn)]
    class Sticker
    {
        private int packageId;
        private bool onSale;
        private Dictionary<string, string> title;
        private Dictionary<string, string> author;
        private List<Dictionary<string, string>> price; //Dictionary<string, string>
        private List<Dictionary<string, string>> stickers; //Dictionary<string, string>
        private bool hasAnimation;

        [JsonProperty("packageId")]
        public int PackageId
        {
            get { return packageId; }
            set { packageId = value; }
        }

        [JsonProperty("onSale")]
        public bool OnSale
        {
            get { return onSale; }
            set { onSale = value; }
        }

        [JsonProperty("title")]
        public Dictionary<string, string> Title
        {
            get { return title; }
            set { title = value; }
        }

        [JsonProperty("author")]
        public Dictionary<string, string> Author
        {
            get { return author; }
            set { author = value; }
        }

        [JsonProperty("price")]
        public List<Dictionary<string, string>> Price
        {
            get { return price; }
            set { price = value; }
        }

        [JsonProperty("stickers")]
        public List<Dictionary<string, string>> Stickers
        {
            get { return stickers; }
            set { stickers = value; }
        }

        [JsonProperty("hasAnimation")]
        public bool HasAnimation
        {
            get { return hasAnimation; }
            set { hasAnimation = value; }
        }
    }
}
