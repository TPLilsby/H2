using System;

namespace MyBanker
{
    // Define a superclass for bank cards
    public abstract class Card : ICard
    {
        // Common fields for all card types
        protected string _cardUsername;
        protected string _cardType;
        protected string _cardNumber;
        protected string _accountNumber;
        protected DateTime _expireDate;

        // Constructor to initialize the card username
        public Card(string cardUsername)
        {
            _cardUsername = cardUsername;
        }

        // Abstract methods to be implemented by subclasses
        public abstract string GenerateCardNumber();
        public abstract string GenerateAccountNumber();
        public abstract string GetCardType();
        public abstract DateTime GetExpiringDate();

        // Concrete method to get the card username
        public string GetUsername() { return _cardUsername; }
    }
}
