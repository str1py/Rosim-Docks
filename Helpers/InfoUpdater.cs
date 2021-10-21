using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RosreestDocks.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RosreestDocks.Helpers
{
    public class InfoUpdater
    {
        private readonly DataBaseContext db;
        private MainVars MainVars;
        public InfoUpdater(DataBaseContext context)
        {
            db = context;
            MainVars = new(db);
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
        public async Task GetData()
        {
            var list = db.Agency.ToList();

            foreach (var item in list)
            {
    
                var json = await GetAsync("https://www.rusprofile.ru/ajax.php?query=" + Base64Encode(item.Name) + "&action=search");
                var response = "dsfsfdsfsd";
            }
        }

        public async Task<JObject> GetAsync(string uri)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = (await httpClient.GetAsync(uri)).EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            JObject jObject = JObject.Parse(responseBody);

            return jObject;
        }
    }
}
