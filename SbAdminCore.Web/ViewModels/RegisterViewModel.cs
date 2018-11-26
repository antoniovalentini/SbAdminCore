using System.ComponentModel.DataAnnotations;

namespace SbAdminCore.Web.ViewModels
{
    public class RegisterViewModel : LoginViewModel
    {
        [Required]
        [Display(Name = "Firstname")]
        public string Firstname { get; set; }

        [Required]
        [Display(Name = "Lastname")]
        public string Lastname { get; set; }
    }
}
