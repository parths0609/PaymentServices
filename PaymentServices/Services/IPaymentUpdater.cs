using PaymentServices.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentServices.Services
{
    public interface IPaymentUpdater
    {
        public Task<int> UpdatePayment(PaymentRequest updateData, string status);
    }
}
