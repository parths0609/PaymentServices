using PaymentServices.Entities;
using PaymentServices.PaymentGateways;
using PaymentServices.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentServices.ServiceImplementations
{

    public class PaymentGatewaySelector : IPaymentGatewaySelector
    {
        public ICheapPaymentGateway _cheapPayment;
        public IExpensivePaymentGateway _expensivePayment;
        public PaymentGatewaySelector(ICheapPaymentGateway cheapPayment,
            IExpensivePaymentGateway expensivePayment)
        {
            _cheapPayment = cheapPayment;
            _expensivePayment = expensivePayment;
        }

        public async Task<bool> PaymentGatewaySelectorLAsync(PaymentRequest payment)
        {
            if (payment.Amount > 20 && payment.Amount < 500) 
            {
                var check = await _expensivePayment.ProcessExpensivePaymentAsync(payment);
                if (check == "Ok")
                    return true;
                else
                    return false;
            }
            else if(payment.Amount <20)
            {
                var check = await _cheapPayment.ProcessCheapPaymentAsync(payment);
                if (check == "Ok")
                    return true;
                else
                    return false;
            }
            else if(payment.Amount > 500)
            {
                var check = await _expensivePayment.ProcessPremiumPaymentAsync(payment);
                if (check == "Ok")
                    return true;
                else
                    return false;
            }
            return false;
        }

      
    }
}
