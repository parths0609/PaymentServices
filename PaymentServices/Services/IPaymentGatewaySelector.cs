using PaymentServices.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentServices.Services
{
    public interface IPaymentGatewaySelector
    {
        public Task<bool> PaymentGatewaySelectorLAsync(PaymentRequest payment);
    }
}
