using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PaymentServices.Entities;
using PaymentServices.Services;

namespace PaymentServices.Controllers
{
    
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private PaymentContext _paymentContext;
        private IPaymentGatewaySelector _paymentGatewaySelector;

        public PaymentsController(PaymentContext paymentContext,
            IPaymentGatewaySelector paymentGatewaySelector)
        {
            _paymentGatewaySelector = paymentGatewaySelector;
            _paymentContext = paymentContext;
        }
        [Route("api/[controller]")]
        [HttpPost]
        public async Task<PaymentStatus> ProcessPaymentAsync([FromBody] PaymentRequest payment)
        {
            
            if (await _paymentGatewaySelector.PaymentGatewaySelectorLAsync(payment))
            {
                Response.StatusCode = StatusCodes.Status200OK;
                _paymentContext.PaymentStatus.Add(new PaymentStatus()
                {
                    PaymentState = "Completed",
                    RequestLogId = payment
                });
                await _paymentContext.SaveChangesAsync();
                return new PaymentStatus()
                {
                    PaymentState = "Completed",
                    RequestLogId = payment
                };
            }
            _paymentContext.PaymentStatus.Add(new PaymentStatus()
            {
                PaymentState = "Failed",
                RequestLogId = payment
            });
            await _paymentContext.SaveChangesAsync();

            return new PaymentStatus()
            {
                PaymentState = "Failed",
                RequestLogId = payment
            };
        }
    }
}
