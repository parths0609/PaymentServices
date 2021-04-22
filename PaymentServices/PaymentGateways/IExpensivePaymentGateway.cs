using PaymentServices.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentServices.PaymentGateways
{
    public interface IExpensivePaymentGateway
    {
        public Task<string> ProcessExpensivePaymentAsync(PaymentRequest request);

        public Task<string> ProcessPremiumPaymentAsync(PaymentRequest request);
    }
}
