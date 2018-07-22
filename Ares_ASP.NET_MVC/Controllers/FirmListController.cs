using Ares_ASP.NET_MVC.Models;
using System.Web.Mvc;

namespace Ares_ASP.NET_MVC.Controllers
{
    public class FirmListController : Controller
    {
        public ActionResult Index()
        {
            FirmList list = null;

            if (ModelState.IsValid)
                list = new FirmList();

            return View(list);
        }
    }
}