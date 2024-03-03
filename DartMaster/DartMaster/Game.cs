using System;
using System.Collections.Generic;
using System.Linq;

namespace DartMaster
{
    public class Game
    {
        private List<Player> players = new List<Player>();
        private int legsToWin = 3; // Change this to the desired number of legs to win

        public void AddPlayer(string name)
        {
            players.Add(new Player { Name = name, TotalScore = 0 });
        }

        public void PlayGame(Dartboard dartboard)
        {
            Console.WriteLine("Welcome to DartMaster!");

            while (!CheckMatchWinCondition())
            {
                PlayLeg(dartboard);
                ResetScores();
            }

            DisplayWinner();
        }

        private void PlayLeg(Dartboard dartboard)
        {
            Console.WriteLine("Starting a new leg!");

            // Reset players' scores for the new leg
            foreach (var player in players)
            {
                player.TotalScore = 501; // Assuming 501 is the starting score for each leg
            }

            while (!CheckLegWinCondition())
            {
                Player currentPlayer = GetCurrentPlayer();
                PlayTurn(currentPlayer, dartboard);
                DisplayScoreboard();
                NextTurn();
            }

            // Update the player who won the leg
            Player legWinner = players.First(p => p.TotalScore == 0);
            legWinner.LegsWon++;

            // Additional leg-end logic can go here
        }


        public void PlayTurn(Player player, Dartboard dartboard)
        {
            Console.WriteLine($"{player.Name}, enter your dart positions for this turn (e.g., 20S 15D DBT):");

            string input = Console.ReadLine().Trim().ToUpper(); // Convert input to uppercase for case-insensitivity
            string[] dartThrows = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            int turnScore = 0;

            foreach (var dartThrow in dartThrows)
            {
                // Parse section and multiplier from dart throw input
                string section = dartThrow.Substring(0, dartThrow.Length - 1);
                string multiplier = dartThrow.Substring(dartThrow.Length - 1);

                // Calculate score for dart throw
                int throwScore = dartboard.CalculateScore(section, multiplier);
                turnScore += throwScore;

                Console.WriteLine($"Score for {section}{multiplier}: {throwScore}");
            }

            // Subtract turn score from player's total score
            player.TotalScore -= turnScore;

            // Check if the player has reached zero score
            if (player.TotalScore <= 0)
            {
                Console.WriteLine($"Leg won by: {player.Name}");
                return;
            }

            Console.WriteLine($"Total score for this turn: {turnScore}");
        }


        private void DisplayScoreboard()
        {
            Console.WriteLine("Scoreboard:");
            foreach (var player in players)
            {
                Console.WriteLine($"{player.Name}: {player.LegsWon} | {player.TotalScore}");
            }
        }

        private void NextTurn()
        {
            // Rotate player turns
            players.Reverse();
        }

        private Player GetCurrentPlayer()
        {
            return players.First();
        }

        private bool CheckLegWinCondition()
        {
            return players.Any(p => p.TotalScore == 0);
        }

        private bool CheckMatchWinCondition()
        {
            return players.Any(p => p.LegsWon == legsToWin);
        }

        private void ResetScores()
        {
            foreach (var player in players)
            {
                player.TotalScore = 0;
            }
        }

        private void DisplayWinner()
        {
            Player winner = players.First(p => p.LegsWon == legsToWin);
            Console.WriteLine($"Match won by: {winner.Name}");
        }
    }
}
