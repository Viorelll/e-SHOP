using System.ComponentModel.DataAnnotations;
using DomainModel.Models;

namespace WebApplication.Models
{
    public class WebcamViewModel : ItemViewModel
    {
        [Required(ErrorMessage = "Please enter webcam model")]
        [StringLength(12)]
        public string WebcamModel { get; set; }

        [Required(ErrorMessage = "Please enter webcam interface")]
        [StringLength(12)]
        public string WebcamInterface { get; set; }

        [Required(ErrorMessage = "Please enter pixels")]
        [Range(1, 50)]
        public double Pixels { get; set; }

        [Required(ErrorMessage = "Please enter video resolution")]
        public Resolution VideoResolution { get; set; }

        [Required(ErrorMessage = "Please enter photo resolution")]
        public Resolution PhotoResolution { get; set; }

    }
}