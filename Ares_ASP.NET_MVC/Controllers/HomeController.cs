using Ares_ASP.NET_MVC.Models;
using System.Web.Mvc;

namespace Ares_ASP.NET_MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Firm firmInput)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Zprava = null;

                Firm firm = new Firm();
                Firm firmResult = firm.Find(firmInput.ICO);

                if (firmResult == null)
                    ViewBag.Zprava = "IČO nenalezeno!";

                else
                {
                    ViewBag.Name = firmResult.Name;
                    ViewBag.ICO = firmResult.ICO;
                }              
            }

            return View();
        }
    }
}