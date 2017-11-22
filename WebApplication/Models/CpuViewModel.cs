using System.ComponentModel.DataAnnotations;
using DomainModel.Models;

namespace WebApplication.Models
{
    public class CpuViewModel: ItemViewModel
    {
        [Required(ErrorMessage = "Please enter cpu model")]
        public int CpuModel { get; set; }

        [Required(ErrorMessage = "Please enter family name")]
        public string FamilyName { get; set; }

        [Required(ErrorMessage = "Please enter frequency")]
        public int Frequency { get; set; }

        public override void Edit(Item itemToUpdate)
        {
            base.Edit(itemToUpdate);

            ((CPU) itemToUpdate).CpuModel = CpuModel;
            ((CPU) itemToUpdate).FamilyName = FamilyName;
            ((CPU) itemToUpdate).Frequency = Frequency;
        }
    }
}