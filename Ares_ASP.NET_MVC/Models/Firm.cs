using Ares_ASP.NET_MVC.Interface;
using System.ComponentModel.DataAnnotations;

namespace Ares_ASP.NET_MVC.Models
{
    /// <summary>
    /// Třída představující firmu z ARES API
    /// </summary>
    public class Firm : IFirm
    {
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
        [Required(ErrorMessage = "Vyplňte povinné pole!")]
        public string ICO { get; set; }

        public string Zprava { get; set; } = null;
    }
}