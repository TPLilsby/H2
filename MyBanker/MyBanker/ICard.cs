using System;

namespace MyBanker
{
    // Define an interface for bank cards
    public interface ICard
    {
        // Method to generate a card number
        string GenerateCardNumber();

        // Method to generate an account number
        string GenerateAccountNumber();

        // Method to get the type of the card (e.g., Debit Card, Visa Electron Card)
        string GetCardType();

        // Method to get the expiration date of the card
        DateTime GetExpiringDate();

        // Method to get the username associated with the card
        string GetUsername();
    }
}
