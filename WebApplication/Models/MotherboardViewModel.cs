using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class MotherboardViewModel : ItemViewModel
    {
        [Required(ErrorMessage = "Please enter motherboard model")]
        [StringLength(32)]
        public string MbModel { get; set; }

        [Required(ErrorMessage = "Please enter format")]
        [StringLength(12)]
        public string Format { get; set; }

        [Required(ErrorMessage = "Please enter processor socket")]
        [StringLength(12)]
        public string ProcessorSocket { get; set; }

        [Required(ErrorMessage = "Please enter processor manufacturer")]
        [StringLength(32)]
        public string ProcessorManufacturer { get; set; }

        [Required(ErrorMessage = "Please enter hdd interface")]
        [StringLength(12)]
        public string HDDInterface { get; set; }

        [Required(ErrorMessage = "Please enter memory type")]
        [StringLength(12)]
        public string MemoryType { get; set; }

        [Required(ErrorMessage = "Please enter video connection")]
        public bool VideoConnection { get; set; }

        [Required(ErrorMessage = "Please enter audio connection")]
        public bool AudioConnection { get; set; }
    }
}