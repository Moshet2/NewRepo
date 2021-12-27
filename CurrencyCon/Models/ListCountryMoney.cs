using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CurrencyCon.Models
{
    public class ListCountryMoney
    {
        [JsonProperty("success")]
        public bool success { get; set; }

        [JsonProperty("timestamp")]
        public int timestamp { get; set; }

        [JsonProperty("base")]
        public string based { get; set; }

        [JsonProperty("date")]
        public DateTime date { get; set; }

        [JsonProperty("rates")]
        public  Dictionary<string,string> rates { get; set; }
    }
}