using System.ComponentModel.DataAnnotations;
using DomainModel.Models;

namespace WebApplication.Models
{
    public abstract class ItemViewModel
    {
        public long Id { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please enter price")]
        [DataType(DataType.Currency)]
        [Range(1, 10000)]
        public double Price { get; set; }

        [Required(ErrorMessage = "Please enter name")]
        [StringLength(32)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter brand")]
        [StringLength(32)]
        public string Brand { get; set; }

        [Required(ErrorMessage = "Please enter category")]
        public CATEGORY Category { get; set; }

        public virtual void Edit(Item itemToUpdate)
        {
            itemToUpdate.Name = Name;
            itemToUpdate.Brand = Brand;
            itemToUpdate.Price = Price;
            itemToUpdate.Description = Description;
        }
    }
}
