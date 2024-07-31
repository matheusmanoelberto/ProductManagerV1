using ProductManager.Domain.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace ProductManager.Api.ViewModels
{
    public class CartItemViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid ProductId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid CartId { get; set; } = Guid.Empty;
    }
}
