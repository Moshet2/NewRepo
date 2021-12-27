using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CurrencyCon.Models
{
    public class CountryMoney<TKey, TValue>
    {
        public TKey Key { get; set; }
        public TValue Value { get; set; }
    } 
}