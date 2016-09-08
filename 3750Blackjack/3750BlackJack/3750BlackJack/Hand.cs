using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace _3750BlackJack
{
    class Hand : INotifyPropertyChanged
    {
        #region Constructor
        /// <summary>
        /// Default Constructor
        /// </summary>
        public Hand()
        {
            _Cards = new ObservableCollection<Card>();
            OnPropertyChanged("CountCardValues");
        }
        #endregion //Constructor

        #region Properties

        /// <summary>
        /// Collection of Cards
        /// </summary>
        private ObservableCollection<Card> _Cards;
        public ObservableCollection<Card> Cards
        {
            get
            {
                return _Cards;
            }
            set
            {
                _Cards = value;
                OnPropertyChanged();
                OnPropertyChanged("CountCardValues");
            }
        }

        /// <summary>
        /// Card value count
        /// </summary>
        public int CountCardValues
        {
            get
            {
                var count = 0;
                var aces = 0;
                foreach (var card in Cards)
                {
                    if (card.Value == 1)
                     {
                        count += 11;
                        aces++;
                    }

                    else if (card.Value < 10 && card.Value > 1)
                    {
                        count += card.Value;
                    }

                    else if (card.Value >= 10)
                    {
                        count += 10;
                    }
                }
                while (count > 21 && aces > 0)
                {
                    if (aces <= 0) continue;
                    count -= 10;
                    aces--;
                }

                return count;
            }
            set { }
        }
        
        #endregion // Properties

        #region Methods

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