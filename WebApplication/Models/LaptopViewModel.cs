using System.ComponentModel.DataAnnotations;
using DomainModel.Models;

namespace WebApplication.Models
{
    public class LaptopViewModel : ItemViewModel
    {
        [Required(ErrorMessage = "Please enter laptop model")]
        [StringLength(32)]
        public string LaptopModel { get; set; }

        [Required(ErrorMessage = "Please enter sistem operation")]
        [StringLength(22)]
        public string SistemOperation { get; set; }

        [Required(ErrorMessage = "Please enter display type")]
        [StringLength(12)]
        public string DisplayType { get; set; }

        [Required(ErrorMessage = "Please enter display size")]
        [Range(1, 128)]
        public double DisplaySize { get; set; }

        [Required(ErrorMessage = "Please enter resolution")]
        public Resolution Resolution { get; set; }

        [Required(ErrorMessage = "Please enter processor manufacturer")]
        [StringLength(12)]
        public string ProcessorManufacturer { get; set; }

        [Required(ErrorMessage = "Please enter processor model")]
        [StringLength(22)]
        public string ProcessorModel { get; set; }

        [Required(ErrorMessage = "Please enter processor frequency")]
        [Range(1, 10000)]
        public int ProcessorFrequency { get; set; }

        [Required(ErrorMessage = "Please enter memory capacity")]
        [Range(1, 100)]
        public int MemoryCapacity { get; set; }

        [Required(ErrorMessage = "Please enter hdd capacity")]
        [Range(1, 10000)]
        public int HDDCapacity { get; set; }

        [Required(ErrorMessage = "Please enter wight")]
        [Range(1, 32)]
        public double Weight { get; set; }

        [Required(ErrorMessage = "Please enter videocard model")]
        [StringLength(32)]
        public string VideocardModel { get; set; }

        [Required(ErrorMessage = "Please enter wifi connection")]
        public bool WifiConnection { get; set; }

        [Required(ErrorMessage = "Please enter bluethooth connection")]
        public bool BluetoothConnection { get; set; }
    }
}