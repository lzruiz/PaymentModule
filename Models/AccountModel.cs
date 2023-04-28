using System.ComponentModel.DataAnnotations;
namespace PaymentModule.Models
{
    public class AccountModel
    {
        [Required]
        public string accountNumber { get; set; }
        [Required]
        public string accountHolder { get; set; }
        public string customerAddress { get; set; }
    }
}
