using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _3750BlackJack
{
    class Hand :INotifyPropertyChanged
    {
        public Hand()
        {
            _Cards = new ObservableCollection<Card>();
        }

        #region Properties

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
            }
        }

        private int _Count;

        public int Count
        {
            get
            {
                return _Count;
            }
            set
            {
                _Count = value;
                OnPropertyChanged();
            }
        }

        #endregion // Properties

        #region Methods
      

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
