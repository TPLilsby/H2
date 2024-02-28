using System;

namespace MyBanker
{
    // Define a subclass for a specific card type, inheriting from the Card superclass
    public class MaestroCard : Card
    {
        // Constructor to initialize the card username using the superclass constructor
        public MaestroCard(string cardUsername) : base(cardUsername)
        {
            _cardUsername = cardUsername;
        }

        // Method to generate an account number for a Maestro card
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

        // Method to generate a card number for a Maestro card
        public override string GenerateCardNumber()
        {
            // Define the list of possible prefix numbers for Maestro cards
            int[] prefix = { 5018, 5020, 5038, 5893, 6304, 6759, 6761, 6762, 6763 };

            // Initialize variables
            int prefixNum;
            Random rnd = new Random();

            // Choose a random prefix from the list
            int rndIndex = rnd.Next(prefix.Length);
            prefixNum = prefix[rndIndex];

            // Start building the card number with the chosen prefix
            _cardNumber = $"{prefixNum}-";

            // Add a random digit to the card number
            _cardNumber += rnd.Next(1, 10);

            // Generate 14 more random digits to complete the card number
            for (int i = 1; i < 15; i++)
            {
                _cardNumber += rnd.Next(10);
            }

            // Return the generated card number
            return _cardNumber;
        }

        // Method to get the type of the card (Maestro Card)
        public override string GetCardType()
        {
            // Return the type of the card as a string
            return "Maestro Card";
        }

        // Method to get the expiration date of the card
        public override DateTime GetExpiringDate()
        {
            // Get the current date
            DateTime currentDate = DateTime.Now;

            // Assuming a validity period of 5 years and 8 months, calculate the expiration date
            _expireDate = currentDate.AddYears(5);
            _expireDate = _expireDate.AddMonths(8);

            // Return the expiration date in the required format
            return _expireDate;
        }
    }
}
