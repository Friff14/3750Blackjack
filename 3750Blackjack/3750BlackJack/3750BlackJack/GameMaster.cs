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
            var winner = false;
            var multiplier = 1.0;
            if (_Player.Count > 21)
            {
                winner = false;
            }
            else if (_Dealer.Count > 21)
            {
                winner = true;
                multiplier = 1.5;
            }
            else if (_Player.Count > Dealer.Count)
            {
                winner = true;
                multiplier = 1.5;
            }
            else if (_Player.Count < Dealer.Count)
            {
                winner = false;
            }
            else if (_Player.Count == Dealer.Count)
            {
                winner = true;
                multiplier = 1;
            }
            if (winner)
            {
                _Wallet += multiplier * CurrentBet;
            }

        }
        public void Bet()
        {
            CurrentBet = 0.0; //set the current betting pool to zero to override any previous bets 
            bool flag = false;

            //need to ask for bet from player,   text box to ask?
            //check for minimum and maximum bets
            do
            {
                if (CurrentBet < MinBet || CurrentBet > MaxBet)
                {
                    //give warning and have them re-enter
                    flag = true;
                }
            } while (flag != true);
            
            
            //go to next stage
        }

        public void Hit()
        {
            Player.Cards.Add(CardDeck.Draw(true));
            OnPropertyChanged("Player");

            if (_Player.Count > 21)
                Stay();
        }

        public void Stay()
        {
            //TODO: dealers first card should now be visible
            Dealer.Cards[0].Visible = true;        
            while (_Dealer.Count <= 16)
            {
                Dealer.Cards.Add(CardDeck.Draw(true));
                OnPropertyChanged("Dealer");
            }
            Resolve();
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
