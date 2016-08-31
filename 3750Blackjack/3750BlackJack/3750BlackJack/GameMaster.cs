using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _3750BlackJack
{
    class GameMaster : INotifyPropertyChanged
    {
        #region Properties
        private double _Wallet;

        /// <summary>
        /// The amount of money the player currently has avaliable
        /// </summary>
        public double Wallet
        {
            get
            {
                return _Wallet;
            }
            set
            {
                _Wallet = value;
                OnPropertyChanged();
            }

        }

        private double _CurrentBet;

        /// <summary>
        /// The amount of the current bet;
        /// </summary>
        public double CurrentBet
        {
            get
            {
                return _CurrentBet;
            }
            set
            {
                _CurrentBet = value;
                OnPropertyChanged();
            }
        }

        private Hand _Player;

        /// <summary>
        /// The player's hand
        /// </summary>
        public Hand Player
        {
            get
            {
                return _Player;
            }
            set
            {
                _Player = value;
                OnPropertyChanged();
            }
        }

        private Hand _Dealer;
        /// <summary>
        /// The dealer's hand
        /// </summary>
        public Hand Dealer
        {
            get
            {
                return _Player;
            }
            set
            {
                _Player = value;
                OnPropertyChanged();
            }
        }

        public void Resolve()
        {

        }

        #endregion //Properties

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            try
            {

                if (this.PropertyChanged != null)
                    this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
            catch (Exception ex)
            {
                throw new Exception(MethodBase.GetCurrentMethod().Name + "() -> " + ex.Message);
            }
        }

        #endregion
    }
}
