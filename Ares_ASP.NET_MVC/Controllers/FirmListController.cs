using Ares_ASP.NET_MVC.Services;
using System.Web.Mvc;

namespace Ares_ASP.NET_MVC.Controllers
{
    public class FirmListController : Controller
    {
        private FirmListService firmListService = FirmListService.CreateInstance();

        public ActionResult Index()
        {
            if (ModelState.IsValid)
                return View(firmListService);

            return View();
        }
    }
}