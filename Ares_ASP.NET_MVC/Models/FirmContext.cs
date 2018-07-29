using System.Data.Entity;

namespace Ares_ASP.NET_MVC.Models
{
    public class FirmContext : DbContext
    {
        public FirmContext()
            : base("FirmsDB") { }

        public DbSet<Firm> Firms { get; set; }
    }
}