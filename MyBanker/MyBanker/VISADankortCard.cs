using System;

namespace MyBanker
{
    // Define a subclass for a specific card type, inheriting from the Card superclass
    public class VISADankortCard : Card
    {
        // Constructor to initialize the card username using the superclass constructor
        public VISADankortCard(string cardUsername) : base(cardUsername)
        {
            _cardUsername = cardUsername;
        }

        // Method to generate an account number for a VISA Dankort card
        public override string GenerateAccountNumber()
        {
            // Initialize a random number generator
            Random rnd = new Random();

            // Start with the common prefix for account numbers
            _accountNumber = "3520-";

            // Generate 9 random digits to complete the account number
            for (int i = 0; i < 9; i++)
            {
                _accountNumber += rnd.Next(10);
            }

            // Return the generated account number
            return _accountNumber;
        }

        // Method to generate a card number for a VISA Dankort card
        public override string GenerateCardNumber()
        {
            // Initialize a random number generator
            Random rnd = new Random();

            // Start with the common prefix for VISA cards
            _cardNumber = "4-";

            // Generate 15 random digits to complete the card number
            for (int i = 0; i < 15; i++)
            {
                _cardNumber += rnd.Next(10);
            }

            // Return the generated card number
            return _cardNumber;
        }

        // Method to get the type of the card (VISA Dankort Card)
        public override string GetCardType()
        {
            // Return the type of the card as a string
            return "VISA Dankort Card";
        }

        // Method to get the expiration date of the card
        public override DateTime GetExpiringDate()
        {
            // Get the current date
            DateTime currentDate = DateTime.Now;

            // Assuming a validity period of 5 years, calculate the expiration date
            _expireDate = currentDate.AddYears(5);

            // Return the current date as the expiration date in the required format
            return _expireDate;
        }
    }
}
