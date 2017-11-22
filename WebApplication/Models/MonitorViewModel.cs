using System.ComponentModel.DataAnnotations;
using DomainModel.Models;

namespace WebApplication.Models
{
    public class MonitorViewModel : ItemViewModel
    {
        [Required(ErrorMessage = "Please enter display size")]
        [Range(1, 100, ErrorMessage = "Display size must be between 1 and 100")]
        public double DisplaySize { get; set; }

        [Required(ErrorMessage = "Please enter display type")]
        [StringLength(12)]
        public string DisplayType { get; set; }

        [Required(ErrorMessage = "Please enter monitor model")]
        [StringLength(22)]
        public string MonitorModel { get; set; }

        public override void Edit(Item itemToUpdate)
        {
            base.Edit(itemToUpdate);

            ((Monitor)itemToUpdate).MonitorModel = MonitorModel;
            ((Monitor)itemToUpdate).DisplaySize = DisplaySize;
            ((Monitor)itemToUpdate).DisplayType = DisplayType;
        }
    }
}