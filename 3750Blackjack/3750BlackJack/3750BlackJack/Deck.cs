using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3750BlackJack
{
    class Deck
    {

        public Deck()
        {
            Cards = new List<Card>();
            BuildDeck();
        }
        #region Properties
        
        /// <summary>
        /// Represents a deck of cards
        /// </summary>
        private List<Card> Cards { get; set; }

        #endregion //Properties

        #region Methods

        /// <summary>
        /// Draws a card from the top of the deck.
        /// </summary>
        /// <returns></returns>
        public Card Draw()
        {
            //remove card on top and return it.
            Card cardOnTop = Cards[0];
            Cards.Remove(Cards[0]);
            return cardOnTop;
        }

        /// <summary>
        /// Burns old deck. Builds new one. Shuffle
        /// </summary>
        public void Shuffle()
        {
            //burn the old deck
            Cards = new List<Card>();
            
            //build new one
            BuildDeck();

            //shuffle
            ActuallyShuffle(Cards);
        }

        /// <summary>
        /// Adds new cards to the deck
        /// </summary>
        private void BuildDeck()
        {
            //for each Suit
            for(int i = 0; i < 4; i++)
            {
                //for each Value
                for(int j = 0; j < 14; j++)
                {
                    //add a the next new card
                    //TODO: wait until the Constructor for Card is finished to add property arguments. 
                    Cards.Add(new Card());
                }
            }
        }

        /// <summary>
        /// Shuffles a list of cards.
        /// </summary>
        /// <typeparam name="Card"></typeparam>
        /// <param name="deck">a deck of cards</param>
        private void ActuallyShuffle<Card>(List<Card> deck)
        {
            //get deck count
            int n = deck.Count;
            Random r = new Random();

            //for each card in the deck
            while (n > 1)
            {
                //find random spot
                int k = r.Next(0, n);
                n--;
                //swap with other card
                Card temp = deck[k];
                deck[k] = deck[n];
                deck[n] = temp;
            }
        }

        #endregion //Methods
    }
}
