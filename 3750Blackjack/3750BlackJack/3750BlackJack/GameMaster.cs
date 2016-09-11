using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace _3750BlackJack
{
    class GameMaster : INotifyPropertyChanged
    {
        #region Constructor
        /// <summary>
        /// Consturctor for GameMaster object
        /// </summary>
        public GameMaster()
        {
            Message = "Welcome!";
            BetInProgress = true;
            CardDeck = new Deck();
            Dealer = new Hand();
            Player = new Hand();
            Wallet = 1.00;
            MinBet = .02;
            MaxBet = .25;
            CurrentBet = MinBet;
        }
        #endregion //constructor

        #region Properties
        private int _Score;
        public int Score
        {
            get
            {
                return _Score;
            }
            set
            {
                _Score = value;
                OnPropertyChanged();
            }
        }
        /// <summary>
        /// Deck of Cards
        /// </summary>
        private Deck CardDeck;

        /// <summary>
        /// Message Property
        /// </summary>
        private string _Message;
        public string Message
        {
            get
            {
                return _Message;
            }
            set
            {
                _Message = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Bet In Progress
        /// </summary>
        private bool _BetInProgress;
        public bool BetInProgress
        {
            get
            {
                return _BetInProgress;
            }
            set
            {
                _BetInProgress = value;
                OnPropertyChanged();
            }
        }
        

        /// <summary>
        /// The amount of money the player currently has avaliable
        /// </summary>
        private double _Wallet;
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

        /// <summary>
        /// The amount of the current bet
        /// </summary>
        private double _CurrentBet;
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

        /// <summary>
        /// The player's hand
        /// </summary>
        private Hand _Player;
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
                OnPropertyChanged("Score");
            }
        }

        /// <summary>
        /// The dealer's hand
        /// </summary>
        private Hand _Dealer;
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

        /// <summary>
        /// The value of the minimum allowable bet.
        /// </summary>
        private double _MinBet;
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

        /// <summary>
        /// The value of the maximum allowable bet.
        /// </summary>
        private double _MaxBet;
        public double MaxBet
        {
            get
            {
                if (_MaxBet > Wallet)
                {
                    return Wallet;
                }
                else
                {
                    return _MaxBet;
                }
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
        /// Resets the cards, score, and begins the game.
        /// </summary>
        public void Begin()
        {
            BetInProgress = false;
            Wallet -= CurrentBet;

            Dealer.Cards.Clear();
            Player.Cards.Clear();
            CardDeck.Shuffle();
            Dealer.Cards.Add(CardDeck.Draw(false));
            Dealer.Cards.Add(CardDeck.Draw(true));
            Player.Cards.Add(CardDeck.Draw(true));
            Player.Cards.Add(CardDeck.Draw(true));
            OnPropertyChanged("Dealer");
            OnPropertyChanged("Player");
        }

        /// <summary>
        /// Totals the 2 hands and determines a winner. Initiates next round.
        /// </summary>
        public void Resolve()
        {
            var winner = false;
            var multiplier = 1.0;
            if (Player.CountCardValues > 21)
            {
                winner = false;
                Message = "You Busted!";
            }
            else if (Dealer.CountCardValues > 21)
            {
                winner = true;
                multiplier = 1.5;
                Message = "Dealer Busted!";
            }
            else if (Player.CountCardValues > Dealer.CountCardValues)
            {
                winner = true;
                multiplier = 1.5;
                Message = "You Win!";
            }
            else if (Player.CountCardValues < Dealer.CountCardValues)
            {
                winner = false;
                Message = "Dealer Wins!";
            }
            else if (Player.CountCardValues == Dealer.CountCardValues)
            {
                winner = true;
                multiplier = 1;
                Message = "Tie";
            }
            if (winner)
            {
                Wallet += multiplier * CurrentBet;
                BetInProgress = true;
            }
            OnPropertyChanged("MaxBet");
            OnPropertyChanged("Wallet");

        }

        /// <summary>
        /// When the player decides to hit
        /// </summary>
        public void Hit()
        {
            Player.Cards.Add(CardDeck.Draw(true));
            OnPropertyChanged("Player");
            //Score = Player.CountCardValues;

            if (Player.CountCardValues > 21)
                Stay();
        }

        /// <summary>
        /// when the player decides to stay
        /// </summary>
        public void Stay()
        {

            BetInProgress = true;
            Dealer.Cards[0].Visible = true;        
            while (Dealer.CountCardValues <= 16)
            {
                Dealer.Cards.Add(CardDeck.Draw(true));
                OnPropertyChanged("Dealer");
            }
            Resolve();
        }
        #endregion // Methods

        #region INotifyPropertyChanged Members

        /// <summary>
        /// Property Changed Event Handler
        /// </summary>
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
