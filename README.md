# PaymentServices

# First commit notes :
1. Repository pattern used to process payments from a credit card to beneficiary account using simulation of two PaymentGateways and three payment services. 
2. The logic for payment in real life scenarios would generally be an external API. The consumption of external API's code in Dotnet Core can be added to repository.
3. Credit card validations and test cases for model validations can be added. 
4. API can be tested for various combinations of credit card numbers using ENUM and pre-defined services. For e.g VISA starts with a specific number and Mastercard with another. 
5. Logic to validate CVV or security pin can be added. 

# Second commit notes :
1. Observed soon after 1st commit that the credit card number cannot be kept as primary key in PaymentRequests. Same user can obviously have multiple payment requests. 
2. Added a column RequestLogId to PaymentRequest Entity for better logging of PaymentStatus. 
3. Validation logic could be improved.
4. Unit Tests to be written. 
5. Added a separate method to log entries. 


