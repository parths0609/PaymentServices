using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentServices.Entities
{
    public class PaymentRequest
    {
        [Column]
        [Required]
        [CreditCard]
        [Key]
        public string CreditCardNumber { get; set; }
        [Column]
        [Required]
        [RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-Za-z]+))$")]
        public string CardHolder { get; set; }
        [Column]
        [Required]
        [DateValidation(ErrorMessage = "Invalid date")]
        public DateTime ExpirationDate { get; set; }
        [Column]
        [MinLength(3, ErrorMessage = "Security code should be minimum 3 digits long")]
        public string SecurityCode { get; set; }
        [Column]
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Only positive amount allowed.")]
        public decimal Amount { get; set; }
    }

    public class DateValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime d = Convert.ToDateTime(value);
            return d >= DateTime.Now;
        }
    }
}
