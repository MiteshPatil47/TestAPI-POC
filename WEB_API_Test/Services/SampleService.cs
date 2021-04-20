using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using WEB_API_Test.Models;

namespace WEB_API_Test.Services
{
    public class SampleService
    {
        public void PostAsync()
        {
            using (var httpClient = new HttpClient())
            {

                TestModels models = new TestModels();
                var myDict = new Dictionary<string, string>
                    {
                        { "key1", "value1" },
                        { "key2", "value2" }
                    };
                //var baseUrl = Request.Url.GetLeftPart(UriPartial.Authority);
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var uri = new Uri("https://localhost:44335/api/values/GetFileData");
                using (var formData = new MultipartFormDataContent())
                {
                    //add content to form data
                    formData.Add(new StringContent(JsonConvert.SerializeObject(models)), "customer");
                   
                    var response = httpClient.PostAsync(uri, formData).Result;
                    string res = "";
                    using (HttpContent content = response.Content)
                    {
                        // ... Read the string.
                        var result = content.ReadAsByteArrayAsync();
                        //res = result.Result;
                    }
                }
            }
        }
    }
}