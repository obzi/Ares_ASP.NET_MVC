using System.ComponentModel.DataAnnotations;

namespace Ares_ASP.NET_MVC.Interface
{
    public interface IFirm
    {
        string Name { get; set; }

        [Display(Name = "Vyhledej firmu dle IČO.")]
        [Required(ErrorMessage = "Vyplňte povinné pole!")]
        string ICO { get; set; }

        string Zprava { get; }
    }
}