using Ares_ASP.NET_MVC.Models;
using Ares_ASP.NET_MVC.Services;
using System.Web.Mvc;

namespace Ares_ASP.NET_MVC.Controllers
{
    public class HomeController : Controller
    {
        private Service service = new Service();

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
               
                Firm firmResult = service.Find(firmInput.ICO);

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