using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamblers_Ruin_Console
{
    class Player
    {
        private int purse;
        private string name;

        public Player(int purse, string name)
        {
            this.purse = purse;
            this.name = name;
        }

        public string GetName()
        {
            return name;
        }

        public bool IsBankrupt()
        {
            return purse == 0;
        }

        public void LoseCoin()
        {
            purse--;
        }

        public void TakeCoin(Player player)
        {
            player.LoseCoin();
            this.purse++;
        }

        public float Odds(Player player)
        {
            return (float)this.purse / (this.purse + player.GetPurse());
        }

        public int GetPurse()
        {
            return purse;
        }
    }
}
