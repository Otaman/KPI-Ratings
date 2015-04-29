using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking.Connectivity;

namespace KPI_Ratings.API
{
    public class Login
    {
        public static string Auth(string login, string password)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:62496");
                var content = new FormUrlEncodedContent(new[] 
                {
                    new KeyValuePair<string, string>("login", login),
                    new KeyValuePair<string, string>("password", password)

                });

                var result = client.PostAsync("/Ratings/Auth", content).Result;
                string resultContent = result.Content.ReadAsStringAsync().Result;
                Debug.WriteLine("OLOLO: " + resultContent);
                return resultContent;
            }            
        }
    }
}
