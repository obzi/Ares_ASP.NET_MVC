using Ares_ASP.NET_MVC.Models;

namespace Ares_ASP.NET_MVC.Services
{
    public class ContextService
    {
        private static FirmContext context = null;

        private ContextService() { }

        public static FirmContext CreateInstance()
            => context ?? new FirmContext();
    }
}