using Contactus1.DataBase;
using Contactus1.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContactForm_US.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(int id)
        {
            ViewBag.message = id;
            ViewData["Message2"] = "Amirhossein";
            TempData["Message3"] = "Mokhtari";
            return View();
        }

        [HttpGet("/codeYad/Privacy/{name}/{id:int}")]
        public IActionResult Privacy(string name, int id, string address)
        {
            return View(model: name);
        }

        public IActionResult Messages()
        {
            return View(DataBase.Messagess);

        }

        [HttpPost]
        public IActionResult SendMessage(Message message)
        {
            if(!ModelState.IsValid)
            {
                return View("index", message);
            }
            if (message.PhoneNumber.Length == 11)
            {
                TempData["IsSuccess"] = true;
                DataBase.Messagess.Add(message);
            }
              
            return Redirect("/home/Messages");
        }
    }
}
