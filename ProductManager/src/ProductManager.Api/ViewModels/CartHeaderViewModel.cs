using System.ComponentModel.DataAnnotations;

namespace ProductManager.Api.ViewModels
{
    public class CartHeaderViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string IdCartItem { get; set; }

        public bool IsClosed { get; set; }
    }
}
