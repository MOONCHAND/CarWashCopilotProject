using System.ComponentModel.DataAnnotations;

namespace CarWashCopilot.Model
{
    public class Cardetails
    {
        public int Id { get; set; }
        [Required]
        public string Carmodel { get; set; }
        [Required]
        public string Status { get; set; }
    }
}
