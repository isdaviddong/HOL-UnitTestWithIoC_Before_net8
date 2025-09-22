using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace ConsoleApp1
{
    public class CurrencyConverter
    {
        const string API_KEY = "________________________"; //請自行申請
        public float Convert(string From, string To)
        {
            HttpClient hc = new HttpClient();
            var ret = hc.GetAsync($"https://v6.exchangerate-api.com/v6/{API_KEY}/pair/USD/TWD").Result;
            var JSON = ret.Content.ReadAsStringAsync().Result;

            dynamic data = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(JSON);
            return data.conversion_rate;
        }

    }
}
