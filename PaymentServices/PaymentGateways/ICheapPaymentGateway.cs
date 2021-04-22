using PaymentServices.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentServices.PaymentGateways
{
    public interface ICheapPaymentGateway
    {
        public Task<string> ProcessCheapPaymentAsync(PaymentRequest request);
    }
}
