using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DemoAPI.Model;
using Newtonsoft.Json;


namespace DemoAPI.Service
{
    public class APIHelper
    {
        public async Task<string> SaveStudent(StudentReg stud)
        {
           

            string APIUrl = "https://localhost:7151/api/User/Register";
            HttpClient client = new HttpClient();
            string json = JsonConvert.SerializeObject(stud);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(APIUrl, content);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        
        }



        public async Task<string> Getdata(StudentReg stud)
        {
            string APIUrl = "https://localhost:7151/api/User/Register";
            HttpClient client = new HttpClient();
            string json = JsonConvert.SerializeObject(stud);


            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(APIUrl),
                Content = new StringContent(json, Encoding.UTF8, "application/json"),
            };

            HttpResponseMessage response = await client.SendAsync(request).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();

        }




        public async Task<string> Getdata()
        {
            string APIUrl = "https://localhost:7151/api/User/Register";
            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync(APIUrl);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }




    }
}
