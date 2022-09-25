using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamblers_Ruin_Console
{
    class Game
    {
        private Player player1;
        private Player player2;
        
        private float initialOddsPlayer1;
        private float initialOdssPlayer2;
        
        private int turns;
        private Random coinFlipper;

        public Game(Player player1,Player player2)
        {
            this.player1 = player1;
            this.player2 = player2;
            coinFlipper = new Random();
            turns = 0;
            initialOddsPlayer1 = PlayerOneCurrentOdds();
            initialOdssPlayer2 = PlayerTwoCurrentOdds();
        }

        public void Play()
        {
            Console.WriteLine("Introducing Our Players:");
            Console.WriteLine(player1.GetName() + " is starting with " + player1.GetPurse() + " coins. Their Odds are" + (initialOddsPlayer1 * 100) + "%.");
            Console.WriteLine(player2.GetName() + " is starting with " + player2.GetPurse() + " coins. Their Odds Are" + (initialOdssPlayer2 * 100) + "%.");
            Console.WriteLine();
            do
            {
                RunTurn();
            } while (!player1.IsBankrupt() && !player2.IsBankrupt());
            
            if (player1.IsBankrupt())
            {
                Console.WriteLine(player1.GetName() + " went bankrupt after " + turns + " turns.");
                Console.WriteLine(player2.GetName() + " wins");
            }
            else
            {
                Console.WriteLine(player2.GetName() + " went bankrupt after " + turns + " turns.");
                Console.WriteLine(player1.GetName() + " wins");
            }
            Console.WriteLine();
        }

        public float Player1Odds()
        {
            return initialOddsPlayer1;
        }

        public float Player2Odds()
        {
            return initialOdssPlayer2;
        }

        public int GetTurns()
        {
            return turns;
        }

        public Player GetPlayer1()
        {
            return player1;
        }

        public Player GetPlayer2()
        {
            return player2;
        }

        public Player GetWinner()
        {
            return player1.IsBankrupt() ? player2 : player1;
        }

        private void RunTurn()
        {
            turns++;
            Console.WriteLine("Starting Turn #" + turns);
            if (FlipCoin())
            {
                //player 1 won
                Console.WriteLine(player1.GetName() + " won this turn.");
                player1.WinCoin();
                player2.LoseCoin();
            }
            else
            {
                //player 2 won
                Console.WriteLine(player1.GetName() + " won this turn.");
                player2.WinCoin();
                player1.LoseCoin();
            }
            Console.WriteLine(player1.GetName() + " now has " + player1.GetPurse() + ". Thier Current Odds are " + (PlayerOneCurrentOdds() * 100) + '%');
            Console.WriteLine(player2.GetName() + " now has " + player2.GetPurse() + ". Thier Current Odds are " + (PlayerTwoCurrentOdds() * 100) + '%');
            Console.WriteLine();
        }

        private bool FlipCoin()
        {
            return coinFlipper.Next(100) <= 50;
        }

        private float PlayerOneCurrentOdds()
        {
            return (float)player1.GetPurse() / (player1.GetPurse() + player2.GetPurse());
        }

        private float PlayerTwoCurrentOdds()
        {
            return (float)player2.GetPurse() / (player1.GetPurse() + player2.GetPurse());
        }
    }
}
