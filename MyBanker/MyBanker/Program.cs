namespace MyBanker
{
    // Program class
    class Program
    {
        // Main method
        public static void Main(string[] args)
        {
            // Create a list to hold different types of cards
            List<Card> cards = new List<Card>();

            // Create instances of different card types and add them to the list
            Card debitCard = new DebitCard("Jhonny");
            cards.Add(debitCard);

            Card maestroCard = new MaestroCard("Joe");
            cards.Add(maestroCard);

            Card visaElectronCard = new VISAElectronCard("Tobias");
            cards.Add(visaElectronCard);

            Card visaDankortCard = new VISADankortCard("Brian");
            cards.Add(visaDankortCard);

            Card mastercard = new Mastercard("Benjamin");
            cards.Add(mastercard);

            Card visaDankortCard1 = new VISADankortCard("Tim");
            cards.Add(visaDankortCard1);

            Card debitCard1 = new DebitCard("Laura");
            cards.Add(debitCard1);

            // Iterate through each card in the list and display card information
            foreach (Card card in cards)
            {
                // Display card type and owner's name
                Console.WriteLine($"\n{card.GetCardType()}: {card.GetUsername()}");

                // Generate and display card number
                Console.WriteLine($"Card Number: {card.GenerateCardNumber()}");

                // Generate and display account number
                Console.WriteLine($"Account Number: {card.GenerateAccountNumber()}");

                // Get and display card's expiration date
                Console.WriteLine($"Expiring date: {card.GetExpiringDate()}");
            }
        }
    }
}
