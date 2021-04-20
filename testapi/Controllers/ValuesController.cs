using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using testapi.Models;

namespace testapi.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
        [AllowAnonymous]
        //http://localhost:29679/api/Values?CustomerID=001
        [HttpPost]
        public HttpResponseMessage PostFormData([FromUri] string CustomerID) //, [FromBody] ArrayList paramList
        {
            string cusID = CustomerID;
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }
            var success = true;
            List<object> lista = new List<object>();
            var provider = new MultipartMemoryStreamProvider();
             Request.Content.ReadAsMultipartAsync(provider);
            foreach (var requestContents in provider.Contents)
            {
                if (requestContents.Headers.ContentDisposition.Name == "customer")
                {
                    Customer q1 = JsonConvert.DeserializeObject<Customer>(requestContents.ReadAsStringAsync().Result);
                    lista.Add(q1);
                }
                else if (requestContents.Headers.ContentDisposition.Name == "order")
                {
                    Order q1 = JsonConvert.DeserializeObject<Order>(requestContents.ReadAsStringAsync().Result);
                    lista.Add(q1);
                }
            }
            List<object> newshowlista = lista;
            HttpResponseMessage result = Request.CreateResponse(success ? HttpStatusCode.OK : HttpStatusCode.InternalServerError, success);
            return result;

        }
    }
}