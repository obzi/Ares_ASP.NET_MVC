using Ares_ASP.NET_MVC.AresReference;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Ares_ASP.NET_MVC.Models
{
    /// <summary>
    /// Třída představující firmu z ARES API
    /// </summary>
    public class Firm
    {
        private FirmList firmList = new FirmList();

        /// <summary>
        /// ID
        /// </summary>  
        /// [Key]
        public long Id { get; set; }

        /// <summary>
        /// Název firmy. 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// IČO firmy.
        /// </summary>
        [Display(Name = "Vyhledej firmu dle IČO.")]
        [Required(ErrorMessage ="Vyplňte povinné pole!")]
        public string ICO { get; set; }

        /// <summary>
        /// Nalezne, uloží a vrací firmu dle IČO. 
        /// </summary>
        /// <param name="ico">IČO. </param>
        /// <returns>Firmu dle IČO. </returns>
        public Firm Find(string ico)
        {
            var firms = firmList.GetFirmList()?.Where(item => item.ICO.Equals(ico));

            if (firms != null && firms.Any())
                return firms.FirstOrDefault();

            var result = getFirms(ico);

            if (result.VBAS != null)
            {
                var firm = new Firm()
                {
                    Name = result.VBAS[0].OF.Value,
                    ICO = result.VBAS[0].ICO.Value
                };

                firmList.context.Firms.Add(firm);
                firmList.context.SaveChanges();

                return firm;
            }

            return null;
        }

        private odpoved_basic getFirms(string ico)
        {                      
            ItemsChoiceType typ = ItemsChoiceType.ICO;
            ItemsChoiceType[] itemsNames = new ItemsChoiceType[] { typ };

            dotaz dotaz = new dotaz();
            dotaz.Items = new object[] { ico };
            dotaz.ItemsElementName = itemsNames;

            Ares_dotazy aresDotazy = new Ares_dotazy();
            aresDotazy.Dotaz = new dotaz[] { dotaz };
            aresDotazy.dotaz_typ = ares_dotaz_typ.Basic;
            aresDotazy.answerNamespaceRequired = "http://wwwinfo.mfcr.cz/ares/xml_doc/schemas/ares/ares_answer_basic/v_1.0.3";

            var httpSoapBasicClient = new HttpSoapBasicClient();
            Ares_odpovedi aresOdpovedi = httpSoapBasicClient.GetXmlFile(aresDotazy);

            return aresOdpovedi.Odpoved[0];
        }
    }
}