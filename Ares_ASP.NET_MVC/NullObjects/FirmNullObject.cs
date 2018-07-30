using Ares_ASP.NET_MVC.Interface;

namespace Ares_ASP.NET_MVC
{
    public class FirmNullObject : IFirm
    {
        public string Zprava
            => "IČO nenalezeno!";

        public string Name { get; set; } = null;

        public string ICO { get; set; } = null;
    }
}