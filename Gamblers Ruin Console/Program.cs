using System;

namespace Gamblers_Ruin_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Player Ones Name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Player Ones Starting Coins");
            int coins = Convert.ToInt32(Console.ReadLine());
            Player player1 = new(coins, name);

            Console.WriteLine("Enter Player Twos Name:");
            name = Console.ReadLine();
            Console.WriteLine("Enter Player Twos Starting Coins");
            coins = Convert.ToInt32(Console.ReadLine());         
            Player player2 = new(coins,name);
            
            Game game = new(player1,player2);
            
            game.Play();
            
            Console.WriteLine("Game Summary:");
            Console.WriteLine("The Game Lasted " + game.GetTurns() + " turns");
            Console.WriteLine(game.GetWinner().GetName() + " Won.");
            Console.WriteLine(game.GetPlayer1().GetName() + " started with " + (game.Player1Odds() * 100) + "% chance of winning");
            Console.WriteLine(game.GetPlayer2().GetName() + " started with " + (game.Player2Odds() * 100) + "% chance of winning");
            
            Console.WriteLine();
            Console.WriteLine("Press Any Key To Exit");
            Console.ReadKey();
        }
    }
}
