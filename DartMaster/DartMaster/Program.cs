using System;

namespace DartMaster
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialize game
            Game game = new Game();

            // Add players
            game.AddPlayer("Alice");
            game.AddPlayer("Bob");

            // Create dartboard
            Dartboard dartboard = new Dartboard();

            // Start the game
            game.PlayGame(dartboard);
        }
    }
}
