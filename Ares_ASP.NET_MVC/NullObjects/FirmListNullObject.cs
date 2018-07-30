using Ares_ASP.NET_MVC.Interface;
using Ares_ASP.NET_MVC.Models;
using System.Collections.Generic;

namespace Ares_ASP.NET_MVC.NullObjects
{
    public class FirmListNullObject : IFirmList
    {
        public IEnumerable<Firm> Firms
            => new List<Firm>();
    }
}