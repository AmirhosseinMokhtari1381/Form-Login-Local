using Contactus1.DataBase;
using Contactus1.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContactForm_US.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Messages()
        {
            return View(DataBase.Messagess);

        }

        [HttpPost]
        public IActionResult SendMessage(Message message)
        {
            DataBase.Messagess.Add(message);    
            return Redirect("/home/Messages");
        }
    }
}
