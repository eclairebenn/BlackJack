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
    }
}