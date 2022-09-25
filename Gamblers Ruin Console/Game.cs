using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamblers_Ruin_Console
{
    class Game
    {
        private List<Player> players;
        private int odds;
        private int turns;
        private Random coinFlipper;
        private List<KeyValuePair<Player,int>> bankruptPlayers;

        public Game(int odds = 60)
        {
            this.odds = odds;
            players = new List<Player>();
            coinFlipper = new Random();
            turns = 0;
            bankruptPlayers = new List<KeyValuePair<Player, int>>();
        }

        public int Odds { get => odds; set => odds = value; }
        
        public void Play()
        {
            Console.WriteLine("Starting a New Game with " + players.Count() + " players.");
            Console.WriteLine("Introducing Our Players:");
            players.ForEach(delegate (Player player) {
                Console.WriteLine(player.GetName() + " is starting with " + player.GetPurse() + " coins.");
            });
            Console.WriteLine();
            while(players.Count() > 0)
            {
                RunTurn();
            }
            Console.WriteLine("All players have gone bankrupt after " + turns + " turns");
            foreach (KeyValuePair<Player,int> bankruptPlayer in bankruptPlayers)
            {
                Console.WriteLine(bankruptPlayer.Key.GetName() + " went bankrupt on turn " + bankruptPlayer.Value);
            }
        }
        public void AddPlayer(Player player)
        {
            players.Add(player);
        }

        private void RunTurn()
        {
            turns++;
            Console.WriteLine("Starting Turn #" + turns);
            foreach (Player player in players.Reverse<Player>()) { 
                if (FlipCoin())
                {
                    //player won
                    player.WinCoin();
                    Console.WriteLine(player.GetName() + " won this turn and now has " + player.GetPurse() + " coins.");
                }
                else
                {
                    //player lost
                    player.LoseCoin();
                    if (player.IsBankrupt())
                    {
                        Console.WriteLine(player.GetName() + " lost this turn and is now bankrupt.");
                        bankruptPlayers.Add(new KeyValuePair<Player, int>(player, turns));
                        players.Remove(player);
                    }
                    else
                    {
                        Console.WriteLine(player.GetName() + " lost this turn and now has " + player.GetPurse() + " coins");
                    }
                }
            }
            Console.WriteLine();
        }

        private bool FlipCoin()
        {
            return coinFlipper.Next(100) >= odds;
        }

    }
}
