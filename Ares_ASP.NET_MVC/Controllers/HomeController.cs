using Ares_ASP.NET_MVC.Interface;
using Ares_ASP.NET_MVC.Models;
using Ares_ASP.NET_MVC.Services;
using System.Web.Mvc;

namespace Ares_ASP.NET_MVC.Controllers
{
    public class HomeController : Controller
    {
        private AresService service = new AresService();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Firm firmInput)
        {
            if (ModelState.IsValid)
            {
                IFirm firmResult = service.Find(firmInput.ICO);

                return View(firmResult);
            }

            return View();
        }
    }
}