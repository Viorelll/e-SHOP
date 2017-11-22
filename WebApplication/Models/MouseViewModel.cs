using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class MouseViewModel : ItemViewModel
    {
        [Required(ErrorMessage = "Please enter mouse model")]
        public string MouseModel { get; set; }

        [Required(ErrorMessage = "Please enter type")]
        public string Type { get; set; }

        [Required(ErrorMessage = "Please enter dpi")]
        public int Dpi { get; set; }

    }
}