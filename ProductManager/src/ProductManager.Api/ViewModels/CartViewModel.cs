using System.ComponentModel.DataAnnotations;

namespace ProductManager.Api.ViewModels
{
    public class CartViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public CartHeaderViewModel CartHeader { get; set; }

        public IEnumerable<CartItemViewModel> CartItems { get; set; }

        public bool IsClosed { get; set; }
    }
}
