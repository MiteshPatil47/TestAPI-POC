using PostAsync.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PostAsync.Controllers
{
    public class StudentController : ApiController
    {
        public StudentController()
        {
        }

        //Get action methods of the previous section
        [HttpPost]
        //[Route("PostStudent")]
        public IHttpActionResult PostNewStudent(StudentViewModel student)
        {
            student.Id = 12;
            student.FirstName = "Mit";
            student.LastName = "Patil";
            return Ok(student);
        }
    }
}
