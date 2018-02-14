using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using form_submission.Models;

namespace form_submission.Controllers
{
    public class HelloController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult index()
        {
            return View();
        }



        [HttpPost]
        [Route("addUser")]
        // public IActionResult addUser(string firstname, string lastname, int age, string email, string password)
        public IActionResult addUser(Users user)
        {
            if (ModelState.IsValid)
            {
                string query = $"INSERT INTO users (first_name, last_name, age, email, password, created_at, updated_at) VALUES ('{user.first_name}','{user.last_name}','{user.age}','{user.email}','{user.password}', NOW(), NOW())";
                DbConnector.Execute(query);

                return RedirectToAction("success");
            }
            else
            {
                ViewBag.allErrors = ModelState.Values;
                ViewBag.status = "fail";
                return View("index");
            }
            
        }

        [HttpGet]
        [Route("success")]
        public IActionResult success()
        {
            return View("success");
        }
    }
}