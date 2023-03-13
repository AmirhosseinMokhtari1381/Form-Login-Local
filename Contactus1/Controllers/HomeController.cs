using Contactus1.DataBase;
using Contactus1.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContactForm_US.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.message = "Salam";
            ViewData["Message2"] = "Amirhossein";
            TempData["Message3"] = "Mokhtari";
            return View();
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
