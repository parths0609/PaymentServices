using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PaymentServices.Entities;
using PaymentServices.Services;
using System.Net;

namespace PaymentServices.Controllers
{
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private PaymentContext _paymentContext;
        private IPaymentGatewaySelector _paymentGatewaySelector;
        private IPaymentUpdater _paymentUpdater;

        public PaymentsController(PaymentContext paymentContext,
            IPaymentGatewaySelector paymentGatewaySelector, IPaymentUpdater paymentUpdater)
        {
            _paymentGatewaySelector = paymentGatewaySelector;
            _paymentContext = paymentContext;
            _paymentUpdater = paymentUpdater;
        }
        [Route("api/[controller]")]
        [HttpPost]
        public async Task<PaymentStatus> ProcessPaymentAsync([FromBody] PaymentRequest payment)
        {
            try
            {
                if (await _paymentGatewaySelector.PaymentGatewaySelectorLAsync(payment))
                {
                    Response.StatusCode = StatusCodes.Status200OK;
                    await _paymentUpdater.UpdatePayment(payment, "Completed");
                    return new PaymentStatus()
                    {
                        PaymentState = "Completed",
                        RequestLogId = payment
                    };
                }
                else
                {
                    await _paymentUpdater.UpdatePayment(payment, "Failed");
                    return new PaymentStatus()
                    {
                        PaymentState = "Failed",
                        RequestLogId = payment
                    };
                }
            }
            catch (Exception e)
            {
                Response.StatusCode = StatusCodes.Status500InternalServerError;
                Console.WriteLine(e.Message);
                return null;
            }


        }
    }
}
