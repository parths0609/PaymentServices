using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentServices.Entities
{
    [Table(name:"PaymentStatus")]
    public class PaymentStatus
    {
        [Column]
        [Key]
        public int LogId { get; set; }

        [Column]
        public PaymentRequest CreditCardNo { get; set; }

        [Column]
        [Required]
        public string PaymentState { get; set; }
    }
}
