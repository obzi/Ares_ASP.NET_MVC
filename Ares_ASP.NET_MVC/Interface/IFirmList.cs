using Ares_ASP.NET_MVC.Models;
using System.Collections.Generic;

namespace Ares_ASP.NET_MVC.Interface
{
    public interface IFirmList
    {
        IEnumerable<Firm> Firms { get; }
    }
}
