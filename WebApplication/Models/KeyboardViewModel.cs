using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class KeyboardViewModel : ItemViewModel
    {
        [Required(ErrorMessage = "Please enter frequency")]
        public string KeyboardModel { get; set; }

        [Required(ErrorMessage = "Please enter type")]
        public string Type { get; set; }

        [Required(ErrorMessage = "Please enter keyboard interface")]
        public string KeyboardInterface { get; set; }
    }
}