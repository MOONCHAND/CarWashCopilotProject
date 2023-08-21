using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CarWashCopilot.Model
{
    public class Admin
    {
        public int Id { get; set; }
        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Email Address is required")]
        [StringLength(60)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]      
        [StringLength(10)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
