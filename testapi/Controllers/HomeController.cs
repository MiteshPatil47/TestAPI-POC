using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Mvc;
using testapi.Models;

namespace testapi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            TestAPi();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        private void Postasyn()
        {
            using (var client = new System.Net.Http.HttpClient())
            {
                // HTTP POST
                var baseUrl = Request.Url.GetLeftPart(UriPartial.Authority);
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Customer customer = new Customer() { ID = "001", name = "testname 20 " };
                //Order order = new Order() { ID = "001Oder" };
                var myDict = new Dictionary<string, object>
                    {
                        { "key1", "value1" },
                        { "key2", "value2" }
                    };
                ArrayList paramList = new ArrayList();
                paramList.Add(myDict);
                paramList.Add(myDict);
                string contents = JsonConvert.SerializeObject(paramList);
                var response = client.PostAsync("/api/values/GetFormData", new StringContent(contents, Encoding.UTF8, "application/json")).Result;
                string res = "";
                using (HttpContent content = response.Content)
                {
                    // ... Read the string.
                    var result = content.ReadAsStringAsync();
                    res = result.Result;
                }
            }
        }

        private void TestAPi()
        {
            using (var httpClient = new HttpClient())
            {
                Customer customer = new Customer() { ID = "001", name = "testname 20 " };
                Order order = new Order() { ID = "001Oder" };
                var baseUrl = Request.Url.GetLeftPart(UriPartial.Authority);
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var uri = new Uri(baseUrl + "/api/Values/PostFormData?CustomerID=001");
                using (var formData = new MultipartFormDataContent())
                {
                    //add content to form data
                    formData.Add(new StringContent(JsonConvert.SerializeObject(customer)), "customer");
                    //add config to form data
                    formData.Add(new StringContent(JsonConvert.SerializeObject(order)), "order");
                    var response = httpClient.PostAsync(uri, formData).Result;
                    string res = "";
                    using (HttpContent content = response.Content)
                    {
                        // ... Read the string.
                        var result = content.ReadAsStringAsync();
                        res = result.Result;
                    }
                }
            }
        }
    }
}