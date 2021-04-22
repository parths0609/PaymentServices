using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentServices.Entities;
using PaymentServices.PaymentGateways;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace PaymentServices.PaymentGatewayImplementation
{
    public class CheapPaymentGateway : ICheapPaymentGateway
    {

        public async Task<string> ProcessCheapPaymentAsync(PaymentRequest request)
        {
            try
            {
               return await DoPayment();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private async Task<string> DoPayment()
        {
            Console.WriteLine("Call to payment API has started...");
            ThrowRandomException();


            // Logic to consume external service provider for payments goes here.. 

            Console.WriteLine("Payment is successfully completed");
            return "Ok";
        }
        //Method to simulate and induce a probablity of error during payment manually set at 50%
        private void ThrowRandomException()
        {
            var randomChance = new Random().Next(0, 10);

            if (randomChance > 5)
            {
                Console.WriteLine("Simulating ERROR! Throwing Exception");
                throw new Exception("Exception in Payments API");
            }
        }



    }
}
