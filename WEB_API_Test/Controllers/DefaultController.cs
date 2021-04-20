using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WEB_API_Test.Models;

namespace WEB_API_Test.Controllers
{
    public class DefaultController : ApiController
    {
        // GET: api/Default
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Default/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Default
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Default/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Default/5
        public void Delete(int id)
        {
        }
        [HttpPost]
        public byte[] GetFileData([FromBody] TestModels model)
        {
            string pdfFilePath = "c:/pdfdocuments/myfile.pdf";
            byte[] bytes = System.IO.File.ReadAllBytes(pdfFilePath);
            return bytes;
        }
    }
}
