using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class RamViewModel : ItemViewModel
    {

        [Required(ErrorMessage = "Please enter type")]
        [StringLength(12)]
        public string Type { get; set; }


        [Required(ErrorMessage = "Please enter capacity")]
        [Range(1, 100)]
        public int Capacity { get; set; }


        [Required(ErrorMessage = "Please enter frequency")]
        [Range(1, 5000)]
        public int Frequency { get; set; }

    }
}