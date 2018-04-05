using System;
using System.Collections.Generic;

namespace blackjack 
{
    public class Dealer : Player
    {
        public Dealer(string name = "dealer") : base(name)
        {

        }

        public bool hitStay()
        {
            if(handtotal <= 16)
            {
                return true;    
            }
            else
            {
                return false;
            }

        }

        public void findTotal()
        {
            foreach(Card card in hand)
            {
                handtotal += card.val;
            }
            foreach(Card card in hand)
            {
                if(card.stringVal == "Ace")
                {
                    if(handtotal > 21)
                    {
                        card.val = 1;
                    }                    
                }                  
            }
        }
    }
}