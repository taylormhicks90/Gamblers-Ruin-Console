using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamblers_Ruin_Console
{
    class Game
    {
        private Player playerOne;
        private Player playerTwo;
        
        private float initialOddsPlayerOne;
        private float initialOddsPlayerTwo;
        
        private int turns;
        private Random coinFlipper;

        private Coin playerOneCoin;

        enum Coin
        {
            Heads,
            Tails,
        }

        public Game(Player player1,Player player2)
        {
            this.playerOne = player1;
            this.playerTwo = player2;
            
            coinFlipper = new Random();
            turns = 0;
            
            initialOddsPlayerOne = this.playerOne.Odds(this.playerTwo);
            initialOddsPlayerTwo = this.playerTwo.Odds(this.playerOne);
        }

        public void Play()
        {
            if(FlipCoin() == Coin.Heads)
            {
                Console.WriteLine(playerOne.GetName() + " Heads or Tails?");
                string choice = Console.ReadLine().ToLower().Trim();
                switch (choice)
                {
                    case "h":
                    case "heads":
                    case "head":
                        playerOneCoin = Coin.Heads;
                        break;
                    case "t":
                    case "tails":
                    case "tail":
                        playerOneCoin = Coin.Tails;
                        break;
                }
            }
            else
            {
                Console.WriteLine(playerTwo.GetName() + " Heads or Tails?");
                string choice = Console.ReadLine().ToLower().Trim();
                switch (choice)
                {
                    case "h":
                    case "heads":
                    case "head":
                        playerOneCoin = Coin.Tails;
                        break;
                    case "t":
                    case "tails":
                    case "tail":
                        playerOneCoin = Coin.Heads;
                        break;
                }
            }
            Console.Clear();

            Console.WriteLine("Introducing Our Players:");
            Console.WriteLine(playerOne.GetName() + " is starting with " + playerOne.GetPurse() + " coins. Their odds are " + (initialOddsPlayerOne * 100) + "%.");
            Console.WriteLine(playerTwo.GetName() + " is starting with " + playerTwo.GetPurse() + " coins. Their odds are " + (initialOddsPlayerTwo * 100) + "%.\n");
            Console.WriteLine(GetHeadsPlayer().GetName() + " is Heads and " + GetTailsPlayer().GetName() + " is Tails.");

            Console.WriteLine("\nPress any Key to Begin Play");
            Console.ReadKey();
            do
            {
                RunTurn();
            } while (!HaveWinner());
            Console.WriteLine(GetWinner().GetName() + " wins\n");
        }

        public float PlayerOneInitialOdds()
        {
            return initialOddsPlayerOne;
        }

        public float PlayerTwoInitialOdds()
        {
            return initialOddsPlayerTwo;
        }

        public int GetTurns()
        {
            return turns;
        }

        public Player GetPlayer1()
        {
            return playerOne;
        }

        public Player GetPlayer2()
        {
            return playerTwo;
        }

        public Player GetWinner()
        {
            if (!HaveWinner()) return null;
            return playerOne.IsBankrupt() ? playerTwo : playerOne;
        }

        private void RunTurn()
        {
            turns++;
            Console.WriteLine("Starting Turn #" + turns);
            if (FlipCoin() == playerOneCoin )
            {
                //player 1 won
                Console.WriteLine(playerOne.GetName() + " won this turn.");
                playerOne.TakeCoin(playerTwo);
            }
            else
            {
                //player 2 won
                Console.WriteLine(playerTwo.GetName() + " won this turn.");
                playerTwo.TakeCoin(playerOne);
            }
            Console.WriteLine(playerOne.GetName() + " now has " + playerOne.GetPurse() + ". Thier Current Odds are " + (playerOne.Odds(playerTwo) * 100) + "%");
            Console.WriteLine(playerTwo.GetName() + " now has " + playerTwo.GetPurse() + ". Thier Current Odds are " + (playerTwo.Odds(playerOne) * 100) + "%\n");
        }

        private Coin FlipCoin()
        {
            return coinFlipper.Next(2) == 1 ? Coin.Heads : Coin.Tails;
        }

        private bool HaveWinner()
        {
            return playerOne.IsBankrupt() || playerTwo.IsBankrupt();
        }

        private Player GetHeadsPlayer()
        {
            return playerOneCoin == Coin.Heads ? playerOne : playerTwo;
        }

        private Player GetTailsPlayer()
        {
            return playerOneCoin == Coin.Tails ? playerOne : playerTwo;
        }
    }
}
