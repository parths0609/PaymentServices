using PaymentServices.Entities;
using PaymentServices.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentServices.ServiceImplementations
{
    public class PaymentUpdater : IPaymentUpdater
    {
        private PaymentContext _paymentContext;
        public PaymentUpdater(PaymentContext paymentContext)
        {
            _paymentContext = paymentContext;
        }
        public async Task<int> UpdatePayment(PaymentRequest updateData, string status)
        {
            _paymentContext.PaymentStatus.Add(new PaymentStatus()
            {
                PaymentState = status,
                RequestLogId = updateData
            });
            return await _paymentContext.SaveChangesAsync();
        }
    }
}
