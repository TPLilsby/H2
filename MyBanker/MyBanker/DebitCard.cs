using System;

namespace MyBanker
{
    // Define subclasses for specific card types, inheriting from the Card superclass
    public class DebitCard : Card
    {
        // Constructor to initialize the card username using the superclass constructor
        public DebitCard(string cardUsername) : base(cardUsername)
        {
            _cardUsername = cardUsername;
        }

        // Method to generate an account number for a debit card
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

        // Method to generate a card number for a debit card
        public override string GenerateCardNumber()
        {
            // Initialize a random number generator
            Random rnd = new Random();

            // Start with the common prefix for card numbers
            _cardNumber = "2400-";

            // Generate 11 random digits to complete the card number
            for (int i = 0; i < 11; i++)
            {
                _cardNumber += rnd.Next(10);
            }

            // Return the generated card number
            return _cardNumber;
        }

        // Method to get the type of the card (Debit Card)
        public override string GetCardType()
        {
            // Return the type of the card as a string
            return "Debit Card";
        }

        // Method to get the expiration date of the card
        public override DateTime GetExpiringDate()
        {
            // Get the current date
            _expireDate = DateTime.Now;

            // Assuming a validity period of 5 years, calculate the expiration date
            _expireDate = _expireDate.AddYears(5);

            // Return the expiration date in the required format
            return _expireDate;
        }
    }
}
