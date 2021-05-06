using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentServices.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UnitTestsPayments
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CheckCreditCardValidity()
        {
            var paymentRequest = new PaymentRequest()
            {
                CreditCardNumber = "4929 9033 9428 8323",
                CardHolder = "Sam Brown",
                ExpirationDate = new System.DateTime(2019, 12, 24),
                SecurityCode = "344",
                Amount = 546
            };

            var validationResults = new List<ValidationResult>();
            var actual = Validator.TryValidateObject(paymentRequest, new ValidationContext(paymentRequest), validationResults, true);


            Assert.IsTrue(actual, "Expected validation to succeed.");
            Assert.AreEqual(0, validationResults.Count, "Unexpected number of validation errors.");
        }
    }
}
