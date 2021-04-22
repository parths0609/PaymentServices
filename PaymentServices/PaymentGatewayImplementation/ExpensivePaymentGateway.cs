using PaymentServices.Entities;
using PaymentServices.PaymentGateways;
using Polly;
using Polly.Retry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentServices.PaymentGatewayImplementation
{
    public class ExpensivePaymentGateway : IExpensivePaymentGateway
    {
        private AsyncRetryPolicy _retryPolicy;
        public ICheapPaymentGateway _cheapPaymentGateway;

        public ExpensivePaymentGateway(ICheapPaymentGateway cheapPaymentGateway)
        {
            _cheapPaymentGateway = cheapPaymentGateway;
        }

        public async Task<string> ProcessPremiumPaymentAsync(PaymentRequest request)
        {
            _retryPolicy = Policy
               .Handle<Exception>()
               .WaitAndRetryAsync(3, retryAttempt => {
                   Console.WriteLine($"Attempt {retryAttempt}. waiting for 5 seconds");
                   return TimeSpan.FromSeconds(5);
               }
               );
            try
            {
                Console.WriteLine($"Retry policy: {_retryPolicy.PolicyKey}");
                return await _retryPolicy.ExecuteAsync<string>(async () =>
                {
                    return await PremiumPaymentAPI(request);
                });
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        public async Task<string> ProcessExpensivePaymentAsync(PaymentRequest request)
        {
           
            try
            {
                return await DoPayment(request);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private async Task<string> DoPayment(PaymentRequest request)
        {
            Console.WriteLine("Call to payment API has started...");
            //if()
            if (checkAvailability())
            {
                Console.WriteLine("Payment is successfully completed");

                // Logic to consume external service provider for payments goes here.. 

                return "Ok";
            }
            else
            {
                return await _cheapPaymentGateway.ProcessCheapPaymentAsync(request);
            }
        }

        private async Task<string> PremiumPaymentAPI(PaymentRequest request)
        {
            Console.WriteLine("Call to payment API has started...");
            //if()
            if (checkAvailability())
            {
                Console.WriteLine("Payment is successfully completed");

                // Logic to consume external service provider for payments goes here.. 

                return "Ok";
            }
            else
            {
                Console.WriteLine("Simulating ERROR!");
                throw new Exception("Payment gateway Unavailable");
                 
            }
            
        }



        private bool checkAvailability()
        {
            var randomChance = new Random().Next(0, 10);

            if (randomChance > 5)
            {
                Console.WriteLine("Simulating ERROR! Throwing Exception");
                return false;
            }

            return true;
        }

    }
}
