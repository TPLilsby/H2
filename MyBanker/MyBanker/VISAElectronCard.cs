using System;

namespace MyBanker
{
    // Define a subclass for a specific card type, inheriting from the Card superclass
    public class VISAElectronCard : Card
    {
        // Constructor to initialize the card username using the superclass constructor
        public VISAElectronCard(string cardUsername) : base(cardUsername)
        {
            _cardUsername = cardUsername;
        }

        // Method to generate an account number for a VISA Electron card
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

        // Method to generate a card number for a VISA Electron card
        public override string GenerateCardNumber()
        {
            // Define the list of possible prefix numbers for VISA Electron cards
            int[] prefix = { 4026, 417500, 4508, 4844, 4913, 4917 };

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

            // Generate 11 more random digits to complete the card number
            for (int i = 1; i < 12; i++)
            {
                _cardNumber += rnd.Next(10);
            }

            // Return the generated card number
            return _cardNumber;
        }

        // Method to get the type of the card (VISA Electron Card)
        public override string GetCardType()
        {
            // Return the type of the card as a string
            return "VISA Electron Card";
        }

        // Method to get the expiration date of the card
        public override DateTime GetExpiringDate()
        {
            // Get the current date
            DateTime currentDate = DateTime.Now;

            // Assuming a validity period of 5 years, calculate the expiration date
            _expireDate = currentDate.AddYears(5);

            // Return the expiration date in the required format
            return _expireDate;
        }
    }
}
