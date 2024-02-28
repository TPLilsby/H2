using System;

namespace MyBanker
{
    // Mastercard class inherits from the Card class
    public class Mastercard : Card
    {
        // Constructor for Mastercard class
        public Mastercard(string cardUsername) : base(cardUsername)
        {
            _cardUsername = cardUsername;
        }

        // Method to generate a random account number for Mastercard
        public override string GenerateAccountNumber()
        {
            Random rnd = new Random();
            _accountNumber = "3520-";

            // Generate a random number for the account number
            _accountNumber += rnd.Next(1, 10);

            for (int i = 1; i < 10; i++)
            {
                _accountNumber += rnd.Next(10);
            }

            return _accountNumber;
        }

        // Method to generate a random card number for Mastercard
        public override string GenerateCardNumber()
        {
            // Prefixes for Mastercard
            int[] prefix = { 51, 52, 53, 54, 55 };

            int prefixNum;
            Random rnd = new Random();

            // Randomly select a prefix from the array
            int rndIndex = rnd.Next(prefix.Length);
            prefixNum = prefix[rndIndex];

            _cardNumber = $"{prefixNum}-";

            // Generate a random number for the card number
            _cardNumber += rnd.Next(1, 10);

            for (int i = 1; i < 14; i++)
            {
                _cardNumber += rnd.Next(10);
            }

            return _cardNumber;
        }

        // Method to get the card type (Mastercard)
        public override string GetCardType()
        {
            return "Mastercard";
        }

        // Method to get the expiration date for Mastercard (5 years from the current date)
        public override DateTime GetExpiringDate()
        {
            DateTime currentDate = DateTime.Now;

            _expireDate = currentDate.AddYears(5);

            return _expireDate;
        }
    }
}
