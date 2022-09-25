using System;

namespace Gamblers_Ruin_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new();
            game.AddPlayer(new Player(100, "Player 1"));
            game.AddPlayer(new Player(100, "Player 2"));
            game.Play();
            Console.WriteLine();
            Console.WriteLine("Press Any Key To Exit");
            Console.ReadKey();
        }
    }
}
