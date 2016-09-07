using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3750BlackJack
{
    class Card
    {
        public enum CardSuit
        {
            Spade,
            Club,
            Heart,
            Diamond
        }

        public CardSuit Suit {get; set;}
        public int Value { get; set; }
        public string FaceVaue
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
    }
}
