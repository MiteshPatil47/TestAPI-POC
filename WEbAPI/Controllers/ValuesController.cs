using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WEbAPI.Models;

namespace WEbAPI.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST 
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
        [HttpPost]
        // POST https://localhost:44335/api/values/GetFileData
        public byte[] GetFileData([FromBody] TestModels model)
        {
            string pdfFilePath = "c:/pdfdocuments/myfile.pdf";
            byte[] bytes = System.IO.File.ReadAllBytes(pdfFilePath);
            return bytes;
        }
    }
}
