using ContactUI.Models;
using ContactUtilities;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ContactUI.Services
{
    public static class APIHelper
    {
        public static IConfiguration _configuration;
              
        public static IConfiguration Configuration
        {
            get { return _configuration; }
            set { _configuration = value; }
        }
        public static string Baseurl
        {
            get { return Configuration.GetSection("AppSettings:ServiceURL").Value; }
           
        }
       
        public async static Task<T> HttpGet<T> (string url)
        {
                      
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                
                HttpResponseMessage Res = await client.GetAsync(url);
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var ContactResponse = Res.Content.ReadAsStringAsync().Result;
                    
                     var result = JsonConvert.DeserializeObject<T>(ContactResponse);
                    return result;
                }
               
                return (JsonConvert.DeserializeObject<T>(string.Empty));
            }

        }

        public async static Task<T> HttpPost<T>(string url, Contact contact)
        {
           

            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                
                HttpResponseMessage Res = await client.PostAsJsonAsync(url, contact);
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var ContactResponse = Res.Content.ReadAsStringAsync().Result;
                    
                    var result = JsonConvert.DeserializeObject<T>(ContactResponse);
                    return result;
                }
                
                return (JsonConvert.DeserializeObject<T>(string.Empty));
            }

        }

        public static int HttpDelete(string url)
        {
            

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                var response = client.DeleteAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    return 1;
                }
                else
                    return -1;
            }

        }


    }
}
