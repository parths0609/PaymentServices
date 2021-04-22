using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentServices.Entities
{
    public partial class PaymentContext : DbContext
    {
       
            public PaymentContext()
            {
            }

            public PaymentContext(DbContextOptions<PaymentContext> options)
                : base(options)
            {
            }

            public virtual DbSet<PaymentRequest> PaymentRequest { get; set; }
            public virtual DbSet<PaymentStatus> PaymentStatus { get; set; }

        }
}
