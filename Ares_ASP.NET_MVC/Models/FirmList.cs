using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Ares_ASP.NET_MVC.Models
{
    public class FirmList
    {
        public FirmContext context = new FirmContext();

        /// <summary>
        /// Seznam všech firem ulžoených v localDb
        /// </summary>
        private DbSet<Firm> firms 
            => context.Firms;

        /// <summary>
        /// Vrací seznam všech firem uložených v localDb.
        /// </summary>
        /// <returns>Seznam všech firem z localDb. </returns>
        public List<Firm> GetFirmList()
            => firms?.ToList() ?? null;
    }
}