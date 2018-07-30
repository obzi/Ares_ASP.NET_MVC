using Ares_ASP.NET_MVC.Interface;
using Ares_ASP.NET_MVC.Models;
using Ares_ASP.NET_MVC.NullObjects;
using System.Linq;

namespace Ares_ASP.NET_MVC.Services
{
    public class FirmListService
    {
        private FirmContext context = ContextService.CreateInstance();

        private FirmList firmList = new FirmList();

        private static FirmListService serviceInstance = null;

        private FirmListService() { }

        public static FirmListService CreateInstance()
            => serviceInstance ?? new FirmListService();

        /// <summary>
        /// Vrací seznam všech firem uložených v localDb.
        /// </summary>
        /// <returns>Seznam všech firem z localDb. </returns>
        public IFirmList GetFirmList()
        {
            if (context.Firms == null || !context.Firms.Any())
                return new FirmListNullObject();

            return firmList;
        }
    }
}