using Ares_ASP.NET_MVC.Interface;
using Ares_ASP.NET_MVC.Services;
using System.Collections.Generic;
using System.Linq;

namespace Ares_ASP.NET_MVC.Models
{
    public class FirmList : IFirmList
    {
        private FirmContext context = ContextService.CreateInstance();

        /// <summary>
        /// Seznam všech firem ulžoených v localDb
        /// </summary>
        public IEnumerable<Firm> Firms
            => context.Firms.ToList();
    }
}