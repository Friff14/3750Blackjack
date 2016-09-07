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
    class Card : INotifyPropertyChanged
    {
        public enum CardSuit
        {
            Spade,
            Club,
            Heart,
            Diamond
        }

        public CardSuit Suit { get; set; }
        private int _Value;
        public int Value
        {
            get
            {
                return _Value;
            }
            set
            {
                _Value = value;
                OnPropertyChanged();
                OnPropertyChanged("FaceValue");
            }
        }
        public string FaceValue
        {
            get
            {
                switch (Value)
                {
                    case 1:
                        return "A";
                    case 11:
                        return "J";
                    case 12:
                        return "Q";
                    case 13:
                        return "K";
                    default:
                        return Value.ToString();
                }

            }
        }
        public bool Visible { get; set; }

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
