using PostAsync.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

namespace PostAsync.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            TestApiPost();
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

        [HttpPost]
        //[Route("PostStudent")]
        public StudentViewModel PostNewStudent(StudentViewModel student)
        {
            student.Id = 12;
            student.FirstName = "Mit";
            student.LastName = "Patil";
            return student;
        }
        private void TestApiPost()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44359/Home/");
                var student = new StudentViewModel() { FirstName = "Steve", LastName = "rats", Id = 13 };

                var postTask = client.PostAsJsonAsync<StudentViewModel>("PostNewStudent", student);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<StudentViewModel>();
                    readTask.Wait();

                    var insertedStudent = readTask.Result;

                    Console.WriteLine("Student {0} inserted with id: {1}", insertedStudent.FirstName, insertedStudent.Id);
                }
                else
                {
                    Console.WriteLine(result.StatusCode);
                }
            }
        }
    }
}