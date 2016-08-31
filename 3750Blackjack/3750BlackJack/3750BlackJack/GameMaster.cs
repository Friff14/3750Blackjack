using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3750BlackJack
{
    class GameMaster
    {
        #region Properties

        public double Wallet { get; set; }
        public double CurrentBet { get; set; }
        public Hand Player { get; set; }
        public Hand Dealer { get; set; }

        public void Resolve()
        {

        }

        #endregion //Properties

    }
}
