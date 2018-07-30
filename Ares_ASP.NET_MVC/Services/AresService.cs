using Ares_ASP.NET_MVC.AresReference;
using Ares_ASP.NET_MVC.Interface;
using Ares_ASP.NET_MVC.Models;
using System.Collections.Generic;
using System.Linq;

namespace Ares_ASP.NET_MVC.Services
{
    /// <summary>
    /// Třída pro práci s ares službou.
    /// </summary>
    public class AresService
    {
        private FirmContext context = ContextService.CreateInstance();

        private FirmListService firmListService = FirmListService.CreateInstance();

        private HttpSoapBasicClient httpSoapBasicClient = new HttpSoapBasicClient();

        private string url = "http://wwwinfo.mfcr.cz/ares/xml_doc/schemas/ares/ares_answer_basic/v_1.0.3";

        /// <summary>
        /// Nalezne, uloží a vrací firmu dle IČO. 
        /// </summary>
        /// <param name="ico">IČO. </param>
        /// <returns>Firmu dle IČO. </returns>
        public IFirm Find(string ico)
        {
            var firms = getFromLocalDB(ico);
        
            if (firms != null && firms.Any())
                return firms.FirstOrDefault();

            var result = getFirmsFromAresAPI(ico);

            if (result?.VBAS == null)
                return new FirmNullObject();

            var firm = new Firm()
            {
                Name = result.VBAS[0].OF.Value,
                ICO = result.VBAS[0].ICO.Value
            };

            save(firm);

            return firm;
        }

        /// <summary>
        /// Hledá firmu v lokální databázi dle ičo.
        /// </summary>
        /// <param name="ico">ičo.</param>
        /// <returns></returns>
        private IEnumerable<Firm> getFromLocalDB(string ico)
            => firmListService.GetFirmList()
                .Firms.Where(item => item.ICO.Equals(ico));

        /// <summary>
        /// Ukládá nově vyhledanou firmu do lokální databáze.
        /// </summary>
        /// <param name="firm">Firma k uložení.</param>
        private void save(Firm firm)
        {
            context.Firms.Add(firm);
            context.SaveChanges();
        }

        /// <summary>
        /// Vyhledá firmu dle ičo v ares službě.
        /// </summary>
        /// <param name="ico">ičo hledané firmy.</param>
        /// <returns>Výsledek hledání.</returns>
        private odpoved_basic getFirmsFromAresAPI(string ico)
        {
            // sestavení dotazu
            dotaz dotaz = new dotaz();

            dotaz.Items = new object[] 
            {
                ico
            };

            dotaz.ItemsElementName = new ItemsChoiceType[]
            {
                ItemsChoiceType.ICO
            };

            Ares_dotazy aresDotazy = new Ares_dotazy();

            aresDotazy.Dotaz = new dotaz[] { dotaz };

            aresDotazy.dotaz_typ = ares_dotaz_typ.Basic;

            aresDotazy.answerNamespaceRequired = url;

            // dotaz na službu
            Ares_odpovedi aresOdpovedi = httpSoapBasicClient.GetXmlFile(aresDotazy);

            // výsledek
            return aresOdpovedi.Odpoved[0];
        }
    }
}