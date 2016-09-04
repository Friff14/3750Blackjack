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
        /// <summary>
        /// Consturctor for GameMaster object
        /// </summary>
        public GameMaster()
        {
            CardDeck = new Deck();
            CardDeck.Shuffle();
            Dealer = new Hand();
            Player = new Hand();
            Wallet = 1.00;
            MinBet = .02;
            MaxBet = .25;

            Dealer.Cards.Add(CardDeck.Draw(false));
            Dealer.Cards.Add(CardDeck.Draw(true));
            Player.Cards.Add(CardDeck.Draw(true));
            Player.Cards.Add(CardDeck.Draw(true));
        }

        #region Properties
        private Deck CardDeck;

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
                OnPropertyChanged(); // Sends an event to let the UI know to update. Should usually be last line of property.
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
                return _Dealer;
            }
            set
            {
                _Dealer = value;
                OnPropertyChanged();
            }
        }

        private double _MinBet;

        /// <summary>
        /// The value of the minimum allowable bet.
        /// </summary>
        public double MinBet
        {
            get
            {
                return _MinBet;
            }
            set
            {
                _MinBet = value;
                OnPropertyChanged();
            }
        }

        private double _MaxBet;

        /// <summary>
        /// The value of the maximum allowable bet.
        /// </summary>
        public double MaxBet
        {
            get
            {
                return _MaxBet;
            }
            set
            {
                _MaxBet = value;
                OnPropertyChanged();
            }
        }
        #endregion //Properties

        #region Methods
        /// <summary>
        /// Totals the 2 hands and determines a winner. Initiates next round.
        /// </summary>
        public void Resolve()
        {
            if (_Player.Count() > 21)
            {
                //dealer wins
                //return
            }
            else if (_Dealer.Count() > 21)
            {
                //player wins
                //add bet * 1.5
                //return
            }
            else if (_Player.Count() > Dealer.Count())
            {
                //player wins
                //add bet * 1.5
                //return
            }
            else if (_Player.Count() < Dealer.Count())
            {
                //dealer wins
                //return
            }
            else if (_Player.Count() == Dealer.Count())
            {
                //tie 
                //add bet back to wallet
            }
        }

        public void Hit()
        {
            Player.Cards.Add(CardDeck.Draw(true));
            OnPropertyChanged("Player");
        }

        public void Stay()
        {
            //TODO: dealers first card should now be visible
            Dealer.Cards[0].Visible = true;        
            while (_Dealer.Count() <= 16)
            {
                Dealer.Cards.Add(CardDeck.Draw(true));
                OnPropertyChanged("Dealer");
            }
        }
        #endregion // Methods

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
